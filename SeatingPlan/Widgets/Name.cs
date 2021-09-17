using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeatingPlan {
    class NameBox : Panel {
        public Button deleteButton;
        private Button nameDisplay;

        public string NameText {
            set {
                nameDisplay.Text = value;
            }
            get {
                return nameDisplay.Text;
            }
        }

        public NameBox() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            this.nameDisplay = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameDisplay
            // 
            this.nameDisplay.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameDisplay.Location = new System.Drawing.Point(0, 12);
            this.nameDisplay.Name = "nameDisplay";
            this.nameDisplay.Size = new System.Drawing.Size(150, 25);
            this.nameDisplay.TabIndex = 0;
            this.nameDisplay.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.BackgroundImage = global::SeatingPlan.Properties.Resources.Delete;
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteButton.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.deleteButton.Location = new System.Drawing.Point(160, 12);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(25, 25);
            this.deleteButton.TabIndex = 0;
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // NameBox
            // 
            this.Controls.Add(this.nameDisplay);
            this.Controls.Add(this.deleteButton);
            this.ResumeLayout(false);

        }
    }
}
