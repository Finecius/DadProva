using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            byte[] foto = ConverterFotoParaByteArray();
            Aluno aluno = new Aluno(txtCPF.Text, txtNome.Text, txtEndereco.Text, txtNumero.Text, txtBairro.Text, txtComplemento.Text, txtCEP.Text, txtCidade.Text, txtEstado.Text, txtTelefone.Text, txtEmail.Text, foto);
             byte[] ConverterFotoParaByteArray()
            {
                using (var stream = new System.IO.MemoryStream())
                {
                    pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //deslocamento de bytes em relação ao parâmetro original
                    //redefine a posição do fluxo para a gravação
                    stream.Seek(0, System.IO.SeekOrigin.Begin);
                    byte[] bArray = new byte[stream.Length];
                    //Lê um bloco de bytes e grava os dados em um buffer (stream)
                    stream.Read(bArray, 0, System.Convert.ToInt32(stream.Length));
                    return bArray;
                }
            }
            if (aluno.consultarAluno())
            {
               
                if (aluno.atualizarAluno())
                    MessageBox.Show("Atualizado com sucesso!");
                else
                    MessageBox.Show("Erro na atualização!");
            }
            else
            {
                if (aluno.cadastrarAluno())
                    MessageBox.Show("Cadastro realizado com sucesso");
                else
                    MessageBox.Show("Erro no cadastro");
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aluno aluno = new Aluno(txtCPF.Text);
            if (e.KeyChar == 13)
            {

                
                if (aluno.verificaCPF(txtCPF.Text))
                {
                    if (aluno.consultarAluno())
                    {
                        MessageBox.Show("Aluno já cadastrado!");

                       


                        txtNome.Enabled = false;
                        txtEndereco.Enabled = false;
                        txtNumero.Enabled = false;
                        txtBairro.Enabled = false;
                        txtComplemento.Enabled = false;
                        txtCEP.Enabled = false;
                        txtCidade.Enabled = false;
                        txtEstado.Enabled = false;
                        txtTelefone.Enabled = false;
                        txtEmail.Enabled = false;
                        
                    }
                    else
                      txtNome.Focus();
                 
                }
                else
                    MessageBox.Show("CPF inválido");
            }


        }

        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Title = "Abrir Foto";
                dialog.Filter = "JPG (*.jpg)|*.jpg" + "|All files (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image = new Bitmap(dialog.OpenFile());

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possivel carregar a foto: " + ex.Message);
                    }
                }
                dialog.Dispose();
            
        }
    }
}
