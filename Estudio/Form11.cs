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
    public partial class Form11 : Form
    {

        public void limpar()
        {
            txtCPF.Text = "";
            txtNome.Text = "";
            txtNumero.Text = "";
            txtTelefone.Text = "";
            txtEstado.Text = "";
            txtEndereco.Text = "";
            txtEmail.Text = "";
            txtComplemento.Text = "";
            txtCidade.Text = "";
            txtCEP.Text = "";
            txtBairro.Text = "";

        }

        public Form11()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            Aluno con_mod = new Aluno();

            MySqlDataReader r = con_mod.consultartodosAlunoCompleto();
            while (r.Read())
            {
                dataGridView1.Rows.Add(r["nomeAluno"].ToString());
            }
            DAOConexao.con.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtCPF.Text = "";
            txtNome.Text = "";
            txtNumero.Text = "";
            txtTelefone.Text = "";
            txtEstado.Text = "";
            txtEndereco.Text = "";
            txtEmail.Text = "";
            txtComplemento.Text = "";
            txtCidade.Text = "";
            txtCEP.Text = "";
            txtBairro.Text = "";


            String AlunoEscolhido = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtCPF.Text = AlunoEscolhido;

            string a = txtNome.Text;
            Aluno model = new Aluno(a);
            MySqlDataReader r = model.consultarAlunoCompleto();

            while (r.Read())
            {

                txtNome.Text = r["nomeAluno"].ToString();
                txtCPF.Text = r["CPFAluno"].ToString();
                txtEndereco.Text = r["ruaAluno"].ToString();
                txtNumero.Text = r["numeroAluno"].ToString();
                txtBairro.Text = r["bairroAluno"].ToString();
                txtComplemento.Text = r["complementoAluno"].ToString();
                txtCEP.Text = r["CEPAluno"].ToString();
                txtCidade.Text = r["cidadeAluno"].ToString();
                txtEstado.Text = r["estadoAluno"].ToString();
                txtTelefone.Text = r["telefoneAluno"].ToString();
                txtEmail.Text = r["emailAluno"].ToString();

            }


            DAOConexao.con.Close();

        }
    }
}
