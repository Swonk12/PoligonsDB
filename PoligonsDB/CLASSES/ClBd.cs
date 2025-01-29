using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PoligonsDB.CLASSES
{
    public class ClBd
    {
        // PROPIETATS
        //
        // Per a millorar la seguretat i per a il·lustrar l'us de GET i SET en les propietats, la cadena de connexió serà una propietat "dual" 
        // La validarem en el SETTER i, si és correcta, la guardarem desencriptada en la variable privada _cadenaConnexio.
        // Internament, la classe farà les operacions amb _cadenaConnexio que, com que és privada, no serà visible des de fora de la classe.
        // Des de fora de la classe només serà accessible la propietat pública (la que no té el guionet) i, com que el GETTER l'encripta, no es podrà veure el valor desencriptat.
        // 
        // Avantatges d'utilitzar propietat amb GET i SET enlloc d'utilitzar variables.
        //      Control de l'accés - El setter permet validar les dadees.
        //      Encapsulament - Si volem fer canvis sobre els requeriments d'aquesta propietat només cal fer-los en el GETTER i/o SETTER i això no implicarà haver de fer canvis a la interfície (el Form).
        //      Millora de la lectura del codi: Les propietats fan que el codi sigui més clar i permeten afegir lògica sense haver de canviar l'ús de la classe 
        //
        private String _cadenaConnexio;
        public string cadenaConnexio
        {
            get => encriptarText(_cadenaConnexio);
            set
            {
                if (validarCadenaConnexioEncriptada(desencriptarText(value)))
                {
                    _cadenaConnexio = desencriptarText(value);
                }
                else
                {
                    throw new ArgumentException("La cadena de connexió no és vàlida");
                }
            }
        }

        // més propietats
        SqlConnection dbConnexio { get; set; }        // Permet establir la connexió amb SQL Server
        SqlDataAdapter dbAdaptador { get; set; }      // El DataAdapter és l'intermediari que executarà les instruccions SQL a la base de dades  


        // NO HI HA CONSTRUCTOR PERÒ CALDRÀ HAVER POSAT LA CADENA DE CONNEXIÓ A LA PROPIETAT PÚBLICA CORRESPONENT

        #region --- MÈTODES PÚBLICS DE LA CLASSE ---
        public Boolean testConnexio()
        {
            // comprovem si tenim connexió amb la BD
            Boolean xb = false;

            if (cadenaConnexio == "null")
            {
                MessageBox.Show("No s'ha introduït cadena de connexió", "ERROR - testConnexio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if ((dbConnexio == null) || (dbConnexio.State != ConnectionState.Open))
                {
                    try
                    {
                        dbConnexio = new SqlConnection(_cadenaConnexio);
                        xb=obrirConnexio();
                    }
                    catch (Exception excp)
                    {
                        MessageBox.Show(excp.Message, "Excepció - testConnexio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    xb = true;
                }
            }
            return xb;
        }

        public Boolean obrirConnexio()
        {
            Boolean xb=false;

            try
            {
                if (dbConnexio != null)
                {
                    dbConnexio.Open();
                    xb = (dbConnexio.State == ConnectionState.Open);
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "Excepció - obrirConnexio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return xb;
        }

        public Boolean hihaConnexio()
        {
            return (dbConnexio != null && dbConnexio.State == ConnectionState.Open);
        }

        public SqlConnection getConnexio()
        {
            return dbConnexio;
        }

        public Boolean getDades(String xsql, DataSet xdset)
        {
            Boolean xb = false;

            try
            {
                dbAdaptador = new SqlDataAdapter(xsql, dbConnexio);
                xdset.Tables.Clear();
                dbAdaptador.Fill(xdset);
                xb = true;
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "Excepció - getDades", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return xb;
        }

        public void tancarConnexio()
        {
            dbConnexio.Close();
        }

        public Boolean executarOrdre(String xsql)
        {
            Boolean xb = false;
            SqlCommand xcommand = new SqlCommand(xsql, dbConnexio);

            try
            {
                xcommand.ExecuteNonQuery();
                xb = true;
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "Excepció - ferOperacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return xb;
        }
        #endregion

        #region ---- ALTRES FUNCIONS O MÈTODES ---
        private Boolean validarCadenaConnexioEncriptada(String xcadena)
        {
            // comprovem que la cadena tingui el Data Source, l'Initial Catalog i l'Integrated Security

            return(xcadena.StartsWith("Data Source=") && xcadena.Contains("Initial Catalog=") && xcadena.Contains("Integrated Security="));
        }

        private string encriptarText(string text)
        {
            // ProtectedData és una classe de .NET que pertany a System.Security.Cryptography;
            // Permet encriptar un text basant-se en el perfil de l'usuari de Windows que té la sessió (DataProtectionScope.CurrentUser)
            // o encriptar-lo basant-se en un perfil de la màquina (DataProtectionScope.LocalMachine).
            // En el primer cas només l'usuari d'aquesta sessió podrà desencriptar el text i, en el segon, qualsevol usuari d'aquest Windows.
            byte[] data = Encoding.UTF8.GetBytes(text);
            byte[] encriptat = ProtectedData.Protect(data, null, DataProtectionScope.LocalMachine);
            return Convert.ToBase64String(encriptat);
        }

        private string desencriptarText(string textEncriptat)
        {
            byte[] data = Convert.FromBase64String(textEncriptat);
            byte[] desencriptat = ProtectedData.Unprotect(data, null, DataProtectionScope.LocalMachine);
            return Encoding.UTF8.GetString(desencriptat);
        }
        #endregion
    }
}
