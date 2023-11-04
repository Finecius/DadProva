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
    public partial class Form12 : Form
    {
        public Form12()
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

            Aluno conAlu = new Aluno();
            MySqlDataReader h = conAlu.consultartodosAlunoCompleto();
            while (h.Read())
            {
                dataGridView2.Rows.Add(h["nomeAluno"].ToString());
            }
            DAOConexao.con.Close();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            String nomeModal = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            String nomeAluno = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();

            int  idTurma, idModal;
            String idAluno;

            Modalidade modalidade = new Modalidade(nomeModal);
            MySqlDataReader r = modalidade.consultarModal();
            r.Read();
            idModal = (int)r["idEstudio_Modalidade"];
            r.Close();

            DAOConexao.con.Close();

            Turma turma = new Turma(idModal);
            MySqlDataReader h = turma.consultarTurma();
            h.Read();
            idTurma = (int)h["idEstudio_Turma"];
            h.Close();

            DAOConexao.con.Close();

            
            Aluno aluno = new Aluno(nomeAluno);
            MySqlDataReader i = aluno.consultarAlunoCompleto();
            i.Read();
            idAluno = i["CPFAluno"].ToString();
            i.Close();

            DAOConexao.con.Close();

            TurmaAluno cad = new TurmaAluno(idTurma, idAluno);

            if (cad.cadastrarAlunoTurma())
            {
                MessageBox.Show("Aluno cadastrado na Turma");
            }
            else
                MessageBox.Show("Erro ");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
