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
    }
}
