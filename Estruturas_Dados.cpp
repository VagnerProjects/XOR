//Estrutura_Dados.cpp 

#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <string>
#include <stack>
#include <Windows.h>
#include <locale.h>
#include "pilha.h"

using namespace std;

int main()
{

	system("color 75");
	SetConsoleTitleA("ESTRUTURA DE DADOS - PILHA EM C E C PLUS PLUS");
	
	
	setlocale(LC_ALL, "Portuguese");

	printf("Hello World \n");

	int quant;

	//Ponteiro para a pilha, o tipo T agora � String
	pilha<string>*stacks = new pilha<string>;

	//Inicia a pilha
	stacks->stackOpen();

	printf("Deseja adicionar quantos elementos na pilha ? ");
	scanf_s(" %d", &quant);
	printf("\n");

	cin.ignore();

	//Quantidade n�o pode chegar ao limite da pilha
	if (quant < 999)
	{
		int insert,query;
		string in, querys;
		

		//Adiciona elementos na pilha at� a quantidade especificada
		for (int i = 0; i < quant; i++)
		{
			system("cls");
			printf("%d� elemento: ", (i + 1));
			getline(cin, in);
		

			//Adiciona o elemento digitado ao topo da pilha
			stacks->push(in);
		}

		printf("\nAguarde... ");
		Sleep(3000);
		system("cls");

		printf("Elementos da pilha: \n\n");

		//Mostra todos os elementos da pilha, removendo quem esta no topo
		for (int i = 0; i < quant; i++)
		{
			//O endere�o da variavel � adiconada ao ponteiro da fun��o 'pop'
			stacks->pop(&querys);

			//A varivel agora tem acesso aos elementos
			cout<<(i+1)<<"�elemento: "<<querys<<endl;
		}
		printf("\n\n");
		int a;
		printf("Remova: ");
		scanf_s(" %d", &a);
		stacks->remove(a);
		querys = "";
		for (int i = 0; i < quant; i++)
		{
			//O endere�o da variavel � adiconada ao ponteiro da fun��o 'pop'
			stacks->pop(&querys);

			//A varivel agora tem acesso aos elementos
			cout << (i + 1) << "�elemento: " << querys << endl;
		}
	}
	else
	{
		printf("Valor muito grande para a pilha !\n");
	}

    //Libera o espa�o de mem�ria usado pelo ponteiro (aloca��o din�mica de mem�ria, em C � o free)
	delete stacks;
	

	printf("\n\n");
	system("pause");

	return 0;
}