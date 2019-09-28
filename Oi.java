/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ola;


import java.text.DecimalFormat;
import java.io.*;
import java.util.*;


public class Oi 
{

    public static void main(String[] args) throws IOException
    {
        Scanner Ler = new Scanner(System.in);
        DecimalFormat Dec = new DecimalFormat("0.00");
        Construtor object = new Construtor();
        int escolha;
        String res = "S";
        
        System.out.println("Voce deseja preencher, consultar ou apagar os dados do arquivo ?\n");
        System.out.print("[1]Preencher \n[2]Consultar \n[3]Apagar \n\nResposta: ");
        escolha = Ler.nextInt();
        Ler.nextLine();
        System.out.println();
        int i = 0;
        int confirma;
        boolean correto = false;
        
        if(escolha == 1)
        {
            while(res == "S")
            {
                 object.clear();
                System.out.println("Cadastro usario: "+(i+1)+"\n");
            
                System.out.print("Nome: ");
                object.nome = Ler.nextLine();
                System.out.println();
            
                System.out.print("Idade: ");
                object.idade = Ler.nextInt();
                Ler.nextLine();
                System.out.println();
            
                System.out.print("Cidade: ");
                object.cidade = Ler.nextLine();
              
                System.out.println();
            
                System.out.print("Estado Civil: ");
                object.civil = Ler.nextLine();
                System.out.println();
            
                do
                {
                 System.out.println("Crie uma senha de 8 DIGITOS INTEIROS: ");
                 object.senha = Ler.nextInt();
                 System.out.println();
                }
                while(String.valueOf(object.senha).length() > 8 || String.valueOf(object.senha).length() < 8);
                           
                do
                {
                    System.out.print("Redigite a senha: ");
                    confirma = Ler.nextInt();
                    System.out.println();
                    
                    if(confirma != object.senha)
                    {
                        System.out.println("As senhas não coincidem !\n");
                    }
                }
                while(confirma != object.senha);
                correto = true;
                
                if(correto)
                {
                    String nome = "Cadastro.txt";
                    BufferedWriter Arquivo = new BufferedWriter(new FileWriter(nome,true));

                    Arquivo.write("Nome: "+object.nome+"\n");
                    Arquivo.write("Senha: "+object.senha+"\n");
                    Arquivo.write("Idade: "+object.idade+"\n");
                    Arquivo.write("Cidade: "+object.cidade+"\n");
                    Arquivo.write("Estado Civil: "+object.civil+"\n");
                    Arquivo.write("==============================================\n-\n");
                    Arquivo.close();
                }
                System.out.print("Adicionar mais ? [S] para SIM: ");
                res = Ler.next();
                System.out.println();
                i++;
               
            }
            
        }
        else if(escolha == 2)
        {
            try
            {
              FileReader arquivo = new FileReader("Cadastro.txt");
              BufferedReader arq = new BufferedReader(arquivo);
            
             Construtor ob = new Construtor();
             ob.clear();
              String Line;
              while((Line = arq.readLine())!= null)
              {
                  System.out.println(Line);
              }
                System.out.println();
                arq.close();
                
               
            }
            catch(IOException e)
            {
                
                System.out.println("Erro ao ler o arquivo: \nCódigo: "+e.getMessage());
            }
        }
        
        
        
    }        
     
   
}

/**
 * Classe para construção dos dados
 * @author sinxb
 */
class Construtor
{
    String nome;
    String cidade;
    int idade;
    String civil;
    int senha;
    
  
    /**
     * Construtor
     */
    public Construtor()
    {
        
    }
    
    /**
     * Método fornecedor dos dados
     * @param n - parametro para nome
     * @param c - parametro para cidade
     * @param i - parametro para idade
     * @param cv - parametro para estado civil
     * @param se - parametro para senha
     */
    public Construtor(String n, String c, int i, String cv, int se)
    {
        this.nome = n;
        this.cidade = c;
        this.idade = i;
        this.civil = cv;
        this.senha = se;
    }
    
    public void clear()
    {
        for(int i = 0; i <= 20;i++)
        {
          System.out.println("\n\n\n\n\n");
        }
    }
}



   
