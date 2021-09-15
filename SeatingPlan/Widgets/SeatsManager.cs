﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeatingPlan {
    class SeatsManager : Panel {
        private SeatsView seatView;
        private NameList nameList;
        private Button shuffleButton;

        public SeatsView SeatsView {
            get {
                return seatView;
            }
            set {
                value.UpdateNames(Names, CurNameIndexes);
                seatView = value;
            }
        }

        public NameList NameList {
            get {
                return nameList;
            }
            set {
                nameList = value;
            }
        }

        private List<string> names = new List<string> {"21201 곽민서", "21202 구윤성", "21203 김규완", "21204 김민서", "21205 김영학", "21206 김태은", "21207 김현빈", "21208 변은지", "21209 서현수", "21210 성태성", "21211 손영휘", "21212 신소영", "21213 이민재", "21214 이시현", "21215 이정호", "21216 장연우", "21217 정우진", "21218 정태민", "21219 정현기", "21220 조현아", "21221 최유리", "21222 황요린"};

        private List<int> curNameIndexes = new List<int>();

        public List<string> Names {
            private set {
                names = value;
            }

            get {
                return names.ToList();
            }
        }

        List<int> CurNameIndexes {
            get {
                if (Names.Count > curNameIndexes.Count) {
                    List<int> temp = curNameIndexes;
                    curNameIndexes = new List<int>();

                    for (int i = 0; i < temp.Count; i++) {
                        if (Names.Count > temp[i]) {
                            curNameIndexes.Add(temp[i]);
                        }
                    }

                    for (int i = curNameIndexes.Count; i < Names.Count; i++) {
                        curNameIndexes.Add(i);
                    }
                } else if (Names.Count < curNameIndexes.Count) {

                }
                return curNameIndexes.ToList();
            }
            set {
                curNameIndexes = value;
            }
        }

        public SeatsManager() {
            InitializeComponent();
        }

        public void AddName(string name) {
            names.Add(name);
            UpdateSeats();
        }

        public void ShuffleNames() {
            Random random = new Random();
            List<string> temp = Names;
            
            names = new List<string>();

            while (temp.Count > 0) {
                int index = random.Next(0, temp.Count);
                names.Add(temp[index]);
                temp.RemoveAt(index);
            }

            UpdateSeats();
        }

        public void UpdateSeats() {
            seatView.UpdateNames(Names, CurNameIndexes);
        }

        private void InitializeComponent() {
            this.shuffleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shuffleButton
            // 
            this.shuffleButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.shuffleButton.Location = new System.Drawing.Point(12, 12);
            this.shuffleButton.Name = "shuffleButton";
            this.shuffleButton.Size = new System.Drawing.Size(75, 25);
            this.shuffleButton.TabIndex = 0;
            this.shuffleButton.Text = "shuffle";
            this.shuffleButton.UseVisualStyleBackColor = false;
            this.shuffleButton.Click += new System.EventHandler(this.shuffleButton_Click);
            // 
            // SeatsManager
            // 
            this.Controls.Add(this.shuffleButton);
            this.ResumeLayout(false);

        }

        private void shuffleButton_Click(object sender, EventArgs e) {
            this.ShuffleNames();
        }
    }
}