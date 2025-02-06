using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PoligonsDB.CLASSES
{
    public abstract class ClPoligons
    {
        public int id_Poligon { get; set; }
        public string tipus { get; set; }

        // Comunes
        public double area { get; set; }
        public double perimetre {  get; set; }
        public int color { get; set; }


        public ClPoligons(ClBd xbd, int xid)
        {
            id_Poligon = xid;
        }

        public ClPoligons(ClBd xbd, String xtipus)
        {
            DataSet xdset = new DataSet();
            String xsql = $"INSERT INTO Poligons(tipus) VALUES(''{tipus}')";

            if (xbd.executarOrdre(xsql))
            {
                xsql = "SELECT TOP 1 Id FROM Poligons ORDER BY Id DESC";
                xbd.getDades(xsql, xdset);
                if (xdset.Tables[0].Rows.Count == 0)
                {
                    id_Poligon = -1;
                    MessageBox.Show("No s'ha pogut recuperar l'Id del nou poligon", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    id_Poligon = (int)xdset.Tables[0].Rows[0].ItemArray[0];
                    tipus = "";
                }
            }

        }

        // Pentagon
        public ClPoligons(ClBd xbd, string tipo , int num , string xnom, double xlado, double xapotema, double xarea, double xperimetre, int xcolor)
        {

            DataSet xdset = new DataSet();
            String xsql = $"INSERT INTO {tipo} (id_Poligon, nom, lado, apotema, area, perimetre, color)  VALUES({num}, '{xnom}', {xlado.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture).Replace(',', '.')}, {xapotema.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture).Replace(',', '.')}, {xarea.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture).Replace(',', '.')}, {xperimetre.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture).Replace(',', '.')}, {xcolor})";


            if (xbd.executarOrdre(xsql))
            {
                // Si la inserció ha anat bé recuperem l'Id generat perquè el necessitem per a fer la inserció en la taula de la subclasse
                // ALERTA!!!! En un entorn multiusuari, aquesta operació s'hauria de fer amb una TRANSACTION per a garantir que el resultat és correcte
                xsql = "SELECT TOP 1 id_Poligon FROM Poligons ORDER BY id_Poligon DESC";
                xbd.getDades(xsql, xdset);
                if (xdset.Tables[0].Rows.Count == 0)
                {
                    id_Poligon = -1;
                    MessageBox.Show("No s'ha pogut recuperar l'Id del nou poligons", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    id_Poligon = (int)xdset.Tables[0].Rows[0].ItemArray[0];
                }
            }
        }

        // Quadrat
        public ClPoligons(ClBd xbd, string xnom, double xlado, double xarea, double xperimetre, int xcolor)
        {

            DataSet xdset = new DataSet();
            String xsql = $"INSERT INTO Quadrats (id_Poligon, nom, lado, area, perimetre, color)  VALUES({id_Poligon}, {xnom}, {xlado}, {xarea}, {xperimetre}, {xcolor})";

            if (xbd.executarOrdre(xsql))
            {
                // Si la inserció ha anat bé recuperem l'Id generat perquè el necessitem per a fer la inserció en la taula de la subclasse
                // ALERTA!!!! En un entorn multiusuari, aquesta operació s'hauria de fer amb una TRANSACTION per a garantir que el resultat és correcte
                xsql = "SELECT TOP 1 Id FROM Poligon ORDER BY Id DESC";
                xbd.getDades(xsql, xdset);
                if (xdset.Tables[0].Rows.Count == 0)
                {
                    id_Poligon = -1;
                    MessageBox.Show("No s'ha pogut recuperar l'Id del nou poligons", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    id_Poligon = (int)xdset.Tables[0].Rows[0].ItemArray[0];
                }
            }
        }

        // Rectangles
        public ClPoligons(ClBd xbd, double xalto, string xnom, double xancho, double xarea, double xperimetre, int xcolor)
        {
            DataSet xdset = new DataSet();
            String xsql = $"INSERT INTO Rectangles (id_Poligon, nom, ancho, alto, area, perimetre, color) " +
                          $"VALUES({id_Poligon}, '{xnom}', {xancho}, {xalto}, {xarea}, {xperimetre}, {xcolor})";

            if (xbd.executarOrdre(xsql))
            {
                xsql = "SELECT TOP 1 Id FROM Poligons ORDER BY Id DESC";
                xbd.getDades(xsql, xdset);
                if (xdset.Tables[0].Rows.Count == 0)
                {
                    id_Poligon = -1;
                    MessageBox.Show("No s'ha pogut recuperar l'Id del nou poligon", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    id_Poligon = (int)xdset.Tables[0].Rows[0].ItemArray[0];
                }
            }
        }

        // Cercle
        public ClPoligons(ClBd xbd, double xradio, string xnom,  double xarea, double xperimetre, int xcolor)
        {
            DataSet xdset = new DataSet();
            string xsql = $"INSERT INTO Cercles (id_Poligon, nom, radio, area, perimetre, color) " +
                          $"VALUES({id_Poligon}, '{xnom}', {xradio}, {xarea}, {xperimetre}, {xcolor})";

            if (xbd.executarOrdre(xsql))
            {
                // Recuperar el Id generado
                xsql = "SELECT TOP 1 Id FROM Poligons ORDER BY Id DESC";
                xbd.getDades(xsql, xdset);
                if (xdset.Tables[0].Rows.Count == 0)
                {
                    id_Poligon = -1;
                    MessageBox.Show("No s'ha pogut recuperar l'Id del nou cercle", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    id_Poligon = (int)xdset.Tables[0].Rows[0].ItemArray[0];
                }
            }
        }

        // Elipse
        public ClPoligons(ClBd xbd, int xcolor, string xnom, double xradioMayor, double xradioMenor, double xarea, double xperimetre)
        {
            DataSet xdset = new DataSet();
            string xsql = $"INSERT INTO Elipses (id_Poligon, nom, radio_mayor, radio_menor, area, perimetre, color) " +
                          $"VALUES({id_Poligon}, '{xnom}', {xradioMayor}, {xradioMenor}, {xarea}, {xperimetre}, {xcolor})";

            if (xbd.executarOrdre(xsql))
            {
                // Recuperar el Id generado
                xsql = "SELECT TOP 1 Id FROM Poligons ORDER BY Id DESC";
                xbd.getDades(xsql, xdset);
                if (xdset.Tables[0].Rows.Count == 0)
                {
                    id_Poligon = -1;
                    MessageBox.Show("No s'ha pogut recuperar l'Id de la nova el·lipse", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    id_Poligon = (int)xdset.Tables[0].Rows[0].ItemArray[0];
                }
            }
        }

        // Triangle_Rectangle

        // Triangle_Isosceles
        public ClPoligons(ClBd xbd, string xnom, double xbase, double xaltura, double xarea ,int xcolor, double xperimetre)
        {
            // Crear un DataSet para manejar la consulta
            DataSet xdset = new DataSet();

            // 1. Primero, insertamos el triángulo isósceles en la tabla Triangles_Isosceles
            string xsql = $"INSERT INTO Triangles_Isosceles (id_Poligon, nom, base, altura, area, perimetre, color) " +
                          $"VALUES({id_Poligon}, '{xnom}', {xbase}, {xaltura}, {xarea}, {xperimetre}, {xcolor})";

            if (xbd.executarOrdre(xsql))
            {
                // 2. Si la inserción fue exitosa, recuperamos el id_Poligon generado
                xsql = "SELECT TOP 1 Id FROM Poligons ORDER BY Id DESC";
                xbd.getDades(xsql, xdset);

                if (xdset.Tables[0].Rows.Count == 0)
                {
                    // Si no se recupera el id, mostramos un mensaje de error
                    id_Poligon = -1;
                    MessageBox.Show("No se ha podido recuperar el Id del nuevo polígono", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Si se recupera el id correctamente, asignamos el id_Poligon
                    id_Poligon = (int)xdset.Tables[0].Rows[0].ItemArray[0];
                }
            }
            else
            {
                // Si la inserción falla, mostramos un mensaje de error
                MessageBox.Show("No se pudo insertar el triángulo isósceles en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        public String dadesComunes()
        {
            // retorna una string amb les dades comunes a tots els personatges
            String xs = "";
            string xcolor;

            if (color == 1)
            {
                xcolor = "TRUE";
            }else
            {
                xcolor = "FALSE";
            }

            xs = "Area: " + area.ToString() + Environment.NewLine +
                "Perimetre: " + perimetre.ToString() + Environment.NewLine +
                "Color: " + xcolor + Environment.NewLine;
            return xs;
        }
        
        // els mètodes abstract s'hauran de definir obligatòriament en cada una de les subclasses
        public abstract String dadesPoligon();
        public abstract Boolean eliminarPoligon(ClBd bd, int id);
        public abstract Boolean getPoligons(ClBd bd, int id);
        public abstract Boolean inserirPoligon();
    }
}