using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeatingPlan {
    class NameList : Panel {
        private TextBox nameEnterBox;

        public SeatsManager seatsManager;

        public NameList() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            this.nameEnterBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nameEnterBox
            // 
            this.nameEnterBox.Font = new System.Drawing.Font("메이플스토리", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameEnterBox.Location = new System.Drawing.Point(10, 10);
            this.nameEnterBox.MaxLength = 20;
            this.nameEnterBox.Name = "nameEnterBox";
            this.nameEnterBox.Size = new System.Drawing.Size(110, 25);
            this.nameEnterBox.TabIndex = 0;
            this.nameEnterBox.Text = "";
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
            
        }
    }
}
