using System;
using System.Collections.Generic;
using System.Data;
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
        public double area { get; set; }
        public double perimetre { get; set; }
        public int color { get; set; }

        public ClRectangle(ClBd xbd, int xid) : base(xbd, xid)
        {
            getPoligons(xbd, xid);
        }

        public ClRectangle(ClBd xbd, string xnom, double xancho, double xalto, double xarea, double xperimetre, int xcolor)
            : base(xbd, xnom, xancho, xalto, xarea, xperimetre, xcolor)
        {
            String xsql = $"INSERT INTO Rectangles (id_Poligon, nom, ancho, alto, area, perimetre, color) " +
                          $"VALUES({id_Poligon}, '{xnom}', {xancho}, {xalto}, {xarea}, {xperimetre}, {xcolor})";

            if (xbd.executarOrdre(xsql))
            {
                MessageBox.Show($"Polígon inserit correctament a la base de dades", "TOT BÉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No s'ha pogut inserir el {tipus} a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override string dadesPoligon()
        {
            return "Nom : " + nom + Environment.NewLine +
                   "Ancho : " + ancho.ToString() + Environment.NewLine +
                   "Alto : " + alto.ToString() + Environment.NewLine +
                   "Area : " + area.ToString() + Environment.NewLine +
                   "Perímetre : " + perimetre.ToString() + Environment.NewLine;
        }

        public override bool eliminarPoligon(ClBd bd, int id)
        {
            Boolean xb = false;
            String xsql = $"DELETE FROM Rectangles WHERE id_Poligon='{id}'";
            DataSet xdset = new DataSet();

            if (bd.getDades(xsql, xdset) && xdset.Tables[0].Rows.Count > 0)
            {
                xb = true;
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
                area = (double)xdset.Tables[0].Rows[0].ItemArray[5];
                perimetre = (double)xdset.Tables[0].Rows[0].ItemArray[6];
                color = (int)xdset.Tables[0].Rows[0].ItemArray[7];
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
