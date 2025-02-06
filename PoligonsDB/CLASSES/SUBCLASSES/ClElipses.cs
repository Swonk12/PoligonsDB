using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoligonsDB.CLASSES.SUBCLASSES
{
    using System;
    using System.Data;
    using System.Windows.Forms;

    namespace PoligonsDB.CLASSES.SUBCLASSES
    {
        internal class ClElipses : ClPoligons
        {
            public string nom { get; set; }
            public double radio_mayor { get; set; }
            public double radio_menor { get; set; }
            public double area { get; set; }
            public double perimetre { get; set; }
            public int color { get; set; }

            public ClElipses(ClBd xbd, int xid) : base(xbd, xid)
            {
                getPoligons(xbd, xid);
            }

            public ClElipses(ClBd xbd, int xcolor, string xnom, double xradioMayor, double xradioMenor, double xarea, double xperimetre)
                : base(xbd, xcolor, xnom, xradioMayor, xradioMenor, xarea, xperimetre)
            {
                string xsql = $"INSERT INTO Elipses (id_Poligon, nom, radio_mayor, radio_menor, area, perimetre, color) " +
                              $"VALUES({id_Poligon}, '{xnom}', {xradioMayor}, {xradioMenor}, {xarea}, {xperimetre}, {xcolor})";

                if (xbd.executarOrdre(xsql))
                {
                    MessageBox.Show($"Elipse inserida correctament a la base de dades", "TOT BÉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"No s'ha pogut inserir l'el·lipse a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public override string dadesPoligon()
            {
                return $"Nom: {nom}{Environment.NewLine}" +
                       $"Radi Major: {radio_mayor}{Environment.NewLine}" +
                       $"Radi Menor: {radio_menor}{Environment.NewLine}" +
                       $"Àrea: {area}{Environment.NewLine}" +
                       $"Perímetre: {perimetre}{Environment.NewLine}";
            }

            public override bool eliminarPoligon(ClBd bd, int id)
            {
                string xsql = $"DELETE FROM Elipses WHERE id_Elipse={id}";
                return bd.executarOrdre(xsql);
            }

            public override bool getPoligons(ClBd bd, int id)
            {
                bool xb = false;
                DataSet xdset = new DataSet();
                string xsql = $"SELECT * FROM Elipses WHERE id_Elipse={id}";

                if (bd.getDades(xsql, xdset) && xdset.Tables[0].Rows.Count > 0)
                {
                    nom = xdset.Tables[0].Rows[0]["nom"].ToString();
                    radio_mayor = Convert.ToDouble(xdset.Tables[0].Rows[0]["radio_mayor"]);
                    radio_menor = Convert.ToDouble(xdset.Tables[0].Rows[0]["radio_menor"]);
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
}