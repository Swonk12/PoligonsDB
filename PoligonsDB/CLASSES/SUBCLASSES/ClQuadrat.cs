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
    internal class ClQuadrat : ClPoligons
    {
        public string nom { get; set; }
        public double lado { get; set; }

        public ClQuadrat(ClBd xbd, int xid) : base(xbd, xid)
        {
            getPoligons(xbd, xid);
        }

        public ClQuadrat(ClBd xbd, string xtipo, string xnom, double xlado, double xarea, double xperimetre, int xcolor) : base(xbd, xtipo, xarea, xperimetre, xcolor)
        {
            // Convertir xlado en un buen formato para nuestro Insert
            string xladoStr = xlado.ToString(CultureInfo.InvariantCulture);

            String xsql = $"INSERT INTO Quadrats (id_Poligon, nom, lado) VALUES({id_Poligon}, '{xnom}', {xladoStr})";
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
                   "Lado : " + lado.ToString() + Environment.NewLine;
        }

        public override bool eliminarPoligon(ClBd bd, int id)
        {
            Boolean xb = false;
            String xsql = "";
            DataSet xdset = new DataSet();

            xsql = $"DELETE FROM Quadrats WHERE id_Poligon={id}";
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
            String xsql = $"SELECT * FROM Quadrats WHERE id_Poligon ='{id}'";
            DataSet xdset = new DataSet();

            if (bd.getDades(xsql, xdset) && xdset.Tables[0].Rows.Count > 0)
            {
                nom = (string)xdset.Tables[0].Rows[0].ItemArray[2];
                lado = (double)xdset.Tables[0].Rows[0].ItemArray[3];
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
