using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Projet2022_Article
{
    public partial class Form1 : Form
    {
        double prixArticle = 0, pourcentage;
        int index=0, supp;
        Article a;

        public Form1()
        {
            InitializeComponent();
        }

        public void enregistrer()
        {
            if (txtcode.Text == "" || txtDesignation.Text == "" || Convert.ToString(cbCategorie.SelectedItem)=="" ||  txtprix.Text == "" || (cb.Checked == true && txtpercent.Text == ""))
            {
                MessageBox.Show("Veuillez remplir tous les champs svp!");
            }
            else if (double.TryParse(txtprix.Text, out prixArticle) == false)
            {
                MessageBox.Show("Veuillez remplir le champ prix correctement svp!");
            }
            else if (cb.Checked == true && double.TryParse(txtpercent.Text, out pourcentage) == false)
            {
                MessageBox.Show("Veuillez remplir le champ pourcentage correctement svp!");
            }

            else
            {
                foreach (Article art in Program.collectionArticle)
                {
                  
                    
                    if (txtcode.Text == art.Code)
                    {
                        MessageBox.Show("Impossible de l'enregistrer!");
                        return ;
                    }
                   
                }
                
                    a = new Article(txtcode.Text, txtDesignation.Text, Convert.ToString(cbCategorie.SelectedItem), double.Parse(txtprix.Text), double.Parse(txtprix.Text) * (1 - (double.Parse(txtpercent.Text) / 100)));
                    Program.collectionArticle.Add(a);
                    dg.Rows.Add(txtcode.Text, txtDesignation.Text, Convert.ToString(cbCategorie.SelectedItem), double.Parse(txtprix.Text), double.Parse(txtprix.Text) * (1 - (pourcentage / 100)));
                    pourcentage = 0;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbCategorie.Items.Add("Informatique");
            cbCategorie.Items.Add("Bureautique");
            txtprix.Text = 0.ToString();
            txtpercent.Text = 0.ToString(); 
            txtpercent.Enabled = false;
       

        }

        private void button1_Click(object sender, EventArgs e)
        {
            enregistrer();
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            if (cb.Checked == true)
            {
                txtpercent.Enabled = true;
            }
            else
            {
                txtpercent.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result =MessageBox.Show("Voulez vous vraiment quitter?");
            if(result== DialogResult.OK)
            {
                Close();
            }
        }

        public void supprimer()
        {
            foreach (Article art in Program.collectionArticle)
            {
                

                if (txtcode.Text == art.Code)
                {
                    supp = index;
                   
                    
                }
                index++;
               

            }
            index = 0;
            
            DialogResult result = MessageBox.Show("Voulez vous vraiment supprimer?");
            if (result == DialogResult.OK)
            {
                Program.collectionArticle.RemoveAt(supp);
                dg.Rows.RemoveAt(supp);
            }
            supp = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            supprimer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtcode.Text = "";
            txtDesignation.Text= "";
            cbCategorie.SelectedItem = null;
            txtprix.Text = 0.ToString();
            cb.Checked = false;
            txtpercent.Enabled = false;
            txtpercent.Text = 0.ToString();

        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcode.Text=Convert.ToString(dg.SelectedRows[0].Cells[0].Value);
            txtDesignation.Text = Convert.ToString(dg.SelectedRows[0].Cells[1].Value);
            cbCategorie.SelectedItem = Convert.ToString(dg.SelectedRows[0].Cells[2].Value);
            txtprix.Text = Convert.ToString(dg.SelectedRows[0].Cells[3].Value);
            if (dg.SelectedRows[0].Cells[3].Value == dg.SelectedRows[0].Cells[4].Value)
           {
               cb.Checked = false;
               txtpercent.Enabled = false;
               txtpercent.Text = 0.ToString();
           }
           else
           {
               txtpercent.Text = Convert.ToString(((double.Parse(Convert.ToString(dg.SelectedRows[0].Cells[3].Value)) - double.Parse(Convert.ToString(dg.SelectedRows[0].Cells[4].Value))) / double.Parse(Convert.ToString(dg.SelectedRows[0].Cells[3].Value))) * 100);
           }

        }
    }
}
