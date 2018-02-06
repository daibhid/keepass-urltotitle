namespace URLInName
{
    partial class CheckboxTableForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.selectAllBtn = new System.Windows.Forms.Button();
            this.unSelectAllBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OldTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Checked,
            this.OldTitle,
            this.NewTitle,
            this.URL,
            this.NewURL,
            this.Uuid});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(550, 331);
            this.dataGridView1.TabIndex = 0;
            // 
            // selectAllBtn
            // 
            this.selectAllBtn.AutoSize = true;
            this.selectAllBtn.Location = new System.Drawing.Point(3, 3);
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.Size = new System.Drawing.Size(61, 23);
            this.selectAllBtn.TabIndex = 1;
            this.selectAllBtn.Text = "&Select All";
            this.selectAllBtn.UseVisualStyleBackColor = true;
            this.selectAllBtn.Click += new System.EventHandler(this.selectAllBtn_Click);
            // 
            // unSelectAllBtn
            // 
            this.unSelectAllBtn.AutoSize = true;
            this.unSelectAllBtn.Location = new System.Drawing.Point(70, 3);
            this.unSelectAllBtn.Name = "unSelectAllBtn";
            this.unSelectAllBtn.Size = new System.Drawing.Size(73, 23);
            this.unSelectAllBtn.TabIndex = 3;
            this.unSelectAllBtn.Text = "&Unselect All";
            this.unSelectAllBtn.UseVisualStyleBackColor = true;
            this.unSelectAllBtn.Click += new System.EventHandler(this.unSelectAllBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.AutoSize = true;
            this.okBtn.Location = new System.Drawing.Point(448, 3);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(43, 23);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "&Apply";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.AutoSize = true;
            this.cancelBtn.Location = new System.Drawing.Point(497, 3);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(50, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "&Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.cancelBtn, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.okBtn, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.unSelectAllBtn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.selectAllBtn, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 302);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 29);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // Checked
            // 
            this.Checked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Checked.HeaderText = "Apply";
            this.Checked.Name = "Checked";
            this.Checked.Width = 39;
            // 
            // OldTitle
            // 
            this.OldTitle.HeaderText = "Old Title";
            this.OldTitle.Name = "OldTitle";
            this.OldTitle.ReadOnly = true;
            // 
            // NewTitle
            // 
            this.NewTitle.HeaderText = "New Title";
            this.NewTitle.Name = "NewTitle";
            this.NewTitle.ReadOnly = true;
            // 
            // URL
            // 
            this.URL.HeaderText = "Old URL";
            this.URL.Name = "URL";
            this.URL.ReadOnly = true;
            // 
            // NewURL
            // 
            this.NewURL.HeaderText = "New URL";
            this.NewURL.Name = "NewURL";
            // 
            // Uuid
            // 
            this.Uuid.HeaderText = "";
            this.Uuid.Name = "Uuid";
            this.Uuid.ReadOnly = true;
            this.Uuid.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 331);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button selectAllBtn;
        private System.Windows.Forms.Button unSelectAllBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn URL;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uuid;
    }
}