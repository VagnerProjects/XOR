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
using CriptoCadastros;
using Connection;

namespace DecrypTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Decrip_Click(object sender, EventArgs e)
        {
            var DLLConect = new SQLConexao();
            var Conectar = DLLConect.Conect();
            Conectar.Open();
            var ListName = new List<string>();
            var ListIdade = new List<int>();
            var ListCidade = new List<string>();
            var ListEmail = new List<string>();
            var ListSenha = new List<int>();
            var ListChave = new List<string>();
            bool controle = true;

            try
            {
                string Busca = "select Nome,Idade,Cidade,Email,Senha,PalavraChave FROM Cadastros";
                string Apaga = "Truncate table DecryCadastros";
                var ComandApaga = new SqlCommand(Apaga, Conectar);
                var Del = new SqlDataAdapter();
                Del.InsertCommand = ComandApaga;
                Del.InsertCommand.ExecuteNonQuery();
               

                ComandApaga.Dispose();

                var ComandBusca = new SqlCommand(Busca, Conectar);
                SqlDataReader Data = ComandBusca.ExecuteReader();

                while(Data.Read())
                {
                    //Decripta os dados da tabela e os envia para as listas
                    ListName.Add(Criptografia.Decrypt(Data.GetValue(0).ToString()));
                    ListIdade.Add(int.Parse(Criptografia.Decrypt(Data.GetValue(1).ToString())));
                    ListCidade.Add(Criptografia.Decrypt(Data.GetValue(2).ToString()));
                    ListEmail.Add(Criptografia.Decrypt(Data.GetValue(3).ToString()));
                    ListSenha.Add(int.Parse(Criptografia.Decrypt(Data.GetValue(4).ToString())));
                    ListChave.Add(Criptografia.Decrypt(Data.GetValue(5).ToString()));
                }
                ComandBusca.Dispose();
                Data.Close();
                string Insere;
             
                //Inserir dados na nova tabela
                for(int i = 0; i < ListName.Count;i++)
                {
                    Insere = "Insert into DecryCadastros (Nome,Idade,Cidade,Email,Senha,PalavraChave) values('" +
                       ListName[i] + "'," + ListIdade[i] + ",'" + ListCidade[i] + "','" + ListEmail[i] + "'," + ListSenha[i] + ",'" + ListChave[i] + "')";
                    var ComandInser = new SqlCommand(Insere, Conectar);
                    Del.InsertCommand = ComandInser;
                    Del.InsertCommand.ExecuteNonQuery();
                }
                Del.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao decriptar tabela ! \n\nMotivo: " + ex.Message,
                    "ERRO :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                controle = false;
            }
            finally
            {
                if(controle)
                {
                    MessageBox.Show("Tabela decripatada com sucesso !",
                   "AES EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Conectar.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "DECRIPTAR O AES";
            this.BackColor = Color.LightBlue;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.CenterToScreen();
        }
    }
}
