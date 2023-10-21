using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    public partial class Form6 : Form
    {
        MySqlDataReader r;
       List <Modalidade> listamodal = new List<Modalidade>();

        public Form6()
        {
           
            InitializeComponent();
            comboBox();
           
            
        }
        public void comboBox()
        {
            Modalidade cad = new Modalidade();
            r = cad.consultartodasModal();
            comboBox1.Items.Clear();

            while (r.Read())
            {
                string desc = r["descricaoModalidade"].ToString();
                float preco = (float)r["precoModalidade"];
                int qtdeAlunos = (int)r["qtdeAlunos"];
                int qtdeAulas = (int)r["qtdeAulas"];

                comboBox1.Items.Add(r["descricaoModalidade"].ToString());
                listamodal.Add(new Modalidade(desc, preco, qtdeAlunos, qtdeAulas));
            }

            DAOConexao.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (listamodal[comboBox1.SelectedIndex].excluirModal()) 
            {
                MessageBox.Show("Cadastro excluido com sucesso");
            }
            else
            {
                MessageBox.Show("Erro na exclusão");
            }

            comboBox1.SelectedIndex = -1;
            comboBox();
        }
    }


   
    
}
