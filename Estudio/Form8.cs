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
    public partial class Form8 : Form
    {
        public void limpar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            maskedTextBox1.Text = "";
            
        }

        public Form8()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            Modalidade conMod = new Modalidade();
            MySqlDataReader r = conMod.consultartodasModal();
            while (r.Read())
            {
                dataGridView1.Rows.Add(r["descricaoModalidade"].ToString());
            }
            DAOConexao.con.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modalidade modalidadeEscolhida = new Modalidade(textBox1.Text);
            MySqlDataReader r = modalidadeEscolhida.consultarModal();
            r.Read();


            int idModalidadeEscolhida = int.Parse(r["idEstudio_Modalidade"].ToString());
            String professor = textBox2.Text;
            String dia = textBox3.Text;
            String hora = maskedTextBox1.Text;

            Turma turma = new Turma(idModalidadeEscolhida, professor, dia, hora);
            DAOConexao.con.Close();

            if (turma.cadastrarTurma())
            {
                MessageBox.Show("Turma cadastrada com sucesso!");
                limpar();
            }
            else
            {
                MessageBox.Show("Falha ao cadastrar Turma!");
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) 
        {
           
                String modalidadeescolhida = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox1.Text = modalidadeescolhida;

        }

        private void dataGridView1_RowHeadersWidthSizeModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }
    }
}
