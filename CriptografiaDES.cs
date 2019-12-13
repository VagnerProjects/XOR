using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Cifras
{
    /// <summary>
    /// Classe que fornece o algoritmo criptográfico da cifra simétrica DES (Padrão de Encriptação de Dados).
    /// </summary>
    class CriptografiaDES
    {
        /// <summary>
        /// Realiza a encriptação simétrica com a cifra DES (Padrão de Encriptação de Dados).
        /// </summary>
        /// <param name="text">O texto claro a ser criptografado</param>
        /// <param name="DES_KEY">A chave criptográfica</param>
        /// <param name="DES_IV">O vetor de inicialização (IV) das cifras simétricas</param>
        /// <param name="DES_KEY_SIZE">O tamanho da chave criptográfica (Em bits)</param>
        /// <returns></returns>
        public static byte[] Encrypt(string text, byte[] DES_KEY, byte[] DES_IV, int DES_KEY_SIZE)
        {
            try
            {
                if(!String.IsNullOrEmpty(text) && !String.IsNullOrWhiteSpace(text))
                {
                    byte[] ret;

                    //A cifra DES
                    using (DES Des = DES.Create())
                    {
                        Des.KeySize = DES_KEY_SIZE;

                        using (var Memory = new MemoryStream())
                        {
                            using (var Encryp = new CryptoStream(Memory, Des.CreateEncryptor(DES_KEY, DES_IV), CryptoStreamMode.Write))
                            {
                                byte[] EncryptDES = new ASCIIEncoding().GetBytes(text);
                                Encryp.Write(EncryptDES, 0, EncryptDES.Length);
                                Encryp.FlushFinalBlock();
                                Encryp.Close();
                            }

                            ret = Memory.ToArray();
                            Memory.Close();
                        }

                        Des.Dispose();
                    }

                    return ret;
                }
            }
            catch(CryptographicException ex)
            {
                Console.WriteLine("Erro na criptografia DES!\nMotivo: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na criptografia DES!\nMotivo: " + ex.Message);
            }
            
            return null;
        }

        private static byte[] MyKey;

        /// <summary>
        /// Realiza a decriptação simétrica com a cifra DES (Padrão de Encriptação de Dados).
        /// </summary>
        /// <param name="text">O texto cifrado a ser descriptografado</param>
        /// <param name="DES_KEY">A chave criptográfica</param>
        /// <param name="DES_IV">O vetor de inicialização (IV) das cifras simétricas</param>
        /// <param name="CipherText">O tamanho da chave criptográfica (Em bits)></param>
        /// <returns></returns>
        public static string Decrypt(byte[] CipherText, byte[] DES_KEY, byte[] DES_IV, int DES_KEY_SIZE)
        {
            try
            {
                if (CipherText.Length != 0)
                {
                    byte[] DecryptDES;

                  
                    using (DES Des = DES.Create())
                    {
                        Des.KeySize = DES_KEY_SIZE;

                        using (var Memory = new MemoryStream(CipherText))
                        {
                            using (var Encryp = new CryptoStream(Memory, Des.CreateDecryptor(DES_KEY, DES_IV), CryptoStreamMode.Read))
                            {
                                DecryptDES = new byte[CipherText.Length];
                                Encryp.Read(DecryptDES, 0, DecryptDES.Length);
                                
                                Encryp.Close();
                                MyKey = DES_KEY;
                            }

     
                            Memory.Close();
                        }

                        Des.Dispose();
                    }

                    return new ASCIIEncoding().GetString(DecryptDES);
                }
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("Erro na descriptografia DES!\nMotivo: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na descriptografia DES!\nMotivo: " + ex.Message);
            }

            return null;
        }

        public static byte[] Key()
        {
            return (MyKey);
        }
    }
}
