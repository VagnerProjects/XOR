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

namespace SQLForms
{
    /// <summary>
    /// Classe principal do software
    /// </summary>
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        //Evento para o botão 'Sair'
        private void Exit_Click(object sender, EventArgs e)
        {
            /*Verifica se o botão clicado na MessageBox é o 'OK'
             * Esse código de verificação se repete outras vezes em todo o App
             */
            if ((DialogResult.OK) == MessageBox.Show("Deseja mesmo sair ?", "EXIT",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk
              ))
            {
                Application.Exit();
            }
        }

        //Propriedades do formulário
        private void Form1_Load(object sender, EventArgs e)
        {
            //Título da form
            this.Text = "SQL SERVER 2019";

            //Cor de fundo
            this.BackColor = Color.LightBlue;

            //Cor da label de boas vindas
            Welcome.ForeColor = Color.Green;

            //Centraliza
            this.CenterToScreen();

            //Impede aumento de tela pela borda e pelo maximizar
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        //Evento do botão 'Cadastro'
        private void Cadastrar_Click(object sender, EventArgs e)
        {
            if((DialogResult.OK)== MessageBox.Show("Abrir ficha de cadastro ?","CADASTRO",
               MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk
              ))
            {
                //Esconde a form atual
                this.Visible = false;

                //instancia para a form de cadastro
                var FormCad = new Ficha();

                //Aguarde 3 segundos
                Thread.Sleep(3000);

                //Abre a form de cadastro
                FormCad.Visible = true;
            }
        }

        //Evento para o botão 'fechar'
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Evento para o botão 'Consultar'
        private void Consultar_Click(object sender, EventArgs e)
        {
           
            if(DialogResult.OK == MessageBox.Show("Deseja abrir a ficha de consulta ?", "CONSULTA",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk
                ))
            {
                //Instancia para a form de consulta
                var FormConsulta = new BuscaDados();

                //Esconde a form atual
                this.Visible = false;
                Thread.Sleep(3000);

                //Abre a form de consulta
                FormConsulta.Visible = true;
                
            }
        }
    }
}
