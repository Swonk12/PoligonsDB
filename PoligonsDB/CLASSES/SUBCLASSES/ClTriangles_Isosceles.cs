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
    internal class ClTriangles_Isosceles : ClPoligons
    {
        public string nom { get; set; }
        public double baseTriangle { get; set; }
        public double altura { get; set; }

        public ClTriangles_Isosceles(ClBd xbd, int xid) : base(xbd, xid)
        {
            getPoligons(xbd, xid);
        }

        public ClTriangles_Isosceles(ClBd xbd, string xtipo,string xnom, double xbase, double xaltura, double xarea, int xcolor, double xperimetre) : base(xbd, xtipo, xarea, xperimetre, xcolor)
        {
            string xbaseStr = xbase.ToString(CultureInfo.InvariantCulture);
            string xalturaStr = xaltura.ToString(CultureInfo.InvariantCulture);

            string xsql = $"INSERT INTO Triangles_Isosceles (id_Poligon, nom, base, altura) VALUES({id_Poligon}, '{xnom}', {xbaseStr}, {xalturaStr})";

            if (xbd.executarOrdre(xsql))
            {
                MessageBox.Show($"Triangle isòsceles inserit correctament a la base de dades", "TOT BÉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No s'ha pogut inserir el triangle isòsceles a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override string dadesPoligon()
        {
            return $"Nom: {nom}{Environment.NewLine}" +
                   $"Base: {baseTriangle}{Environment.NewLine}" +
                   $"Altura: {altura}{Environment.NewLine}";
        }

        public override bool eliminarPoligon(ClBd bd, int id)
        {
            Boolean xb = false;
            String xsql = "";
            DataSet xdset = new DataSet();

            xsql = $"DELETE FROM Triangles_Isosceles WHERE id_Poligon={id}";
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
            bool xb = false;
            DataSet xdset = new DataSet();
            string xsql = $"SELECT * FROM Triangles_Isosceles WHERE id_Poligon={id}";

            if (bd.getDades(xsql, xdset) && xdset.Tables[0].Rows.Count > 0)
            {
                nom = xdset.Tables[0].Rows[0]["nom"].ToString();
                baseTriangle = Convert.ToDouble(xdset.Tables[0].Rows[0]["base"]);
                altura = Convert.ToDouble(xdset.Tables[0].Rows[0]["altura"]);
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
