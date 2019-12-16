using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

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
            NpgsqlConnection connexion;
            connexion = new NpgsqlConnection("server=localhost;Port=5433;database=Gedimat;user id=powertom2;pwd=.Genius22.");

            // ouverture de la connexion
            connexion.Open();
            foreach (Client C in lesC)
            {
                NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.res_partner(company_id, signup_token, name, display_name, street, " +
                    "city, zip, phone, mobile, email, customer, signup_type, active) " +
                    "VALUES (1, @code, @raison_soc, @raison_soc, @rue, @ville, @cp, @tel, @fax, @email, true, @reglement, @actif)", connexion);
                cmd.Parameters.AddWithValue("@code", C.GetCode());
                cmd.Parameters.AddWithValue("@raison_soc", C.GetRaisonSoc());
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
