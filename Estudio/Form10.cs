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
    public partial class Form10 : Form
    {
        public void limpar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            maskedTextBox1.Text = "";

        }

        List<Modalidade> listaModalidade = new List<Modalidade>();

        public Form10()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            Modalidade con_mod = new Modalidade();

            MySqlDataReader r = con_mod.consultartodasModal();
            while (r.Read())
                dataGridView1.Rows.Add(r["descricaoModalidade"].ToString());
            DAOConexao.con.Close();
        }

        private void Form10_Load(object sender, EventArgs e)
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
            if (textBox1.Text == "")
            {
                MessageBox.Show("Selecione uma modalidade!");
            }
            else
            {
                int idModalidadeEscolhida = 0;
                String mod = textBox1.Text;
                String professor = textBox2.Text;
                String dia = textBox3.Text;
                String hora = maskedTextBox1.Text;



                Modalidade modalidadeEscolhida = new Modalidade(mod);
                MySqlDataReader r = modalidadeEscolhida.consultartodasModal();

                while (r.Read())
                {
                    string descricao = r["descricaoModalidade"].ToString();
                    float preco = (float)r["precoModalidade"];
                    int qtde_alunos = (int)r["qtdeAlunos"];
                    int qtde_aulas = (int)r["qtdeAulas"];
                    int id = (int)r["idEstudio_Modalidade"];
                    Modalidade modalidade = new Modalidade(id, descricao, preco, qtde_alunos, qtde_aulas);

                    listaModalidade.Add(modalidade);
                }

                DAOConexao.con.Close();

                idModalidadeEscolhida = listaModalidade[dataGridView1.CurrentCell.RowIndex].Id;

                Turma turma = new Turma(idModalidadeEscolhida, professor, dia, hora);
                if (turma.verificaTurma() == false)
                {
                    if (turma.atualizarTurma(textBox1.Text))
                        MessageBox.Show("Turma atualizada");
                    else
                        MessageBox.Show("Erro!");
                } else {
                    MessageBox.Show("Erro durante a verificação!");
                }
            }
        }
    

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Text = "";


            String modalidadeescolhida = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = modalidadeescolhida;

            string a = textBox1.Text;
            Modalidade modal = new Modalidade(a);
            MySqlDataReader r = modal.consultarModal();



            r.Read();

            int id = (int)r["idEstudio_Modalidade"];


            

            DAOConexao.con.Close();

            Turma turma = new Turma(id);
            MySqlDataReader h = turma.consultarTurma();

            while (h.Read())
            {


                textBox2.Text = h["professorTurma"].ToString();
                textBox3.Text = h["diasemanaTurma"].ToString();
                maskedTextBox1.Text = h["horaTurma"].ToString();
                textBox4.Text = h["nalunosmatriculadosTurma"].ToString();
            }


            DAOConexao.con.Close();

        }

        

        private void dataGridView1_RowHeadersWidthSizeModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
