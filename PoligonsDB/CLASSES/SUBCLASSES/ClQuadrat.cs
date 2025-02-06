using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoligonsDB.CLASSES.SUBCLASSES
{
    internal class ClQuadrat : ClPoligons
    {
        public string nom { get; set; }
        public double lado { get; set; }
        public double area { get; set; }
        public double perimetre { get; set; }
        public int color { get; set; }

        public ClQuadrat(ClBd xbd, int xid) : base(xbd, xid)
        {
            getPoligons(xbd, xid);
        }

        public ClQuadrat(ClBd xbd, string xnom, double xlado, double xarea, double xperimetre, int xcolor) : base(xbd, xnom, xlado, xarea, xperimetre, xcolor)
        {
            String xsql = $"INSERT INTO Quadrats (id_Poligon, nom, lado, area, perimetre, color) VALUES({id_Poligon}, '{xnom}', {xlado}, {xarea}, {xperimetre}, {xcolor})";
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
                   "Lado : " + lado.ToString() + Environment.NewLine +
                   "Area : " + area.ToString() + Environment.NewLine +
                   "Perímetre : " + perimetre.ToString() + Environment.NewLine;
        }

        public override bool eliminarPoligon(ClBd bd, int id)
        {
            Boolean xb = false;
            String xsql = $"DELETE FROM Quadrats WHERE id_Quadrat='{id}'";
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
            String xsql = $"SELECT * FROM Quadrats WHERE id_Quadrat ='{id}'";
            DataSet xdset = new DataSet();

            if (bd.getDades(xsql, xdset) && xdset.Tables[0].Rows.Count > 0)
            {
                nom = (string)xdset.Tables[0].Rows[0].ItemArray[2];
                lado = (double)xdset.Tables[0].Rows[0].ItemArray[3];
                area = (double)xdset.Tables[0].Rows[0].ItemArray[4];
                perimetre = (double)xdset.Tables[0].Rows[0].ItemArray[5];
                color = (int)xdset.Tables[0].Rows[0].ItemArray[6];
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
