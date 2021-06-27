namespace mostaan
{
    partial class Bakhsh_List
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
            this.panelHolder = new Telerik.WinControls.UI.RadPanel();
            this.message = new System.Windows.Forms.Label();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radVScrollBar1 = new Telerik.WinControls.UI.RadVScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.panelHolder)).BeginInit();
            this.panelHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radVScrollBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHolder
            // 
            this.panelHolder.BackColor = System.Drawing.Color.Transparent;
            this.panelHolder.Controls.Add(this.message);
            this.panelHolder.Location = new System.Drawing.Point(12, 12);
            this.panelHolder.Name = "panelHolder";
            this.panelHolder.Size = new System.Drawing.Size(929, 587);
            this.panelHolder.TabIndex = 3;
            ((Telerik.WinControls.UI.RadPanelElement)(this.panelHolder.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.panelHolder.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.panelHolder.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.panelHolder.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.panelHolder.GetChildAt(0).GetChildAt(0))).GradientStyle = Telerik.WinControls.GradientStyles.Linear;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.panelHolder.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.panelHolder.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(20, 11);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(0, 13);
            this.message.TabIndex = 0;
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.Transparent;
            this.radPanel1.Controls.Add(this.radVScrollBar1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(964, 602);
            this.radPanel1.TabIndex = 2;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radVScrollBar1
            // 
            this.radVScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.radVScrollBar1.Location = new System.Drawing.Point(947, 0);
            this.radVScrollBar1.MinThumbLength = 60;
            this.radVScrollBar1.Name = "radVScrollBar1";
            this.radVScrollBar1.Size = new System.Drawing.Size(17, 602);
            this.radVScrollBar1.SmallChange = 10;
            this.radVScrollBar1.TabIndex = 0;
            this.radVScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.radVScrollBar1_Scroll);
            // 
            // Bakhsh_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 602);
            this.Controls.Add(this.panelHolder);
            this.Controls.Add(this.radPanel1);
            this.DoubleBuffered = true;
            this.Name = "Bakhsh_List";
            this.Text = "bakhsh_List";
            ((System.ComponentModel.ISupportInitialize)(this.panelHolder)).EndInit();
            this.panelHolder.ResumeLayout(false);
            this.panelHolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radVScrollBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel panelHolder;
        private System.Windows.Forms.Label message;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadVScrollBar radVScrollBar1;
    }
}