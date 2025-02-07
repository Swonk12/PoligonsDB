using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoligonsDB.CLASSES.SUBCLASSES
{
    internal class ClCercles : ClPoligons
    {
        public string nom { get; set; }
        public double radio { get; set; }

        public ClCercles(ClBd xbd, int xid) : base(xbd, xid)
        {
            getPoligons(xbd, xid);
        }

        public ClCercles(ClBd xbd, string xtipo, double xradio, string xnom, double xarea, double xperimetre, int xcolor) : base(xbd, xtipo, xarea, xperimetre, xcolor)
        {
            string xsql = $"INSERT INTO Cercles (id_Poligon, nom, radio) VALUES({id_Poligon}, '{xnom}', {xradio})";

            if (xbd.executarOrdre(xsql))
            {
                MessageBox.Show($"Cercle inserit correctament a la base de dades", "TOT BÉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No s'ha pogut inserir el cercle a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override string dadesPoligon()
        {
            return $"Nom : {nom}{Environment.NewLine}" +
                   $"Radi : {radio}{Environment.NewLine}";
        } 

        public override bool eliminarPoligon(ClBd bd, int id)
        {
            string xsql = $"DELETE FROM Cercles WHERE id_Poligon={id}";
            return bd.executarOrdre(xsql);
        }

        public override bool getPoligons(ClBd bd, int id)
        {
            bool xb = false;
            DataSet xdset = new DataSet();
            string xsql = $"SELECT * FROM Cercles WHERE id_Poligon={id}";

            if (bd.getDades(xsql, xdset) && xdset.Tables[0].Rows.Count > 0)
            {
                nom = xdset.Tables[0].Rows[0]["nom"].ToString();
                radio = Convert.ToDouble(xdset.Tables[0].Rows[0]["radio"]);
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
