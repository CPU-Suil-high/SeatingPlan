using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeatingPlan {
    class SeatsView : Panel {
        private SeatsManager seatsManager;

        public SeatsManager SeatsManager {
            get {
                return seatsManager;
            }
            set {
                seatsManager = value;
            }
        }

        private bool[] fixedNames;

        Seat[] seats = new Seat[Constants.MaxSeatCount];

        Seat[] Seats {
            get {
                return seats;
            }
            set {
                seats = value;
            }
        }

        Seat[] movingSeats = new Seat[Constants.MaxSeatCount];

        Seat[] MovingSeats {
            get {
                return movingSeats;
            }
            set {
                movingSeats = value;
            }
        }

        private bool isMoveMode = false;

        public bool IsMoveMode {
            set {
                isMoveMode = value;
                UpdateSeats();
            }
            get {
                return isMoveMode;
            }
        }

        private bool isViewEmptySeat = false;

        public bool IsViewEmptySeat {
            get {
                return isViewEmptySeat;
            }
            set {
                isViewEmptySeat = value;
                UpdateSeats();
            }
        }

        int movingSeatIndex = -1;
        Point beforeMousePosition;

        int selectedSeatIndex = -1;
        private Seat table;
        int[][] defaultPositions = new int[][]{
            new int[]{1, 6},
            new int[]{11, 6},
            new int[]{21, 6},
            new int[]{31, 6},
            new int[]{41, 6},
            new int[]{1, 10},
            new int[]{11, 10},
            new int[]{21, 10},
            new int[]{31, 10},
            new int[]{41, 10},
            new int[]{1, 14},
            new int[]{11, 14},
            new int[]{21, 14},
            new int[]{31, 14},
            new int[]{41, 14},
            new int[]{1, 18},
            new int[]{11, 18},
            new int[]{21, 18},
            new int[]{31, 18},
            new int[]{41, 18},
            new int[]{1, 22},
            new int[]{11, 22},
            new int[]{21, 22},
            new int[]{31, 22},
            new int[]{41, 22},
            new int[]{1, 26},
            new int[]{11, 26},
            new int[]{21, 26},
            new int[]{31, 26},
            new int[]{41, 26},
        };

        public SeatsView() {
            InitializeComponent();
            SizeChanged += (object sender, EventArgs e) => {
                ((SeatsView)sender).UpdateSeats();
            };

            InitSeats();
            UpdateSeats();

            DoubleBuffered = true;
        }

        public void InitSeats() {
            for (int i = 0; i < Seats.Length; i++) {
                Seat seat = new Seat();
                Seat movingSeat = new Seat();

                seat.BackgroundImage = Properties.Resources.Seat;
                movingSeat.BackgroundImage = Properties.Resources.Seat;

                seat.Index = i;
                movingSeat.Index = i;

                seat.X = defaultPositions[i][0];
                seat.Y = defaultPositions[i][1];

                movingSeat.X = defaultPositions[i][0];
                movingSeat.Y = defaultPositions[i][1];

                seat.MouseDown += new MouseEventHandler(SeatClick);

                movingSeat.Visible = false;
                movingSeat.Text = i.ToString();

                movingSeat.MouseDown += new MouseEventHandler(MovingSeatMouseDown);
                movingSeat.MouseMove += new MouseEventHandler(MovingSeatMouseMove);
                movingSeat.MouseUp += new MouseEventHandler(MovingSeatMouseUp);
                movingSeat.MouseLeave += new EventHandler(MovingSeatMouseLeave);

                Seats[i] = seat;
                MovingSeats[i] = movingSeat;

                Controls.Add(Seats[i]);
                Controls.Add(MovingSeats[i]);
            }
        }

        public void UpdateNames(List<string> names, List<int> nameIndexes, bool[] fixedNames) {
            this.fixedNames = fixedNames;

            selectedSeatIndex = -1;

            for (int i = 0; i < Seats.Length; i++) {
                if (names.Count > i) {
                    int index = nameIndexes[i];
                    Seats[i].Text = names[index];

                    if (fixedNames[i]) {
                        Seats[i].BackgroundImage = Properties.Resources.FixedSeat;
                    } else {
                        Seats[i].BackgroundImage = Properties.Resources.Seat;
                    }
                    
                } else {
                    Seats[i].Text = "";
                }
            }
            UpdateSeats();
        }

        void UpdateSeats() {
            int seatWidth = Width / 8;
            int seatHeight = Height / 8;

            Font font = new Font("한컴 고딕", 6.6f + seatHeight / 16.8f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));

            for (int i = 0; i < Seats.Length; i++) {
                Seat seat = Seats[i];
                Seat movingSeat = MovingSeats[i];

                seat.Width = seatWidth;
                seat.Height = seatHeight;
                movingSeat.Width = seatWidth;
                movingSeat.Height = seatHeight;

                int seatX = (int)Math.Round((float)seat.X / Constants.SeatViewColumnCount * Width);
                int seatY = (int)Math.Round((float)seat.Y / Constants.SeatViewRowCount * Height);

                int movingSeatX = (int)Math.Round((float)movingSeat.X / Constants.SeatViewColumnCount * Width);
                int movingSeatY = (int)Math.Round((float)movingSeat.Y / Constants.SeatViewRowCount * Height);

                seat.Location = new Point(seatX, seatY);
                movingSeat.Location = new Point(movingSeatX, movingSeatY);

                seat.Font = font;
                movingSeat.Font = font;

                if (IsMoveMode) {
                    if (!IsViewEmptySeat && seat.Text == "") {
                        movingSeat.Visible = false;
                    } else {
                        movingSeat.Visible = true;
                    }
                    seat.Visible = false;
                } else {
                    if (!IsViewEmptySeat && seat.Text == "") {
                        seat.Visible = false;
                    } else {
                        seat.Visible = true;
                    }
                    movingSeat.Visible = false;
                }
            }

            table.Width = seatWidth;
            table.Height = seatHeight;

            int x = (int)Math.Round((float)table.X / Constants.SeatViewColumnCount * Width);
            int y = (int)Math.Round((float)table.Y / Constants.SeatViewRowCount * Height);

            Point location = new Point(x, y);

            table.Location = location;
        }

        void DropMovingSeat() {
            if (movingSeatIndex == -1) {
                return;
            }
            Seat movingSeat = MovingSeats[movingSeatIndex];
            Seat seat = Seats[movingSeatIndex];

            Point location = movingSeat.Location;

            int x = (int)Math.Round((float)location.X / Width * Constants.SeatViewColumnCount);
            int y = (int)Math.Round((float)location.Y / Height * Constants.SeatViewRowCount);

            if (x < 0 || x >= Constants.SeatViewColumnCount || y < 0 || y >= Constants.SeatViewRowCount || (x == table.X && y == table.Y)) {
                UpdateSeats();
                return;
            }

            movingSeat.X = x;
            movingSeat.Y = y;

            seat.X = x;
            seat.Y = y;

            UpdateSeats();

            movingSeatIndex = -1;
        }

        void MovingSeatMouseDown(object sender, MouseEventArgs e) {
            Seat seat = (Seat)sender;

            movingSeatIndex = seat.Index;
            beforeMousePosition = e.Location;
        }

        void MovingSeatMouseMove(object sender, MouseEventArgs e) {
            if (movingSeatIndex == -1) {
                return;
            }
            Point moveVec = new Point(e.X - beforeMousePosition.X, e.Y - beforeMousePosition.Y);
            Point location = MovingSeats[movingSeatIndex].Location;

            location.X += moveVec.X;
            location.Y += moveVec.Y;

            MovingSeats[movingSeatIndex].Location = location;

            Refresh();
        }

        void MovingSeatMouseUp(object sender, MouseEventArgs e) {
            DropMovingSeat();
        }

        void MovingSeatMouseLeave(object sender, EventArgs e) {
            DropMovingSeat();
        }

        void SeatClick(object sender, MouseEventArgs e) {
            Seat seat = (Seat)sender;

            if (seat.Text == "") {
                return;
            }

            int index = seat.Index;

            if (e.Button == MouseButtons.Left) {
                SeatLeftClick(index);
            } else if (e.Button == MouseButtons.Right) {
                SeatRightClick(index);
            }
        }

        void SeatLeftClick(int index) {
            if (selectedSeatIndex == -1) {
                selectedSeatIndex = index;
                Seats[index].BackgroundImage = Properties.Resources.SelectedSeat;
            } else {
                if (fixedNames[selectedSeatIndex]) {
                    Seats[selectedSeatIndex].BackgroundImage = Properties.Resources.FixedSeat;
                } else {
                    Seats[selectedSeatIndex].BackgroundImage = Properties.Resources.Seat;
                }
                if (selectedSeatIndex != index) {
                    SeatsManager.SwapNames(selectedSeatIndex, index);
                }
                selectedSeatIndex = -1;
            }
        }
        
        void SeatRightClick(int index) {
            SeatsManager.FixSeat(index);
        }

        public int[][] GetSeatPositions() {
            int[][] seatPositions = new int[Seats.Length][];

            for (int i = 0; i < Seats.Length; i++) {
                int x = Seats[i].X;
                int y = Seats[i].Y;
                seatPositions[i] = new int[] {x, y};
            }

            return seatPositions;
        }

        public void SetSeatPositions(int[][] seatPositions) {
            for (int i = 0; i < seatPositions.Length; i++) {
                int x = seatPositions[i][0];
                int y = seatPositions[i][1];

                Seats[i].X = x;
                Seats[i].Y = y;

                MovingSeats[i].X = x;
                MovingSeats[i].Y = y;
            }
        }

        public void ResetSeatPositions() {
            for (int i = 0; i < Seats.Length; i++) {
                int x = defaultPositions[i][0];
                int y = defaultPositions[i][1];

                Seats[i].X = x;
                Seats[i].Y = y;

                MovingSeats[i].X = x;
                MovingSeats[i].Y = y;
            }

            UpdateSeats();
        }

        private void InitializeComponent() {
            this.table = new SeatingPlan.Seat();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.BackColor = System.Drawing.Color.Transparent;
            this.table.BackgroundImage = global::SeatingPlan.Properties.Resources.Seat;
            this.table.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.table.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.table.Font = new System.Drawing.Font("한컴 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.table.Index = -1;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(75, 23);
            this.table.TabIndex = 0;
            this.table.TabStop = false;
            this.table.Text = "교탁";
            this.table.UseVisualStyleBackColor = true;
            this.table.X = 21;
            this.table.Y = 1;
            // 
            // SeatsView
            // 
            this.Controls.Add(this.table);
            this.ResumeLayout(false);

        }
    }
}
