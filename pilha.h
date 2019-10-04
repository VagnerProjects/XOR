#pragma once

#include <iostream>
#include <locale.h>
#include <list>

using namespace std;

//O tipo T possibilita adicionar qualquer valor
template< typename T>
struct pilha
{
	//Tamanho máximo da pilha
	T armazen[1000];

	//variavel de controle da pilha
	int stack_ptr;


	 //Verifica se a pilha está vazia e inicia
	 void stackOpen()
	 {
		 stack_ptr = -1;
	 }

	 //Função para adicionar elementos na pilha
	 int push(T push_this)
	 {
		 //Se o número de elementos chegar ao limite, retorne erro a função main
		 if (stack_ptr >= 999)
			 return 0;
		 //Caso não, incremente a variavel de controle, e adicione o elemento ao vetor da pilha
		 else
			 armazen[++stack_ptr] = push_this;

		 //Retorna exito a função main
		 return 1;
	 }

	 //Elimina o elemento do topo da pilha
	 int pop(T *ptr_pop)
	 {
		 //Verifica se pilha esta vazia
		 if (stack_ptr == -1)
			 return 0;
         //Decremente o ponteiro e retire um elemeno da pilha (que foi o último colocado)
		 else
			 *ptr_pop = armazen[stack_ptr--];


		 //Retorna exito a função main
		 return 1;
	 }

	
};




