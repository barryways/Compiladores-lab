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
            string input = "oct numero1 = 0;\r\nbin numero2 = 7;\r\nhex numero3 = 1A3F;\r\n\r\nexp: (numero2 - 10) + numero3;";
            try
            {
                AnalizadorLexico analizador = new AnalizadorLexico(input);
                List<Token> tokens = analizador.Tokenizador();
                foreach (Token token in tokens)
                {
                    Console.WriteLine(token.Type.ToString() + " " +token.Value.ToString());
                }
                Console.WriteLine(tokens.Count);
                Console.WriteLine("La expresión es sintácticamente correcta.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de sintaxis: {ex.Message}");
            }
        }
    }
}
