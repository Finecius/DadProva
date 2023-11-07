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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            Modalidade con_mod = new Modalidade();
            Turma con_tur = new Turma();

            MySqlDataReader r = con_mod.consultartodasModal();
            while (r.Read())
                comboBox1.Items.Add(r["descricaoModalidade"].ToString());
            DAOConexao.con.Close();

            MySqlDataReader h = con_tur.consultartodasTurma();
            while (h.Read())
            {
                comboBox2.Items.Add(h["diasemanaTurma"].ToString());
                comboBox3.Items.Add(h["horaTurma"].ToString());
            }
            DAOConexao.con.Close();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String modal = (comboBox1.SelectedItem.ToString());
            String dia = comboBox2.SelectedItem.ToString();
            String hora = comboBox3.SelectedItem.ToString();

            Turma turma = new Turma(dia, hora);
            Modalidade modalidade = new Modalidade(modal);

            if (turma.excluirTurma())
                MessageBox.Show("Turma excluída com sucesso");
            else
                MessageBox.Show("Erro na exclusão");
        }
    }
}
