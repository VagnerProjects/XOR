using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace Cifras
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CRIPTOGRAFIA SIMÉTRICA - AES VS DES VS OTP";
            string name;
            Console.ForegroundColor = ConsoleColor.Magenta;
 
            //Contagem de tempo
            var Temp = new Stopwatch();
            Temp.Start();

            Console.Write(" Digite um nome: ");
            name = Console.ReadLine();
            Console.WriteLine();
            Thread.Sleep(1000);

            Console.WriteLine("                         CIFRA DES");
            Console.WriteLine("====================================================================================================\n");
            Thread.Sleep(2000);

            //Chamada da classe criptográfica do DES
            using (DES Des = DES.Create())
            {
                //Tamanho da chave secreta do DES (Em bits).
                Des.KeySize = 64;

                Console.ForegroundColor = ConsoleColor.Black;
                byte[] Cipher = CriptografiaDES.Encrypt(name, Des.Key, Des.IV, Des.KeySize);

                //O texto criptografado
                Console.Write(" Texto cifrado com DES - Padrão de Encriptação de Dados: ");
                for (int i = 0; i < Cipher.Length; i++)
                    Console.Write(Cipher[i]);
                Console.WriteLine("\n");
                Thread.Sleep(1000);

                //O texto decriptado
                Console.WriteLine(" Texto claro: " + CriptografiaDES.Decrypt(Cipher, Des.Key, Des.IV, Des.KeySize));
                Console.WriteLine();
                Thread.Sleep(1000);

                //A chave usada pelo DES
                Console.Write(" Key: ");
                byte[] KeyDES = CriptografiaDES.Key();
                for (int i = 0; i < KeyDES.Length; i++)
                    Console.Write(KeyDES[i]);
                Console.WriteLine("\n");
                Thread.Sleep(1000);

                //Tamanho da chave usada pelo DES (Em bits). As chaves possuem 64 bits de tamanho.
                Console.WriteLine(" Tamanho da chave (Em bits): " + Des.BlockSize);
                Console.WriteLine();
                Thread.Sleep(1000);

                //Tamanho do bloco usado pelo DES (Em bits).
                Console.WriteLine(" Tamanho do bloco (Em bits): " + Des.BlockSize);
                Console.WriteLine();
                Thread.Sleep(1000);

                //Fecha o fluxo criptográfico do DES
                Des.Dispose();
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Thread.Sleep(1000);

            Console.WriteLine("                         CIFRA AES");
            Console.WriteLine("====================================================================================================\n");
            Thread.Sleep(2000);

            //Chamada da classe criptográfica do AES
            using (Aes AES = Aes.Create())
            {
                //Tamanho da chave secreta do AES (Em bits).
                AES.KeySize = 256;
                
                Console.ForegroundColor = ConsoleColor.Black;
                byte[] Cipher = CriptografiaAES.Encrypt(name, AES.Key, AES.IV, AES.KeySize);

                //O texto criptográfado
                Console.Write(" Texto cifrado com AES - Padrão de Encriptação Avançado: ");
                for (int i = 0; i < Cipher.Length; i++)
                    Console.Write(Cipher[i]);
                Console.WriteLine("\n");
                Thread.Sleep(1000);

                //O texto decriptado
                Console.WriteLine(" Texto claro: " + CriptografiaAES.Decrypt(Cipher, AES.Key, AES.IV, AES.KeySize));
                Console.WriteLine();
                Thread.Sleep(1000);

                //A chave usada pelo AES
                Console.Write(" Key: ");
                byte[] KeyAES = CriptografiaAES.Key();
                for (int i = 0; i < KeyAES.Length; i++)
                    Console.Write(KeyAES[i]);
                Console.WriteLine("\n");
                Thread.Sleep(1000);

                //Tamanho da chave usada pelo AES (Em bits). As chaves podem ser de 128, 192 ou 256 bits de tamanho.
                Console.WriteLine(" Tamanho da chave (Em bits): " + AES.KeySize);
                Console.WriteLine();
                Thread.Sleep(1000);

                //Tamanho do bloco usado pelo AES (Em bits).
                Console.WriteLine(" Tamanho do bloco (Em bits): " + AES.BlockSize);
                Console.WriteLine();
                Thread.Sleep(1000);

                //Fecha o fluxo criptográfico usado pelo AES
                AES.Dispose();
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Thread.Sleep(1000);

            Console.WriteLine("                         CIFRA ONE-TIME PAD");
            Console.WriteLine("====================================================================================================\n");
            Console.ForegroundColor = ConsoleColor.Black;
            Thread.Sleep(2000);

            //Chamada para a classe criptográfica do One-Time Pad (OTP), já realizando a encriptação.
            Console.WriteLine(" Texto cifrado com OTP - One-Time Pad: " + CriptografiaOneTimePad.Encrypt(name));
            Thread.Sleep(1000);

            //A string recebe o texto cifrado para efeitos de descriptografia
            string cipher = CriptografiaOneTimePad.Encrypt(name);
            Console.WriteLine();

            //O texto decriptado
            Console.WriteLine(" Texto claro: " + CriptografiaOneTimePad.Decrypt(cipher));
            Console.WriteLine();
            Thread.Sleep(1000);

            //A chave usada pelo OTP.
            Console.Write(" Key: ");
            char[] KeyOTP = CriptografiaOneTimePad.Key();
            for (int i = 0; i < KeyOTP.Length; i++)
                Console.Write(KeyOTP[i]);

            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine();

            Temp.Stop();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                          TEMPO DE EXECUÇÃO");
            Console.WriteLine("====================================================================================================\n");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($" Horas: {Temp.Elapsed.Hours} Minutos: {Temp.Elapsed.Minutes} Segundos: {Temp.Elapsed.Seconds}");
            Console.WriteLine();

            //Fim do programa
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Digite qualquer tecla para encerrar... ");
            Console.ReadKey();
        }
    }
}
