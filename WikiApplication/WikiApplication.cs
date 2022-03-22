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
            try
            {
                int currentDataStructure = listViewDataStructures.SelectedIndices[0];
                textBoxName.Text = dataStructures[currentDataStructure, 0];
                textBoxCategory.Text = dataStructures[currentDataStructure, 1];
                textBoxStructure.Text = dataStructures[currentDataStructure, 2];
                textBoxDefinition.Text = dataStructures[currentDataStructure, 3];
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select an item from the listbox.");
            }

        }
        #endregion
        #region Display Data Structures
        private void DisplayDataStructures()
        {
            listViewDataStructures.Items.Clear();
            listViewDataStructures.ForeColor = Color.Black;
            for (int x = 0; x < rowSize; x++)
            {
                if (!string.IsNullOrWhiteSpace(dataStructures[x,0]))
                {
                    // Displaying name and category
                    // StackOverflowException when bubble sort method added
                    ListViewItem listviewItem = new ListViewItem(dataStructures[x, 0]);
                    listviewItem.SubItems.Add(dataStructures[x, 1]);
                    listviewItem.SubItems.Add(dataStructures[x, 2]);
                    listviewItem.SubItems.Add(dataStructures[x, 3]);
                    listViewDataStructures.Items.Add(listviewItem);
                }
            }
            BubbleSort();   
        }
        #endregion
        #region Clear TextBoxes Method
        private void ClearTextBoxes()
        {
            textBoxName.Text = "";
            textBoxName.Focus();
            textBoxCategory.Text = "";
            textBoxStructure.Text = "";
            textBoxDefinition.Text = "";
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
                var result = MessageBox.Show("Proceed with new Record?", "Add New Record",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                for (int x = 0; x < rowSize; x++)
                {
                    
                    if (result == DialogResult.OK)
                    {
                        if (dataStructures[x, 0] == null)
                        {
                            dataStructures[x, 0] = textBoxName.Text;
                            dataStructures[x, 1] = textBoxCategory.Text;
                            dataStructures[x, 2] = textBoxStructure.Text;
                            dataStructures[x, 3] = textBoxDefinition.Text;
                            ptr++;
                        break;
                        }
                    }
                }
            }
            BubbleSort();
            DisplayDataStructures();
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
                        ptr--;
                        DisplayDataStructures();
                        BubbleSort();
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
            try
            {   
                int currentRecord = listViewDataStructures.SelectedIndices[0];
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
                        toolStripStatusLabel1.Text = "Data item changed.";
                    }
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select an item to edit.");
                
            }
             
        }
        #endregion
        #region Search Button (Binary method)
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // The user can search for an item which will be displayed in the four text boxes
            // Search input box must clear if search unsuccessful
            // Write the code for a Binary Search for the Name in the 2D array
            // Display the information in the other textboxes when found
            // Add suitable feedback if the search in not successful and clear the search textbox
            ClearStatusMessage();
            int startIndex = -1;
            int finalIndex = ptr;
            Console.WriteLine(finalIndex);
            bool flag = false;
            int foundIndex = -1;

            while (!flag && !((finalIndex - startIndex) <= 1))
            {
                int newIndex = (finalIndex + startIndex) / 2;
                if (string.Compare(dataStructures[newIndex, 0], textBoxSearch.Text) == 0)
                {
                    foundIndex = newIndex;
                    flag = true;
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
        #region Bubble sort 
        private void BubbleSort()
        // Sort 2D array by Name ascending
        {
            for (int x = 1; x < rowSize; x++)
            {
                for (int i = 0; i < rowSize - 1; i++)
                {
                    if (!(string.IsNullOrEmpty(dataStructures[i + 1, 0])))
                    {
                        if (string.Compare(dataStructures[i, 0], dataStructures[i + 1, 0]) == 1)
                        {
                            Swap(i);
                        }
                    }
                }
            }
        }
        #endregion
        #region Swap Method
        private void Swap(int index)
        {
            // Use a separate swap method that passes (by reference) the array element to be swapped
            string temp;
            for (int i = 0; i < colSize; i++)
            {
                temp = dataStructures[index, i];
                dataStructures[index, i] = dataStructures[index + 1, i];
                dataStructures[index + 1, i] = temp;
            }
        }
        #endregion
        #region Double-click Clear Searchbox
        private void textBoxSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        // A double mouse click in the search text box will clear the search input box
        {
            if (!string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                textBoxSearch.Clear();
                ClearTextBoxes();
                textBoxSearch.Focus();
            }
        }
        #endregion
        #region Utility methods
        private void ClearStatusMessage()
        {
            toolStripStatusLabel1.Text = "";
        }
        #endregion
        private void WikiApplication_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "hello";
        }
    }
}
