using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatingPlan {
    [Serializable]
    struct SaveData {
        public int[][] SeatPositions;
        public string[] Names;
        public int[] NamesIndexes;
        public bool[] FixedNames;

        public SaveData(int[][] seatPositions, string[] names, int[] nameIndexes, bool[] fixedNames) {
            SeatPositions = seatPositions;
            Names = names;
            NamesIndexes = nameIndexes;
            FixedNames = fixedNames;
        }
    }
}
