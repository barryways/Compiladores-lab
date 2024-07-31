using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio1_Compis
{
    /// <summary>
    /// Este enum sirve para tener el tipo de token que tenemos, si lo que viene es una variable hexa, en base a esto selecciona que sea una varhx
    /// </summary>
    public enum TokenType
    {
        sigMas,
        sigMenos,
        sigMultiplicar,
        sigDividir,
        parAbierto,
        parCerrado,
        noBin,
        noOct,
        noHex,
        identificador,
        sigIgual,
        puntoComa,
        expresionComienza,
        tipadoBin,
        tipadoOct,
        tipadoHex,
        EOF 
    }

    /// <summary>
    /// Esta clase nos sirve para clasificar los tokens y almacenar su valor en el mismo
    /// </summary>
    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }

}
