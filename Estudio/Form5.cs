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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String descricao = textBox1.Text;
            float preco = float.Parse(textBox2.Text);
            int qtdeAlunos = int.Parse(textBox3.Text);
            int qtedeAulas = int.Parse(textBox4.Text);

            
            Modalidade modalidade = new Modalidade(descricao, preco, qtdeAlunos, qtedeAulas);

         
            
                if (modalidade.cadastrarModal())
                    MessageBox.Show("Cadastro realizado com sucesso");
                else
                    MessageBox.Show("Erro no cadastro");
            
            

        }
    }
}
