namespace WikiApplication
{
    partial class WikiApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.textBoxStructure = new System.Windows.Forms.TextBox();
            this.textBoxDefinition = new System.Windows.Forms.TextBox();
            this.listViewDataStructures = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.statusStripMessage = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonSort = new System.Windows.Forms.Button();
            this.toolTipWikiApplication = new System.Windows.Forms.ToolTip(this.components);
            this.statusStripMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(273, 51);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 41);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add";
            this.toolTipWikiApplication.SetToolTip(this.buttonAdd, "Add Data Structure");
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(13, 51);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(220, 22);
            this.textBoxName.TabIndex = 0;
            this.toolTipWikiApplication.SetToolTip(this.textBoxName, "Enter Data Structure Name");
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxName_KeyPress);
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(13, 97);
            this.textBoxCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(220, 22);
            this.textBoxCategory.TabIndex = 2;
            this.toolTipWikiApplication.SetToolTip(this.textBoxCategory, "Enter Data Structure Category");
            this.textBoxCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCategory_KeyPress);
            // 
            // textBoxStructure
            // 
            this.textBoxStructure.Location = new System.Drawing.Point(13, 150);
            this.textBoxStructure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxStructure.Name = "textBoxStructure";
            this.textBoxStructure.Size = new System.Drawing.Size(220, 22);
            this.textBoxStructure.TabIndex = 3;
            this.toolTipWikiApplication.SetToolTip(this.textBoxStructure, "Enter Data Structure");
            this.textBoxStructure.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStructure_KeyPress);
            // 
            // textBoxDefinition
            // 
            this.textBoxDefinition.Location = new System.Drawing.Point(13, 201);
            this.textBoxDefinition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDefinition.Multiline = true;
            this.textBoxDefinition.Name = "textBoxDefinition";
            this.textBoxDefinition.Size = new System.Drawing.Size(220, 266);
            this.textBoxDefinition.TabIndex = 4;
            this.toolTipWikiApplication.SetToolTip(this.textBoxDefinition, "Enter Data Structure Definition");
            this.textBoxDefinition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDefinition_KeyPress);
            // 
            // listViewDataStructures
            // 
            this.listViewDataStructures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnCategory});
            this.listViewDataStructures.FullRowSelect = true;
            this.listViewDataStructures.HideSelection = false;
            this.listViewDataStructures.Location = new System.Drawing.Point(273, 201);
            this.listViewDataStructures.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewDataStructures.Name = "listViewDataStructures";
            this.listViewDataStructures.Size = new System.Drawing.Size(391, 266);
            this.listViewDataStructures.TabIndex = 5;
            this.toolTipWikiApplication.SetToolTip(this.listViewDataStructures, "Listview for Data Structures");
            this.listViewDataStructures.UseCompatibleStateImageBehavior = false;
            this.listViewDataStructures.View = System.Windows.Forms.View.Details;
            this.listViewDataStructures.Click += new System.EventHandler(this.ListViewDataStructures_Click);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 192;
            // 
            // columnCategory
            // 
            this.columnCategory.Text = "Category";
            this.columnCategory.Width = 193;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(377, 51);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 41);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete";
            this.toolTipWikiApplication.SetToolTip(this.buttonDelete, "Delete Data Structure");
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(273, 95);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(100, 41);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "Search";
            this.toolTipWikiApplication.SetToolTip(this.buttonSearch, "Search Data Structure");
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(377, 95);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(100, 41);
            this.buttonEdit.TabIndex = 8;
            this.buttonEdit.Text = "Edit";
            this.toolTipWikiApplication.SetToolTip(this.buttonEdit, "Edit Data Structure");
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(273, 150);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(391, 22);
            this.textBoxSearch.TabIndex = 9;
            this.toolTipWikiApplication.SetToolTip(this.textBoxSearch, "Data Structure Search TextBox");
            this.textBoxSearch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxSearch_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Structure";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 180);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Definition";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(462, 472);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(100, 41);
            this.buttonOpen.TabIndex = 14;
            this.buttonOpen.Text = "Open";
            this.toolTipWikiApplication.SetToolTip(this.buttonOpen, "Open File");
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(565, 472);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 41);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Save";
            this.toolTipWikiApplication.SetToolTip(this.buttonSave, "Save File");
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // statusStripMessage
            // 
            this.statusStripMessage.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStripMessage.Location = new System.Drawing.Point(0, 524);
            this.statusStripMessage.Name = "statusStripMessage";
            this.statusStripMessage.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStripMessage.Size = new System.Drawing.Size(696, 22);
            this.statusStripMessage.TabIndex = 17;
            this.statusStripMessage.Text = "statusStrip1";
            this.toolTipWikiApplication.SetToolTip(this.statusStripMessage, "Application Status Bar");
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 16);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(128, 475);
            this.buttonTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(105, 28);
            this.buttonTest.TabIndex = 18;
            this.buttonTest.Text = "test";
            this.toolTipWikiApplication.SetToolTip(this.buttonTest, "Fill Listview with Test Data");
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(13, 475);
            this.buttonSort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(107, 28);
            this.buttonSort.TabIndex = 19;
            this.buttonSort.Text = "sort";
            this.toolTipWikiApplication.SetToolTip(this.buttonSort, "Sort Data");
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // toolTipWikiApplication
            // 
            this.toolTipWikiApplication.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // WikiApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 546);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.statusStripMessage);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.listViewDataStructures);
            this.Controls.Add(this.textBoxDefinition);
            this.Controls.Add(this.textBoxStructure);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonAdd);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WikiApplication";
            this.Text = "Wiki Data Structures";
            this.Load += new System.EventHandler(this.WikiApplication_Load);
            this.statusStripMessage.ResumeLayout(false);
            this.statusStripMessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.TextBox textBoxStructure;
        private System.Windows.Forms.TextBox textBoxDefinition;
        private System.Windows.Forms.ListView listViewDataStructures;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnCategory;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.StatusStrip statusStripMessage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.ToolTip toolTipWikiApplication;
    }
}

