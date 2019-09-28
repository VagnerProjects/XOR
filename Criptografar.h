#pragma once

#ifdef CRIPTOGRAFAR_EXPORTS
#define CRIPTOGRAFAR_API __declspec(dllexport)
#else
#define CRIPTOGRAFAR_API __declspec(dllimport)
#endif // CRIPTOGRAFAR_EXPORTS

#include <iostream>

using namespace std;

extern"C" class CRIPTOGRAFAR_API Criptografia
{	

 public:
	static string Encrypt(string text);
	static string Decrypt(string crypi_text);
	static string Key();
};
