using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeatingPlan {
    class SeatsManager : Panel {
        private SeatsView seatsView;
        private NameList nameList;
        private Button shuffleButton;

        public SeatsView SeatsView {
            get {
                return seatsView;
            }
            set {
                value.UpdateNames(Names, CurNameIndexes, FixedNames);
                seatsView = value;
            }
        }

        public NameList NameList {
            get {
                return nameList;
            }
            set {
                value.UpdateNames(Names);
                nameList = value;
            }
        }

        private List<string> names = new List<string>();
        private List<int> curNameIndexes = new List<int>();
        private bool[] fixedNames = new bool[Constants.MaxSeatCount];

        private Button sortButton;
        private Button moveModeButton;
        private Button viewEmptySeatButton;
        private Button resetButton;
        private Button testButton;

        public List<string> Names {
            private set {
                names = value;
            }
            get {
                return names;
            }
        }

        List<int> CurNameIndexes {
            get {
                return curNameIndexes;
            }
            set {
                curNameIndexes = value;
            }
        }

        bool[] FixedNames {
            get {
                return fixedNames;
            }
            set {
                fixedNames = value;
            }
        }

        public SeatsManager() {
            InitializeComponent();

            for (int i = 0; i < Names.Count; i++) {
                CurNameIndexes.Add(i);
            }
        }

        public void AddName(string name) {
            if (Names.Count >= Constants.MaxSeatCount) {
                return;
            }
            Names.Add(name);
            Names.Sort();
            int index = Names.FindLastIndex(x => x == name);

            for (int i = 0; i < CurNameIndexes.Count; i++) {
                if (CurNameIndexes[i] >= index) {
                    CurNameIndexes[i]++;
                }
            }

            CurNameIndexes.Add(index);

            UpdateSeats();
        }

        public void RemoveName(int index) {
            Names.RemoveAt(index);
            CurNameIndexes.Remove(index);

            for (int i = 0; i < CurNameIndexes.Count; i++) {
                if (CurNameIndexes[i] > index) {
                    CurNameIndexes[i]--;
                }
            }

            UpdateSeats();
        }

        public void SwapNames(int index1, int index2) {
            int temp = CurNameIndexes[index1];
            CurNameIndexes[index1] = CurNameIndexes[index2];
            CurNameIndexes[index2] = temp;

            UpdateSeats();
        }

        public void FixSeat(int index) {
            FixedNames[index] = FixedNames[index] ^ true;
            UpdateSeats();
        }

        public void ShuffleNames() {
            Random random = new Random();
            List<int> temp = new List<int>();

            int[] tempArray = CurNameIndexes.ToArray();

            for (int i = 0; i < Names.Count; i++) {
                if (FixedNames[i]) {
                    continue;
                }
                temp.Add(CurNameIndexes[i]);
            }

            for (int i = 0; i < Names.Count; i++) {
                if (FixedNames[i]) {
                    continue;
                }

                int index = random.Next(0, temp.Count);
                tempArray[i] = temp[index];
                temp.RemoveAt(index);
            }

            CurNameIndexes = tempArray.ToList();

            UpdateSeats();
        }

        public void UpdateSeats() {
            SeatsView.UpdateNames(Names, CurNameIndexes, FixedNames);
            NameList.UpdateNames(Names);
        }

        public SaveData GetSaveData() {
            SaveData saveData = new SaveData(SeatsView.GetSeatPositions(), Names.ToArray(), CurNameIndexes.ToArray(), FixedNames);
            return saveData;
        }

        public void SetSaveData(SaveData saveData) {
            SeatsView.SetSeatPositions(saveData.SeatPositions);

            Names = saveData.Names.ToList();
            CurNameIndexes = saveData.NamesIndexes.ToList();
            FixedNames = saveData.FixedNames;

            UpdateSeats();
        }

        public void Sort() {
            List<int> temp = new List<int>();
            for (int i = 0; i < CurNameIndexes.Count; i++) {
                if (FixedNames[i]) {
                    continue;
                }
                temp.Add(CurNameIndexes[i]);
            }

            temp.Sort();

            for (int i = 0; i < CurNameIndexes.Count; i++) {
                if (FixedNames[i]) {
                    continue;
                }

                CurNameIndexes[i] = temp[0];
                temp.RemoveAt(0);
            }

            UpdateSeats();
        }

        private void InitializeComponent() {
            this.shuffleButton = new System.Windows.Forms.Button();
            this.sortButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.moveModeButton = new System.Windows.Forms.Button();
            this.viewEmptySeatButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shuffleButton
            // 
            this.shuffleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.shuffleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shuffleButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shuffleButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.shuffleButton.Location = new System.Drawing.Point(18, 12);
            this.shuffleButton.Name = "shuffleButton";
            this.shuffleButton.Size = new System.Drawing.Size(75, 50);
            this.shuffleButton.TabIndex = 0;
            this.shuffleButton.Text = "Shuffle";
            this.shuffleButton.UseVisualStyleBackColor = false;
            this.shuffleButton.Click += new System.EventHandler(this.shuffleButton_Click);
            // 
            // sortButton
            // 
            this.sortButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.sortButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sortButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortButton.Location = new System.Drawing.Point(102, 12);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(75, 50);
            this.sortButton.TabIndex = 0;
            this.sortButton.Text = "Sort";
            this.sortButton.UseVisualStyleBackColor = false;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // testButton
            // 
            this.testButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.testButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testButton.Location = new System.Drawing.Point(354, 12);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 50);
            this.testButton.TabIndex = 0;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = false;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // moveModeButton
            // 
            this.moveModeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.moveModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveModeButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveModeButton.Location = new System.Drawing.Point(186, 12);
            this.moveModeButton.Name = "moveModeButton";
            this.moveModeButton.Size = new System.Drawing.Size(75, 50);
            this.moveModeButton.TabIndex = 0;
            this.moveModeButton.Text = "Move Mode";
            this.moveModeButton.UseVisualStyleBackColor = false;
            this.moveModeButton.Click += new System.EventHandler(this.movingModeButton_Click);
            // 
            // viewEmptySeatButton
            // 
            this.viewEmptySeatButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.viewEmptySeatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewEmptySeatButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewEmptySeatButton.Location = new System.Drawing.Point(270, 12);
            this.viewEmptySeatButton.Name = "viewEmptySeatButton";
            this.viewEmptySeatButton.Size = new System.Drawing.Size(75, 50);
            this.viewEmptySeatButton.TabIndex = 0;
            this.viewEmptySeatButton.Text = "View Emtpy Seat";
            this.viewEmptySeatButton.UseVisualStyleBackColor = false;
            this.viewEmptySeatButton.Click += new System.EventHandler(this.viewEmptySeatButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(354, 12);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 50);
            this.resetButton.TabIndex = 0;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // SeatsManager
            // 
            this.Controls.Add(this.shuffleButton);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.moveModeButton);
            this.Controls.Add(this.viewEmptySeatButton);
            this.Controls.Add(this.resetButton);
            this.ResumeLayout(false);

        }

        private void shuffleButton_Click(object sender, EventArgs e) {
            if (seatsView.IsMoveMode) {
                return;
            }
            this.ShuffleNames();
        }

        private void sortButton_Click(object sender, EventArgs e) {
            if (seatsView.IsMoveMode) {
                return;
            }
            this.Sort();
        }

        private void testButton_Click(object sender, EventArgs e) {
            int[][] temp = SeatsView.GetSeatPositions();

            for (int i = 0; i < temp.Length; i++) {
                Console.WriteLine($"new int[]{{{temp[i][0]}, {temp[i][1]}}},");
            }
            Console.WriteLine();
        }

        private void movingModeButton_Click(object sender, EventArgs e) {
            SeatsView.IsMoveMode = SeatsView.IsMoveMode ^ true;

            if (SeatsView.IsMoveMode) {
                moveModeButton.BackColor = System.Drawing.Color.FromArgb(204, 136, 0);
            } else {
                moveModeButton.BackColor = System.Drawing.Color.FromArgb(255, 170, 0);
            }
        }

        private void viewEmptySeatButton_Click(object sender, EventArgs e) {
            SeatsView.IsViewEmptySeat = SeatsView.IsViewEmptySeat ^ true;

            if (SeatsView.IsViewEmptySeat) {
                viewEmptySeatButton.BackColor = System.Drawing.Color.FromArgb(204, 136, 0);
            } else {
                viewEmptySeatButton.BackColor = System.Drawing.Color.FromArgb(255, 170, 0);
            }
        }

        private void resetButton_Click(object sender, EventArgs e) {
            SeatsView.ResetSeatPositions();
        }
    }
}
