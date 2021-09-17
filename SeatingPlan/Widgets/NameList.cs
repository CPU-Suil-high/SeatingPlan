using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeatingPlan {
    class NameList : Panel {
        private TextBox nameEnterBox;
        private SeatsManager seatsManager;

        public SeatsManager SeatManager {
            get {
                return seatsManager;
            }
            set {
                seatsManager = value;
            }
        }

        private List<NameBox> nameBoxes = new List<NameBox>();

        public List<NameBox> NameBoxes {
            get {
                return nameBoxes;
            }
            set {
                nameBoxes = value;
            }
        }

        public NameList() {
            InitializeComponent();
            AutoScroll = true;
        }

        private void InitializeComponent() {
            this.nameEnterBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nameEnterBox
            // 
            this.nameEnterBox.Font = new System.Drawing.Font("한컴 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameEnterBox.Location = new System.Drawing.Point(10, 10);
            this.nameEnterBox.MaxLength = 14;
            this.nameEnterBox.Name = "nameEnterBox";
            this.nameEnterBox.Size = new System.Drawing.Size(110, 26);
            this.nameEnterBox.TabIndex = 0;
            this.nameEnterBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameEnterBox_KeyDown);
            // 
            // NameList
            // 
            this.Controls.Add(this.nameEnterBox);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void nameEnterBox_KeyDown(object sender, KeyEventArgs e) {
            if (! (e.KeyData == Keys.Enter)) {
               return;
            }
            e.Handled = true;
            e.SuppressKeyPress = true;

            AddName();
        }

        private void AddName() {
            seatsManager.AddName(nameEnterBox.Text);
            nameEnterBox.Text = "";
        }

        public void UpdateNames(List<string> names) {
            while (names.Count > NameBoxes.Count) {
                NameBox nameBox = new NameBox();
                nameBox.NameText = "";

                nameBox.Size = new Size(200, 50);
                nameBox.deleteButton.MouseClick += (object sender, MouseEventArgs e) => {
                    Button temp = (Button)sender;
                    int index = nameBoxes.FindIndex(x => x == temp.Parent);
                    seatsManager.RemoveName(index);
                };

                NameBoxes.Add(nameBox);
                Controls.Add(nameBox);
            }

            while (names.Count < NameBoxes.Count) {
                Controls.Remove(nameBoxes[0]);
                nameBoxes.RemoveAt(0);
            }

            for (int i = 0; i < names.Count; i++) {
                NameBox name = NameBoxes[i];
                name.NameText = names[i];

                name.Location = new Point(10, nameEnterBox.Bottom + i * name.Height);
            }
        }
    }
}
