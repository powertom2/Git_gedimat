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
        private string host = "";
        private int port = 587;
        private string sujet = "Erreur de lecture du fichier csv";
        string body = "Les clients suivants n'ont pas été ajoutés à la base";

        //constructeur d'un objet mail
        public Mail(string unEnvoyeur, string nomEnvoyeur, string unReceveur)
        {
            this.from = unEnvoyeur;
            this.fromname = nomEnvoyeur;
            this.to = unReceveur;
        }

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

        public void EnvoieDuMail(string unReceveur, List<Client> ClientNonValide)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(this.from, this.fromname);
            message.To.Add(new MailAddress(unReceveur));
            message.Subject = this.sujet;
            message.Body = this.body;
            foreach(Client c in ClientNonValide)
            {
                message.Body += "\n" + c.GetRaisonSoc();
            }

            SmtpClient client = new SmtpClient(host);

            //Pass SMTP credentials
            client.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPasswrod);

            //Enable SSL encryption
            client.EnableSsl = true;
            client.Port = this.port;

            //Essaie d'envoie du mail. Montre le statu dans la console
            try
            {
                Console.WriteLine("Tentative d'envoie du mail ...");
                client.Send(message);
                Console.WriteLine("Mail envoyé!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Le mail n'a pas été envoyé");
                Console.WriteLine("Message d'erreur : " + ex.Message);
            }
        }
    }
}
