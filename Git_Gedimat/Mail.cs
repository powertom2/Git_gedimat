using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Git_Gedimat
{
    public class Mail
    {
        //Déclaration des variables
        private string from;
        private string fromname;
        private string to;
        protected string smtpUsername = "erreur.visualstudio2@gmail.com";
        protected string smtpPasswrod = "Anthony#21042000";
        private string host = "smtp.gmail.com";
        private int port = 587;
        private string sujet = "Erreur de lecture du fichier csv";
        string body = "Voici un récapitulatif d'insertions des clients :";

        //constructeur d'un objet mail
        public Mail(string unEnvoyeur, string nomEnvoyeur, string unReceveur)
        {
            this.from = unEnvoyeur;
            this.fromname = nomEnvoyeur;
            this.to = unReceveur;
        }

        //méthodes permettant de récupérer des données provenant de cette classe
        #region methode getteur
        public string GetFrom()
        {
            return this.from;
        }

        public string GetTo()
        {
            return this.to;
        }
        public string GetFromName()
        {
            return this.fromname;
        }
        #endregion

        /// <summary>
        /// Méthode qui permet d'envoyer un mail
        /// </summary>
        /// <param name="unReceveur">le destinataire du mail</param>
        /// <param name="ClientValide">liste des clients valide</param>
        /// <param name="ClientNonValide">liste des clients non valide</param>
        /// <param name="ClientMailManquant">liste de client valide mais sans mail</param>
        public void EnvoieDuMail(string unReceveur, List<Client> ClientValide, List<Client> ClientNonValide, List<Client> ClientMailManquant)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(this.from, this.fromname);
            message.To.Add(new MailAddress(unReceveur));
            message.Subject = this.sujet;
            message.Body = this.body;
            message.Body += "\nIl y a " + ClientValide.Count + " clients qui ont été insérés.";
            message.Body += "\nIl y a " + ClientNonValide.Count + " clients qui n'ont pas été insérés.";
            message.Body += "\nIl y a " + ClientMailManquant.Count + " client qui ont été insérés dont leur mail n'a pas été indiqué.";

            SmtpClient client = new SmtpClient(host);

            //Pass SMTP credentials
            client.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPasswrod);

            //Enable SSL encryption
            client.EnableSsl = true;
            client.Port = this.port;
            client.Send(message);
        }
    }
}
