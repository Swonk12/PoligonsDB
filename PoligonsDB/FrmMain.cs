using PoligonsDB.CLASSES;
using PoligonsDB.CLASSES.SUBCLASSES;
using PoligonsDB.CLASSES.SUBCLASSES.PoligonsDB.CLASSES.SUBCLASSES;
using PoligonsDB.FORMULARIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
        //String cadenaConnexio = @"AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAKZt0PpACLEye0nls4yvFgAQAAAACAAAAAAAQZgAAAAEAACAAAACfiYECuEAFyofHsBt4jPIkK+ghmMpQlVHxWuo9hgxnGwAAAAAOgAAAAAIAACAAAADFlKTjjyXotH2DaVOOQhuGiInjKxNk7znYQ1db7siYSVAAAABfOk0PUD2QTWtnsyKF2ju9IWDmOJZYufQtfZCisX1dfuyZTpYOPg2VJX2LYu4cs4kJD+EAhDRKPxYLT6nZsM2rSXAs0lGJo7ie3Q1IXia0aEAAAAAGiZGSqbHu+f1xTRzK6f/OikdZy/v2yR6zI8Cc3dBpFN8Dlun+VXfMGwzGKStQYaKLllbbU0QdFf5KVuEW7WKt";
        // Cadena Marc
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
                xsql = $"SELECT       P.id_Poligon,       P.tipus,   COALESCE(Q.id_Quadrat, R.id_Rectangle, C.id_Cercle, E.id_Elipse, TR.id_TriangleRect , TI.id_TriangleIso, Ro.id_Rombe , Pe.id_Pentagon, He.id_Hexagon , Oc.id_Octagon) AS idFigura , COALESCE(Q.nom, R.nom, C.nom, E.nom, TR.nom, TI.nom, Ro.nom, Pe.nom, He.nom, Oc.nom) AS Nombre , P.area, P.perimetre, P.color FROM Poligons P LEFT JOIN Quadrats Q ON P.id_Poligon = Q.id_Poligon LEFT JOIN Rectangles R ON P.id_Poligon = R.id_Poligon LEFT JOIN Cercles C ON P.id_Poligon = C.id_Poligon LEFT JOIN Elipses E ON P.id_Poligon = E.id_Poligon LEFT JOIN Triangles_Rectangles TR ON P.id_Poligon = TR.id_Poligon LEFT JOIN Triangles_Isosceles TI ON P.id_Poligon = TI.id_Poligon LEFT JOIN Rombes Ro ON P.id_Poligon = Ro.id_Poligon LEFT JOIN Pentagons Pe ON P.id_Poligon = Pe.id_Poligon LEFT JOIN Hexagons He ON P.id_Poligon = He.id_Poligon LEFT JOIN Octagons Oc ON P.id_Poligon = Oc.id_Poligon;\r\n";
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
                    case "Rectangle":
                        p = new ClRectangle(bd, id);
                        llRectangles.Add((ClRectangle)p);
                        break;
                    case "Cercle":
                        p = new ClCercles(bd, id);
                        llCercles.Add((ClCercles)p);
                        break;
                    case "Elipse":
                        p = new ClElipses(bd, id);
                        llElipses.Add((ClElipses)p);
                        break;
                    case "Triangle Rectangle":
                        p = new ClTriangles_Rectangles(bd, id);
                        llTriangles_Rectangles.Add((ClTriangles_Rectangles)p);
                        break;
                    case "Triangle Isosceles":
                        p = new ClTriangles_Isosceles(bd, id);
                        llTriangles_Isosceles.Add((ClTriangles_Isosceles)p);
                        break;
                    case "Rombe":
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

                p.id_Poligon = id;
                p.tipus = fila.Cells["tipus"].Value.ToString();
                p.area = (double)fila.Cells["area"].Value;
                p.perimetre = (double)fila.Cells["perimetre"].Value;
                p.color = (int)fila.Cells["color"].Value;
                p.getPoligons(bd, id);
                llPoligons.Add(p);

            }
        }

        private void customDgrid()
        {
            dgPoligons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgPoligons.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgPoligons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgPoligons.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgPoligons.Columns["id_Poligon"].Visible = false;
            dgPoligons.Columns[2].Visible = false;
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
            llTriangles_Rectangles.Clear();
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
            if (dgPoligons.SelectedRows.Count == 0) return; // Si no hay selección, salir.

            // Obtener la fila seleccionada
            DataGridViewRow fila = dgPoligons.SelectedRows[0];
            int cont = fila.Index, indexLado, indexEnd, lado;
            int xCentro = tbInfo.Left + tbInfo.Width / 2;
            int yCentro = tbInfo.Bottom + 50;
            double ancho, altura, radio, radioMayor, radioMenor, diagonalMayor, diagonalMenor;
            string todo, ladoString;
            Graphics g = e.Graphics;
            switch (fila.Cells["tipus"].Value.ToString())
            {
                case "Quadrat":
                    todo = llPoligons[cont].dadesPoligon();

                    indexLado = todo.IndexOf("Lado :") + "Lado :".Length;

                    indexEnd = todo.IndexOf("\r\n", indexLado);
                    ladoString = todo.Substring(indexLado, indexEnd - indexLado).Trim();

                    double ladoDouble = double.Parse(ladoString);
                    int ladoInt = (int)Math.Round(ladoDouble);

                    Pen p = new Pen(Color.Black);
                    Rectangle r = new Rectangle(xCentro, yCentro, ladoInt, ladoInt);

                    if (llPoligons[cont].color == 1)
                    {
                        Brush brush = new SolidBrush(Color.Blue);
                        g.FillRectangle(brush, r);
                    }
                    else
                    {
                        g.DrawRectangle(p, r);
                    }
                    break;

                case "Rectangle":

                    todo = llPoligons[cont].dadesPoligon();

                    indexLado = todo.IndexOf("Ancho :") + "Ancho :".Length;

                    indexEnd = todo.IndexOf("\r\n", indexLado);
                    ladoString = todo.Substring(indexLado, indexEnd - indexLado).Trim();

                    ancho = double.Parse(ladoString);

                    indexLado = todo.IndexOf("Alto :") + "Alto :".Length;

                    indexEnd = todo.IndexOf("\r\n", indexLado);
                    ladoString = todo.Substring(indexLado, indexEnd - indexLado).Trim();

                    altura = double.Parse(ladoString);

                    Pen penR = new Pen(Color.Black);
                    Rectangle rect = new Rectangle(xCentro, yCentro, (int)Math.Round(ancho), (int)Math.Round(altura));


                    if (llPoligons[cont].color == 1)
                    {

                        Brush brush = new SolidBrush(Color.Blue);
                        g.FillRectangle(brush, rect);

                    }
                    else
                    {

                        g.DrawRectangle(penR, rect);

                    }

                    break;

                case "Cercle":
                    todo = llPoligons[cont].dadesPoligon();
                    indexLado = todo.IndexOf("Radi :") + "Radi :".Length;

                    indexEnd = todo.IndexOf("\r\n", indexLado);
                    ladoString = todo.Substring(indexLado, indexEnd - indexLado).Trim();

                    radio = Math.Round(double.Parse(ladoString), 0);

                    Pen penC = new Pen(Color.Black);
                    Rectangle circle = new Rectangle(xCentro - (int)radio, yCentro - (int)radio, (int)radio * 2, (int)radio * 2);

                    if (llPoligons[cont].color == 1)
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
                    todo = llPoligons[cont].dadesPoligon();
                    indexLado = todo.IndexOf("Radi Major:") + "Radi Major:".Length;

                    indexEnd = todo.IndexOf("\r\n", indexLado);
                    ladoString = todo.Substring(indexLado, indexEnd - indexLado).Trim();

                    radioMayor = Math.Round(double.Parse(ladoString), 0);

                    indexLado = todo.IndexOf("Radi Menor:") + "Radi Menor:".Length;

                    indexEnd = todo.IndexOf("\r\n", indexLado);
                    ladoString = todo.Substring(indexLado, indexEnd - indexLado).Trim();

                    radioMenor = Math.Round(double.Parse(ladoString), 0);

                    Pen penE = new Pen(Color.Black);

                    Rectangle ellipseRect = new Rectangle(
                        xCentro - (int)radioMayor, // Centrar la elipse en X
                        yCentro - (int)radioMenor, // Centrar la elipse en Y
                        (int)radioMayor * 2,       // Ancho total
                        (int)radioMenor * 2        // Alto total
                    );

                    if (llPoligons[cont].color == 1)
                    {
                        Brush brushE = new SolidBrush(Color.Green);
                        g.FillEllipse(brushE, ellipseRect);
                    }
                    else
                    {
                        g.DrawEllipse(penE, ellipseRect);
                    }
                    break;

                case "Triangle Rectangle":
                    todo = llPoligons[cont].dadesPoligon();
                    indexLado = todo.IndexOf("Base:") + "Base:".Length;

                    indexEnd = todo.IndexOf("\r\n", indexLado);
                    ladoString = todo.Substring(indexLado, indexEnd - indexLado).Trim();

                    ancho = Math.Round(double.Parse(ladoString), 0);

                    indexLado = todo.IndexOf("Altura:") + "Altura:".Length;

                    indexEnd = todo.IndexOf("\r\n", indexLado);
                    ladoString = todo.Substring(indexLado, indexEnd - indexLado).Trim();

                    altura = Math.Round(double.Parse(ladoString), 0);

                    indexLado = todo.IndexOf("Lado:") + "Lado:".Length;

                    indexEnd = todo.IndexOf("\r\n", indexLado);
                    ladoString = todo.Substring(indexLado, indexEnd - indexLado).Trim();

                    lado = int.Parse(ladoString);
                    Point[] puntos;
                    Pen penT = new Pen(Color.Black);
                    if (lado == 0)
                    {

                        puntos = new Point[]
                        {
                                    new Point(xCentro, yCentro),
                                    new Point(xCentro + (int)ancho, yCentro),
                                    new Point(xCentro, yCentro - (int)altura)
                        };

                        if (llPoligons[cont].color == 1)
                        {
                            Brush brushT = new SolidBrush(Color.Orange);
                            g.FillPolygon(brushT, puntos);
                        }
                        else
                        {
                            g.DrawPolygon(penT, puntos);
                        }
                    }
                    else
                    {
                        puntos = new Point[]
                        {
                                    new Point(xCentro, yCentro),
                                    new Point(xCentro + (int)ancho, yCentro),
                                    new Point(xCentro + (int)ancho, yCentro - (int)altura)
                        };

                        if (llPoligons[cont].color == 1)
                        {
                            Brush brushT = new SolidBrush(Color.Orange);
                            g.FillPolygon(brushT, puntos);
                        }
                        else
                        {
                            g.DrawPolygon(penT, puntos);
                        }

                    }

                    break;
                case "Triangle Isosceles":
                    todo = llPoligons[cont].dadesPoligon();
                    indexLado = todo.IndexOf("Base:") + "Base:".Length;

                    indexEnd = todo.IndexOf("\r\n", indexLado);
                    ladoString = todo.Substring(indexLado, indexEnd - indexLado).Trim();

                    ancho = Math.Round(double.Parse(ladoString), 0);

                    indexLado = todo.IndexOf("Altura:") + "Altura:".Length;

                    indexEnd = todo.IndexOf("\r\n", indexLado);
                    ladoString = todo.Substring(indexLado, indexEnd - indexLado).Trim();

                    altura = Math.Round(double.Parse(ladoString), 0);

                    Point[] puntos3;
                    puntos3 = new Point[]
                    {
                                new Point(xCentro - (int)(ancho / 2), yCentro + (int)(altura / 2)), // Vértice inferior izquierdo
                                new Point(xCentro + (int)(ancho / 2), yCentro + (int)(altura / 2)), // Vértice inferior derecho
                                new Point(xCentro, yCentro - (int)(altura / 2))                             // Vértice superior
                    };

                    Pen penTI = new Pen(Color.Black);
                    if (llPoligons[cont].color == 1)
                    {
                        // Pintar triángulo isósceles relleno
                        Brush brushTI = new SolidBrush(Color.Green);
                        g.FillPolygon(brushTI, puntos3);
                    }
                    else
                    {
                        // Dibujar solo el contorno
                        g.DrawPolygon(penTI, puntos3);
                    }
                    break;

                case "Rombe":
                    todo = llPoligons[cont].dadesPoligon();
                    indexLado = todo.IndexOf("Diagonal Major:") + "Diagonal Major:".Length;
                    indexEnd = todo.IndexOf("\r\n", indexLado);
                    ladoString = todo.Substring(indexLado, indexEnd - indexLado).Trim();
                    diagonalMayor = Math.Round(double.Parse(ladoString), 0);

                    indexLado = todo.IndexOf("Diagonal Menor:") + "Diagonal Menor:".Length;
                    indexEnd = todo.IndexOf("\r\n", indexLado);
                    ladoString = todo.Substring(indexLado, indexEnd - indexLado).Trim();
                    diagonalMenor = Math.Round(double.Parse(ladoString), 0);

                    Point[] puntos2 = new Point[]
                    {
                        new Point(xCentro, yCentro - (int)(diagonalMayor / 2)), // Vértice superior
                        new Point(xCentro + (int)(diagonalMenor / 2), yCentro), // Vértice derecho
                        new Point(xCentro, yCentro + (int)(diagonalMayor / 2)), // Vértice inferior
                        new Point(xCentro - (int)(diagonalMenor / 2), yCentro)  // Vértice izquierdo
                    };

                    Pen penTIR = new Pen(Color.Black);
                    if (llPoligons[cont].color == 1)
                    {
                        Brush brushTI = new SolidBrush(Color.Purple);
                        g.FillPolygon(brushTI, puntos2);
                    }
                    else
                    {
                        g.DrawPolygon(penTIR, puntos2);
                    }
                    break;


                case "Pentagon":
                    indexLado = (llPoligons[cont].dadesPoligon()).IndexOf("Lado :") + "Lado :".Length;
                    indexEnd = (llPoligons[cont].dadesPoligon()).IndexOf("\r\n", indexLado);
                    ladoString = (llPoligons[cont].dadesPoligon()).Substring(indexLado, indexEnd - indexLado).Trim();
                    ladoDouble = Math.Round(double.Parse(ladoString), 2);

                    Point[] vPuntsPentagon = CalcularPuntosPentagono(xCentro, yCentro, ladoDouble);
                    if (llPoligons[cont].color == 1)
                    {
                        Brush brush = new SolidBrush(Color.Blue);
                        g.FillPolygon(brush, vPuntsPentagon);
                        g.DrawPolygon(new Pen(Color.Black, 2), vPuntsPentagon);
                    }
                    else if (llPoligons[cont].color == 0)
                    {
                        Pen pen = new Pen(Color.Black, 2);
                        g.DrawPolygon(pen, vPuntsPentagon);
                    }

                    g.DrawPolygon(new Pen(Color.Black, 2), vPuntsPentagon);
                    break;

                case "Hexagon":
                    cont = fila.Index;
                    indexLado = (llPoligons[cont].dadesPoligon()).IndexOf("Lado :") + "Lado :".Length;
                    indexEnd = (llPoligons[cont].dadesPoligon()).IndexOf("\r\n", indexLado);
                    ladoString = (llPoligons[cont].dadesPoligon()).Substring(indexLado, indexEnd - indexLado).Trim();
                    ladoDouble = Math.Round(double.Parse(ladoString), 2);

                    Point[] vPuntsHexagono = CalcularPuntosHexagono(xCentro, yCentro, ladoDouble);

                    if (llPoligons[cont].color == 0)
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

                case "Octagon":
                    indexLado = (llPoligons[cont].dadesPoligon()).IndexOf("Lado :") + "Lado :".Length;
                    indexEnd = (llPoligons[cont].dadesPoligon()).IndexOf("\r\n", indexLado);
                    ladoString = (llPoligons[cont].dadesPoligon()).Substring(indexLado, indexEnd - indexLado).Trim();
                    ladoDouble = Math.Round(double.Parse(ladoString), 2);

                    Point[] vPuntsOctagono = CalcularPuntosOctagono(xCentro, yCentro, ladoDouble);

                    if (llPoligons[cont].color == 0)
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


        Point[] CalcularPuntosPentagono(int xCentro, int yCentro, double lado)
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

        Point[] CalcularPuntosHexagono(int xCentro, int yCentro, double lado)
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

        Point[] CalcularPuntosOctagono(int xCentro, int yCentro, double lado)
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
            FrmAdd fAdd = new FrmAdd("A", bd);

            fAdd.ShowDialog();
            fAdd.Dispose();
            fAdd = null;
            getPoligons(cbPoligon.SelectedIndex == 0);
        }


        private void pbDel_Click(object sender, EventArgs e)
        {
            ClPoligons p;
            if (dgPoligons.SelectedRows.Count == 0)
            {
                MessageBox.Show("Cal seleccionar una fila", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Estàs segur que vols suprimir el Poligon seleccionat?", "ATENCIÓ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataGridViewRow fila = dgPoligons.SelectedRows[0];
                    int cont = fila.Index;
                    p = llPoligons[cont+1];
                    p.eliminarPoligon(bd, cont);
                }
            }
            getPoligons(true);
        }
    }
}
