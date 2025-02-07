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

            double xlado, xapotema, perimetro, area;
            int color;

            if (tbNom.Text.Trim().Length == 0)
            {
                MessageBox.Show("Cal introduir el nom", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else{
                switch (tipus)
                {
                    //    case "Quadrats":
                    //        ClBalrog bal = new ClBalrog(bd, tbNom.Text, strength, intelligence, grup, R.Next(0, 101), 1, R.Next(0, 51), R.Next(0, 101));
                    //        break;
                    //    case "Elfs":
                    //        ClElf elf = new ClElf(bd, tbNom.Text, strength, intelligence, grup, R.Next(1200, 10000), 1, R.Next(1000, 100000) / 100, llColorsCabell[R.Next(0, llColorsCabell.Count)], R.Next(0, 101));
                    //        break;
                    //    case "Hobbits":
                    //        ClHobbit hob = new ClHobbit(bd, tbNom.Text, strength, intelligence, grup, R.Next(90, 121), R.Next(20, 101), 1, "La Comarca", R.Next(0, 101));
                    //        break;
                    //    case "Humans":
                    //        ClHuma hum = new ClHuma(bd, tbNom.Text, strength, intelligence, grup, R.Next(90, 121), llCaracterístiques[R.Next(0, llCaracterístiques.Count)], 1, R.Next(0, 101), llTerresHumans[R.Next(0, llTerresHumans.Count)]);
                    //        break;
                    //    case "Mags":
                    //        ClMag mag = new ClMag(bd, tbNom.Text, strength, intelligence, grup, R.Next(0, 101), R.Next(1500, 5001), 1, llColorsCapa[R.Next(0, llColorsCapa.Count)], R.Next(0, 101));
                    //        break;
                    //    case "Nans":
                    //        ClNan nan = new ClNan(bd, tbNom.Text, strength, intelligence, grup, R.Next(100, 501), R.Next(0, 101), 1, llClansNans[R.Next(0, llClansNans.Count)]);
                    //        break;
                    //    case "Nazguls":
                    //        ClNazgul naz = new ClNazgul(bd, tbNom.Text, strength, intelligence, grup, R.Next(0, 101), R.Next(0, 2), R.Next(0, 101), llMunturaNazguls[R.Next(0, llMunturaNazguls.Count)], R.Next(0, 101));
                    //        break;
                    case "Pentàgons":
                        xlado = Math.Round((r.NextDouble() + r.Next(20,50)), 2);
                        xapotema = Math.Round((r.NextDouble() + r.Next(10, 20)) ,2);

                        perimetro = 5 * xlado;
                        area = (perimetro * xapotema) / 2;
                        color = r.Next(0,2);

                        ClPentagons penta = new ClPentagons(bd, "Pentagon",tbNom.Text, xlado, xapotema, perimetro, area, color);
                        break;
                    case "Hexàgons":
                        xlado = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);
                        xapotema = Math.Round((r.NextDouble() + r.Next(10, 20)), 2);

                        perimetro = 6 * xlado;
                        area = (perimetro * xapotema) / 2;
                        color = r.Next(0, 2);

                        ClHexagons hexa = new ClHexagons(bd, "Hexagons", tbNom.Text, xlado, xapotema, perimetro, area, color);
                        break;
                    case "Octògons":
                        xlado = Math.Round((r.NextDouble() + r.Next(20, 50)), 2);
                        xapotema = Math.Round((r.NextDouble() + r.Next(10, 20)), 2);

                        perimetro = 7 * xlado;
                        area = (perimetro * xapotema) / 2;
                        color = r.Next(0, 2);

                        ClOctagons oct = new ClOctagons(bd, "Octagons", tbNom.Text, xlado, xapotema, perimetro, area, color);
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
