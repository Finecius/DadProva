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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if (DAOConexao.getConexao("143.106.241.3", "cl202204","cl202204","V1n!180806"))
                Console.WriteLine("Conectado");
            else
                Console.WriteLine("Erro de conexão");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tipo = DAOConexao.Login(textBox1.Text, textBox2.Text);
            if (tipo == 0)
            {
                MessageBox.Show("Erro!");
                
            }
            if(tipo==1)
            {
                
                groupBox1.Visible = false;
                menuStrip1.Enabled = true;
            }
            if (tipo == 2)
            {
                
                groupBox1.Visible = false;
                menuStrip1.Enabled = true;
                cadastrarLoginToolStripMenuItem.Enabled = false;
                cadastrarToolStripMenuItem.Enabled = false;
                cadastrarToolStripMenuItem1.Enabled = false;
                excluirToolStripMenuItem.Enabled = false;
                excluirToolStripMenuItem1.Enabled = false;

            }
                

        }

        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        { 

        }

        private void cadastrarLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.MdiParent = this;
            form2.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cadastrarAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.MdiParent = this;
            form3.Show();
        }

        private void exlcuirAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.MdiParent = this;
            form4.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

     

  
        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.MdiParent = this;
            form5.Show();
        }

        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.MdiParent = this;
            form7.Show();
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.MdiParent = this;
            form6.Show();
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.MdiParent = this;
            form8.Show();
        }

        private void excluirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.MdiParent = this;
            form9.Show();
        }

        private void consultarAtualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.MdiParent = this;
            form10.Show();
        }

        private void consultarAlunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.MdiParent = this;
            form11.Show();
        }

        private void cadastrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
            form12.MdiParent = this;
            form12.Show();
        }

        private void excluirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            form13.MdiParent = this;
            form13.Show();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();
            form14.MdiParent = this;
            form14.Show();
        }
    }
}
