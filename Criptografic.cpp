#include <iostream>
#include <locale.h>
#include <Windows.h>
#include <windows.security.cryptography.h>
#include <string>
#include <time.h>
#include <stdio.h>
#include <stdlib.h>
#include "..\Criptografar\Criptografar.h"


using namespace std;



int main()
{
	setlocale(LC_ALL, "Portuguese");
	system("color 75");
	SetConsoleTitle(TEXT("CRIPTOGRAFIA SIMETRICA EM C++"));

	string text;
	cout << "Digite um texto claro: ";
	getline(cin, text);
	cout << endl;
	string b = Criptografia::Encrypt(text);
	cout << "Texto Encriptado: " << Criptografia::Encrypt(text) << endl << endl;
	cout << "Texto Decriptado: " << Criptografia::Decrypt(b) << endl << endl<<"Key: "<<Criptografia::Key()<<endl<<endl;
	system("pause");

	return 0;
}

