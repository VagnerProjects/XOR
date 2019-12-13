using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifras
{
    /// <summary>
    /// Classe que fornece a 'cifra inquebrável' One-Time Pad (OTP) de 1917
    /// </summary>
    class CriptografiaOneTimePad
    {
        //Chave aleatória do OTP
        private static char[] key;

        /// <summary>
        /// Aplica a criptográfia aleatória e inquebrável OCP (One-Time Pad)
        /// </summary>
        /// <param name="text">O texto claro a ser criptografado</param>
        /// <returns></returns>
        public static string Encrypt(string text)
        {
            try
            {
                if(!String.IsNullOrEmpty(text) && !String.IsNullOrWhiteSpace(text))
                {
                    int qtd = text.Length;
                    key = new char[qtd];
                    int rec = 0;
                    var Rand = new Random();

                    for(int i = 0; i < qtd;i++)
                    {
                        rec = Rand.Next(5, 98);

                        if (rec < 90 || rec > 97)
                            key[i] = (char)rec;
                        else
                            i--;
                    }

                    string texto = "";
                    char[] transfer = text.ToCharArray();
                    int calc = 0;

                    for(int i = 0; i < qtd; i++)
                    {
                        calc = ((int)key[i]) ^ ((int)transfer[i]);

                        
                        texto += (char)calc;
                    }

                    return texto;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na criptografia One-Time Pad!\nMotivo: " + ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Realiza a decriptação com a cifra OTP (One-Time Pad).
        /// </summary>
        /// <param name="CipherText">O texto cifrado a ser descriptografado pelo OTP</param>
        /// <returns></returns>
        public static string Decrypt(string CipherText)
        {
            try
            {
                if (!String.IsNullOrEmpty(CipherText) && !String.IsNullOrWhiteSpace(CipherText))
                {
                    int qtd = CipherText.Length;


                    int calc = 0;
                    string texto = "";
                    char[] transfer = CipherText.ToCharArray();

                    for (int i = 0; i < qtd; i++)
                    {
                        calc  = ((int)key[i]) ^ ((int)transfer[i]);
                        texto += (char)calc;
                    }

                    return texto;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na criptografia One-Time Pad!\nMotivo: " + ex.Message);
            }

            return null;
        }

        public static char[] Key()
        {
            return key;
        }
    }
}
