namespace mostaan
{
    partial class DaryaftiReport
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.newRecordPanel = new Telerik.WinControls.UI.RadPanel();
            this.newRecord = new System.Windows.Forms.Label();
            this.filterPanel = new Telerik.WinControls.UI.RadPanel();
            this.filter = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newRecordPanel)).BeginInit();
            this.newRecordPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterPanel)).BeginInit();
            this.filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.71844F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.28156F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 469F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(964, 602);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(958, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "بانک دریافتی";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.875F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel2.Controls.Add(this.newRecordPanel, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.filterPanel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 42);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(958, 46);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // newRecordPanel
            // 
            this.newRecordPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newRecordPanel.BackColor = System.Drawing.Color.Silver;
            this.newRecordPanel.Controls.Add(this.newRecord);
            this.newRecordPanel.Location = new System.Drawing.Point(827, 3);
            this.newRecordPanel.Name = "newRecordPanel";
            this.newRecordPanel.Size = new System.Drawing.Size(128, 40);
            this.newRecordPanel.TabIndex = 3;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.newRecordPanel.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // newRecord
            // 
            this.newRecord.BackColor = System.Drawing.Color.Transparent;
            this.newRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newRecord.ForeColor = System.Drawing.Color.White;
            this.newRecord.Location = new System.Drawing.Point(0, 0);
            this.newRecord.Name = "newRecord";
            this.newRecord.Size = new System.Drawing.Size(128, 40);
            this.newRecord.TabIndex = 1;
            this.newRecord.Text = "جدید";
            this.newRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newRecord.Click += new System.EventHandler(this.newRecord_Click_1);
            // 
            // filterPanel
            // 
            this.filterPanel.BackColor = System.Drawing.Color.Silver;
            this.filterPanel.Controls.Add(this.filter);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterPanel.Location = new System.Drawing.Point(658, 3);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(139, 40);
            this.filterPanel.TabIndex = 3;
            this.filterPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.filterPanel_Paint);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.filterPanel.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // filter
            // 
            this.filter.BackColor = System.Drawing.Color.Transparent;
            this.filter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filter.ForeColor = System.Drawing.Color.White;
            this.filter.Location = new System.Drawing.Point(0, 0);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(139, 40);
            this.filter.TabIndex = 0;
            this.filter.Text = "فلیتر اختصاصی";
            this.filter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.filter.Click += new System.EventHandler(this.filter_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(958, 464);
            this.dataGridView1.TabIndex = 2;
            // 
            // DaryaftiReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 602);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DaryaftiReport";
            this.Text = "DaryaftiReport";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.newRecordPanel)).EndInit();
            this.newRecordPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filterPanel)).EndInit();
            this.filterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadPanel filterPanel;
        private System.Windows.Forms.Label filter;
        private Telerik.WinControls.UI.RadPanel newRecordPanel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label newRecord;
    }
}