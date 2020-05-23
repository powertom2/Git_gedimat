using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Git_Gedimat
{
    static class DAOClients
    {
        public static void AjouterClient(List<Client> lesC)
        {
            // initialisation des paramètres de la chaine de connexion :
            // - URL du serveur Mysql
            // - identifiants de connexion
            // - nom de la base de données
            // instanciation d’une connexion au serveur MySQL
            MySqlConnection connexion;
            connexion = new MySqlConnection("server=localhost;database=negomat;user id=root;pwd=");

            // ouverture de la connexion
            connexion.Open();
            foreach (Client C in lesC)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO client(code, raison_soc, rue, ville, code_postal, tel, fax, email, reglement, actif) " +
                    "VALUES (@code, @raison_soc, @rue, @ville, @cp, @tel, @fax, @email, @reglement, @actif)", connexion);
                cmd.Parameters.AddWithValue("@code", C.GetCode());
                cmd.Parameters.AddWithValue("@raison_soc", C.GetRaisonSoc());
                cmd.Parameters.AddWithValue("@rue", C.GetAdresse());
                cmd.Parameters.AddWithValue("@ville", C.GetVille());
                cmd.Parameters.AddWithValue("@cp", C.GetCodePostal());
                cmd.Parameters.AddWithValue("@tel", C.GetTel());
                cmd.Parameters.AddWithValue("@fax", C.GetFax());
                cmd.Parameters.AddWithValue("@email", C.GetEmail());
                cmd.Parameters.AddWithValue("@reglement", C.GetReglement());
                cmd.Parameters.AddWithValue("@actif", C.GetActif());
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            connexion.Close();
            // fermeture de la connexion
        }
    }
}
