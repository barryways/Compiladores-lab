using Laboratorio1_Compis;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Macrosystems
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Ingrese la expresión aritmética:");
            //string input = Console.ReadLine();
            string input = "var: oct numero1 = 7;\r\nbin numero2 = 011;\r\nhex numero3 = A3F;\r\n\r\nexp: (numero2 - 10) + numero3;";
            try
            {
                AnalizadorLexico analizador = new AnalizadorLexico(input);
                AnalizadorSintactico analizadorSintactico = new AnalizadorSintactico();
                List<Token> tokens = analizador.Tokenizador();
                List<string> tokensAPasar = new List<string>();
                foreach (Token token in tokens)
                {
                    Console.WriteLine($"Token: {token.Type.ToString()} Value: {token.Value.ToString()}");
                    tokensAPasar.Add(token.Type.ToString());
                }
                int valor = analizadorSintactico.parsear(tokensAPasar);

                if (valor == 1)
                {
                    Console.WriteLine("Salio todo bien");

                }
                else
                {
                    Console.WriteLine("Tal vez tengas un pequeño error");
                }


                Console.WriteLine("La expresión es sintácticamente correcta.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de sintaxis: {ex.Message}");
            }
        }
    }
}