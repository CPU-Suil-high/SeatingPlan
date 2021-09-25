using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeatingPlan {
    public partial class SeatingPlanForm : Form {
        public SeatingPlanForm() {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            saveFileDialog.ShowDialog();
            string path = saveFileDialog.FileName;

            if (path == "") {
                return;
            }

            Stream ws = new FileStream(path, FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();

            serializer.Serialize(ws, seatsManager.GetSaveData());

            ws.Close();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            openFileDialog.ShowDialog();
            string path = openFileDialog.FileName;

            if (path == "") {
                return;
            }

            Stream rs = new FileStream(path, FileMode.Open);
            BinaryFormatter deserializer = new BinaryFormatter();

            SaveData saveData = (SaveData)deserializer.Deserialize(rs);

            rs.Close();

            seatsManager.SetSaveData(saveData);
        }
    }
}