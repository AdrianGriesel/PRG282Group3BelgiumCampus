    namespace PRG282Project
{
    partial class frmMain
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
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.btnUpdateStudent = new System.Windows.Forms.Button();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.btnSummary = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchVia = new System.Windows.Forms.TextBox();
            this.cmbVia = new System.Windows.Forms.ComboBox();
            this.lblVia = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDebug = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(14, 119);
            this.btnAddStudent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(155, 38);
            this.btnAddStudent.TabIndex = 0;
            this.btnAddStudent.Text = "Add Student";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // dgvStudents
            // 
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(188, 119);
            this.dgvStudents.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowHeadersWidth = 51;
            this.dgvStudents.RowTemplate.Height = 24;
            this.dgvStudents.Size = new System.Drawing.Size(611, 318);
            this.dgvStudents.TabIndex = 2;
            this.dgvStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellContentClick);
            // 
            // btnUpdateStudent
            // 
            this.btnUpdateStudent.Location = new System.Drawing.Point(14, 195);
            this.btnUpdateStudent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateStudent.Name = "btnUpdateStudent";
            this.btnUpdateStudent.Size = new System.Drawing.Size(155, 38);
            this.btnUpdateStudent.TabIndex = 3;
            this.btnUpdateStudent.Text = "Update Student";
            this.btnUpdateStudent.UseVisualStyleBackColor = true;
            this.btnUpdateStudent.Click += new System.EventHandler(this.btnUpdateStudent_Click);
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.Location = new System.Drawing.Point(14, 266);
            this.btnDeleteStudent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(155, 38);
            this.btnDeleteStudent.TabIndex = 4;
            this.btnDeleteStudent.Text = "Delete Student";
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // btnSummary
            // 
            this.btnSummary.Location = new System.Drawing.Point(12, 334);
            this.btnSummary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(155, 38);
            this.btnSummary.TabIndex = 5;
            this.btnSummary.Text = "Generate a Summary";
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(14, 38);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(153, 38);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchVia
            // 
            this.txtSearchVia.Location = new System.Drawing.Point(386, 46);
            this.txtSearchVia.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchVia.Name = "txtSearchVia";
            this.txtSearchVia.Size = new System.Drawing.Size(397, 22);
            this.txtSearchVia.TabIndex = 7;
            // 
            // cmbVia
            // 
            this.cmbVia.AutoCompleteCustomSource.AddRange(new string[] {
            "StudentID",
            "Name",
            "Age",
            "Course"});
            this.cmbVia.FormattingEnabled = true;
            this.cmbVia.Items.AddRange(new object[] {
            "Student ID",
            "Name",
            "Age",
            "Course"});
            this.cmbVia.Location = new System.Drawing.Point(216, 44);
            this.cmbVia.Margin = new System.Windows.Forms.Padding(4);
            this.cmbVia.Name = "cmbVia";
            this.cmbVia.Size = new System.Drawing.Size(160, 24);
            this.cmbVia.TabIndex = 8;
            this.cmbVia.SelectedIndexChanged += new System.EventHandler(this.cmbVia_SelectedIndexChanged);
            // 
            // lblVia
            // 
            this.lblVia.AutoSize = true;
            this.lblVia.Location = new System.Drawing.Point(176, 50);
            this.lblVia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVia.Name = "lblVia";
            this.lblVia.Size = new System.Drawing.Size(28, 16);
            this.lblVia.TabIndex = 9;
            this.lblVia.Text = "via ";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(14, 391);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(153, 38);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export to CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(14, 456);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 11;
            this.btnDebug.Text = "Debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BackgroundImage = global::PRG282Project.Properties.Resources._5625780;
            this.ClientSize = new System.Drawing.Size(800, 501);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblVia);
            this.Controls.Add(this.cmbVia);
            this.Controls.Add(this.txtSearchVia);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSummary);
            this.Controls.Add(this.btnDeleteStudent);
            this.Controls.Add(this.btnUpdateStudent);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.btnAddStudent);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button btnUpdateStudent;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchVia;
        private System.Windows.Forms.ComboBox cmbVia;
        private System.Windows.Forms.Label lblVia;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnDebug;
    }
}

