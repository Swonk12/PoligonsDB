using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoligonsDB.CLASSES.SUBCLASSES
{
    internal class ClRombes : ClPoligons
    {
        public string nom { get; set; }
        public double diagonalMayor { get; set; }
        public double diagonalMenor { get; set; }
        public double area { get; set; }
        public double perimetre { get; set; }
        public int color { get; set; }

        public ClRombes(ClBd xbd, int xid) : base(xbd, xid)
        {
            getPoligons(xbd, xid);
        }

        public ClRombes(ClBd xbd, string xnom, double xdiagonalMayor, double xdiagonalMenor, double xarea, double xperimetre, int xcolor)
            : base(xbd, xnom, xdiagonalMayor, xdiagonalMenor, xarea, xperimetre, xcolor)
        {
            string xsql = $"INSERT INTO Rombes (id_Poligon, nom, diagonal_mayor, diagonal_menor, area, perimetre, color) " +
                          $"VALUES({id_Poligon}, '{xnom}', {xdiagonalMayor}, {xdiagonalMenor}, {xarea}, {xperimetre}, {xcolor})";

            if (xbd.executarOrdre(xsql))
            {
                MessageBox.Show($"Rombe inserit correctament a la base de dades", "TOT BÉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No s'ha pogut inserir el rombe a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override string dadesPoligon()
        {
            return $"Nom: {nom}{Environment.NewLine}" +
                   $"Diagonal Major: {diagonalMayor}{Environment.NewLine}" +
                   $"Diagonal Menor: {diagonalMenor}{Environment.NewLine}" +
                   $"Àrea: {area}{Environment.NewLine}" +
                   $"Perímetre: {perimetre}{Environment.NewLine}";
        }

        public override bool eliminarPoligon(ClBd bd, int id)
        {
            string xsql = $"DELETE FROM Rombes WHERE id_Poligon={id}";
            return bd.executarOrdre(xsql);
        }

        public override bool getPoligons(ClBd bd, int id)
        {
            bool xb = false;
            DataSet xdset = new DataSet();
            string xsql = $"SELECT * FROM Rombes WHERE id_Poligon={id}";

            if (bd.getDades(xsql, xdset) && xdset.Tables[0].Rows.Count > 0)
            {
                nom = xdset.Tables[0].Rows[0]["nom"].ToString();
                diagonalMayor = Convert.ToDouble(xdset.Tables[0].Rows[0]["diagonal_mayor"]);
                diagonalMenor = Convert.ToDouble(xdset.Tables[0].Rows[0]["diagonal_menor"]);
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
