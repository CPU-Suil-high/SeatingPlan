using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeatingPlan {
    class Seat : Button {
        public int Index {
            get;
            set;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public Seat() {
            BackgroundImageLayout = ImageLayout.Stretch;
            BackColor = Color.Transparent;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            Font = new Font("한컴 고딕", 10, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            TabStop = false;
            DoubleBuffered = true;
        }
    }
}
