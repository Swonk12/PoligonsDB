        using PoligonsDB.CLASSES;
        using PoligonsDB.CLASSES.SUBCLASSES;
using PoligonsDB.CLASSES.SUBCLASSES.PoligonsDB.CLASSES.SUBCLASSES;
using System;
using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
        using System.Windows.Forms;
        using static PoligonsDB.CLASSES.SUBCLASSES.ClCercle;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

        namespace PoligonsDB
        {
            public partial class FrmMain : Form
            {
                ClBd bd { get; set; }
                DataSet dset { get; set; } = new DataSet();
                //String cadenaConnexio = "Data Source=Vidallaptop;Initial Catalog=PoligonsBD;Integrated Security=True";
                String cadenaConnexio = @"AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAKZt0PpACLEye0nls4yvFgAQAAAACAAAAAAAQZgAAAAEAACAAAACfiYECuEAFyofHsBt4jPIkK+ghmMpQlVHxWuo9hgxnGwAAAAAOgAAAAAIAACAAAADFlKTjjyXotH2DaVOOQhuGiInjKxNk7znYQ1db7siYSVAAAABfOk0PUD2QTWtnsyKF2ju9IWDmOJZYufQtfZCisX1dfuyZTpYOPg2VJX2LYu4cs4kJD+EAhDRKPxYLT6nZsM2rSXAs0lGJo7ie3Q1IXia0aEAAAAAGiZGSqbHu+f1xTRzK6f/OikdZy/v2yR6zI8Cc3dBpFN8Dlun+VXfMGwzGKStQYaKLllbbU0QdFf5KVuEW7WKt";

                // Listas
                List<ClPoligons> llPoligons { get; set; } = new List<ClPoligons>();
                List<ClQuadrat> llQuadrats { get; set; } = new List<ClQuadrat>();
                List<ClRectangle> llRectangles { get; set; } = new List<ClRectangle>();
                List<ClCercles> llCercles { get; set; } = new List<ClCercles>();
                List<ClElipses> llElipses { get; set; } = new List<ClElipses>();
                List<ClTriangles_Rectangles> llTriangles_Rectangles { get; set; } = new List<ClTriangles_Rectangles>();
                List<ClTriangles_Isosceles> llTriangles_Isosceles { get; set; } = new List<ClTriangles_Isosceles>();
                List<ClRombes> llRombes { get; set; } = new List<ClRombes>();
                List<ClPentagons> llPentagons { get; set; } = new List<ClPentagons>();
                List<ClHexagons> llHexagons { get; set; } = new List<ClHexagons>();
                List<ClOctagons> llOctagons { get; set; } = new List<ClOctagons>();


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
                            case "Quadrat":
                                p = new ClQuadrat(bd, id);
                                llQuadrats.Add((ClQuadrat)p);
                                break;
                            case "Rectangles":
                                p = new ClRectangle(bd, id);
                                llRectangles.Add((ClRectangle)p);
                                break;
                            case "Cercles":
                                p = new ClCercles(bd, id);
                                llCercles.Add((ClCercles)p);
                                break;
                            case "Elipses":
                                p = new ClElipses(bd, id);
                                llElipses.Add((ClElipses)p);
                                break;
                            case "Triangles_Rectangles":
                                //p = new ClTriangles_Rectangles(bd, id);
                                //llTriangles_Rectangles.Add((ClTriangles_Rectangles)p);
                                break;
                            case "Triangles_Isosceles":
                                p = new ClTriangles_Isosceles(bd, id);
                                llTriangles_Isosceles.Add((ClTriangles_Isosceles)p);
                                break;
                            case "Rombes":
                                p = new ClRombes(bd, id);
                                llRombes.Add((ClRombes)p);
                                break;
                            case "Pentagon":
                                p = new ClPentagons(bd, id);
                                llPentagons.Add((ClPentagons)p);
                                break;
                            case "Hexagon":
                                p = new ClHexagons(bd, id);
                                llHexagons.Add((ClHexagons)p);
                                break;
                            case "Octagon":
                                p = new ClOctagons(bd, id);
                                llOctagons.Add((ClOctagons)p);
                                break;

                        }
                        if (fila.Cells["tipus"].Value.ToString() == "Quadrat" || fila.Cells["tipus"].Value.ToString() == "Pentagon" || fila.Cells["tipus"].Value.ToString() == "Hexagon" || fila.Cells["tipus"].Value.ToString() == "Octagon")
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
                    llQuadrats.Clear();
                    llRectangles.Clear();
                    llCercles.Clear();
                    llElipses.Clear();
                    //llTriangles_Rectangles.Clear();
                    llTriangles_Isosceles.Clear();
                    llRombes.Clear();
                    llPentagons.Clear();
                    llHexagons.Clear();
                    llOctagons.Clear();
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

                private void FrmMain_Paint(object sender, PaintEventArgs e)
                {
                    foreach (DataGridViewRow fila in dgPoligons.Rows)
                    {
                        int xCentro = tbInfo.Left + tbInfo.Width / 2;
                        int yCentro = tbInfo.Bottom + 50;
                        int lado = 0;
                        string info, info2, info2Color;
                        string[] partes;
                        Graphics g = e.Graphics;
                        switch (fila.Cells["tipus"].Value.ToString())
                        {
                            case "Quadrat":
                                info = tbInfo.Text;
                                partes = info.Split(':');
                                string ladoStrig = "";
                                ladoStrig = partes[5].Replace("\r\nArea", "");
                                lado = int.Parse(ladoStrig.Trim());

                                string colorStrig = "";
                                colorStrig = partes[3].Replace("\r\nNom", "");

                                // Crear los objetos de dibujo
                                Pen p = new Pen(Color.Black);
                                Rectangle r = new Rectangle(0, 0, lado, lado);

                                if (colorStrig == "TRUE")
                                {
                                    // PINTAR CUADRADO RELLENO DE AZUL
                                    Brush b = new SolidBrush(Color.Blue);
                                    g.FillRectangle(b, r);
                                }
                                else
                                {
                                    // DIBUJAR SOLO EL CONTORNO
                                    g.DrawRectangle(p, r);
                                }
                                break;

                            case "Rectangle":
                                info = tbInfo.Text;
                                partes = info.Split(':');
                                string anchoString = "";
                                string altoString = "";

                                // Extraer valores de ancho y alto
                                anchoString = partes[5].Replace("\r\nAltura", "").Trim();
                                altoString = partes[7].Replace("\r\nArea", "").Trim();

                                int ancho = int.Parse(anchoString);
                                int alto = int.Parse(altoString);

                                colorStrig = partes[3].Replace("\r\nNom", "").Trim();

                                Pen penR = new Pen(Color.Black);
                                Rectangle rect = new Rectangle(xCentro - (ancho / 2), yCentro - (alto / 2), ancho, alto);

                                if (colorStrig == "TRUE")
                                {
                                    // Pintar rectángulo relleno
                                    Brush brush = new SolidBrush(Color.Blue);
                                    g.FillRectangle(brush, rect);
                                }
                                else
                                {
                                    // Dibujar sin relleno
                                    g.DrawRectangle(penR, rect);
                                }
                                break;

                            case "Cercles":
                                info = tbInfo.Text;
                                partes = info.Split(':');
                                string radioString = "";

                                // Extraer el valor del radio
                                radioString = partes[5].Replace("\r\nArea", "").Trim();
                                int radio = int.Parse(radioString);

                                colorStrig = partes[3].Replace("\r\nNom", "").Trim();

                                Pen penC = new Pen(Color.Black);
                                Rectangle circle = new Rectangle(xCentro - radio, yCentro - radio, radio * 2, radio * 2);

                                if (colorStrig == "TRUE")
                                {
                                    // Pintar círculo relleno
                                    Brush brushC = new SolidBrush(Color.Red);
                                    g.FillEllipse(brushC, circle);
                                }
                                else
                                {
                                    // Dibujar sin relleno
                                    g.DrawEllipse(penC, circle);
                                }
                                break;

                            case "Elipse":
                                info = tbInfo.Text;
                                partes = info.Split(':');
                                string anchoStringE = "";
                                string altoStringE = "";

                                // Extraer valores de ancho y alto de la elipse
                                anchoStringE = partes[5].Replace("\r\nAltura", "").Trim();
                                altoStringE = partes[7].Replace("\r\nArea", "").Trim();

                                int anchoE = int.Parse(anchoStringE);
                                int altoE = int.Parse(altoStringE);

                                colorStrig = partes[3].Replace("\r\nNom", "").Trim();

                                Pen penE = new Pen(Color.Black);
                                Rectangle ellipseRect = new Rectangle(xCentro - (anchoE / 2), yCentro - (altoE / 2), anchoE, altoE);

                                if (colorStrig == "TRUE")
                                {
                                    // Pintar elipse rellena
                                    Brush brushE = new SolidBrush(Color.Green);
                                    g.FillEllipse(brushE, ellipseRect);
                                }
                                else
                                {
                                    // Dibujar elipse sin relleno
                                    g.DrawEllipse(penE, ellipseRect);
                                }
                                break;

                            case "Triangles_Rectangles":
                                //p = new ClTriangleRectangle(bd, id);
                                //llTriangles_Rectangles.Add((ClTriangleRectangle)p);
                                break;
                            case "Triangles_Isosceles":
                                info = tbInfo.Text;
                                partes = info.Split(':');

                                string baseString = partes[5].Replace("\r\nAltura", "").Trim();
                                string alturaString = partes[7].Replace("\r\nArea", "").Trim();
                                string colorString = partes[3].Replace("\r\nNom", "").Trim();

                                if (!int.TryParse(baseString, out int baseT) || !int.TryParse(alturaString, out int alturaT))
                                    break;

                                // Calcular los puntos del triángulo isósceles
                                Point p1 = new Point(xCentro, yCentro - (alturaT / 2)); // Vértice superior
                                Point p2 = new Point(xCentro - (baseT / 2), yCentro + (alturaT / 2)); // Esquina inferior izquierda
                                Point p3 = new Point(xCentro + (baseT / 2), yCentro + (alturaT / 2)); // Esquina inferior derecha

                                Point[] puntosTriangulo = { p1, p2, p3 };

                                Pen penT = new Pen(Color.Black);

                                if (colorString == "TRUE")
                                {
                                    // Pintar triángulo relleno
                                    Brush brushT = new SolidBrush(Color.Orange);
                                    g.FillPolygon(brushT, puntosTriangulo);
                                }
                                else
                                {
                                    // Dibujar sin relleno
                                    g.DrawPolygon(penT, puntosTriangulo);
                                }
                                break;

                            case "Rombes":
                                info = tbInfo.Text;
                                partes = info.Split(':');

                                if (partes.Length < 8) // Verificar que haya suficientes partes
                                    break;

                                string diagonalMayorString = partes[5].Replace("\r\nDiagonalMenor", "").Trim();
                                string diagonalMenorString = partes[7].Replace("\r\nArea", "").Trim();
                                string colorString2 = partes[3].Replace("\r\nNom", "").Trim();

                                if (!int.TryParse(diagonalMayorString, out int diagonalMayor) || !int.TryParse(diagonalMenorString, out int diagonalMenor))
                                    break;

                                // Calcular los vértices del rombo
                                Point p1r = new Point(xCentro, yCentro - (diagonalMayor / 2)); // Vértice superior
                                Point p2r = new Point(xCentro + (diagonalMenor / 2), yCentro); // Vértice derecho
                                Point p3r = new Point(xCentro, yCentro + (diagonalMayor / 2)); // Vértice inferior
                                Point p4 = new Point(xCentro - (diagonalMenor / 2), yCentro); // Vértice izquierdo

                                Point[] puntosRombo = { p1r, p2r, p3r, p4 };

                                Pen penRo = new Pen(Color.Black);

                                if (colorString2 == "TRUE")
                                {
                                    // Pintar rombo relleno
                                    Brush brushR = new SolidBrush(Color.Purple);
                                    g.FillPolygon(brushR, puntosRombo);
                                }
                                else
                                {
                                    // Dibujar sin relleno
                                    g.DrawPolygon(penRo, puntosRombo);
                                }
                                break;

                            case "Pentagon":
                                info = tbInfo.Text.Trim();
                                Match match = Regex.Match(info, @"Lado\s:\s(\d+)");
                                lado = int.Parse(match.Groups[1].Value);
                                partes = info.Split(':');
                                colorStrig = "";
                                info2Color = partes[3].Replace("\r\nNom", "").Trim();

                                // Calcular los puntos del pentágono
                                Point[] vPuntsPentagon = CalcularPuntosPentagono(xCentro, yCentro, lado);
                                if (info2Color.Trim() == "TRUE")
                                {
                                    Brush brush = new SolidBrush(Color.Blue);
                                    g.FillPolygon(brush, vPuntsPentagon);
                                    g.DrawPolygon(new Pen(Color.Black, 2), vPuntsPentagon);
                                }
                                else
                                {
                                    Pen pen = new Pen(Color.Black, 2);
                                    g.DrawPolygon(pen, vPuntsPentagon);
                                }

                                g.DrawPolygon(new Pen(Color.Black, 2), vPuntsPentagon);
                                break;

                            case "Hexagons":
                                info = tbInfo.Text;
                                partes = info.Split(':');
                                info2 = partes[5].Replace("\r\nApotema", "");
                                lado = int.Parse(info2.Trim());

                                info2Color = partes[3].Replace("\r\nNom", "");
                                Point[] vPuntsHexagono = CalcularPuntosHexagono(xCentro, yCentro, lado);
                                
                                if (info2Color.Trim() == "TRUE")
                                {
                                    Brush brush = new SolidBrush(Color.Blue);
                                    g.FillPolygon(brush, vPuntsHexagono);
                                    g.DrawPolygon(new Pen(Color.Black, 2), vPuntsHexagono);
                                }
                                else 
                                { 
                                    Pen pen = new Pen(Color.Black, 2);
                                    g.DrawPolygon(pen, vPuntsHexagono);
                                }
                                break;

                            case "Octagons":
                                info = tbInfo.Text;
                                partes = info.Split(':');
                                info2 = partes[5].Replace("\r\nApotema", "");
                                lado = int.Parse(info2.Trim());

                                info2Color = partes[3].Replace("\r\nNom", "");
                                Point[] vPuntsOctagono = CalcularPuntosOctagono(xCentro, yCentro, lado);
                                
                                if (info2Color.Trim() == "TRUE")
                                {
                                    Brush brush = new SolidBrush(Color.Blue);
                                    g.FillPolygon(brush, vPuntsOctagono);
                                    g.DrawPolygon(new Pen(Color.Black, 2), vPuntsOctagono);
                                }
                                else 
                                { 
                                    Pen pen = new Pen(Color.Black, 2);
                                    g.DrawPolygon(pen, vPuntsOctagono);
                                }
                                break;
                        }
                    }
                }

                Point[] CalcularPuntosPentagono(int xCentro, int yCentro, int lado)
                {
                    Point[] puntos = new Point[5];
                    double anguloInicial = -Math.PI / 2; 
                    double anguloIncremento = 2 * Math.PI / 5; 

                    for (int i = 0; i < 5; i++)
                    {
                        double x = xCentro + (lado / (2 * Math.Sin(Math.PI / 5))) * Math.Cos(anguloInicial + i * anguloIncremento);
                        double y = yCentro + (lado / (2 * Math.Sin(Math.PI / 5))) * Math.Sin(anguloInicial + i * anguloIncremento);
                        puntos[i] = new Point((int)x, (int)y);
                    }

                    return puntos;
                }

                Point[] CalcularPuntosHexagono(int xCentro, int yCentro, int lado)
                {
                    Point[] puntos = new Point[6];
                    double anguloInicial = -Math.PI / 2; 
                    double anguloIncremento = 2 * Math.PI / 6;

                    for (int i = 0; i < 6; i++)
                    {
                        double x = xCentro + (lado * Math.Cos(anguloInicial + i * anguloIncremento));
                        double y = yCentro + (lado * Math.Sin(anguloInicial + i * anguloIncremento));
                        puntos[i] = new Point((int)x, (int)y);
                    }

                    return puntos;
                }

                Point[] CalcularPuntosOctagono(int xCentro, int yCentro, int lado)
                {
                    Point[] puntos = new Point[8];
                    double anguloInicial = -Math.PI / 2;
                    double anguloIncremento = 2 * Math.PI / 8; 

                    for (int i = 0; i < 8; i++)
                    {
                        double x = xCentro + (lado * Math.Cos(anguloInicial + i * anguloIncremento));
                        double y = yCentro + (lado * Math.Sin(anguloInicial + i * anguloIncremento));
                        puntos[i] = new Point((int)x, (int)y);
                    }

                    return puntos;
                }

                private void pbAdd_Click(object sender, EventArgs e)
                {
                    //FrmAdd fAdd = new FrmAdd("A", bd);

                    //fAdd.ShowDialog();
                    //fAdd.Dispose();
                    //fAdd = null;
                    getPoligons(cbPoligon.SelectedIndex == 0);
                }


                private void pbDel_Click(object sender, EventArgs e)
                {
                    //FrmAdd fAdd = new FrmAdd("B", bd);

                    //fAdd.ShowDialog();
                    //fAdd.Dispose();
                    //fAdd = null;
                    getPoligons(cbPoligon.SelectedIndex == 0);
                }
            }
        }
