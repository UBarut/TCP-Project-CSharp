
namespace CepteSef
{
    partial class MainPanel
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
            this.pnlMostViewed = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRandomRecipe = new System.Windows.Forms.Label();
            this.pnlRandomRecipe = new System.Windows.Forms.Panel();
            this.lblMostViewed = new System.Windows.Forms.Label();
            this.pnlFavorites = new System.Windows.Forms.Panel();
            this.lblFavorites = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMostViewed
            // 
            this.pnlMostViewed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMostViewed.Location = new System.Drawing.Point(269, 48);
            this.pnlMostViewed.Name = "pnlMostViewed";
            this.pnlMostViewed.Size = new System.Drawing.Size(260, 399);
            this.pnlMostViewed.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.lblRandomRecipe, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlRandomRecipe, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMostViewed, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlMostViewed, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlFavorites, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFavorites, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblRandomRecipe
            // 
            this.lblRandomRecipe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRandomRecipe.AutoSize = true;
            this.lblRandomRecipe.Font = new System.Drawing.Font("Coolvetica Condensed Rg", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRandomRecipe.ForeColor = System.Drawing.Color.White;
            this.lblRandomRecipe.Location = new System.Drawing.Point(76, 9);
            this.lblRandomRecipe.Name = "lblRandomRecipe";
            this.lblRandomRecipe.Size = new System.Drawing.Size(114, 26);
            this.lblRandomRecipe.TabIndex = 0;
            this.lblRandomRecipe.Text = "Rastgele Seçim";
            // 
            // pnlRandomRecipe
            // 
            this.pnlRandomRecipe.BackColor = System.Drawing.Color.Transparent;
            this.pnlRandomRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRandomRecipe.Location = new System.Drawing.Point(3, 48);
            this.pnlRandomRecipe.Name = "pnlRandomRecipe";
            this.pnlRandomRecipe.Size = new System.Drawing.Size(260, 399);
            this.pnlRandomRecipe.TabIndex = 0;
            // 
            // lblMostViewed
            // 
            this.lblMostViewed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMostViewed.AutoSize = true;
            this.lblMostViewed.Font = new System.Drawing.Font("Coolvetica Condensed Rg", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMostViewed.ForeColor = System.Drawing.Color.White;
            this.lblMostViewed.Location = new System.Drawing.Point(339, 9);
            this.lblMostViewed.Name = "lblMostViewed";
            this.lblMostViewed.Size = new System.Drawing.Size(119, 26);
            this.lblMostViewed.TabIndex = 1;
            this.lblMostViewed.Text = "En Çok Bakılanlar";
            // 
            // pnlFavorites
            // 
            this.pnlFavorites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFavorites.Location = new System.Drawing.Point(535, 48);
            this.pnlFavorites.Name = "pnlFavorites";
            this.pnlFavorites.Size = new System.Drawing.Size(262, 399);
            this.pnlFavorites.TabIndex = 3;
            // 
            // lblFavorites
            // 
            this.lblFavorites.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFavorites.AutoSize = true;
            this.lblFavorites.Font = new System.Drawing.Font("Coolvetica Condensed Rg", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFavorites.ForeColor = System.Drawing.Color.White;
            this.lblFavorites.Location = new System.Drawing.Point(632, 9);
            this.lblFavorites.Name = "lblFavorites";
            this.lblFavorites.Size = new System.Drawing.Size(68, 26);
            this.lblFavorites.TabIndex = 4;
            this.lblFavorites.Text = "Favoriler";
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainPanel";
            this.Text = "MainPanel";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMostViewed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblRandomRecipe;
        private System.Windows.Forms.Panel pnlRandomRecipe;
        private System.Windows.Forms.Label lblMostViewed;
        private System.Windows.Forms.Panel pnlFavorites;
        private System.Windows.Forms.Label lblFavorites;
    }
}