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
        private int modalidade, qtdAl, idTurma;

        public int Modalidade { get => modalidade; set => modalidade = value; }
        public string Professor { get => professor; set => professor = value; }
        public string Dia_semana { get => dia_semana; set => dia_semana = value; }
        public string Hora { get => hora; set => hora = value; }
        public int QtdAl { get => qtdAl; set => qtdAl = value; }
        public int IdTurma { get => idTurma; set => idTurma = value; }

        public Turma(string professor, string dia_semana, string hora, int modalidade, int qtdAl, int idTurma) : this(professor, dia_semana)
        {
            this.hora = hora;
            this.modalidade = modalidade;
            this.qtdAl = qtdAl;
            this.idTurma = idTurma;
        }

        public Turma(int modalidade, string professor, string dia_semana, string hora, int qtdAl)
        {
            this.modalidade = modalidade;
            this.professor = professor;
            this.dia_semana = dia_semana;
            this.hora = hora;
            this.qtdAl = qtdAl;
        }

        public Turma(int modalidade, string dia_da_semana)
        {
            this.modalidade = modalidade;
            this.dia_semana = dia_da_semana;
            
        }

        public Turma(String dia_semana, String hora)
        {
            this.dia_semana = dia_semana;
            this.hora = hora;
        }

        public Turma(int modalidade)
        {
            this.modalidade = modalidade;
        }


        public Turma()
        {
            
        }

        public Turma(int modalidade, string professor, string dia_semana, string hora)
        {
            Modalidade = modalidade;
            Professor = professor;
            Dia_semana = dia_semana;
            Hora = hora;
        }

        public Turma(string professor, string dia_semana, string hora)
        {
            Professor = professor;
            Dia_semana = dia_semana;
            Hora = hora;
        }

        public bool cadastrarTurma()
        {
            bool cad = false;
            try
            {
                DAOConexao.con.Open();
                MySqlCommand cadastar = new MySqlCommand("insert into Estudio_Turma (idModalidade, professorTurma, diasemanaTurma, horaTurma) values (" + modalidade + ", '" + professor + "', '" + dia_semana + "', '" + hora + "')", DAOConexao.con);
                cadastar.ExecuteNonQuery();
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

        public bool verificaTurma()
        {
            bool existe = false;
            try
            {
                DAOConexao.con.Open();
                MySqlCommand ex = new MySqlCommand("select * from Estudio_Turma where idModalidade = " + modalidade + " and diasemanaTurma = '" + dia_semana + "' and horaTurma = '" + hora + "'", DAOConexao.con);
                MySqlDataReader exr = ex.ExecuteReader();
                while (exr.Read())
                {
                    existe = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAOConexao.con.Close();
            }
            return existe;
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
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Turma WHERE idModalidade = '" + modalidade + "';", DAOConexao.con);
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
