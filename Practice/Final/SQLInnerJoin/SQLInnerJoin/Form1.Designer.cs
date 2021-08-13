
namespace SQLInnerJoin
{
    partial class Form1
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
            this.dgvInnerJoin = new System.Windows.Forms.DataGridView();
            this.SecondCategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainCategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInnerJoin)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInnerJoin
            // 
            this.dgvInnerJoin.AllowUserToAddRows = false;
            this.dgvInnerJoin.AllowUserToDeleteRows = false;
            this.dgvInnerJoin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInnerJoin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SecondCategoryId,
            this.SecondCategoryName,
            this.MainCategoryId});
            this.dgvInnerJoin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInnerJoin.Location = new System.Drawing.Point(0, 0);
            this.dgvInnerJoin.Name = "dgvInnerJoin";
            this.dgvInnerJoin.ReadOnly = true;
            this.dgvInnerJoin.RowHeadersWidth = 51;
            this.dgvInnerJoin.RowTemplate.Height = 24;
            this.dgvInnerJoin.Size = new System.Drawing.Size(890, 538);
            this.dgvInnerJoin.TabIndex = 0;
            // 
            // SecondCategoryId
            // 
            this.SecondCategoryId.DataPropertyName = "SecondCategoryId";
            this.SecondCategoryId.HeaderText = "Second Category Id";
            this.SecondCategoryId.MinimumWidth = 6;
            this.SecondCategoryId.Name = "SecondCategoryId";
            this.SecondCategoryId.ReadOnly = true;
            this.SecondCategoryId.Width = 125;
            // 
            // SecondCategoryName
            // 
            this.SecondCategoryName.DataPropertyName = "SecondCategoryName";
            this.SecondCategoryName.HeaderText = "Second Category Name";
            this.SecondCategoryName.MinimumWidth = 6;
            this.SecondCategoryName.Name = "SecondCategoryName";
            this.SecondCategoryName.ReadOnly = true;
            this.SecondCategoryName.Width = 125;
            // 
            // MainCategoryId
            // 
            this.MainCategoryId.DataPropertyName = "MainCategoryId";
            this.MainCategoryId.HeaderText = "Main Category Id";
            this.MainCategoryId.MinimumWidth = 6;
            this.MainCategoryId.Name = "MainCategoryId";
            this.MainCategoryId.ReadOnly = true;
            this.MainCategoryId.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 538);
            this.Controls.Add(this.dgvInnerJoin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInnerJoin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInnerJoin;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondCategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondCategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MainCategoryId;
    }
}

