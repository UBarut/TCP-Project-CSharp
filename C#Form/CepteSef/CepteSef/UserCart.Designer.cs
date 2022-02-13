
namespace CepteSef
{
    partial class UserCart
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
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.btnSendCart = new System.Windows.Forms.Button();
            this.lbCartList = new System.Windows.Forms.ListBox();
            this.btnCloseCart = new System.Windows.Forms.Button();
            this.gradientPanel1 = new CepteSef.GradientPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlButtons, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbCartList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCloseCart, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(472, 441);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sepetin";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnClear);
            this.pnlButtons.Controls.Add(this.btnRemove);
            this.pnlButtons.Controls.Add(this.btnAddFood);
            this.pnlButtons.Controls.Add(this.btnSendCart);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(380, 47);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(89, 391);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClear.Location = new System.Drawing.Point(0, 40);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 40);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRemove.Location = new System.Drawing.Point(0, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(89, 40);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Çıkart";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnAddFood
            // 
            this.btnAddFood.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFood.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddFood.Location = new System.Drawing.Point(0, 311);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(89, 40);
            this.btnAddFood.TabIndex = 1;
            this.btnAddFood.Text = "Yemek Ekle";
            this.btnAddFood.UseVisualStyleBackColor = true;
            // 
            // btnSendCart
            // 
            this.btnSendCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendCart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSendCart.Location = new System.Drawing.Point(0, 351);
            this.btnSendCart.Name = "btnSendCart";
            this.btnSendCart.Size = new System.Drawing.Size(89, 40);
            this.btnSendCart.TabIndex = 2;
            this.btnSendCart.Text = "Sepeti Onayla";
            this.btnSendCart.UseVisualStyleBackColor = true;
            // 
            // lbCartList
            // 
            this.lbCartList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCartList.FormattingEnabled = true;
            this.lbCartList.ItemHeight = 15;
            this.lbCartList.Location = new System.Drawing.Point(3, 47);
            this.lbCartList.Name = "lbCartList";
            this.lbCartList.Size = new System.Drawing.Size(371, 391);
            this.lbCartList.TabIndex = 4;
            // 
            // btnCloseCart
            // 
            this.btnCloseCart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCloseCart.BackgroundImage = global::CepteSef.Properties.Resources.exit;
            this.btnCloseCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseCart.FlatAppearance.BorderSize = 0;
            this.btnCloseCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseCart.Location = new System.Drawing.Point(406, 4);
            this.btnCloseCart.Name = "btnCloseCart";
            this.btnCloseCart.Size = new System.Drawing.Size(36, 36);
            this.btnCloseCart.TabIndex = 5;
            this.btnCloseCart.UseVisualStyleBackColor = true;
            this.btnCloseCart.Click += new System.EventHandler(this.btnCloseCart_Click);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.ColorBottom = System.Drawing.Color.Empty;
            this.gradientPanel1.ColorTop = System.Drawing.Color.Empty;
            this.gradientPanel1.Controls.Add(this.tableLayoutPanel1);
            this.gradientPanel1.Degree = 0F;
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(472, 441);
            this.gradientPanel1.TabIndex = 1;
            // 
            // UserCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 441);
            this.Controls.Add(this.gradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserCart";
            this.Text = "UserCart";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.gradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private GradientPanel gradientPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlButtons;
        public System.Windows.Forms.Button btnAddFood;
        public System.Windows.Forms.Button btnSendCart;
        private System.Windows.Forms.Button btnRemove;
        public System.Windows.Forms.ListBox lbCartList;
        private System.Windows.Forms.Button btnCloseCart;
        private System.Windows.Forms.Button btnClear;
    }
}