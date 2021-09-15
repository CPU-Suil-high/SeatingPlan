
namespace SeatingPlan {
    partial class SeatingPlanForm {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            this.nameList = new SeatingPlan.NameList();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.seats = new SeatingPlan.SeatsView();
            this.seatsManager = new SeatingPlan.SeatsManager();
            this.nameList.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameList
            // 
            this.nameList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameList.BackColor = System.Drawing.SystemColors.Info;
            this.nameList.Controls.Add(this.vScrollBar1);
            this.nameList.Location = new System.Drawing.Point(821, 12);
            this.nameList.Name = "nameList";
            this.nameList.Size = new System.Drawing.Size(149, 479);
            this.nameList.TabIndex = 4;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(128, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 479);
            this.vScrollBar1.TabIndex = 1;
            // 
            // seats
            // 
            this.seats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seats.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.seats.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.seats.Location = new System.Drawing.Point(15, 12);
            this.seats.Name = "seats";
            this.seats.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.seats.Size = new System.Drawing.Size(800, 400);
            this.seats.TabIndex = 0;
            // 
            // seatsManager
            // 
            this.seatsManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seatsManager.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.seatsManager.Location = new System.Drawing.Point(15, 418);
            this.seatsManager.Name = "seatsManager";
            this.seatsManager.NameList = this.nameList;
            this.seatsManager.SeatsView = this.seats;
            this.seatsManager.Size = new System.Drawing.Size(800, 73);
            this.seatsManager.TabIndex = 3;
            // 
            // SeatingPlanForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(982, 503);
            this.Controls.Add(this.nameList);
            this.Controls.Add(this.seats);
            this.Controls.Add(this.seatsManager);
            this.MinimumSize = new System.Drawing.Size(550, 475);
            this.Name = "SeatingPlanForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "SeatingPlan";
            this.nameList.ResumeLayout(false);
            this.nameList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SeatingPlan.SeatsView seats;
        private SeatingPlan.SeatsManager seatsManager;
        private SeatingPlan.NameList nameList;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}

