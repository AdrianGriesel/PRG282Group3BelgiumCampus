namespace PRG282Project
{
    partial class frmDebugger
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
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.btnSqlTest = new System.Windows.Forms.Button();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudents
            // 
            this.dgvStudents.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(24, 105);
            this.dgvStudents.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowHeadersWidth = 51;
            this.dgvStudents.RowTemplate.Height = 24;
            this.dgvStudents.Size = new System.Drawing.Size(616, 265);
            this.dgvStudents.TabIndex = 3;
            // 
            // btnSqlTest
            // 
            this.btnSqlTest.BackColor = System.Drawing.Color.LightCyan;
            this.btnSqlTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSqlTest.Location = new System.Drawing.Point(24, 50);
            this.btnSqlTest.Name = "btnSqlTest";
            this.btnSqlTest.Size = new System.Drawing.Size(156, 34);
            this.btnSqlTest.TabIndex = 4;
            this.btnSqlTest.Text = "Test SQL Select";
            this.btnSqlTest.UseVisualStyleBackColor = false;
            this.btnSqlTest.Click += new System.EventHandler(this.btnSqlTest_Click);
            // 
            // txtSql
            // 
            this.txtSql.Location = new System.Drawing.Point(199, 56);
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(441, 22);
            this.txtSql.TabIndex = 5;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.LightCyan;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Location = new System.Drawing.Point(24, 390);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(616, 34);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmDebugger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PRG282Project.Properties.Resources._5625780;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtSql);
            this.Controls.Add(this.btnSqlTest);
            this.Controls.Add(this.dgvStudents);
            this.Name = "frmDebugger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Debugger";
            this.Load += new System.EventHandler(this.Debugger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button btnSqlTest;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.Button btnBack;
    }
}