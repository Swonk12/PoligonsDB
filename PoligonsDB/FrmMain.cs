        using PoligonsDB.CLASSES;
        using PoligonsDB.CLASSES.SUBCLASSES;
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

        namespace PoligonsDB
        {
            public partial class FrmMain : Form
            {
                ClBd bd { get; set; }
                DataSet dset { get; set; } = new DataSet();
                //String cadenaConnexio = "Data Source=Vidallaptop;Initial Catalog=PoligonsBD;Integrated Security=True";
                String cadenaConnexio = @"AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAXVOCHU/ie0KxSzCJEKv98gQAAAACAAAAAAAQZgAAAAEAACAAAADpCJNnkl+FmczvjlLYXOviXot5VV9Ybw6wX3BgOwDIkwAAAAAOgAAAAAIAACAAAADTd4YMDdrbpTn+v2ZDXP+Hq08mUl8gvhcqKyrGUr+iklAAAAD6Wy1d9Y15hFDI9Bztl1VteFUpM4CPQVjoMXML3VWi5YsITj486ycxOHLLfImQU1NMuu3aPGeVcnOi1LmCDrL2TTjmKfDqYklZaCmgSPd0QEAAAABt5kuUZ2xLPCwceQj1Pce5oktjU0UCXs9uZsbfvPVYWOncW/JPAriNfGFzET/4EPXj8Ka1KnjprxZNSbY6tqOu";

                // Listas
                List<ClPoligons> llPoligons { get; set; } = new List<ClPoligons>();
                //List<ClQuadrats> llQuadrats { get; set; } = new List<ClQuadrats>();
                //List<ClRectangles> llRectangles { get; set; } = new List<ClRectangles>();
                //List<ClCercles> llCercles { get; set; } = new List<ClCercles>();
                //List<ClElipses> llElipses { get; set; } = new List<ClElipses>();
                //List<ClTriangles_Rectangles> llTriangles_Rectangles { get; set; } = new List<ClTriangles_Rectangles>();
                //List<ClTriangles_Isosceles> llTriangles_Isosceles { get; set; } = new List<ClTriangles_Isosceles>();
                //List<ClRombes> llRombes { get; set; } = new List<ClRombes>();
                List<ClPentagons> llPentagons { get; set; } = new List<ClPentagons>();
                //List<ClHexagons> llHexagons { get; set; } = new List<ClHexagons>();
                //List<ClOctagons> llOctagons { get; set; } = new List<ClOctagons>();


                public FrmMain()
                {
                    InitializeComponent();
                }

                private void FrmMain_Load(object sender, EventArgs e)
                {
                    bd = new ClBd();
                    bd.cadenaConnexio = cadenaConnexio;
                    if (bd.testConnexio())
                    {
                        cbPoligon.SelectedIndex = 0;
                        getPoligons(true);
                        customDgrid();
                    }
                    else
                    {
                        MessageBox.Show("No em puc connectar a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }

                private void getPoligons(Boolean xbTots)
                {
                    String xsql = "";

                    if (xbTots)
                    {
                        xsql = "SELECT \r\n    P.id_Poligon, \r\n    P.tipus,\r\n  COALESCE(Q.nom, R.nom, C.nom, E.nom, TR.nom, TI.nom, Ro.nom, Pe.nom, He.nom, Oc.nom) AS Nombre , COALESCE(Q.area, R.area, C.area, E.area, TR.area, TI.area, Ro.area, Pe.area, He.area, Oc.area) AS area,\r\n    COALESCE(Q.perimetre, R.perimetre, C.perimetre, E.perimetre, TR.perimetre, TI.perimetre, Ro.perimetre, Pe.perimetre, He.perimetre, Oc.perimetre) AS perimetre,\r\n    COALESCE(Q.color, R.color, C.color, E.color, TR.color, TI.color, Ro.color, Pe.color, He.color, Oc.color) AS color\r\nFROM Poligons P\r\nLEFT JOIN Quadrats Q ON P.id_Poligon = Q.id_Poligon\r\nLEFT JOIN Rectangles R ON P.id_Poligon = R.id_Poligon\r\nLEFT JOIN Cercles C ON P.id_Poligon = C.id_Poligon\r\nLEFT JOIN Elipses E ON P.id_Poligon = E.id_Poligon\r\nLEFT JOIN Triangles_Rectangles TR ON P.id_Poligon = TR.id_Poligon\r\nLEFT JOIN Triangles_Isosceles TI ON P.id_Poligon = TI.id_Poligon\r\nLEFT JOIN Rombes Ro ON P.id_Poligon = Ro.id_Poligon\r\nLEFT JOIN Pentagons Pe ON P.id_Poligon = Pe.id_Poligon\r\nLEFT JOIN Hexagons He ON P.id_Poligon = He.id_Poligon\r\nLEFT JOIN Octagons Oc ON P.id_Poligon = Oc.id_Poligon;\r\n";
                    }
                    else
                    {
                        xsql = $"SELECT * FROM Poligons JOIN {cbPoligon.SelectedItem.ToString()} ON Poligons.id_Poligon = {cbPoligon.SelectedItem.ToString()}.id_Poligon ORDER BY 2 ";
                    }

                    bd.getDades(xsql, dset);
                    dgPoligons.DataSource = dset.Tables[0];
                    if (xbTots == false)
                    {
                        dgPoligons.Columns.Remove("id_Poligon1");
                    }

                    omplirLlistes();
                }

                private void omplirLlistes()
                {
                    int id;
                    ClPoligons p = null;

                    iniLlistes();
                    foreach (DataGridViewRow fila in dgPoligons.Rows)
                    {

                        id = (int)fila.Cells["id_Poligon"].Value;
                        switch (fila.Cells["tipus"].Value.ToString())
                        {
                            case "Quadrats":
                                //p = new ClQuadrat(bd, id);
                                //llQuadrats.Add((ClQuadrat)p);
                                break;
                            case "Rectangles":
                                //p = new ClRectangle(bd, id);
                                //llRectangles.Add((ClRectangle)p);
                                break;
                            case "Cercles":
                                //p = new ClCercle(bd, id);
                                //llCercles.Add((ClCercle)p);
                                break;
                            case "Elipses":
                                //p = new ClElipse(bd, id);
                                //llElipses.Add((ClElipse)p);
                                break;
                            case "Triangles_Rectangles":
                                //p = new ClTriangleRectangle(bd, id);
                                //llTriangles_Rectangles.Add((ClTriangleRectangle)p);
                                break;
                            case "Triangles_Isosceles":
                                //p = new ClTriangleIso(bd, id);
                                //llTriangles_Isosceles.Add((ClTriangleIso)p);
                                break;
                            case "Rombes":
                                //p = new ClRombe(bd, id);
                                //llRombes.Add((ClRombe)p);
                                break;
                            case "Pentagon":
                                p = new ClPentagons(bd, id);
                                llPentagons.Add((ClPentagons)p);
                                break;
                            case "Hexagons":
                                //p = new ClHexagon(bd, id);
                                //llHexagons.Add((ClHexagon)p);
                                break;
                            case "Octagons":
                                //p = new ClOctagon(bd, id);
                                //llOctagons.Add((ClOctagon)p);
                                break;

                        }
                        if (fila.Cells["tipus"].Value.ToString() == "Pentagon")
                        {
                            p.id_Poligon = id;
                            p.tipus = fila.Cells["tipus"].Value.ToString();
                            p.area = (double)fila.Cells["area"].Value;
                            p.perimetre = (double)fila.Cells["perimetre"].Value;
                            p.color = (int)fila.Cells["color"].Value;
                            p.getPoligons(bd, id);
                            llPoligons.Add(p);
                        }

                    }
                }

                private void customDgrid()
                {
                    dgPoligons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgPoligons.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgPoligons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgPoligons.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                    dgPoligons.Columns["id_Poligon"].Visible = false;
                    dgPoligons.Columns["tipus"].HeaderText = "Poligon";
                    dgPoligons.Columns["area"].HeaderText = "Area";
                    dgPoligons.Columns["area"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgPoligons.Columns["perimetre"].HeaderText = "Perimetre";
                    dgPoligons.Columns["perimetre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgPoligons.Columns["color"].HeaderText = "ColorFons";

                }

                private void cbPoligon_SelectedIndexChanged(object sender, EventArgs e)
                {
                    getPoligons(cbPoligon.SelectedIndex == 0);
                    customDgrid();
                    if (llPoligons.Count > 0 && dgPoligons.SelectedRows.Count > 0)
                    {
                        mostrarDades(dgPoligons.SelectedRows[0].Index);
                    }
                }

                private void iniLlistes()
                {
                    llPoligons.Clear();
                    //llQuadrats.Clear();
                    //llRectangles.Clear();
                    //llCercles.Clear();
                    //llElipses.Clear();
                    //llTriangles_Rectangles.Clear();
                    //llTriangles_Isosceles.Clear();
                    //llRombes.Clear();
                    llPentagons.Clear();
                    //llHexagons.Clear();
                    //llOctagons.Clear();
                }

                private void dgPoligons_SelectionChanged(object sender, EventArgs e)
                {

                    if (llPoligons.Count > 0 && dgPoligons.SelectedRows.Count > 0)
                    {
                        mostrarDades(dgPoligons.SelectedRows[0].Index);
                    }
                }

                private void mostrarDades(int xfila)
                {
                    ClPoligons p;

                    if (xfila >= 0 && dgPoligons.SelectedRows.Count > 0)
                    {
                        p = llPoligons[xfila];
                        tbInfo.Text = p.dadesComunes() + p.dadesPoligon();
                        this.Invalidate();
                    }
                }

                private void pbAdd_Click(object sender, EventArgs e)
                {
                    //FrmAdd fAdd = new FrmAdd(bd);

                    //fAdd.ShowDialog();
                    //fAdd.Dispose();
                    //fAdd = null;
                    getPoligons(cbPoligon.SelectedIndex == 0);
                }

                private void FrmMain_Paint(object sender, PaintEventArgs e)
                {
                    foreach (DataGridViewRow fila in dgPoligons.Rows)
                    {
                        switch (fila.Cells["tipus"].Value.ToString())
                        {
                            case "Quadrats":
                                //p = new ClQuadrat(bd, id);
                                //llQuadrats.Add((ClQuadrat)p);
                                break;
                            case "Rectangles":
                                //p = new ClRectangle(bd, id);
                                //llRectangles.Add((ClRectangle)p);
                                break;
                            case "Cercles":
                                //p = new ClCercle(bd, id);
                                //llCercles.Add((ClCercle)p);
                                break;
                            case "Elipses":
                                //p = new ClElipse(bd, id);
                                //llElipses.Add((ClElipse)p);
                                break;
                            case "Triangles_Rectangles":
                                //p = new ClTriangleRectangle(bd, id);
                                //llTriangles_Rectangles.Add((ClTriangleRectangle)p);
                                break;
                            case "Triangles_Isosceles":
                                //p = new ClTriangleIso(bd, id);
                                //llTriangles_Isosceles.Add((ClTriangleIso)p);
                                break;
                            case "Rombes":
                                //p = new ClRombe(bd, id);
                                //llRombes.Add((ClRombe)p);
                                break;
                            case "Pentagon":
                                int xCentro = tbInfo.Left + tbInfo.Width / 2;
                                int yCentro = tbInfo.Bottom + 50;

                                string info = tbInfo.Text;
                                string[] partes = info.Split(':');
                                string info2 = partes[5].Replace("\r\nApotema", "");
                                int lado = int.Parse(info2.Trim());

                                string info2Color = partes[3].Replace("\r\nNom", "");

                                // Calcular los puntos del pentágono
                                Point[] vPuntsPentagon = CalcularPuntosPentagono(xCentro, yCentro, lado);
                                Graphics g = e.Graphics;
                                if (info2Color.Trim() == "TRUE")
                                {
                                    Brush brush = new SolidBrush(Color.Blue);
                                    g.FillPolygon(brush, vPuntsPentagon);
                                    g.DrawPolygon(new Pen(Color.Black, 2), vPuntsPentagon);
                                }else
                                {
                                    Pen pen = new Pen(Color.Black, 2);
                                    g.DrawPolygon(pen, vPuntsPentagon);
                                }

                                g.DrawPolygon(new Pen(Color.Black, 2), vPuntsPentagon);

                                break;
                            case "Hexagons":
                                //p = new ClHexagon(bd, id);
                                //llHexagons.Add((ClHexagon)p);
                                break;
                            case "Octagons":
                                //p = new ClOctagon(bd, id);
                                //llOctagons.Add((ClOctagon)p);
                                break;
                        }
                    }
                }

                Point[] CalcularPuntosPentagono(int xCentro, int yCentro, int lado)
                {
                    Point[] puntos = new Point[5];
                    double anguloInicial = -Math.PI / 2; // Inicia en la parte superior
                    double anguloIncremento = 2 * Math.PI / 5; // Ángulo entre cada vértice

                    for (int i = 0; i < 5; i++)
                    {
                        double x = xCentro + (lado / (2 * Math.Sin(Math.PI / 5))) * Math.Cos(anguloInicial + i * anguloIncremento);
                        double y = yCentro + (lado / (2 * Math.Sin(Math.PI / 5))) * Math.Sin(anguloInicial + i * anguloIncremento);
                        puntos[i] = new Point((int)x, (int)y);
                    }

                    return puntos;
                }
            }
        }
