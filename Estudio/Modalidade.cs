using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    class Modalidade
    {
        private int id;
        private string descricao;
        private float preco;
        private int qtde_alunos, qtde_aulas, ativo;


        public string Descricao { get => descricao; set => descricao = value; }
        public float Preco { get => preco; set => preco = value; }
        public int Qtde_alunos { get => qtde_alunos; set => qtde_alunos = value; }
        public int Qtde_aulas { get => qtde_aulas; set => qtde_aulas = value; }
        public int Ativo { get => ativo; set => ativo = value; }
        public int Id { get => id; set => id = value; }

        public Modalidade(string descricao, float preco, int qtde_alunos, int qtde_aulas)
        {
            this.descricao = descricao;
            this.preco = preco;
            this.qtde_aulas = qtde_aulas;
            this.qtde_alunos = qtde_alunos;
        }
        public Modalidade(int id , string descricao, float preco, int qtde_alunos, int qtde_aulas)
        {
            this.id = id;
            this.descricao = descricao;
            this.preco = preco;
            this.qtde_aulas = qtde_aulas;
            this.qtde_alunos = qtde_alunos;
        }
        public Modalidade(string descricao)
        {
            this.descricao = descricao;
            
        }
        public Modalidade()
        {
        }

        public MySqlDataReader consultarModal()
        {
            MySqlDataReader resultado = null;
         
            try
            {
                DAOConexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Modalidade where descricaoModalidade = '" + descricao + "'", DAOConexao.con);
                 resultado = consulta.ExecuteReader();
             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
      
          
            return resultado;
        }

        public bool cadastrarModal()
        {
            bool cad = false;
            try
            {
                DAOConexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Modalidade (descricaoModalidade, precoModalidade, qtdeAlunos, qtdeAulas,ativa) values ('" + descricao + "','" + preco + "','" + qtde_alunos + "','" + qtde_aulas +"','1')", DAOConexao.con);
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

        public MySqlDataReader consultartodasModal()
        {
            MySqlDataReader resultado = null;
           
            try
            {
                DAOConexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Modalidade WHERE ativa = 1", DAOConexao.con);
                 resultado = consulta.ExecuteReader();
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        
            return resultado;
        }

        public bool atualizarModalidade()
        {
            bool exc = false;
            try
            {
                DAOConexao.con.Open();
               // Console.WriteLine("update Modalidade set  descricaoModalidade= '" + descricao + "', precoModalidade = '" + preco + "', qtdeAlunos = '" + qtde_alunos + "', qtdeAulas = '" + qtde_aulas+ "'");
                MySqlCommand atualiza = new MySqlCommand("update Modalidade set  descricaoModalidade= '" + descricao + "', precoModalidade = '" + preco + "', qtdeAlunos = '" + qtde_alunos + "', qtdeAulas = '" + qtde_aulas + "' where idEstudio_Modalidade = '"+id+"'", DAOConexao.con);
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
        public bool excluirModal()
        {
            bool exc = false;
            try
            {
                DAOConexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("update Modalidade set ativa = 0 where descricaoModalidade  = '" + descricao + "'", DAOConexao.con);
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

    }
}
