using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git_Gedimat
{
    public class Erreur
    {
        //Déclaration des variables
        private int code;
        private string libelle;
        List<Client> lesClientsValide = new List<Client>();
        List<Client> lesClientsNonValide = new List<Client>();
        List<Client> ClientMailManquant = new List<Client>();

        //Constructeur
        public Erreur(int unCode, string unLibelle)
        {
            this.code = unCode;
            this.libelle = unLibelle;
        }

        /// <summary>
        /// Méthode qui verifie si les entreprises sont encore en activité
        /// </summary>
        /// <param name="lesClients">liste de clients</param>
        /// <returns>liste de clients dont l'activité a été vérifié</returns>
        public List<Client> verifActif(List<Client> lesClients)
        {
            List<Client> ClientActifCheck = new List<Client>();
            foreach (Client c in lesClients)
            {
                bool unActif = c.GetActif();
                if (unActif == true)
                {
                    ClientActifCheck.Add(c);
                }
                else
                {
                    c.SetRefus("Client non actif");
                    this.lesClientsNonValide.Add(c);
                }
            }
            return ClientActifCheck;
        }

        /// <summary>
        /// Méthode qui vérifie que le code du client n'est pas vide. S'il ne l'est pas, elle vérifie aussi
        /// qu'il n'est pas utilisé plusieurs fois.
        /// </summary>
        /// <param name="lesClients">liste des clients actif</param>
        /// <returns>liste de client dont les code est valide</returns>
        public List<Client> verifCode(List<Client> ClientActifCheck)
        {
            List<Client> codeClientCheck = new List<Client>();
            foreach (Client c in ClientActifCheck)
            {
                int count = 0;
                string unCode = c.GetCode();
                if(unCode == "")
                {
                    c.SetRefus("Code du client vide");
                    this.lesClientsNonValide.Add(c);
                }
                else
                {
                    foreach (Client c1 in ClientActifCheck)
                    {
                        string unCode1 = c1.GetCode();
                        if (unCode == unCode1)
                        {
                            count += +1;
                        }
                    }
                    if(count == 1)
                    {
                        c.SetValide(true);
                    }
                    else
                    {
                        c.SetRefus("Code de client en double");
                        this.lesClientsNonValide.Add(c);
                    }
                }
                if(c.GetValide() == true)
                {
                    codeClientCheck.Add(c);
                }
            }
            return codeClientCheck;
        }

        /// <summary>
        ///  Méthode qui vérifie que le mail contient bien un @ et l'extension de l'adresse necessaire (.fr / .com / .org / .net / .eu).
        ///  Elle vérifie aussi le mail est utilisé plusieurs fois par differents clients.
        /// </summary>
        /// <param name="codeClientCheck">liste de client dont le code à été verifier</param>
        /// <returns>liste de client dont la mail est verifier</returns>
        public List<Client> verifMail(List<Client> uneListCodeClientCheck)
        {
            List<Client> mailClientCheck = new List<Client>();
            foreach (Client c in uneListCodeClientCheck)
            {
                c.SetValide(false);
                int count = 0;
                string unMail = c.GetEmail();
                string unTel = c.GetTel();
                if (unMail == "")
                {
                    this.ClientMailManquant.Add(c);
                    mailClientCheck.Add(c);
                }
                else
                {
                    if(unMail.Contains("@"))
                    {
                        if(unMail.Contains(".fr") || unMail.Contains(".com") || unMail.Contains(".org") || unMail.Contains(".eu") || unMail.Contains(".net"))
                        {
                            foreach(Client c1 in uneListCodeClientCheck)
                            {
                                string unMail1 = c1.GetEmail();
                                if (unMail1 != "")
                                {
                                    if (unMail == unMail1)
                                    {
                                        count += +1;
                                    }
                                }
                            }
                            if (count == 1)
                            {
                                c.SetValide(true);
                            }
                            else
                            {
                                c.SetRefus("Mail du client en double");
                                this.lesClientsNonValide.Add(c);
                            }
                        }
                        else
                        {
                            c.SetRefus("Format du mail non valide");
                            this.lesClientsNonValide.Add(c);
                        }
                    }
                    else
                    {
                        c.SetRefus("Format du mail non valide");
                        this.lesClientsNonValide.Add(c);
                    }
                    if (c.GetValide() == true)
                    {
                        mailClientCheck.Add(c);
                    }
                }
            }
            return mailClientCheck;
        }

        /// <summary>
        /// Méthode qui verifie que le numéro de telephone est 10 nombres + 4 espaces (soit 14 caracteres).
        /// Elle verifie aussi si le numero de telephone est utilisé par plusieurs clients.
        /// </summary>
        /// <param name="uneListMailCheck">liste de client dont le tel à été verifier</param>
        public void verifTel (List<Client> uneListMailCheck)
        {
            foreach (Client c in uneListMailCheck)
            {
                c.SetValide(false);
                int count = 0;
                string unTel = c.GetTel();
                if (unTel == "")
                {
                    c.SetRefus("Client sans telephone");
                    this.lesClientsNonValide.Add(c);
                }
                else
                {
                    if (unTel.Length == 14)
                    {
                        foreach (Client c1 in uneListMailCheck)
                        {
                            string unTel1 = c1.GetTel();
                            if (unTel1 != "")
                            {
                                if (unTel == unTel1)
                                {
                                    count += +1;
                                }
                            }
                        }
                        if (count == 1)
                        {
                            c.SetValide(true);
                        }
                    }
                    else
                    {
                        c.SetRefus("Format du numero de telephone non valide");
                        this.lesClientsNonValide.Add(c);
                    }
                    if (c.GetValide() == true)
                    {
                        this.lesClientsValide.Add(c);
                    }
                }
            }
        }

        /// <summary>
        /// Méthode qui récupère la liste des clients valide
        /// </summary>
        /// <returns>liste de clients valide</returns>
        public List<Client> GetLesClientsValides()
        {
            return this.lesClientsValide;
        }

        /// <summary>
        /// méthode qui récupère la liste des clients non valide
        /// </summary>
        /// <returns>liste de clients non valide</returns>
        public List<Client> GetLesClientsNonValides()
        {
            return this.lesClientsNonValide;
        }


        public List<Client> GetLesClientSansMail()
        {
            return this.ClientMailManquant;
        }
    }
}