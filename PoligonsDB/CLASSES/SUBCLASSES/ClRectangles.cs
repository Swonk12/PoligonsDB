using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoligonsDB.CLASSES.SUBCLASSES
{
    internal class ClRectangle : ClPoligons
    {
        public string nom { get; set; }
        public double ancho { get; set; }
        public double alto { get; set; }

        public ClRectangle(ClBd xbd, int xid) : base(xbd, xid)
        {
            getPoligons(xbd, xid);
        }

        public ClRectangle(ClBd xbd, string xtipo ,double xalto, string xnom, double xancho, double xarea, double xperimetre, int xcolor) : base(xbd, xtipo, xarea, xperimetre, xcolor)
        {
            // Convertir los valores double a string con punto decimal
            string xanchoStr = xancho.ToString(CultureInfo.InvariantCulture);
            string xaltoStr = xalto.ToString(CultureInfo.InvariantCulture);

            String xsql = $"INSERT INTO Rectangles (id_Poligon, nom, ancho, alto) VALUES({id_Poligon}, '{xnom}', {xanchoStr}, {xaltoStr})";

            if (xbd.executarOrdre(xsql))
            {
                MessageBox.Show($"Rectangle inserit correctament a la base de dades", "TOT BÉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No s'ha pogut inserir el {xtipo} a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override string dadesPoligon()
        {
            return "Nom : " + nom + Environment.NewLine +
                   "Ancho : " + ancho.ToString() + Environment.NewLine +
                   "Alto : " + alto.ToString() + Environment.NewLine;
        }

        public override bool eliminarPoligon(ClBd bd, int id)
        {
            Boolean xb = false;
            String xsql = "";
            DataSet xdset = new DataSet();

            xsql = $"DELETE FROM Rectangles WHERE id_Poligon={id}";
            if (bd.executarOrdre(xsql))
            {
                xsql = $"DELETE FROM Poligons WHERE id_Poligon={id}";
                if (bd.executarOrdre(xsql))
                {
                    xb = true;
                }
            }
            return xb;
        }

        public override bool getPoligons(ClBd bd, int id)
        {
            Boolean xb = false;
            String xsql = $"SELECT * FROM Rectangles WHERE id_Poligon='{id}'";
            DataSet xdset = new DataSet();

            if (bd.getDades(xsql, xdset) && xdset.Tables[0].Rows.Count > 0)
            {
                nom = (string)xdset.Tables[0].Rows[0].ItemArray[2];
                ancho = (double)xdset.Tables[0].Rows[0].ItemArray[3];
                alto = (double)xdset.Tables[0].Rows[0].ItemArray[4];
                xb = true;
            }
            return xb;
        }

        public override bool inserirPoligon()
        {
            throw new NotImplementedException();
        }
    }
}
