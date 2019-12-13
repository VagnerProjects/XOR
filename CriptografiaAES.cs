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
    /// Classe que fornece o algoritmo Rijndael da cifra AES (Padrão de Encriptação Avançado).
    /// </summary>
    class CriptografiaAES
    {
        private static byte[] MyKey;

        /// <summary>
        /// Realiza a encriptação simétrica com a cifra AES (Padrão de Encriptação Avançado).
        /// </summary>
        /// <param name="text">O texto claro a ser criptografado</param>
        /// <param name="AES_KEY">A chave criptográfica</param>
        /// <param name="AES_IV">O vetor de inicialização (IV) das cifras simétricas</param>
        /// <param name="AES_KEY_SIZE">O tamanho da chave criptográfica (Em bits)></param>
        /// <returns></returns>
        public static byte[] Encrypt(string text, byte[] AES_KEY, byte[] AES_IV, int AES_KEY_SIZE)
        {
            try
            {
                if(!String.IsNullOrEmpty(text) && !String.IsNullOrWhiteSpace(text))
                {
                    byte[] Encrypted;

                    using(Aes AES = Aes.Create())
                    {
                        AES.KeySize = AES_KEY_SIZE;
                        AES.Key = AES_KEY;
                        AES.IV = AES_IV;

                        ICryptoTransform TransfAES = AES.CreateEncryptor(AES.Key, AES.IV);
                        MyKey = AES_KEY;

                        using (var Memory = new MemoryStream())
                        {
                            using(var Cryp = new CryptoStream(Memory, TransfAES,CryptoStreamMode.Write))
                            {
                                using(var Stream = new StreamWriter(Cryp))
                                {
                                    Stream.Write(text);

                                    Stream.Close();
                                }

                                Encrypted = Memory.ToArray();

                                Cryp.Close();
                            }

                            AES.Dispose();
                        }

                        return Encrypted;
                    }
                }
                             
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("Erro na criptografia AES!\nMotivo: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na criptografia AES!\nMotivo: " + ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Realiza a decriptação com a cifra AES (Padrão de Encriptação Avançado).
        /// </summary>
        /// <param name="CipherText">O texto cifrado a ser descriptografado</param>
        /// <param name="AES_KEY">A chave criptográfica</param>
        /// <param name="AES_IV">O vetor de inicialização (IV) das cifras simétricas</param>
        /// <param name="AES_KEY_SIZE">O tamanho da chave criptográfica (Em bits)</param>
        /// <returns></returns>
        public static string Decrypt(byte[] CipherText, byte[] AES_KEY, byte[] AES_IV, int AES_KEY_SIZE)
        {
            try
            {
                if (CipherText.Length != 0)
                {
                    string Decrypted = null;

                    using (Aes AES = Aes.Create())
                    {
                        AES.KeySize = AES_KEY_SIZE;
                        AES.Key = AES_KEY;
                        AES.IV = AES_IV;

                        ICryptoTransform TransfAES = AES.CreateDecryptor(AES.Key, AES.IV);

                        using (var Memory = new MemoryStream(CipherText))
                        {
                            using (var Cryp = new CryptoStream(Memory, TransfAES, CryptoStreamMode.Read))
                            {
                                using (var Stream = new StreamReader(Cryp))
                                {
                                    Decrypted = Stream.ReadToEnd();

                                    Stream.Close();
                                }

                                Cryp.Close();
                            }

                            AES.Dispose();
                        }

                        return Decrypted;
                    }
                }

            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("Erro na descriptografia AES!\nMotivo: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na descriptografia AES!\nMotivo: " + ex.Message);
            }

            return null;
        }

        public static byte[] Key()
        {
            return MyKey;
        }
    }
}
