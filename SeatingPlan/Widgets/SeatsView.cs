using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeatingPlan {
    public class SeatsView : Panel {
        Seat[] seatPictures;

        public SeatsView() {
            seatPictures = new Seat[25];

            for (int i = 0; i < seatPictures.Length; i++) {
                seatPictures[i] = new Seat();
            }

            SizeChanged += (object sender, EventArgs e) => {
                ((SeatsView)sender).UpdateSeatPictures();
            };

            InitSeats();
            UpdateSeatPictures();
        }

        public void InitSeats() {
            for (int i = 0; i < seatPictures.Length; i++) {
                seatPictures[i] = new Seat();
                Controls.Add(seatPictures[i]);
            }
        }

        public void UpdateNames(List<string> names, List<int> nameIndexes) {
            for (int i = 0; i < seatPictures.Length; i++) {
                if (names.Count > i) {
                    int index = nameIndexes[i];
                    seatPictures[i].Text = names[index];
                } else {
                    seatPictures[i].Text = "";
                }
            }
        }

        void UpdateSeatPictures() {
            int seatWidth = Width / 8;
            int seatHeight = Height / 8;

            int padx = (Width - seatWidth * 5) / (5 * 2);
            int pady = (Height - seatHeight * 5) / (5 * 2);

            //Font font = new Font("메이플스토리", seatHeight / 4, FontStyle.Regular, GraphicsUnit.Point, ((byte)(129)));

            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    Seat seat = seatPictures[i * 5 + j];

                    seat.X = j;
                    seat.Y = i;


                    seat.Width = seatWidth;
                    seat.Height = seatHeight;
                    seat.Location = new Point(j * seat.Width + padx * (j * 2 + 1), i * seat.Height + pady * (i * 2 + 1));

                    //seat.Font = font;

                    seat.MouseDown += (object sender, MouseEventArgs e) => {
                        Seat senderSeat = (Seat)sender;
                        Console.WriteLine($"{senderSeat.X},{senderSeat.Y}");
                    };
                }
            }
        }
    }
}
