using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    class Turma
    {

        private string professor, dia_semana, hora;
        private int modalidade, idTurma;

        public string Professor { get => professor; set => professor = value; }
        public string Dia_semana { get => dia_semana; set => dia_semana = value; }
        public string Hora { get => hora; set => hora = value; }
        public int Modalidade { get => modalidade; set => modalidade = value; }
        public int IdTurma { get => idTurma; set => idTurma = value; }


        public Turma (int modalidade, string professor, string dia_semana, string hora)
        {
            this.modalidade = modalidade;
            this.professor = professor;
            this.dia_semana = dia_semana;
            this.hora = hora;
      

        }

        public Turma(int idTurma)
        {
            this.idTurma    =   idTurma;
        }

        public Turma(string dia_semana, string hora)
        {
            
            this.dia_semana = dia_semana;
            this.hora = hora;
        }

        public Turma()
        {
            
        }





        public bool cadastrarTurma()
        {
            bool cad = false;
            try
            {
                DAOConexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Turma (idModalidade, professorTurma, diasemanaTurma, horaTurma) values ('" + modalidade + "','" + professor + "','" + dia_semana + "','" + hora + "');", DAOConexao.con);
                insere.ExecuteNonQuery();   
                cad = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAOConexao.con.Close();
            }
            return cad;
        }


        public bool excluirTurma()
        {
            bool exc = false;
            try
            {
                Modalidade modalidade = new Modalidade();
                
                DAOConexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("update Estudio_Turma t inner join Modalidade m on m.idEstudio_Modalidade  = t.idModalidade AND t.diasemanaTurma = '" +dia_semana+ "' AND t.horaTurma = '" +hora+ "' set t.ativa = 0;", DAOConexao.con);
                exclui.ExecuteNonQuery();
                exc = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAOConexao.con.Close();
            }
            return exc;
        }
        public MySqlDataReader consultartodasTurma()
        {
            MySqlDataReader resultado = null;

            try
            {
                DAOConexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Turma WHERE ativa = 1;", DAOConexao.con);
                resultado = consulta.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return resultado;
        }

        public MySqlDataReader consultarTurma()
        {
            MySqlDataReader result = null;

            try
            {
                DAOConexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Turma WHERE idModalidade = '" + idTurma + "';", DAOConexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        public bool atualizarTurma(string desc)
        {
            bool exc = false;
            try
            {
                DAOConexao.con.Open();
                MySqlCommand atualiza = new MySqlCommand("update Estudio_Turma t inner join Modalidade m on m.idEstudio_T = t.idModalidade  set  t.professorTurma= '" + professor + "', t.diasemanaTurma = '" + dia_semana + "', t.horaTurma = '" + hora + "' where m.descricaoModalidade = '" +desc  + "';", DAOConexao.con);
                atualiza.ExecuteNonQuery();
                exc = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAOConexao.con.Close();
            }
            return exc;
        }
    }
}
