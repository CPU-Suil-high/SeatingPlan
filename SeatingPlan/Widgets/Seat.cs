using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeatingPlan {
    public class Seat : Button {
        public int X {
            get;
            set;
        }
        public int Y {
            get;
            set;
        }

        public SeatsView seats;

        public Seat() {
            BackgroundImage = Properties.Resources.Seat;
            BackgroundImageLayout = ImageLayout.Stretch;
            Font = new Font("메이플스토리", 10, FontStyle.Regular, GraphicsUnit.Point, ((byte)(129)));
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            TabStop = false;
        }
    }
}
