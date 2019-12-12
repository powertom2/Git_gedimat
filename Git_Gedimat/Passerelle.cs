using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Git_Gedimat
{
    static class Passerelle
    {
        /// <summary>
        /// Méthode qui lit et récupère les données d'un fichier csv
        /// </summary>
        /// <returns> une liste de clients</returns>
        public static List<Client> ChargerLesClients()
        {
            // déclaration et instanciation d'une collection de Clients
            List<Client> lesClients = new List<Client>();
            try
            {
                // création d'un objet StreamReader qui pointe sur le fichier Negomat_Client.csv
                StreamReader fic = new StreamReader("Negomat_Client.csv");
                string ligne = fic.ReadLine();  // lecture de la 1ère ligne du fichier
                while (ligne != null)           // tant qu'on a pas atteint la fin du fichier
                {
                    if (ligne != "CODE;RAISON SOCIALE;ADRESSE;CP;VILLE;TEL.;FAX; EMAIL;ACTIF;REGLEMENT")
                    {
                        // "eclatement" de la ligne à l'aide du séparateur -> on obtient un tableau
                        string[] tab = ligne.Split(';');
                        // récupération des différentes valeurs 
                        string code = tab[0];
                        string raisonSoc = tab[1];
                        string adresse = tab[2];
                        string codePostal = tab[3];
                        string ville = tab[4];
                        string tel = tab[5];
                        string fax = tab[6];
                        string email = tab[7].ToLower();
                        string actif = tab[8];
                        string reglement = tab[9];

                        if (tel.Contains("."))
                        {
                            tel = tel.Replace(".", " ");
                        }
                        if (tel.Contains("-"))
                        {
                            tel = tel.Replace("-", " ");
                        }

                        // construction d'un objet Client à partir des valeurs  
                        Client c = new Client(code, raisonSoc, adresse, codePostal, ville, tel, fax, email, actif, reglement);

                        // ajout de l'objet Client à la collection lesClients 
                        lesClients.Add(c);
                    }
                    // lecture de la ligne suivante
                    ligne = fic.ReadLine();
                }
                fic.Close();    // fermeture du fichier
            }
            // capture et traitement en cas d'exception
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            // renvoi de la collection 
            return lesClients;
        }
    }
}
