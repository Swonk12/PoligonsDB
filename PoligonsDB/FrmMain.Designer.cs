namespace PoligonsDB
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lbGrup = new System.Windows.Forms.Label();
            this.cbPoligon = new System.Windows.Forms.ComboBox();
            this.lbPersonatges = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.dgPoligons = new System.Windows.Forms.DataGridView();
            this.pbAdd = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgPoligons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // lbGrup
            // 
            this.lbGrup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGrup.Location = new System.Drawing.Point(29, 23);
            this.lbGrup.Name = "lbGrup";
            this.lbGrup.Size = new System.Drawing.Size(292, 36);
            this.lbGrup.TabIndex = 0;
            this.lbGrup.Text = "Tria el teu poligon:";
            // 
            // cbPoligon
            // 
            this.cbPoligon.FormattingEnabled = true;
            this.cbPoligon.Items.AddRange(new object[] {
            "TOTS",
            "Quadrats",
            "Rectangles",
            "Cercles",
            "Elipses",
            "Triangles_Rectangles",
            "Triangles_Isosceles",
            "Rombes",
            "Pentagons",
            "Hexagons",
            "Octagons"});
            this.cbPoligon.Location = new System.Drawing.Point(352, 29);
            this.cbPoligon.Name = "cbPoligon";
            this.cbPoligon.Size = new System.Drawing.Size(406, 24);
            this.cbPoligon.TabIndex = 1;
            this.cbPoligon.SelectedIndexChanged += new System.EventHandler(this.cbPoligon_SelectedIndexChanged);
            // 
            // lbPersonatges
            // 
            this.lbPersonatges.BackColor = System.Drawing.Color.LightGray;
            this.lbPersonatges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPersonatges.Location = new System.Drawing.Point(12, 85);
            this.lbPersonatges.Name = "lbPersonatges";
            this.lbPersonatges.Padding = new System.Windows.Forms.Padding(3);
            this.lbPersonatges.Size = new System.Drawing.Size(535, 25);
            this.lbPersonatges.TabIndex = 2;
            this.lbPersonatges.Text = "Poligons";
            this.lbPersonatges.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbInfo
            // 
            this.lbInfo.BackColor = System.Drawing.Color.LightGray;
            this.lbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInfo.Location = new System.Drawing.Point(553, 85);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Padding = new System.Windows.Forms.Padding(3);
            this.lbInfo.Size = new System.Drawing.Size(513, 25);
            this.lbInfo.TabIndex = 8;
            this.lbInfo.Text = "Informació del poligon";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbInfo
            // 
            this.tbInfo.Location = new System.Drawing.Point(553, 113);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(513, 278);
            this.tbInfo.TabIndex = 9;
            // 
            // dgPoligons
            // 
            this.dgPoligons.AllowUserToAddRows = false;
            this.dgPoligons.AllowUserToDeleteRows = false;
            this.dgPoligons.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dgPoligons.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgPoligons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPoligons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPoligons.Location = new System.Drawing.Point(12, 113);
            this.dgPoligons.MultiSelect = false;
            this.dgPoligons.Name = "dgPoligons";
            this.dgPoligons.ReadOnly = true;
            this.dgPoligons.RowHeadersVisible = false;
            this.dgPoligons.RowHeadersWidth = 51;
            this.dgPoligons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPoligons.Size = new System.Drawing.Size(535, 629);
            this.dgPoligons.TabIndex = 10;
            this.dgPoligons.SelectionChanged += new System.EventHandler(this.dgPoligons_SelectionChanged);
            // 
            // pbAdd
            // 
            this.pbAdd.Image = ((System.Drawing.Image)(resources.GetObject("pbAdd.Image")));
            this.pbAdd.Location = new System.Drawing.Point(920, 748);
            this.pbAdd.Name = "pbAdd";
            this.pbAdd.Size = new System.Drawing.Size(51, 52);
            this.pbAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAdd.TabIndex = 11;
            this.pbAdd.TabStop = false;
            this.pbAdd.Click += new System.EventHandler(this.pbAdd_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 808);
            this.Controls.Add(this.pbAdd);
            this.Controls.Add(this.dgPoligons);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.lbPersonatges);
            this.Controls.Add(this.cbPoligon);
            this.Controls.Add(this.lbGrup);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmMain_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgPoligons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbGrup;
        private System.Windows.Forms.ComboBox cbPoligon;
        private System.Windows.Forms.Label lbPersonatges;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.DataGridView dgPoligons;
        private System.Windows.Forms.PictureBox pbAdd;
    }
}

