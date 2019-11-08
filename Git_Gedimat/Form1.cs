using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using Npgsql;
//using NpgsqlTypes;

namespace Git_Gedimat
{
    public partial class Form1 : Form
    {
        //Collection d'objet Client
        List<Client> lesCli;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // appel de la méthode ChargerLesDepartements de la classe Passerelle
            lesCli = Passerelle.ChargerLesClients();
        }

        private void ChargerListCli()
        {
            list_cli.Items.Clear();
            foreach (Client c in this.lesCli)
            {
                string rsCli = c.GetRaisonSoc();
                list_cli.Items.Add(rsCli);
            }
        }

        private void Actualiser_Click(object sender, EventArgs e)
        {
            ChargerListCli();
        }

        private void Envoyer_Click(object sender, EventArgs e)
        {
            DAOClients.AjouterClient(lesCli);
        }
    }
}
