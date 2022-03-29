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
        // The prototype must use a two-dimensional array of type string
        // All wiki data is stored/retrieved using a binary file format
        static int rowSize = 12;
        static int colSize = 4; // Name, Category, Structure, Definition
        string[,] dataStructures = new string[rowSize, colSize];
        string defaultFileName = "default.dat";
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

        #region Clear TextBoxes Method
        private void ClearTextBoxes()
        {
            textBoxName.Clear();
            textBoxName.Focus();
            textBoxCategory.Clear();
            textBoxStructure.Clear();
            textBoxDefinition.Clear();
        }
        #endregion

        #region Add button
        // The user can add a new item.
        private void buttonAdd_Click(object sender, EventArgs e)
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
                        if (dataStructures[x, 0] == null || dataStructures[x, 0] == "")
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

        #region Delete Button
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            listViewDataStructures.Items.Clear();
            listViewDataStructures.ForeColor = Color.Black;
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
                        dataStructures[currentRecord, 0] = null;
                        dataStructures[currentRecord, 1] = null;
                        dataStructures[currentRecord, 2] = null;
                        dataStructures[currentRecord, 3] = null;
                        ptr--;
                        ClearTextBoxes();
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

            #region Edit Button
            private void buttonEdit_Click(object sender, EventArgs e)
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

            #region Search Button (Binary method)
            // The user can search for an item which will be displayed in the four text boxes
            // Search input box must clear if search unsuccessful.
            // Write the code for a Binary Search for the Name in the 2D array
            // Display the information in the other textboxes when found
            // Add suitable feedback if the search in not successful and clear the search textbox
            private void buttonSearch_Click(object sender, EventArgs e)
            {
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
                    //toolStripStatusLabel1.Text = "Found at index " + foundIndex;
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
                {
                    toolStripStatusLabel1.Text = "Enter a name to search.";
                    textBoxSearch.Clear();
                    textBoxSearch.Focus();
                }
                else
                {
                    toolStripStatusLabel1.Text = "Not Found.";
                    textBoxSearch.Clear();
                    textBoxSearch.Focus();
                }

            }
            #endregion

            #region Bubble sort 
            private void Sort()
            {
                for (int x = 0; x < rowSize; x++)
                {
                    for (int i = 0; i < rowSize - 1; i++)
                    {
                        if (!(string.IsNullOrEmpty(dataStructures[i + 1, 0])))
                        {
                            if (string.Compare(dataStructures[i, 0], dataStructures[i + 1, 1]) == 1)
                            {
                                Swap(i);
                                Console.WriteLine(dataStructures[i, 0] + " is now at index " + i);
                            }
                        }
                    }
                }
            }
            #endregion

            #region Swap Method
            private void Swap(int index)
            // Use a separate swap method that passes (by reference) the array element to be swapped
            {
                string temp;
                for (int i = 0; i < colSize; i++)
                {
                    temp = dataStructures[index, i];
                    dataStructures[index, i] = dataStructures[index + 1, i];
                    dataStructures[index + 1, i] = temp;
                    Console.WriteLine(dataStructures[index, i]);
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
                    ClearStatusMessage();
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
                toolStripStatusLabel1.Text = "Wiki Application for Data Structures.";
            }

            #region Open 
            private void buttonOpen_Click(object sender, EventArgs e)
            {
                BinaryReader br;
                int x = 0;
                listViewDataStructures.Items.Clear();
                try
                {
                    br = new BinaryReader(new FileStream("default.dat", FileMode.Open));
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

            #region Save Button
            private void buttonSave_Click(object sender, EventArgs e)
            {
                BinaryWriter bw;
                try
                {
                    bw = new BinaryWriter(new FileStream("default.dat", FileMode.Create));
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
        }
    }
