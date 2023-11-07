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
        List<Modalidade> listaModalidade = new List<Modalidade>();
        List<Turma> listaTurma = new List<Turma>();
        List<Aluno> listaAluno = new List<Aluno>();
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
        int n;
        private void button1_Click(object sender, EventArgs e)
        {
             

            String nomeModal = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            String nomeAluno = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();

            int  idTurma, idModal;
            String idAluno;

            Modalidade modalidade = new Modalidade(nomeModal);
            MySqlDataReader r = modalidade.consultarModal();

            while (r.Read())
            {
                idModal = (int)r["idEstudio_Modalidade"];
                string descricao = r["descricaoModalidade"].ToString();
                float preco = (float)r["precoModalidade"];
                int qtde_alunos = (int)r["qtdeAlunos"];
                int qtde_aulas = (int)r["qtdeAulas"];
             
                Modalidade modalidade1 = new Modalidade(idModal, descricao, preco, qtde_alunos, qtde_aulas);

                listaModalidade.Add(modalidade1);
            }

            DAOConexao.con.Close();

            Turma turma = new Turma(listaModalidade[dataGridView1.CurrentCell.RowIndex].Id);
            
            MySqlDataReader h = turma.consultarTurma();
            while (h.Read())
            {
                idTurma = (int)h["idEstudio_Turma"];
                int idModalidade = (int)h["idModalidade"];
                String professorTurma = h["professorTurma"].ToString();
                String diasemanaTurma = h["diasemanaTurma"].ToString();
                String horaTurma = h["horaTurma"].ToString();
                int nalunosmatriculadosTurma = (int)h["nalunosmatriculadosTurma"];

                Turma turma1 = new Turma(professorTurma, diasemanaTurma, horaTurma, idModalidade, nalunosmatriculadosTurma, idTurma);

                listaTurma.Add(turma1);
                n = idModalidade;
            }

            DAOConexao.con.Close();

            
            Aluno aluno = new Aluno(nomeAluno);
            MySqlDataReader i = aluno.consultarAlunoCompleto();
            while (i.Read())
            {
                idAluno = i["CPFAluno"].ToString();

                Aluno aluno1 = new Aluno(idAluno);

                listaAluno.Add(aluno1);
            }

            DAOConexao.con.Close();

            TurmaAluno cad = new TurmaAluno(listaTurma[listaTurma.IndexOf(turma)].IdTurma, listaAluno[dataGridView2.CurrentCell.RowIndex].getCPF()); 

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
