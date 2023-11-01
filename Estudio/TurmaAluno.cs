using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    class TurmaAluno
    {
        private int idTurmaAluno, idTurma, idAluno;

        private String descricaoModalidade, nomeAluno;


        public int IdTurmaAluno { get => idTurmaAluno; set => idTurmaAluno = value; }
        public int IdTurma { get => idTurma; set => idTurma = value; }
        public int IdAluno { get => idAluno; set => idAluno = value; }
        public string DescricaoModalidade { get => descricaoModalidade; set => descricaoModalidade = value; }
        public string NomeAluno { get => nomeAluno; set => nomeAluno = value; }

        public TurmaAluno(int idTurma, int idAluno)
        {
         
            this.idTurma = idTurma;
            this.idAluno = idAluno;
        }

        public TurmaAluno(string descricaoModalidade, string nomeAluno)
        {
            this.descricaoModalidade = descricaoModalidade;
            this.nomeAluno = nomeAluno;
        }

        public TurmaAluno()
        {

        }


        public bool cadastrarAlunoTurma()
        {
            bool resultado = false;
            try
            {
                DAOConexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Turma_Aluno (codigoTurma, codigoAluno) values (" + idTurma + ", " + idAluno+");");
                insere.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAOConexao.con.Close();
            }

            return resultado;
        }



    }
}
