
namespace CepteSef
{
    partial class UC_CategoryCardPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCategoryPanelName = new System.Windows.Forms.Label();
            this.pbCategory = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblCategoryPanelName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbCategory, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblCategoryPanelName
            // 
            this.lblCategoryPanelName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCategoryPanelName.AutoSize = true;
            this.lblCategoryPanelName.Font = new System.Drawing.Font("Caviar Dreams", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCategoryPanelName.Location = new System.Drawing.Point(86, 115);
            this.lblCategoryPanelName.Name = "lblCategoryPanelName";
            this.lblCategoryPanelName.Size = new System.Drawing.Size(127, 24);
            this.lblCategoryPanelName.TabIndex = 0;
            this.lblCategoryPanelName.Text = "Kategori Adi";
            // 
            // pbCategory
            // 
            this.pbCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCategory.Location = new System.Drawing.Point(3, 3);
            this.pbCategory.Name = "pbCategory";
            this.pbCategory.Size = new System.Drawing.Size(294, 99);
            this.pbCategory.TabIndex = 1;
            this.pbCategory.TabStop = false;
            this.pbCategory.Click += new System.EventHandler(this.pbCategory_Click);
            // 
            // UC_CategoryCardPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_CategoryCardPanel";
            this.Size = new System.Drawing.Size(300, 150);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label lblCategoryPanelName;
        public System.Windows.Forms.PictureBox pbCategory;
    }
}
