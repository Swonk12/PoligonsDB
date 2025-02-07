using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PoligonsDB.CLASSES
{
    public abstract class ClPoligons
    {
        public int id_Poligon { get; set; }
        public string tipus { get; set; }

        // Comunes
        public double area { get; set; }
        public double perimetre {  get; set; }
        public int color { get; set; }


        public ClPoligons(ClBd xbd, int xid)
        {
            id_Poligon = xid;
        }

        public ClPoligons(ClBd xbd, String xtipus)
        {
            DataSet xdset = new DataSet();
            String xsql = $"INSERT INTO Poligons(tipus) VALUES(''{tipus}')";

            if (xbd.executarOrdre(xsql))
            {
                xsql = "SELECT TOP 1 Id FROM Poligons ORDER BY Id DESC";
                xbd.getDades(xsql, xdset);
                if (xdset.Tables[0].Rows.Count == 0)
                {
                    id_Poligon = -1;
                    MessageBox.Show("No s'ha pogut recuperar l'Id del nou poligon", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    id_Poligon = (int)xdset.Tables[0].Rows[0].ItemArray[0];
                    tipus = "";
                }
            }

        }

        // Pentagon
        public ClPoligons(ClBd xbd, string tipo , double xarea, double xperimetre, int xcolor)
        {

            DataSet xdset = new DataSet();
            String xsql = $"INSERT INTO Poligons(tipus, area, perimetre, color)  VALUES('{tipo}', {xarea.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture).Replace(',', '.')}, {xperimetre.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture).Replace(',', '.')}, {xcolor})";


            if (xbd.executarOrdre(xsql))
            {
                // Si la inserció ha anat bé recuperem l'Id generat perquè el necessitem per a fer la inserció en la taula de la subclasse
                // ALERTA!!!! En un entorn multiusuari, aquesta operació s'hauria de fer amb una TRANSACTION per a garantir que el resultat és correcte
                xsql = "SELECT TOP 1 id_Poligon FROM Poligons ORDER BY id_Poligon DESC";
                xbd.getDades(xsql, xdset);
                if (xdset.Tables[0].Rows.Count == 0)
                {
                    id_Poligon = -1;
                    MessageBox.Show("No s'ha pogut recuperar l'Id del nou poligons", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    id_Poligon = (int)xdset.Tables[0].Rows[0].ItemArray[0];
                }
            }
        }

        public String dadesComunes()
        {
            // retorna una string amb les dades comunes a tots els personatges
            String xs = "";
            string xcolor;

            if (color == 1)
            {
                xcolor = "TRUE";
            }else
            {
                xcolor = "FALSE";
            }

            xs = "Area: " + area.ToString() + Environment.NewLine +
                "Perimetre: " + perimetre.ToString() + Environment.NewLine +
                "Color: " + xcolor + Environment.NewLine;
            return xs;
        }
        
        // els mètodes abstract s'hauran de definir obligatòriament en cada una de les subclasses
        public abstract String dadesPoligon();
        public abstract Boolean eliminarPoligon(ClBd bd, int id);
        public abstract Boolean getPoligons(ClBd bd, int id);
        public abstract Boolean inserirPoligon();
    }
}