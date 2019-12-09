﻿using System;
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
        List<Client>lesClientsNonValide = new List<Client>();

        //Constructeur
        public Erreur(int unCode, string unLibelle)
        {
            this.code = unCode;
            this.libelle = unLibelle;
        }

        /// <summary>
        /// Méthode qui vérifie que le code du client n'est pas vide. S'il ne l'est pas, elle vérifie aussi
        /// qu'il n'est pas utilisé plusieurs fois.
        /// </summary>
        /// <param name="lesClients">liste des clients</param>
        /// <returns>liste de client dont les code est valide</returns>
        public List<Client> verifCode(List<Client> lesClients)
        {
            List<Client> codeClientCheck = new List<Client>();
            foreach (Client c in lesClients)
            {
                int count = 0;
                string unCode = c.GetCode();
                if(unCode == "")
                {
                    this.lesClientsNonValide.Add(c);
                }
                else
                {
                    foreach (Client c1 in lesClients)
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
                if (unMail == "")
                {
                    this.lesClientsNonValide.Add(c);
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
                        }
                    }
                    else
                    {
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
    }
}