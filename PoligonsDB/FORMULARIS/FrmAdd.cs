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
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace PoligonsDB.FORMULARIS
{
    public partial class FrmAdd : Form
    {
        ClBd bd { get; set; }
        String tipus = "Quadrats";
        String operacio;
        public FrmAdd(string xoperacio, ClBd xbd)
        {
            bd = xbd;
            InitializeComponent();
            operacio = xoperacio;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            // Campos a usar:

            double xlado, xapotema, perimetro, area, xbase, xaltura;
            double alto, ancho, xradio, xradioMayor, xradioMenor, xdiagonalMenor, xdiagonalMayor;

            if (tbNom.Text.Trim().Length == 0)
            {
                MessageBox.Show("Cal introduir el nom", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else{
                switch (tipus)
                {
                    case "Quadrats":
                        xlado = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);
                        area = xlado * xlado;
                        perimetro = xlado * 4;
                        ClQuadrat bal = new ClQuadrat(bd, "Quadrat", tbNom.Text, xlado, area, perimetro, r.Next(0, 2));
                        break;
                    case "Rectangles":
                        alto = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);
                        ancho = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);
                        area = alto * alto;
                        perimetro = 2 * (alto + ancho);
                        ClRectangle elf = new ClRectangle(bd, "Rectangle", alto, tbNom.Text, ancho, area, perimetro, r.Next(0,2));
                        break;
                    case "Cercles":
                        xradio = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);
                        area = Math.Round((Math.PI*(xradio * xradio)),2);
                        perimetro = Math.Round((2 * Math.PI*xradio),2);
                        ClCercles hob = new ClCercles(bd, "Cercle", xradio,tbNom.Text, area, perimetro, r.Next(0,2));
                        break;
                    case "Elipses":
                        xradioMayor = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);
                        xradioMenor = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);

                        area = Math.Round((Math.PI*xradioMayor*xradioMenor),2);
                        perimetro = Math.Round((Math.PI * (3 * (xradioMayor + xradioMenor)) - (Math.Sqrt((3 * xradioMayor + xradioMenor) * (xradioMayor + 3 * xradioMenor)))),2);
                        ClElipses hum = new ClElipses(bd, "Elipse", tbNom.Text, xradioMayor, xradioMenor, area, perimetro, r.Next(0,2));
                        break;
                    case "TrianglesRectangles ":
                        xbase = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);
                        xaltura = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);
                        double hipotenusa = Math.Round(Math.Sqrt(Math.Pow(xbase, 2) + Math.Pow(xaltura, 2)), 2);

                        area = Math.Round(((xbase * xaltura) / 2),2);
                        perimetro = Math.Round((xbase + xaltura + hipotenusa), 2);
                        ClTriangles_Rectangles mag = new ClTriangles_Rectangles(bd, "Triangle Rectangle", r.Next(0,2), tbNom.Text, xbase, xaltura, area, r.Next(0,2), perimetro);
                        break;
                    case "Triangles_isòsceles":
                        xbase = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);
                        xaltura = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);
                        area = Math.Round((xbase * xaltura) / 2);
                        perimetro = Math.Round(((xaltura * xaltura) + xbase),2);
                        ClTriangles_Isosceles nan = new ClTriangles_Isosceles(bd, "Triangle Isosceles",tbNom.Text, xbase, xaltura,area, r.Next(0,2), perimetro);
                        break;
                    case "Rombes":
                        xdiagonalMenor = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);
                        xdiagonalMayor = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);

                        area = Math.Round(((xdiagonalMayor * xdiagonalMayor) / 2),2);
                        xlado = Math.Round(Math.Sqrt(Math.Pow(xdiagonalMayor / 2, 2) + Math.Pow(xdiagonalMenor / 2, 2)),2);

                        perimetro = 4 * xlado;
                        ClRombes naz = new ClRombes(bd, "Rombe", tbNom.Text, xdiagonalMayor, xdiagonalMenor, area, perimetro, r.Next(0,2));
                        break;
                    case "Pentàgons":
                        xlado = Math.Round((r.NextDouble() + r.Next(20,50)), 2);
                        xapotema = Math.Round((r.NextDouble() + r.Next(10, 20)) ,2);

                        perimetro = 5 * xlado;
                        area = (perimetro * xapotema) / 2;

                        ClPentagons penta = new ClPentagons(bd, "Pentagon",tbNom.Text, xlado, xapotema, perimetro, area, r.Next(0, 2));
                        break;
                    case "Hexàgons":
                        xlado = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);
                        xapotema = Math.Round((r.NextDouble() + r.Next(10, 20)), 2);

                        perimetro = 6 * xlado;
                        area = (perimetro * xapotema) / 2;

                        ClHexagons hexa = new ClHexagons(bd, "Hexagons", tbNom.Text, xlado, xapotema, perimetro, area, r.Next(0, 2));
                        break;
                    case "Octògons":
                        xlado = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);
                        xapotema = Math.Round((r.NextDouble() + r.Next(10, 20)), 2);

                        perimetro = 7 * xlado;
                        area = (perimetro * xapotema) / 2;

                        ClOctagons oct = new ClOctagons(bd, "Octagons", tbNom.Text, xlado, xapotema, perimetro, area, r.Next(0, 2));
                        break;
                }
                this.Close();
            }

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdQuadrat_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                tipus = ((RadioButton)sender).Text;
            }
        }
    }
}
