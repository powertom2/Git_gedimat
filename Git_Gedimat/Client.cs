using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git_Gedimat
{
    public class Client
    {
        #region attribut
        private string code;
        private string raison_soc;
        private string adresse;
        private string code_postal;
        private string ville;
        private string tel;
        private string fax;
        private string email;
        private string actif;
        private string reglement;
        #endregion

        #region constructeur
        public Client(string unCode, string uneRaison, string uneAdresse, string unCP, string uneVille, string unTel, string unFax, string unEmail, string unActif, string unReglement)
        {
            this.code = unCode;
            this.raison_soc = uneRaison;
            this.adresse = uneAdresse;
            this.code_postal = unCP;
            this.ville = uneVille;
            this.tel = unTel;
            this.fax = unFax;
            this.email = unEmail;
            this.actif = unActif;
            this.reglement = unReglement;
        }
        #endregion

        #region methode
        //Liste des récupérateur d'info
        public string GetCode()
        {
            return this.code;
        }

        public string GetRaisonSoc()
        {
            return this.raison_soc;
        }

        public string GetAdresse()
        {
            return this.adresse;
        }

        public string GetCodePostal()
        {
            return this.code_postal;
        }

        public string GetVille()
        {
            return this.ville;
        }

        public string GetTel()
        {
            return this.tel;
        }

        public string GetFax()
        {
            return this.fax;
        }

        public string GetEmail()
        {
            return this.email;
        }

        public string GetReglement()
        {
            return this.reglement;
        }

        public string GetActif()
        {
            return this.actif;
        }
        #endregion
    }
}
