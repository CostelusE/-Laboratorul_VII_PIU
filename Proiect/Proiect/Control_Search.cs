using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Proiect
{
    public partial class Control_Search : UserControl
    {
        IStocareData adminPersoane = StocareFactory.GetAdministratorStocare();
        public Control_Search()
        {

            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnCauta.BringToFront();
            lblNume1.BringToFront();
            lblPrenume1.BringToFront();
            txtPrenume1.BringToFront();
            txtNume1.BringToFront();
            label1.SendToBack();
            lblSuccesAdaugare.SendToBack();
            txtNume1.Enabled = true;
            txtPrenume1.Enabled = true;
            txtNume1.Clear();
            txtPrenume1.Clear();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agenda s = adminPersoane.GetPersoana(txtNume1.Text, txtPrenume1.Text);
            if (s != null)
            {
                
                btnModifica.BringToFront();
                label5.BringToFront();
                label6.BringToFront();
                textNNume.BringToFront();
                textNPrenume.BringToFront();
                txtNume1.Enabled = false;
                txtPrenume1.Enabled = false;
                btnModificaPers.BringToFront();
            }
            else
            {
                label1.BringToFront();
                btnCauta.SendToBack();
                lblNume1.SendToBack();
                lblPrenume1.SendToBack();
                txtPrenume1.SendToBack();
                txtNume1.SendToBack();
            }
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            rtbNumeComplet.Clear();
            ArrayList AGENDA = adminPersoane.GetPersoane();
            foreach (Agenda pers in AGENDA)
            {
                rtbNumeComplet.AppendText(pers.Nume_Complet());
                rtbNumeComplet.SelectionTabs = new int[] { 25 };
                rtbNumeComplet.AppendText(Environment.NewLine);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (textNNume.Text == "" || textNPrenume.Text == "")
            {
                if (textNNume.Text == "")
                    label6.ForeColor = Color.Red;
                else
                    label6.ForeColor = Color.Black;
                if (textNPrenume.Text == "")
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;
            }
            else
            {
                Agenda s = adminPersoane.GetPersoana(txtNume1.Text, txtPrenume1.Text);
                s.CautaSiModifica(textNNume.Text, textNPrenume.Text);
                adminPersoane.UpdateStudent(s);
                lblSuccesAdaugare.BringToFront();
                btnModificaPers.SendToBack();
                textNNume.SendToBack();
                textNPrenume.SendToBack();
                btnModifica.SendToBack();
                btnCauta.SendToBack();
                lblNume1.SendToBack();
                lblPrenume1.SendToBack();
                txtPrenume1.SendToBack();
                txtNume1.SendToBack();
                label6.SendToBack();
                label5.SendToBack();
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnModificaPers.SendToBack();
            txtNume1.Enabled = true;
            txtPrenume1.Enabled = true;
            btnModifica.SendToBack();
            label5.SendToBack();
            label6.SendToBack();
            textNNume.SendToBack();
            textNPrenume.SendToBack();
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;

        }
    }
}
