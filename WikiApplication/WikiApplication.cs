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
// Name: Kristiin Tribbeck
// ID: 30045325
// This application is using 2d array to demonstrate the name, structure, category, and definiton of a data structure.
namespace WikiApplication
{
    public partial class WikiApplication : Form
    {
        public WikiApplication()
        {
            InitializeComponent();
        }
        #region Properties
        // This prototype uses a two-dimensional array of type string
        // All wiki data is stored/retrieved using a binary file format
        static int rowSize = 12;
        static int colSize = 4; // Name, Category, Structure, Definition
        string[,] dataStructures = new string[rowSize, colSize];
        string defaultFileName = "definitions.dat";
        int ptr = 0;
        #endregion

        #region ListView
        private void ListViewDataStructures_Click(object sender, EventArgs e)
        {
            try
            {
                ClearStatusMessage();
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
        // Create a display method that will show the following information in a List box: Name and Category.
        #region Display Data Structures
        private void DisplayArray()
        {
            listViewDataStructures.Items.Clear();
            listViewDataStructures.ForeColor = Color.Black;
            for (int x = 0; x < rowSize; x++)
            {
                if (!string.IsNullOrWhiteSpace(dataStructures[x, 0]))
                {
                    // Displaying name and category
                    ListViewItem lvi = new ListViewItem(dataStructures[x, 0]);
                    lvi.SubItems.Add(dataStructures[x, 1]);
                    lvi.SubItems.Add(dataStructures[x, 2]);
                    lvi.SubItems.Add(dataStructures[x, 3]);
                    listViewDataStructures.Items.Add(lvi);
                }
            }
        }
        #endregion
        // Create an ADD button that will store the information from the 4 text boxes into the 2D array.
        #region Add button

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            ClearStatusMessage();
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
                        if (dataStructures[x, 0] == "~" || dataStructures[x, 0] == "")
                        {
                            ClearStatusMessage();
                            dataStructures[x, 0] = textBoxName.Text;
                            dataStructures[x, 1] = textBoxCategory.Text;
                            dataStructures[x, 2] = textBoxStructure.Text;
                            dataStructures[x, 3] = textBoxDefinition.Text;
                            ptr++;
                            Sort();
                            DisplayArray();
                            ClearTextBoxes();
                            toolStripStatusLabel1.Text = "Item added successfully.";
                            break;
                        }
                        else
                        {
                            toolStripStatusLabel1.Text = "Array is full.";
                        }
                    }
                }
            }
        }
        #endregion
        // Create a DELETE button that will clear the selected item from the listviewbox.
        #region Delete Button
        
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ClearStatusMessage();
                int currentRecord = listViewDataStructures.SelectedIndices[0];
                if (currentRecord >= 0)
                {
                    DialogResult delName = MessageBox.Show("Do you wish to delete this definition?",
                     "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (delName == DialogResult.Yes)
                    {
                        ListViewItem lvi = new ListViewItem(dataStructures[currentRecord, 0]);
                        dataStructures[currentRecord, 0] = "~";
                        dataStructures[currentRecord, 1] = "~";
                        dataStructures[currentRecord, 2] = "~";
                        dataStructures[currentRecord, 3] = "~";
                        ptr--;
                        ClearTextBoxes();
                        Sort();
                        DisplayArray();
                        toolStripStatusLabel1.Text = "Data item deleted.";
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
            }
        }
        #endregion
        // Create an EDIT button that will change the selected items value.
        #region Edit Button
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ClearStatusMessage();
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
                        DisplayArray();
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
        // The user can search for an item which will be displayed in the four text boxes
        // Search input box must clear if search unsuccessful.
        // Write the code for a Binary Search for the Name in the 2D array.
        // Display the information in the other textboxes when found.
        // Add suitable feedback if the search in not successful and clear the search textbox.
        #region Search Button (Binary method)
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            ClearStatusMessage();
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
                    listViewDataStructures.Items[0].Selected = true;   
                    toolStripStatusLabel1.Text = "Found at index " + foundIndex;
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
            else if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                toolStripStatusLabel1.Text = "Enter a name to search.";
                ClearSearchBox();
            }
            else if (!string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                toolStripStatusLabel1.Text = "Error: Add data to list first.";
                ClearSearchBox();
            }
            else
            {
                toolStripStatusLabel1.Text = "Not Found.";
                ClearSearchBox();
            }
        }
        #endregion
        // Write the code for a Bubble Sort method to sort the 2D array by Name ascending.
        #region Bubble sort 
        private void Sort()
        {
            for (int x = 0; x < rowSize; x++)
            {
                for (int i = 0; i < rowSize - 1; i++)
                {
                    if (!(string.IsNullOrEmpty(dataStructures[i + 1, 0])))
                    {
                        if (string.CompareOrdinal(dataStructures[i, 0], dataStructures[i + 1, 1]) > 0)
                        {
                            Swap(i);
                        }
                    }
                }
            }
        }
        #endregion
        // Use a separate swap method that passes (by reference) the array element to be swapped
        #region Swap Method
        private void Swap(int index)
        {
            string temp;
            for (int i = 0; i < colSize; i++)
            {
                temp = dataStructures[index, i];
                dataStructures[index, i] = dataStructures[index + 1, i];
                dataStructures[index + 1, i] = temp;
            }
        }
        #endregion
        // A double mouse click in the search text box will clear the search input box.
        #region Double-click Clear Searchbox
        private void TextBoxSearch_MouseDoubleClick(object sender, MouseEventArgs e)
       
        {
            if (!string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                textBoxSearch.Clear();
                ClearTextBoxes();
                textBoxSearch.Focus();
                ClearStatusMessage();
            }
        }
        #endregion

        #region Form Load
        private void WikiApplication_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Wiki Application for Data Structures.";
            for (int x = 0; x < rowSize - 1; x++)
            {
                for (int y = 0; y < colSize - 1; y++)
                {
                    dataStructures[x, y] = "~";
                }
            }
            DisplayArray();
        }
        #endregion
        // Create a LOAD/OPEN button that will read the information from a binary file called definitions.dat into the 2D array.
        #region Open 
        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            BinaryReader br;
            int x = 0;
            listViewDataStructures.Items.Clear();
            try
            {
                br = new BinaryReader(new FileStream("definitions.dat", FileMode.Open));
            }
            catch (Exception fe)
            {
                MessageBox.Show(fe.Message + "\n Cannot open file for reading");
                return;
            }
            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                try
                {
                    dataStructures[x, 0] = br.ReadString();
                    dataStructures[x, 1] = br.ReadString();
                    dataStructures[x, 2] = br.ReadString();
                    dataStructures[x, 3] = br.ReadString();
                    x++;
                }
                catch (Exception fe)
                {
                    MessageBox.Show("Cannot read data from file or EOF" + fe);
                    break;
                }
                ptr = x;
                DisplayArray();
            }
            br.Close();
        }
        #endregion
        // Create a SAVE button so the information from the 2D array can be written into a binary file called definitions.dat which is sorted by Name.
        #region Save Button
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            BinaryWriter bw;
            try
            {
                bw = new BinaryWriter(new FileStream("definitions.dat", FileMode.Create));
            }
            catch (Exception fe)
            {
                MessageBox.Show(fe.Message + "\n Cannot append to file.");
                return;
            }
            try
            {
                for (int i = 0; i < ptr; i++)
                {
                    bw.Write(dataStructures[i, 0]);
                    bw.Write(dataStructures[i, 1]);
                    bw.Write(dataStructures[i, 2]);
                    bw.Write(dataStructures[i, 3]);
                }
            }
            catch (Exception fe)
            {
                MessageBox.Show(fe.Message + "\n Cannot write data to file.");
                return;
            }
            bw.Close();
        }
        #endregion

        #region TEST
        private void buttonTest_Click(object sender, EventArgs e)
        {
            dataStructures[0, 0] = "nameone";
            dataStructures[1, 0] = "nametwo";
            dataStructures[2, 0] = "namethree";
            dataStructures[3, 0] = "namefour";

            dataStructures[0, 1] = "categoryone";
            dataStructures[1, 1] = "categorytwo";
            dataStructures[2, 1] = "categorythree";
            dataStructures[3, 1] = "categoryfour";

            dataStructures[0, 2] = "structureone";
            dataStructures[1, 2] = "structureetwo";
            dataStructures[2, 2] = "structurethree";
            dataStructures[3, 2] = "structurefour";

            dataStructures[0, 3] = "definitionone";
            dataStructures[1, 3] = "definitiontwo";
            dataStructures[2, 3] = "definitionthree";
            dataStructures[3, 3] = "definitionfour";
            ptr += 4;
            DisplayArray();
        }
        #endregion

        #region Input Handling
        private void InputHandling(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar == '-')
            {
                // These characters may pass.
                e.Handled = false;
            }
            else
            {
                // Everything that is not a letter, a backspace, a space, or dash will be blocked.
                e.Handled = true;
            }
        }
        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputHandling(e);
        }

        private void textBoxCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputHandling(e);
        }

        private void textBoxStructure_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputHandling(e);
        }

        private void textBoxDefinition_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputHandling(e);
        }
        #endregion
        // Create a CLEAR method to clear the four text boxes so a new definition can be added.
        #region Utility Methods
        private void ClearStatusMessage()
        {
            toolStripStatusLabel1.Text = "";
        }
        // Clear 4 text boxes method and clear search textbox.
        private void ClearSearchBox()
        {
            textBoxSearch.Clear();
            textBoxSearch.Focus();
        }
        
        private void ClearTextBoxes()
        {
            textBoxName.Clear();
            textBoxName.Focus();
            textBoxCategory.Clear();
            textBoxStructure.Clear();
            textBoxDefinition.Clear();
        }
        #endregion
    }
}
