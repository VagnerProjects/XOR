#include <iostream>
#include <fstream>
#include <Windows.h>
#include <locale.h>
#include <string>

using namespace std;

int main()
{
	system("color 75");
	SetConsoleTitle(TEXT("ARQUIVOS EM C++"));
	setlocale(LC_ALL, "Portuguese");

	fstream arq;
	int esc;
	string Res = "S";
	string Name,City,profession;
	cout << "Voce deseja adicionar, ler ou apagar os dados no arquivo ?\n\n[1]Adicionar \n[2]Ler \n[3]Apagar \n\nResposta: ";
	cin >> esc;
	cin.ignore();
	cout << endl;

	system("cls");

	if (esc == 1)
	{
		arq.open("Hello.txt", ios::app);
		int i = 1;

		while (Res == "S")
		{
			cout << "Usuario " << i << endl << endl;

			cout << "Name:";
			getline(cin, Name);
			cout << endl;

			cout << "City: ";
			getline(cin, City);
			cout << endl;

			cout << "Profession: ";
			getline(cin, profession);
			cout << endl;

			arq << "Name: " << Name << endl;
			arq << "City: " << City << endl;
			arq << "Profession: " << profession << endl;
			arq << "================================" << endl;

			cout << "Adicionar mais ? [S] para SIM: ";
			getline(cin, Res);
			system("cls");
			i++;
		}
		arq.close();
	}
	else if (esc == 2)
	{
		arq.open("Hello.txt", ios::in);
		cout << "Dados no arquivo: \n" << endl;

		if (arq.is_open())
		{
			string Line;

			while (!arq.eof())
			{
				getline(arq, Line);

				cout << Line << endl;
			}
			arq.close();
		}
		else
			cout << "Não foi possível abri o arquivo !" << endl << endl;
	}
	else if (esc == 3)
	{
		arq.open("Hello.txt", ios::out);

		if (arq.is_open())
		{
			cout << "Todos os dados do arquivo foram deletados com sucesso !" << endl << endl;
			arq.close();
		}
		else
			cout << "Não foi possível abri o arquivo !" << endl << endl;
	}
	else
		cout << "Escolha inválida !" << endl << endl;


	system("pause");
	return 0;
}