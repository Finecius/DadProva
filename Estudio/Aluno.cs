using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    class Aluno
    {
       

        #region
        private String CPF;
        private String Nome;
        private String Rua;
        private String Numero;
        private String Bairro;
        private String Complemento;
        private String CEP;
        private String Cidade;
        private String Estado;
        private String Telefone;
        private String Email;
        private byte[] Foto;
        private bool Ativo;

       
        public Aluno(string cpf, string nome, string rua, string numero, string bairro, string complemento, string cep, string cidade, string estado, string telefone, string email)
        {
            setCPF(cpf);
            setNome(nome);
            setRua(rua);
            setNumero(numero);
            setBairro(bairro);
            setComplemento(complemento);
            setCEP(cep);
            setCidade(cidade);
            setEstado(estado);
            setTelefone(telefone);
            setEmail(email);
         
        }

        public Aluno(string nome, string rua, string numero, string bairro, string complemento, string cep, string cidade, string estado, string telefone, string email)
        {
            
            setNome(nome);
            setRua(rua);
            setNumero(numero);
            setBairro(bairro);
            setComplemento(complemento);
            setCEP(cep);
            setCidade(cidade);
            setEstado(estado);
            setTelefone(telefone);
            setEmail(email);

        }

        public Aluno() { }
        public String getNumero() {
        return this.Numero;
    }

    public void setNumero(String numero) {
        Numero = numero;
    }
        public Aluno(string cpf)
        {
            setCPF(cpf);
        }

        public String getCPF()
        {
            return this.CPF;
        }

        public void setCPF(String CPF)
        {
            this.CPF = CPF;
        }

        public String getNome()
        {
            return this.Nome;
        }

        public void setNome(String nome)
        {
            this.Nome = nome;
        }

        public String getRua()
        {
            return this.Rua;
        }

        public void setRua(String rua)
        {
            this.Rua = rua;
        }

        public String getBairro()
        {
            return this.Bairro;
        }

        public void setBairro(String bairro)
        {
            this.Bairro = bairro;
        }

        public String getComplemento()
        {
            return this.Complemento;
        }

        public void setComplemento(String complemento)
        {
            this.Complemento = complemento;
        }

        public String getCEP()
        {
            return this.CEP;
        }

        public void setCEP(String CEP)
        {
            this.CEP = CEP;
        }

        public String getCidade()
        {
            return this.Cidade;
        }

        public void setCidade(String cidade)
        {
            this.Cidade = cidade;
        }

        public String getEstado()
        {
            return this.Estado;
        }

        public void setEstado(String estado)
        {
            this.Estado = estado;
        }

        public String getTelefone()
        {
            return this.Telefone;
        }

        public void setTelefone(String telefone)
        {
            this.Telefone = telefone;
        }

        public String getEmail()
        {
            return this.Email;
        }

        public void setEmail(String email)
        {
            this.Email = email;
        }

        public byte[] getFoto()
        {
            return this.Foto;
        }

        public void setFoto(byte[] foto)
        {
            this.Foto = foto;
        }

        public bool isAtivo()
        {
            return this.Ativo;
        }

        public void setAtivo(bool ativo)
        {
            this.Ativo = ativo;
        }

        public bool consultarAluno()
        {
            bool existe = false;
            try
            {
                DAOConexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Aluno WHERE CPFAluno= '" + CPF + "'", DAOConexao.con);
                MySqlDataReader resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    existe = true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAOConexao.con.Close();
            }
            return existe;
        }
     
        public bool cadastrarAluno()
        {
            bool cad = false;
            try
            {
                DAOConexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Aluno (CPFAluno, nomeAluno, ruaAluno, numeroAluno, bairroAluno, complementoAluno, CEPAluno, cidadeAluno, estadoAluno, telefoneAluno, emailAluno) values ('" + CPF + "','" + Nome + "','" + Rua + "','" + Numero + "','" + Bairro + "','" + Complemento + "','" + CEP + "','" + Cidade + "','" + Estado + "','" + Telefone + "','" + Email + "')",DAOConexao.con);
                insere.ExecuteNonQuery();
                cad = true;

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAOConexao.con.Close();
            }
            return cad;
        } 

        public bool excluirAluno()
        {
            bool exc = false;
            try
            {
                DAOConexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("delete * from Estudio_Aluno where CPFAluno = '" + CPF + "'", DAOConexao.con);
                exclui.ExecuteNonQuery();
                exc = true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAOConexao.con.Close();
            }
            return exc;
        }

        public bool atualizarAluno()
        {
            bool exc = false;
            try
            {
                DAOConexao.con.Open();
                Console.WriteLine("update Estudio_Aluno set nomeAluno = '" + Nome + "', ruaAluno = '" + Rua + "', numeroAluno = '" + Numero + "', bairroAluno = '" + Bairro + "' complementoAluno ='" + Complemento + "',CEPAluno='" + CEP + "', cidadeAluno='" + Cidade + "', estadoAluno='" + Estado + "', telefoneAluno = '" + Telefone + "', emailAluno = '" + Email + "' where CPFAluno = '" + CPF + "'");
                MySqlCommand atualiza = new MySqlCommand("update Estudio_Aluno set nomeAluno = '" + Nome + "', ruaAluno = '" + Rua + "', numeroAluno = '" + Numero + "', bairroAluno = '" + Bairro + "', complementoAluno ='" + Complemento + "',CEPAluno='" + CEP + "', cidadeAluno='" + Cidade + "', estadoAluno='" + Estado + "', telefoneAluno = '" + Telefone + "', emailAluno = '" + Email + "' where CPFAluno = '" + CPF + "'", DAOConexao.con);
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

        #endregion
    }
}
