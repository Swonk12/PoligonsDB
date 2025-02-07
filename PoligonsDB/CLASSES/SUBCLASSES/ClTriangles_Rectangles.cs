using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoligonsDB.CLASSES.SUBCLASSES
{
    internal class ClTriangles_Rectangles : ClPoligons
    {
        public string nom { get; set; }
        public double baseTriangle { get; set; }
        public double altura { get; set; }
        public int ladoRect {  get; set; }

        public ClTriangles_Rectangles(ClBd xbd, int xid) : base(xbd, xid)
        {
            getPoligons(xbd, xid);
        }

        public ClTriangles_Rectangles(ClBd xbd, string xtipo, int xladoRect,string xnom, double xbase, double xaltura, double xarea, int xcolor, double xperimetre) : base(xbd, xtipo, xarea, xperimetre, xcolor)
        {
            string xsql = $"INSERT INTO Triangles_Rectangles (id_Poligon, nom, ladoRect, base, altura) VALUES({id_Poligon}, '{xnom}', {xladoRect}, {xbase}, {xaltura})";

            if (xbd.executarOrdre(xsql))
            {
                MessageBox.Show($"Triangle Rectangle inserit correctament a la base de dades", "TOT BÉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No s'ha pogut inserir el Triangle Rectangle a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override string dadesPoligon()
        {
            return $"Nom: {nom}{Environment.NewLine}" +
                   $"Base: {baseTriangle}{Environment.NewLine}" +
                   $"Altura: {altura}{Environment.NewLine}" +
                   $"Lado:  {ladoRect}{Environment.NewLine}";
        }

        public override bool eliminarPoligon(ClBd bd, int id)
        {
            string xsql = $"DELETE FROM Triangles_Rectangles WHERE id_Poligon={id}";
            return bd.executarOrdre(xsql);
        }

        public override bool getPoligons(ClBd bd, int id)
        {
            bool xb = false;
            DataSet xdset = new DataSet();
            string xsql = $"SELECT * FROM Triangles_Rectangles WHERE id_Poligon={id}";

            if (bd.getDades(xsql, xdset) && xdset.Tables[0].Rows.Count > 0)
            {
                nom = xdset.Tables[0].Rows[0]["nom"].ToString();
                baseTriangle = Convert.ToDouble(xdset.Tables[0].Rows[0]["base"]);
                altura = Convert.ToDouble(xdset.Tables[0].Rows[0]["altura"]);
                ladoRect = (int)(xdset.Tables[0].Rows[0]["ladoRect"]);
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
