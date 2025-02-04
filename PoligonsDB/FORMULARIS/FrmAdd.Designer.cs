namespace PoligonsDB.FORMULARIS
{
    partial class FrmAdd
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
            this.btClose = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.lbComentari = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.lbNom = new System.Windows.Forms.Label();
            this.gbGrup = new System.Windows.Forms.GroupBox();
            this.rdOctogons = new System.Windows.Forms.RadioButton();
            this.rdHexagons = new System.Windows.Forms.RadioButton();
            this.rdPentagons = new System.Windows.Forms.RadioButton();
            this.rdRombes = new System.Windows.Forms.RadioButton();
            this.rdTriangle_iso = new System.Windows.Forms.RadioButton();
            this.rdTriangle_Rect = new System.Windows.Forms.RadioButton();
            this.rdElipses = new System.Windows.Forms.RadioButton();
            this.rdCercle = new System.Windows.Forms.RadioButton();
            this.rdRectangle = new System.Windows.Forms.RadioButton();
            this.rdQuadrat = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSi = new System.Windows.Forms.CheckBox();
            this.chkNo = new System.Windows.Forms.CheckBox();
            this.gbGrup.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.Color.DarkRed;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.ForeColor = System.Drawing.Color.White;
            this.btClose.Location = new System.Drawing.Point(274, 428);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(113, 32);
            this.btClose.TabIndex = 14;
            this.btClose.Text = "Tancar";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btOk
            // 
            this.btOk.BackColor = System.Drawing.Color.OliveDrab;
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.ForeColor = System.Drawing.Color.White;
            this.btOk.Location = new System.Drawing.Point(140, 428);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(113, 32);
            this.btOk.TabIndex = 13;
            this.btOk.Text = "Inserir";
            this.btOk.UseVisualStyleBackColor = false;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // lbComentari
            // 
            this.lbComentari.BackColor = System.Drawing.Color.LightGray;
            this.lbComentari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbComentari.Location = new System.Drawing.Point(12, 360);
            this.lbComentari.Name = "lbComentari";
            this.lbComentari.Padding = new System.Windows.Forms.Padding(2);
            this.lbComentari.Size = new System.Drawing.Size(488, 53);
            this.lbComentari.TabIndex = 12;
            this.lbComentari.Text = "La resta de dades es generaran aleatòriament";
            this.lbComentari.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(192, 16);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(308, 22);
            this.tbNom.TabIndex = 11;
            // 
            // lbNom
            // 
            this.lbNom.BackColor = System.Drawing.Color.LightGray;
            this.lbNom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNom.Location = new System.Drawing.Point(12, 15);
            this.lbNom.Name = "lbNom";
            this.lbNom.Padding = new System.Windows.Forms.Padding(2);
            this.lbNom.Size = new System.Drawing.Size(141, 25);
            this.lbNom.TabIndex = 10;
            this.lbNom.Text = "Introdueix un nom";
            this.lbNom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbGrup
            // 
            this.gbGrup.Controls.Add(this.rdOctogons);
            this.gbGrup.Controls.Add(this.rdHexagons);
            this.gbGrup.Controls.Add(this.rdPentagons);
            this.gbGrup.Controls.Add(this.rdRombes);
            this.gbGrup.Controls.Add(this.rdTriangle_iso);
            this.gbGrup.Controls.Add(this.rdTriangle_Rect);
            this.gbGrup.Controls.Add(this.rdElipses);
            this.gbGrup.Controls.Add(this.rdCercle);
            this.gbGrup.Controls.Add(this.rdRectangle);
            this.gbGrup.Controls.Add(this.rdQuadrat);
            this.gbGrup.Location = new System.Drawing.Point(12, 109);
            this.gbGrup.Margin = new System.Windows.Forms.Padding(4);
            this.gbGrup.Name = "gbGrup";
            this.gbGrup.Padding = new System.Windows.Forms.Padding(4);
            this.gbGrup.Size = new System.Drawing.Size(488, 237);
            this.gbGrup.TabIndex = 9;
            this.gbGrup.TabStop = false;
            this.gbGrup.Text = " Tria un grup de poligon";
            // 
            // rdOctogons
            // 
            this.rdOctogons.AutoSize = true;
            this.rdOctogons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rdOctogons.Location = new System.Drawing.Point(354, 196);
            this.rdOctogons.Margin = new System.Windows.Forms.Padding(4);
            this.rdOctogons.Name = "rdOctogons";
            this.rdOctogons.Size = new System.Drawing.Size(86, 20);
            this.rdOctogons.TabIndex = 9;
            this.rdOctogons.Text = "Octògons";
            this.rdOctogons.UseVisualStyleBackColor = true;
            // 
            // rdHexagons
            // 
            this.rdHexagons.AutoSize = true;
            this.rdHexagons.Location = new System.Drawing.Point(354, 156);
            this.rdHexagons.Margin = new System.Windows.Forms.Padding(4);
            this.rdHexagons.Name = "rdHexagons";
            this.rdHexagons.Size = new System.Drawing.Size(90, 20);
            this.rdHexagons.TabIndex = 8;
            this.rdHexagons.Text = "Hexàgons";
            this.rdHexagons.UseVisualStyleBackColor = true;
            // 
            // rdPentagons
            // 
            this.rdPentagons.AutoSize = true;
            this.rdPentagons.Location = new System.Drawing.Point(354, 117);
            this.rdPentagons.Margin = new System.Windows.Forms.Padding(4);
            this.rdPentagons.Name = "rdPentagons";
            this.rdPentagons.Size = new System.Drawing.Size(93, 20);
            this.rdPentagons.TabIndex = 7;
            this.rdPentagons.Text = "Pentàgons";
            this.rdPentagons.UseVisualStyleBackColor = true;
            // 
            // rdRombes
            // 
            this.rdRombes.AutoSize = true;
            this.rdRombes.Location = new System.Drawing.Point(354, 79);
            this.rdRombes.Margin = new System.Windows.Forms.Padding(4);
            this.rdRombes.Name = "rdRombes";
            this.rdRombes.Size = new System.Drawing.Size(80, 20);
            this.rdRombes.TabIndex = 6;
            this.rdRombes.Text = "Rombes";
            this.rdRombes.UseVisualStyleBackColor = true;
            // 
            // rdTriangle_iso
            // 
            this.rdTriangle_iso.AutoSize = true;
            this.rdTriangle_iso.Location = new System.Drawing.Point(354, 42);
            this.rdTriangle_iso.Margin = new System.Windows.Forms.Padding(4);
            this.rdTriangle_iso.Name = "rdTriangle_iso";
            this.rdTriangle_iso.Size = new System.Drawing.Size(146, 20);
            this.rdTriangle_iso.TabIndex = 5;
            this.rdTriangle_iso.Text = "Triangles isòsceles";
            this.rdTriangle_iso.UseVisualStyleBackColor = true;
            // 
            // rdTriangle_Rect
            // 
            this.rdTriangle_Rect.AutoSize = true;
            this.rdTriangle_Rect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rdTriangle_Rect.Location = new System.Drawing.Point(29, 196);
            this.rdTriangle_Rect.Margin = new System.Windows.Forms.Padding(4);
            this.rdTriangle_Rect.Name = "rdTriangle_Rect";
            this.rdTriangle_Rect.Size = new System.Drawing.Size(154, 20);
            this.rdTriangle_Rect.TabIndex = 4;
            this.rdTriangle_Rect.Text = "Triangles rectangles ";
            this.rdTriangle_Rect.UseVisualStyleBackColor = true;
            // 
            // rdElipses
            // 
            this.rdElipses.AutoSize = true;
            this.rdElipses.Location = new System.Drawing.Point(29, 156);
            this.rdElipses.Margin = new System.Windows.Forms.Padding(4);
            this.rdElipses.Name = "rdElipses";
            this.rdElipses.Size = new System.Drawing.Size(73, 20);
            this.rdElipses.TabIndex = 3;
            this.rdElipses.Text = "Elipses";
            this.rdElipses.UseVisualStyleBackColor = true;
            // 
            // rdCercle
            // 
            this.rdCercle.AutoSize = true;
            this.rdCercle.Location = new System.Drawing.Point(29, 117);
            this.rdCercle.Margin = new System.Windows.Forms.Padding(4);
            this.rdCercle.Name = "rdCercle";
            this.rdCercle.Size = new System.Drawing.Size(74, 20);
            this.rdCercle.TabIndex = 2;
            this.rdCercle.Tag = "";
            this.rdCercle.Text = "Cercles";
            this.rdCercle.UseVisualStyleBackColor = true;
            // 
            // rdRectangle
            // 
            this.rdRectangle.AutoSize = true;
            this.rdRectangle.Location = new System.Drawing.Point(29, 79);
            this.rdRectangle.Margin = new System.Windows.Forms.Padding(4);
            this.rdRectangle.Name = "rdRectangle";
            this.rdRectangle.Size = new System.Drawing.Size(97, 20);
            this.rdRectangle.TabIndex = 1;
            this.rdRectangle.Tag = "";
            this.rdRectangle.Text = "Rectangles";
            this.rdRectangle.UseVisualStyleBackColor = true;
            // 
            // rdQuadrat
            // 
            this.rdQuadrat.AutoSize = true;
            this.rdQuadrat.Checked = true;
            this.rdQuadrat.Location = new System.Drawing.Point(29, 42);
            this.rdQuadrat.Margin = new System.Windows.Forms.Padding(4);
            this.rdQuadrat.Name = "rdQuadrat";
            this.rdQuadrat.Size = new System.Drawing.Size(83, 20);
            this.rdQuadrat.TabIndex = 0;
            this.rdQuadrat.TabStop = true;
            this.rdQuadrat.Tag = "";
            this.rdQuadrat.Text = "Quadrats";
            this.rdQuadrat.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2);
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Vols color de fons";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkSi
            // 
            this.chkSi.AutoSize = true;
            this.chkSi.Location = new System.Drawing.Point(192, 61);
            this.chkSi.Name = "chkSi";
            this.chkSi.Size = new System.Drawing.Size(41, 20);
            this.chkSi.TabIndex = 16;
            this.chkSi.Text = "Si";
            this.chkSi.UseVisualStyleBackColor = true;
            // 
            // chkNo
            // 
            this.chkNo.AutoSize = true;
            this.chkNo.Location = new System.Drawing.Point(303, 62);
            this.chkNo.Name = "chkNo";
            this.chkNo.Size = new System.Drawing.Size(47, 20);
            this.chkNo.TabIndex = 17;
            this.chkNo.Text = "No";
            this.chkNo.UseVisualStyleBackColor = true;
            // 
            // FrmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 476);
            this.Controls.Add(this.chkNo);
            this.Controls.Add(this.chkSi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.lbComentari);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.lbNom);
            this.Controls.Add(this.gbGrup);
            this.Name = "FrmAdd";
            this.Text = "FrmAdd";
            this.gbGrup.ResumeLayout(false);
            this.gbGrup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Label lbComentari;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.Label lbNom;
        private System.Windows.Forms.GroupBox gbGrup;
        private System.Windows.Forms.RadioButton rdOctogons;
        private System.Windows.Forms.RadioButton rdHexagons;
        private System.Windows.Forms.RadioButton rdPentagons;
        private System.Windows.Forms.RadioButton rdRombes;
        private System.Windows.Forms.RadioButton rdTriangle_iso;
        private System.Windows.Forms.RadioButton rdTriangle_Rect;
        private System.Windows.Forms.RadioButton rdElipses;
        private System.Windows.Forms.RadioButton rdCercle;
        private System.Windows.Forms.RadioButton rdRectangle;
        private System.Windows.Forms.RadioButton rdQuadrat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSi;
        private System.Windows.Forms.CheckBox chkNo;
    }
}