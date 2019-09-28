using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using Connection;
using System.IO;
using System.Security.Cryptography;
using CriptoCadastros;
using EsqueceuSenha;

namespace SQLForms
{

    public partial class Form3 : Form
    {

        internal static List<string> Line = new List<string>();

        internal static string text = "";


        public Form3()
        {
           
            InitializeComponent();
        }

       

        private bool Buscar()
        {
            if (textEmail.Text == "")
            {
                VerEmail.Text = "Preencha o campo E-mail.";
                textEmail.Focus();
                return false;
            }
            else
                VerEmail.Text = "*";

            if (textEmail.Text.Trim().Length == 0)
            {
                VerEmail.Text = "Preencha o campo E-mail.";
                textEmail.Focus();
                return false;
            }
            else
                VerEmail.Text = "*";

            if (textEmail.TextLength < 11)
            {
                VerEmail.Text = "E-mail muito pequeno.";
                textEmail.Focus();
                return false;
            }
      

            if(!textEmail.Text.Contains("@gmail.com") && !textEmail.Text.Contains("@hotmail.com"))
            {
                VerEmail.Text = "E-mail inválido.";
                textEmail.Focus();
                return false;
            }


            if (!textEmail.Text.EndsWith("@gmail.com") && !textEmail.Text.EndsWith("@hotmail.com"))
            {
                VerEmail.Text = "E-mail inválido.";
                textEmail.Focus();
                return false;
            }
            bool teste2 = true;
            try
            {
                int senha = int.Parse(textSenha.Text);

            }
            catch (FormatException)
            {
                if (textSenha.Text.Trim().Length == 0)
                {
                    VerSenha.Text = "Preencha o campo senha.";
                    textSenha.Focus();
                    teste2 = false;
                    return false;
                }
                else if (textSenha.Text == "")
                {
                    VerSenha.Text = "Preencha o campo senha.";
                    textSenha.Focus();
                    teste2 = false;
                    return false;
                }
                else
                {
                    VerSenha.Text = "Caracteres incorretos.";
                    textSenha.Focus();
                    teste2 = false;
                    return false;
                }
            }

            if (teste2)
                VerSenha.Text = "*";

            return true;
        }
        private void Busca_Click(object sender, EventArgs e)
        {
           
            Line.Clear();
            var Conectar = new SQLConexao();
            var ObjectConect = Conectar.Conect();
            ObjectConect.Open();
            bool Ok = true;
            bool Ok2 = true;
            bool control = true;

            if (Buscar())
            {
                string LineID = "", LineN = "", LineI = "", LineE = "", LineC = "", LineS = "", LineP = "";
                try
                {

                    do
                    {
                        string Pesq = "Select ID,Nome,Idade,Cidade,Email, Senha, PalavraChave from Cadastros";
                        var ComandoBusca = new SqlCommand(Pesq, ObjectConect);
                        SqlDataReader DataBusca;
                        DataBusca = ComandoBusca.ExecuteReader();
                       
                        while (DataBusca.Read())
                        {
                            LineID = DataBusca.GetValue(0).ToString();
                            LineN = DataBusca.GetValue(1).ToString();
                            LineI = DataBusca.GetValue(2).ToString();
                            LineC = DataBusca.GetValue(3).ToString();
                            LineE = DataBusca.GetValue(4).ToString();
                            LineS = DataBusca.GetValue(5).ToString();
                            LineP = DataBusca.GetValue(6).ToString();

                            int S = int.Parse(textSenha.Text);
                          
                            if (DataBusca.GetValue(4).Equals(Criptografia.Encrypt(textEmail.Text)))
                            {
                                if (!(DataBusca.GetValue(5).Equals(Criptografia.Encrypt(S.ToString()))))
                                {

                                    Ok2 = true;
                                    control = false;

                                    textEmail.Enabled = false;
                                    Ver.ForeColor = Color.Red;
                                    Ver.Text = "Senha incorreta ! Digite novamente.";
                                    textSenha.Clear();
                                    textSenha.Focus();
                                      
                                    
                                }
                                Ok = true;
                                break;
                            }
                            else
                            {
                                Ok = false;
                                Ok2 = false;
                            }
                        }

                        if (!Ok && !Ok2)
                        {
                            control = false;
                            textSenha.Clear();
                            textEmail.Focus();
                            textEmail.Clear();
                            Ver.ForeColor = Color.Red;
                            Ver.Text = "Usuário e Senha incorretos ! Digite novamente.";
                        }
                        DataBusca.Close();
                    }
                    while (!Ok);

                    if (control)
                    {
                        Line.Add(LineID);
                        Line.Add(LineN);
                        Line.Add(LineI);
                        Line.Add(LineC);
                        Line.Add(LineE);
                        Line.Add(LineS);
                        Line.Add(LineP);
                        text = Criptografia.Decrypt(LineN);
                        var Forma4 = new Form4();
                        this.Dispose();
                        Thread.Sleep(3000);
                        Forma4.Visible = true;
                    }



                }
                catch (Exception ex)
                {
                    if (control)
                    {
                        MessageBox.Show("Não foi possível realizar a busca no SQL Server !\n\nErro: " + ex.Message,
                           "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error
                            );
                    }
                }
                finally
                {
                    ObjectConect.Close();
                }

               
            }
                    
        }
       
       

        private void TextNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                textSenha.Focus();
        }

        private void TextSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Busca.Focus();
        }

        private void Limpar_Click(object sender, EventArgs e)
        {
            textEmail.Enabled = true;
            textEmail.Clear();
            textEmail.Focus();
            textSenha.Clear();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "BUSCA NO SQL SERVER";
            this.CenterToScreen();
            this.BackColor = Color.LightBlue;
            VerEmail.ForeColor = Color.Red;
            VerSenha.ForeColor = Color.Red;
            textSenha.MaxLength = 8;
            textSenha.PasswordChar = '*';
            textEmail.MaxLength = 33;
           
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Voce sera enviado para a janela inicial", "CONSULTA CLOSE",
              MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation
              ))
            {
                this.Dispose();
                var Formaone = new Form1();

                Formaone.Visible = true;
            }
            else
                e.Cancel = true;
           
        }

        private void Voltar_Click(object sender, EventArgs e)
        {
            if(DialogResult.OK == MessageBox.Show("    Deseja voltar ? ","RETURN",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk
                ))
            {
                var form1 = new Form1();
                this.Dispose();
                form1.Visible = true;
            }
        }

        private void Esqueci_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            var Esqueceu = new NewPassword();
            this.Dispose();
            Thread.Sleep(3000);
            Esqueceu.Alterar();
        }
    }
}
