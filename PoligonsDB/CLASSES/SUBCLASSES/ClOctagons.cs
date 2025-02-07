using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoligonsDB.CLASSES.SUBCLASSES
{
    internal class ClOctagons : ClPoligons
    {
        public string nom { get; set; }
        public double lado { get; set; }
        public double apotema { get; set; }

        public ClOctagons(ClBd xbd, int xid) : base(xbd, xid)
        {
            getPoligons(xbd, xid);
        }

        public ClOctagons(ClBd xbd, string xtipo, string xnom, double xlado, double xapotema, double xarea, double xperimetre, int xcolor) : base(xbd, xtipo, xarea, xperimetre, xcolor)
        {
            String xsql = $"INSERT INTO Octagons (id_Poligon, nom, lado, apotema)  VALUES({id_Poligon}, {xnom}, {xlado}, {xapotema})";
            if (xbd.executarOrdre(xsql))
            {
                MessageBox.Show($"Octagon inserit correctament a la base de dades", "TOT BÉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No s'ha pogut inserir el {tipus} a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override string dadesPoligon()
        {
            String xs = "";

            xs = "Nom : " + nom + Environment.NewLine +
                "Lado :  " + lado.ToString() + Environment.NewLine +
                "Apotema : " + apotema.ToString() + Environment.NewLine;
            return xs;
        }


        public override bool eliminarPoligon(ClBd bd, int id)
        {
            Boolean xb = false;
            String xsql = "";
            DataSet xdset = new DataSet();

            xsql = $"DELETE FROM Octagons WHERE id_Poligon={id}";
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
            String xsql = "";
            DataSet xdset = new DataSet();

            xsql = $"SELECT * FROM Octagons WHERE id_Poligon='{id}'";
            if (bd.getDades(xsql, xdset) && xdset.Tables[0].Rows.Count > 0)
            {
                nom = (string)xdset.Tables[0].Rows[0].ItemArray[2];
                lado = (double)xdset.Tables[0].Rows[0].ItemArray[3];
                apotema = (double)xdset.Tables[0].Rows[0].ItemArray[4];
            }
            return xb;
        }

        public override bool inserirPoligon()
        {
            throw new NotImplementedException();
        }
    }
}
