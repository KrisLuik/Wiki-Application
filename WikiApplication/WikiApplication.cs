using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WikiApplication
{
    public partial class WikiApplication : Form
    {
        public WikiApplication()
        {
            InitializeComponent();
        }
        #region Properties
        static int rowSize = 12;
        static int colSize = 4; // Name, Category, Structure, Definition
        string[,] dataStructures = new string[rowSize, colSize];
        string defaultFileName = "default.bin";
        int ptr = 0;
        #endregion
        #region ListView
        private void ListViewDataStructures_Click(object sender, EventArgs e)
        {
            int currentDataStructure = listViewDataStructures.SelectedIndices[0];
            textBoxName.Text = dataStructures[currentDataStructure, 0 ];
            textBoxCategory.Text = dataStructures[currentDataStructure, 1];
            textBoxStructure.Text = dataStructures[currentDataStructure, 2];
            textBoxDefinition.Text = dataStructures[currentDataStructure, 3];
        }
        #endregion
        #region Display Data Structures
        private void DisplayDataStructures()
        {
            listViewDataStructures.Items.Clear();
            listViewDataStructures.ForeColor = Color.Black;
            for (int x = 0; x < rowSize; x++)
            {
                // Displaying name and category
                ListViewItem listviewItem = new ListViewItem(dataStructures[x, 0]);
                listviewItem.SubItems.Add(dataStructures[x, 1]);
                listviewItem.SubItems.Add(dataStructures[x, 2]);
                listViewDataStructures.Items.Add(listviewItem);
            }
        }
        #endregion
        #region Clear TextBoxes Method
        private void ClearTextBoxes()
        {
            textBoxName.Clear();
            textBoxName.Focus();

            textBoxCategory.Clear();
            textBoxCategory.Focus();

            textBoxStructure.Clear();
            textBoxStructure.Focus();

            textBoxDefinition.Clear();
            textBoxDefinition.Focus();
        }
        #endregion
        #region Add button
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxName.Text) &&
               !string.IsNullOrWhiteSpace(textBoxCategory.Text) &&
               !string.IsNullOrWhiteSpace(textBoxStructure.Text) &&
               !string.IsNullOrWhiteSpace(textBoxDefinition.Text))
            {
                for (int x = 0; x < rowSize; x++)
                {
                    if (ptr < rowSize)
                    {
                        dataStructures[x, 0] = textBoxName.Text;
                        dataStructures[x, 1] = textBoxCategory.Text;
                        dataStructures[x, 2] = textBoxStructure.Text;
                        dataStructures[x, 3] = textBoxDefinition.Text;

                        var result = MessageBox.Show("Proceed with new definition?", "Add New Definition",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                            break;
                        else
                        {
                            dataStructures[x, 0] = "";
                            dataStructures[x, 1] = "Category";
                            dataStructures[x, 2] = "Structure";
                            dataStructures[x, 3] = "Definition";
                            break;
                        }
                    }
                }
                
            }
            DisplayDataStructures();
            ClearTextBoxes();
        }
        #endregion
        #region Delete Button
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int currentRecord = listViewDataStructures.SelectedIndices[0];
            if (currentRecord >= 0)
            {
                DialogResult delName = MessageBox.Show("Do you wish to delete this Name?",
                 "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (delName == DialogResult.Yes)
                {
                    dataStructures[currentRecord, 0] = "";
                    dataStructures[currentRecord, 1] = "";
                    dataStructures[currentRecord, 2] = "";
                    dataStructures[currentRecord, 3] = "";
                    DisplayDataStructures();
                    ClearTextBoxes();
                    
                }
            }
        }
        #endregion
    }
}
