using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeatingPlan {
    class NameList : Panel {
        private TextBox nameEnterBox;
        private SeatsManager seatsManager;
        private Button addButton;

        public SeatsManager SeatsManager {
            get {
                return seatsManager;
            }
            set {
                seatsManager = value;
            }
        }
        private List<NameBox> nameBoxes = new List<NameBox>();
        [System.ComponentModel.Browsable(true)]
        private List<NameBox> NameBoxes {
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
            DoubleBuffered = true;
        }

        private void InitializeComponent() {
            this.nameEnterBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameEnterBox
            // 
            this.nameEnterBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(26)))));
            this.nameEnterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameEnterBox.Font = new System.Drawing.Font("한컴 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameEnterBox.Location = new System.Drawing.Point(10, 10);
            this.nameEnterBox.MaxLength = 14;
            this.nameEnterBox.Name = "nameEnterBox";
            this.nameEnterBox.Size = new System.Drawing.Size(150, 30);
            this.nameEnterBox.TabIndex = 0;
            this.nameEnterBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nameEnterBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameEnterBox_KeyDown);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(170, 10);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(50, 30);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // NameList
            // 
            this.Controls.Add(this.nameEnterBox);
            this.Controls.Add(this.addButton);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.NameList_Scroll);
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
            if (nameEnterBox.Text == "") {
                return;
            }

            SeatsManager.AddName(nameEnterBox.Text);
            nameEnterBox.Text = "";
        }

        public void UpdateNames(List<string> names) {
            while (names.Count > NameBoxes.Count) {
                NameBox nameBox = new NameBox();
                nameBox.NameText = "";

                nameBox.Size = new Size(210, 50);
                nameBox.deleteButton.MouseClick += (object sender, MouseEventArgs e) => {
                    Button temp = (Button)sender;
                    int index = nameBoxes.FindIndex(x => x == temp.Parent);
                    SeatsManager.RemoveName(index);
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

        private void addButton_Click(object sender, EventArgs e) {
            AddName();
        }

        private void NameList_Scroll(object sender, ScrollEventArgs e) {
            Refresh();
        }
    }
}
