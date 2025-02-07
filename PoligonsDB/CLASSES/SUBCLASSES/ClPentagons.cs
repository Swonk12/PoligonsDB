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
    internal class ClPentagons : ClPoligons
    {
        public string nom { get; set; }
        public double lado { get; set; }
        public double apotema { get; set; } 

        public ClPentagons(ClBd xbd, int xid) : base(xbd, xid)
        {
            getPoligons(xbd, xid);
        }

        public ClPentagons(ClBd xbd, string xtipo, string xnom, double xlado, double xapotema, double xarea, double xperimetre, int xcolor) : base(xbd, xtipo , xarea, xperimetre, xcolor)
        {
            String xsql = $"INSERT INTO Pentagons(id_Poligon, nom, lado, apotema)  VALUES({id_Poligon}, '{xnom}', {xlado.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture).Replace(',', '.')}, {xapotema.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture).Replace(',', '.')})";
            if (xbd.executarOrdre(xsql))
            {
                MessageBox.Show($"Pentagon inserit correctament a la base de dades", "TOT BÉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No s'ha pogut inserir el Pentagon a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            xsql = $"DELETE FROM Pentagons WHERE id_Poligon='{id}";
            if (bd.getDades(xsql, xdset) && xdset.Tables[0].Rows.Count > 0)
            {
                xb = true;
            }
            // pendent de codificar
            return xb;
        }

        public override bool getPoligons(ClBd bd, int id)
        {
            Boolean xb = false;
            String xsql = "";
            DataSet xdset = new DataSet();

            xsql = $"SELECT * FROM Pentagons WHERE id_Poligon='{id}'";
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
