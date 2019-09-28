#include "pch.h"
#include "framework.h"
#include "Criptografar.h"
#include <iostream>
#include <string>
#include <locale.h>
#include <time.h>
#include <Windows.h>

using namespace std;

static char key[80];

string Criptografia::Encrypt(string text)
{
	
	setlocale(LC_ALL, "Portuguese");
	int recebe = 0;
	string cifra = "";
	srand(time(NULL));
	char* rece = new char;


	for (int i = 0; i < text.length(); i++)
	{
		recebe = (rand() % 56) + 65;

		if (recebe < 90 || recebe >97)
			key[i] = recebe;
		else
			i--;
	}



	for (int i = 0; i < text.length(); i++)
	{

		rece[i] = (key[i] - 48) ^ (text[i] - 48) + '0';

	}
	cifra = rece;

	return cifra;
}

string Criptografia::Decrypt(string crypi_text)
{
	setlocale(LC_ALL, "Portuguese");
	string cifra = "";


	char* rece = new char;

	for (int i = 0; i < crypi_text.length(); i++)
	{

		rece[i] = (key[i] - 48) ^ (crypi_text[i] - 48) + '0';
	}

	int forn = 0;
	cifra = rece;


	if (cifra.length() >= strlen(key))
	{
		for (int i = cifra.length(); i >= strlen(key); i--)
		{
			cifra[i] = '\0';
		}
	}
	return cifra;
}

string Criptografia::Key()
{
	return key;
}