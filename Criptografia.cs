using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace CriptoCadastros
{

    /*Criptografia
     * A Criptografia é um conjunto de príncipios e técnicas responsável por transformar textos legíveis em ilegíveis.
     * Seu conceito está na proteção de dados confidenciais, desde conversas em WhatsAppp até contas báncarias
     * A criptografia existe para proteger informações, fornecendo acesso apenas a pessoas autorizadas
     * Se trata da técnica de segurança mais utilizada no mundo digital
     * 
     * A Criptografia consiste em muitas coisas, entre eles está os recursos básicos para as técnicas de encriptação
     * Esses recursos são: 
     * 
     * Texto Claro - O texto em sua forma natural, independente da língua, se trata de um texto que é possível ler e entender
     * Texto Cifrado - A transformção de um texto claro para um texto completamente ilegível
     * Textos cifrados consistem em embaralhamento e várias outras transformações em um texto claro.
     * Se usa os algoritmos de Encriptação para transformar um texto claro em um texto cifrado
     * 
     * Chave Criptográfica - Uma sequencia de caracteres embaralhados responsável pela encriptação de um texto claro
     * 
     * Algoritmos De Encriptação - Sequencia de regras lógicas e matemáticas que utilizam uma ou mais chaves criptograficas
     * para transformar um texto claro em um texto cifrado.
     * 
     * Algoritmos de Decriptação - Mesmo algoritmo de Encriptação, porém inverso, responsável por tornar um texto cifrado
     * em um texto legível novamente, em seu estado natural
     * 
     * Cifras de fluxo - caractere por caractere de um texto claro é transformado em bits, e um operador lógico chamado XOR faz cálculos
     * binarios bit por bit
     * 
     * Cifras de bloco - transferem blocos inteiros de texto para sua base binária, também utilizam o XOR bit a bit
     * 
     * Alogoritmos de cifras Simétricas - Algoritmos de encriptação que consistem em apenas uma chave criptográfica, tanto para encriptação
     * quanto para a decriptação. Essas cifras trabalham com a encriptação em blocos, podendo encriptar até mesmo arquivos
     * suas chaves são chamadas de chaves privadas
     * 
     * Algoritmos de cifras Assimétricas - Consistem na encriptação com mais de uma chave criptográfica
     * também trabalham com a encriptação em blocos, mas encriptam menos quantidade de dados
     * suas chaves são chamadas de chaves públicas
     * 
     * A junção desses algoritmos formam os Algoritmos Criptográficos.
     * 
     * Criptoanalise - Técnicas usadas para decriptar um texto sem autorização, ou seja, sem possuir a chave criptográfica
     * Um criptoanalista pode ser um policial em busca de informações, um programador testando a força de seu algoritmo criptográfico
     * ou no pior dos casos, uma pessoa mal-intensionada, como um Hacker, que deseja ter acesso a informações confidenciais
     * 
     * Existem 2 tipos de ataques criptoanaliticos, eles são:
     * 
     * Ataque passivo: O criptoanalista busca apenas ter acesso as informações criptografadas, mas sem alterar seu conteúdo
     * Ataque por força bruta/Ativo: O criptoanalista busca ter acesso e modificar as informações criptografadas
     * 
     * Ataques criptoanaliticos possuem níveis de gravidade, esses níveis são:
     * 
     * Baixo - Quando a decriptação de dados não autorizada não causa efeitos significativos na organização/pessoa
     * Médio - Quando a decriptação de dados não autorizada causa graves danos a orgnaização/pessoa
     * levando a sérios prejuízos financeiros, obrigando a realização de mudanças no sistema de segurança
     * porém não oferecendo riscos físicos as vítimas
     * 
     * Alto - Quando a decriptação de dados não autorizada causa graves danos a organização/pessoa
     * podendo levar a prejuízos irrecuperáveis e até mesmo a falencias
     * o ataque pode causar ferimentos físicos a vítima e até mesmo a morte
     * 
     * Criptologia - A junção dos Algoritmos Criptográficos e Criptoanálise.
     * Area da ciencia da computação responsável pelo estudo e aplicação da criptografia
     * 
     * A criptografia requer determinadas condiçoes para o seu funcionamento ocorrer com êxito, esses são:
     * 
     * Confidenciabilidade - Garantir que as informações confidencias estejam disponiveis apenas a pessoas autorizadas
     * 
     * Privacidade -Permitir que as pessoas autorizadas possuam acesso e permissão para a manipulaçao das informações
     * 
     * Integridade - consiste em dois conceitos:
     * Integridade de dados - Assegura a modificação das informações somente de uma maneira autorizada
     * Integridade do sistema - Garantir que o sistema irá funcionar de forma correta e coerente, e assegurar a privacidade
     * das informações contidas nele
     * 
     * Disponibilidade - Assegurar que os sistemas não fiquem indisponíveis a pessoas autorizadas
     * 
     * Esta é a Triade CIA, que envolve os conceitos principais para a segurança da informação.
     * 
     * Há dois conceitos a mais que devem ser levantados:
     * 
     * Autenticidade - A propriedade de ser confiável, de assegurar que informações só sejam utilizadas se forem fornecidas
     * por fontes confiaveis, a validação de informações
     * 
     * Responsabilidade - Os sistemas devem manter registros de suas verificações, serem responsáveis, buscarem por falhas
     * e resolverem qualquer tipo de problema que possa afetar a informação.
     * 
     * 
     * Padrão de Encriptação Avançado - AES
     * 
     * Publicado pela NIST em 2001, o AES se tornou o substituto do DES (Padrão de Encriptação de informação)
     * Se tornou o principal algoritmo de encriptação de cifra Simétrica, oferencendo um poder incálculavel na proteção da informação
     * O AES é uma cifra de bloco simétrica, onde suas chaves podem possuir 64,128 ou até 256 bits
     * As chaves são tratadas como bits pois seus caracteres são transformados em bits pelo operador Lógico XOR bit a bit
     * Esse operador realiza os cálculos de bit por bit dos caracteres da chave com os caracteres do texto claro
     * 
     * A Encriptação AES é formada por rodadas, a cada rodada acontece uma modificação na chave e no texto
     * Sua chave deve conter 16 bits, que durante as rodadas podem se extender em até 256 (O padrão mais poderoso do AES)
     *É o padrão de encriptação mais utlizado na atualidade, formado pelo algoritmo Rijndel
     * nome dado a técnica de enriptação bit a bit do AES, usando as cifras de blocos
     * AES também consiste em um vetor de inicialização, chamado de IV, que irá manipular a chave criptográfica
     * 
     * Uma tentativa de criptoanálise contra uma cifra AES, buscando exaustivamente um espaço de chaves pode levar em média:
     * 6,3 x 10^6 ANOS, contendo mais de 2^256 = 1,2 x10^77 chaves
     * 
     * O Algoritmo criptográfico abaixo te faz mergulhar no poder do AES :).
    
     */
    /// <summary>
    /// Classe que aplica o Padrão de Encriptação Avançado - AES
    /// </summary>
    public class Criptografia
    {
        //A chave criptográfica de 16 bits, que se estendera a 256 bits na última rodada de encriptação/decriptação
        private const string Key = "6Hjyu84g6ruiKfgw";

        //O vetor de inicialização do AES, responsável por armazenar todos os caracteres da chave
        private static byte[] AES_IV = new byte[16];

        /// <summary>
        /// Encripta um texto claro para um texto cifrado
        /// </summary>
        /// <param name="texto_puro">Texto claro a ser encriptado</param>
        /// <returns></returns>
        public static string Encrypt(string texto_claro)
        {
            //O bloco try ira testar se o código contém erros
            try
            {
                //Verifica se o texto claro está vazio ou preenchido apenas com espaços
                if (!string.IsNullOrEmpty(texto_claro) && texto_claro.Trim().Length != 0)
                {
                    //Converte todos os caracteres da chave para sua representação binária, através do XOR bit a bit
                    byte[] AES_KEY = Convert.FromBase64String(Key);

                    //Específica o tipo de texto, e o converte para a base binária, através do XOR bit a bit
                    byte[] AES_VALUE = new UTF8Encoding().GetBytes(texto_claro);

                    //Instancia para o Algoritmo Rijndael. Padrão AES de criptografia simétrica
                    Rijndael Crypt = new RijndaelManaged();

                    //Tamanho máximo da chave em bits
                    Crypt.KeySize = 256;

                    //Libera espaço na memória para um texto cifrado
                    var stream = new MemoryStream();

                    //O fluxo a ser usado, o modo de manipulação, transfere a key para o vetor IV e executa a encriptação
                    var Encriptar = new CryptoStream(stream, Crypt.CreateEncryptor(AES_KEY, AES_IV),
                        CryptoStreamMode.Write);

                    //Texto a ser ecnriptado, e define quantos caracteres devem ser criptografados
                    Encriptar.Write(AES_VALUE, 0, AES_VALUE.Length);

                    //Atualiza e limpa o buffer usado na encriptação
                    Encriptar.FlushFinalBlock();

                    //Em caso de êxito na encriptação, retorna uma string cifrada ao método chamador.
                    return Convert.ToBase64String(stream.ToArray());

                }

                //Tratamento de excessões
            }
            catch (CryptographicException e)
            {
                MessageBox.Show("Houve um erro na criptografia dos dados :(\n\nMotivo: " + e.Message,
                    "ERRO DE CRIPTOGRAFIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception e)
            {
                MessageBox.Show("Houve um erro na criptografia dos dados :(\n\nMotivo: " + e.Message,
                   "ERRO DE CRIPTOGRAFIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Em caso de erro de encriptação, retorna uma string nula ao método chamador.
            return null;
        }

        /// <summary>
        /// Decripta um texto cifrado para um texto claro novamente
        /// </summary>
        /// <param name="texto_cifrado">Texto cifrado a ser decriptado</param>
        /// <returns></returns>
        public static string Decrypt(string texto_cifrado)
        {
           
            try
            {
             
                if (!string.IsNullOrEmpty(texto_cifrado) && texto_cifrado.Trim().Length != 0)
                {
                    byte[] AES_KEY = Convert.FromBase64String(Key);

                    //O tipo de texto agora está na base binária
                    byte[] AES_VALUE = Convert.FromBase64String(texto_cifrado);

                    Rijndael Crypt = new RijndaelManaged();
                    Crypt.KeySize = 256;

                    //Libera espaço de memória para um texto claro
                    var stream = new MemoryStream();

                    //A diferença aqui é que executa uma decriptação no espaço de memória
                    var Decriptar = new CryptoStream(stream, Crypt.CreateDecryptor(AES_KEY, AES_IV),
                        CryptoStreamMode.Write);

                    Decriptar.Write(AES_VALUE, 0, AES_VALUE.Length);
                    Decriptar.FlushFinalBlock();


                    //Especifica o tipo de dados que deve ser transformado o texto cifrado
                    var UTF = new UTF8Encoding();

                    //Em caso de êxito na decriptação, retorna uma string no padrão UTF-8 ao método chamador.
                    return UTF.GetString(stream.ToArray());

                }
            }
            catch (CryptographicException e)
            {
                
                MessageBox.Show("Houve um erro na descriptografia dos dados :(\n\nMotivo: " + e.Message,
                    "ERRO DE DESCRIPTOGRAFIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
            catch(Exception e)
            {
                if (e.Message.Contains("matriz"))
                {
                    //Ignorar
                }
                else
                {
                    MessageBox.Show("Houve um erro na descriptografia dos dados :(\n\nMotivo: " + e.Message,
                       "ERRO DE DESCRIPTOGRAFIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Em caso de erro de decriptação, retorna uma string nula ao método chamador.
            return null;
        }


    }
}
