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
        // The prototype must use a two-dimensional array of type string
        // All wiki data is stored/retrieved using a binary file format
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
            textBoxName.Text = dataStructures[currentDataStructure, 0];
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
            // The user can add a new item
            if (!string.IsNullOrWhiteSpace(textBoxName.Text) &&
               !string.IsNullOrWhiteSpace(textBoxCategory.Text) &&
               !string.IsNullOrWhiteSpace(textBoxStructure.Text) &&
               !string.IsNullOrWhiteSpace(textBoxDefinition.Text))
            {
                if (ptr < rowSize)
                {
                    dataStructures[ptr, 0] = textBoxName.Text;
                    dataStructures[ptr, 1] = textBoxCategory.Text;
                    dataStructures[ptr, 2] = textBoxStructure.Text;
                    dataStructures[ptr, 3] = textBoxDefinition.Text;
              
                    var result = MessageBox.Show("Proceed with new definition?", "Add New Definition",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        ptr++;
                    }
                    else
                    {
                        dataStructures[ptr, 0] = "";
                        dataStructures[ptr, 1] = "Category";
                        dataStructures[ptr, 2] = "Structure";
                        dataStructures[ptr, 3] = "Definition";
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
            try
            {
                int currentRecord = listViewDataStructures.SelectedIndices[0];

                if (currentRecord >= 0)
                {
                    DialogResult delName = MessageBox.Show("Do you wish to delete this definition?",
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
                    else
                    {
                        MessageBox.Show("Item NOT Deleted", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select an item to delete.");
                // needs focus
            }
        }
        #endregion
        #region Edit Button
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int currentRecord = listViewDataStructures.SelectedIndices[0];
            // System.ArgumentOutOfRangeException - needs try/catch
            if (currentRecord >= 0)
            {
                var result = MessageBox.Show("Proceed with update?", "Edit Record",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    dataStructures[currentRecord, 0] = textBoxName.Text;
                    dataStructures[currentRecord, 1] = textBoxCategory.Text;
                    dataStructures[currentRecord, 2] = textBoxStructure.Text;
                    dataStructures[currentRecord, 3] = textBoxDefinition.Text;
                    DisplayDataStructures();
                    ClearTextBoxes();
                }
            }
        }
        #endregion
        #region Search Button
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // A double mouse click in the search text box will clear the search input box
            // The user can search for an item which will be displayed in the four text boxes
            // Search input box must clear if search unsuccessful

            int startIndex = -1;
            int finalIndex = ptr;
            bool flag = false;
            int foundIndex = -1;

            while (!flag && !((finalIndex - startIndex) <= 1))
            {
                int newIndex = (finalIndex + startIndex) / 2;
                if (string.Compare(dataStructures[newIndex, 0], textBoxSearch.Text) == 0) 
                {
                    foundIndex = newIndex;
                    flag = true;
                    DisplayDataStructures();
                    ClearTextBoxes();
                    break;
                }
                else
                {
                    if (string.Compare(dataStructures[newIndex, 0], textBoxSearch.Text) == 1)
                    {
                        finalIndex = newIndex;
                    }   
                    else
                        startIndex = newIndex;
                }
            }
            if (flag)
            {
                textBoxSearch.Text = dataStructures[foundIndex, 0];
                textBoxName.Text = dataStructures[foundIndex, 0];
                textBoxCategory.Text = dataStructures[foundIndex, 1];
                textBoxStructure.Text = dataStructures[foundIndex, 2];
                textBoxDefinition.Text = dataStructures[foundIndex, 3];
            }
            else
                textBoxSearch.Text = "Not found ";
        }
        #endregion

    }
}
