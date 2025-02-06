using System;
using System.Collections.Generic;
using System.Data;
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
        public double area { get; set; }
        public double perimetre { get; set; }
        public int color { get; set; }

        public ClTriangles_Isosceles(ClBd xbd, int xid) : base(xbd, xid)
        {
            getPoligons(xbd, xid);
        }

        public ClTriangles_Isosceles(ClBd xbd, string xnom, double xbase, double xaltura, double xarea, double xperimetre, int xcolor)
            : base(xbd, xnom, xbase, xaltura, xarea, xperimetre, xcolor)
        {
            string xsql = $"INSERT INTO Triangles_Isosceles (id_Poligon, nom, base, altura, area, perimetre, color) " +
                          $"VALUES({id_Poligon}, '{xnom}', {xbase}, {xaltura}, {xarea}, {xperimetre}, {xcolor})";

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
                   $"Altura: {altura}{Environment.NewLine}" +
                   $"Àrea: {area}{Environment.NewLine}" +
                   $"Perímetre: {perimetre}{Environment.NewLine}";
        }

        public override bool eliminarPoligon(ClBd bd, int id)
        {
            string xsql = $"DELETE FROM Triangles_Isosceles WHERE id_Poligon={id}";
            return bd.executarOrdre(xsql);
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
                area = Convert.ToDouble(xdset.Tables[0].Rows[0]["area"]);
                perimetre = Convert.ToDouble(xdset.Tables[0].Rows[0]["perimetre"]);
                color = Convert.ToInt32(xdset.Tables[0].Rows[0]["color"]);
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
