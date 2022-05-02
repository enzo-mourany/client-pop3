using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientPOP3
{
    public partial class ClientPOP3 : Form
    {
        public ClientPOP3()
        {
            InitializeComponent();

            WriteAffichage("Démarrage du client POP3 - Version 2021");

            /* Connexion au serveur POP3 */
            Communication.Initialise(this);
            WriteAffichage("Connecté au serveur - Prêt !");

            /* Identification */
            Communication.Identification();

            /* envoi STAT pour recuperer nb messages */
            Communication.Stat();
        }

        #region Méthodes d'écriture dans les zones d'affichage utilisateur et verbose (debug)
        public void WriteAffichage(string line)
        {
            listBoxAffichage.Items.Add(line);
            // permet "l'auto-scroll" : défiler l'affichage de la fenêtre jusqu'à la dernière ligne
            listBoxAffichage.SelectedIndex = listBoxAffichage.Items.Count - 1;
            listBoxAffichage.SelectedIndex = -1;
        }

        public void WriteVerbose(string line)
        {
            listBoxVerbose.Items.Add(line);
            // permet "l'auto-scroll" : défiler l'affichage de la fenêtre jusqu'à la dernière ligne
            listBoxVerbose.SelectedIndex = listBoxVerbose.Items.Count - 1;
            listBoxVerbose.SelectedIndex = -1;
        }
        #endregion

        private void buttonQUIT_Click(object sender, EventArgs e)
        {
            Communication.Quit();
            MessageBox.Show("Fin du client");
            this.Dispose();
        }

        private void buttonSTAT_Click(object sender, EventArgs e)
        {
            Communication.Stat();
        }

        private void buttonLIST_Click(object sender, EventArgs e)
        {
            Communication.List();
        }

    }
}
