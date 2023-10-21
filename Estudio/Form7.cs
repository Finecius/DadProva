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
    public partial class Form7 : Form
    {
        List<Modalidade> listamodal = new List<Modalidade>();
        MySqlDataReader r;
        public Form7()
        {
            InitializeComponent();
            comboBox();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        
        }
        public void comboBox()
        {
            Modalidade cad = new Modalidade();
            r = cad.consultartodasModal();
            comboBox1.Items.Clear();

            while (r.Read())
            {
                int id =(int) r["idEstudio_Modalidade"];
                string desc = r["descricaoModalidade"].ToString();
                float preco = (float)r["precoModalidade"];
                int qtdeAlunos = (int)r["qtdeAlunos"];
                int qtdeAulas = (int)r["qtdeAulas"];

                comboBox1.Items.Add(r["descricaoModalidade"].ToString());
                listamodal.Add(new Modalidade(id,desc, preco, qtdeAlunos, qtdeAulas));
            }

            DAOConexao.con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id = listamodal[comboBox1.SelectedIndex].Id;
            String desc = comboBox1.SelectedItem.ToString();
            float preco = float.Parse(textBox1.Text);
            int alun =  int.Parse(textBox2.Text);
            int aula = int.Parse(textBox3.Text);


            Modalidade modal = new Modalidade(id,desc, preco, alun, aula);


            if (modal.atualizarModalidade())
            {
                MessageBox.Show("Cadastro atualizado");
            }
            else
            {
                MessageBox.Show("Erro na atualização!");
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Enabled=true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                if (e.KeyChar == 13)
                {
                    textBox1.Text = listamodal[comboBox1.SelectedIndex].Preco.ToString();
                    textBox2.Text =listamodal[comboBox1.SelectedIndex].Qtde_alunos.ToString();
                    textBox3.Text = listamodal[comboBox1.SelectedIndex].Qtde_aulas.ToString();

                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                }
            }
         }
    }
}
