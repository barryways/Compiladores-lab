using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Laboratorio1_Compis
{
    public class AnalizadorLexico
    {
        private string input;
        private int posicion;

        /// <summary>
        /// Este diccionario nos ayuda a establecer un patron para cada una de las cosas que encontramos dentro del input
        /// </summary>
        private static readonly Dictionary<string, TokenType> tokenPatterns = new Dictionary<string, TokenType>
        {
            { @"oct", TokenType.tipadoOct },
            { @"bin", TokenType.tipadoBin },
            { @"hex", TokenType.tipadoHex },
            { @"=", TokenType.sigIgual },
            { @";", TokenType.puntoComa },
            { @"exp:", TokenType.expresionComienza },
            { @"var:", TokenType.variablesComienza },
            { @"\+", TokenType.sigMas },
            { @"\-", TokenType.sigMenos },
            { @"\*", TokenType.sigMultiplicar },
            { @"\/", TokenType.sigDividir },
            { @"\(", TokenType.parAbierto },
            { @"\)", TokenType.parCerrado },
            { @"([0-1])+", TokenType.noBin },
            { @"([0-7])+", TokenType.noOct },
            { @"([0-9A-Fa-f])+", TokenType.noHex },
            { @"[a-zA-Z_][a-zA-Z0-9_]*", TokenType.identificador },
        };

        public AnalizadorLexico(string input)
        {
            this.input = input;
            this.posicion = 0;
        }


        /// <summary>
        /// Este metodo nos sirve para tokenizar el input que nos dan.
        /// </summary>
        /// <returns>Devuelve una lista con cada uno de los tokens correspondientes a cada una de las palabras encontradas en el REGEX</returns>
        /// <exception cref="Exception">No esperab el token que analiza</exception>
        public List<Token> Tokenizador()
        {
            var tokens = new List<Token>();
            while (posicion < input.Length)
            {
                // Ignorar espacios en blanco
                if (char.IsWhiteSpace(input[posicion]))
                {
                    posicion++;
                    continue;
                }

                bool matched = false;

                //Va recorriendo el diccionario hasta ver en donde cuadra el patron que va de acuerdo a la posicion del tokeb
                foreach (var pattern in tokenPatterns)
                {
                    var regex = new Regex($"^({pattern.Key})");
                    var match = regex.Match(input.Substring(posicion));

                    //Si pasa el matcher anade el token
                    if (match.Success)
                    {
                        tokens.Add(new Token(pattern.Value, match.Value));
                        posicion += match.Value.Length;
                        matched = true;
                        break;
                    }
                }

                if (!matched)
                {
                    throw new Exception($"No se esperaba el token en la posicion:  {posicion}");
                }
            }

            tokens.Add(new Token(TokenType.EOF, string.Empty));
            return tokens;
        }

    }
}
