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

        List<Modalidade> listaModalidade = new List<Modalidade>();

        public Form8()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            Modalidade conMod = new Modalidade();
            textBox1.Enabled = false;
            MySqlDataReader r = conMod.consultartodasModal();
            while (r.Read())
            {
                dataGridView1.Rows.Add(r["descricaoModalidade"].ToString());
            }
            DAOConexao.con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int idModalidadeEscolhida = 0;
            String mod = textBox1.Text;
            String professor = textBox2.Text;
            String dia = textBox3.Text;
            String hora = maskedTextBox1.Text;


            
            Modalidade modalidadeEscolhida = new Modalidade(mod);
            MySqlDataReader r = modalidadeEscolhida.consultartodasModal();

            while(r.Read())
            {
                string descricao = r["descricaoModalidade"].ToString();
                float preco = (float) r["precoModalidade"];
                int qtde_alunos = (int)r["qtdeAlunos"];
                int qtde_aulas = (int)r["qtdeAulas"];
                int id = (int) r["idEstudio_Modalidade"];
                Modalidade modalidade = new Modalidade(id, descricao,  preco,  qtde_alunos, qtde_aulas);

                listaModalidade.Add(modalidade);
            }

            DAOConexao.con.Close();

            idModalidadeEscolhida = listaModalidade[dataGridView1.CurrentCell.RowIndex].Id;

            Turma turma = new Turma(idModalidadeEscolhida, professor, dia, hora);
            if (turma.verificaTurma() == false) {
            
            if (turma.cadastrarTurma())
            {
                MessageBox.Show("Turma cadastrada com sucesso!");
                limpar();
            }
                else
            {
                MessageBox.Show("Falha ao cadastrar Turma!");
            }
            } else
            {
                MessageBox.Show("Turma ja existente..");
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e) 
        {
           
                String modalidadeescolhida = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox1.Text = modalidadeescolhida;

        }
    }
}
