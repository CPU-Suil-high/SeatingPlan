using System;
using System.Collections.Generic;
using System.Drawing;
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
            DoubleBuffered = true;
        }

        private void InitializeComponent() {
            this.nameDisplay = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameDisplay
            // 
            this.nameDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.nameDisplay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.nameDisplay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.nameDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nameDisplay.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameDisplay.Location = new System.Drawing.Point(0, 10);
            this.nameDisplay.Name = "nameDisplay";
            this.nameDisplay.Size = new System.Drawing.Size(150, 30);
            this.nameDisplay.TabIndex = 0;
            this.nameDisplay.TabStop = false;
            this.nameDisplay.UseVisualStyleBackColor = false;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Red;
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(160, 10);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(50, 30);
            this.deleteButton.TabIndex = 0;
            this.deleteButton.TabStop = false;
            this.deleteButton.Text = "Del";
            this.deleteButton.UseVisualStyleBackColor = false;
            // 
            // NameBox
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.nameDisplay);
            this.Controls.Add(this.deleteButton);
            this.ResumeLayout(false);

        }
    }
}