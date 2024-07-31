using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio1_Compis
{
    public class AnalizadorSintactico
    {
        private Stack<string> pila;
        public AnalizadorSintactico()
        {
            pila = new Stack<string>();
        }
        public int parsear(List<string> tokens)
        {
            pila.Push("S");

            while (tokens.Count() != 0)
            {
                string lookahead = tokens[0];
                switch (pila.Peek())
                {
                    case "sigMas":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "sigMenos":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                return 0;
                            }
                        }
                        break;
                    case "sigMultiplicar":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                return 0;
                            }
                        }
                        break;
                    case "sigDividir":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                return 0;
                            }
                        }
                        break;
                    case "parAbierto":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                return 0;
                            }
                        }
                        break;
                    case "parCerrado":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                return 0;
                            }
                        }
                        break;
                    case "noBin":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);   
                            }
                        }
                        break;
                    case "noOct":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "noHex":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "tipadoBin":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "tipadoOct":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "tipadoHex":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "sigIgual":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "puntoComa":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "expresionComienza":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "identificador":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "S":
                        {
                            pila.Pop();
                            pila.Push("StmtList");
                        }
                        break;
                    case "StmtList":
                        {
                            if (lookahead == "StmtList")
                            {
                                pila.Pop();
                                pila.Push("Stmt");
                                pila.Push("StmtList");
                            }
                            else
                            {
                                pila.Pop();
                            }

                        }
                        break;
                    case "Stmt":
                        {
                            if (lookahead == "VarDecl")
                            {
                                pila.Pop();
                                pila.Push("VarDecl");
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("ExprStmt");
                            }

                        }
                        break;
                    case "VarDecl":
                        {
                            if (lookahead == "oct")
                            {
                                pila.Pop();
                                pila.Push("puntoComa");
                                pila.Push("noOct");
                                pila.Push("sigIgual");
                                pila.Push("identificador");
                                pila.Push("tipadoOct");
                            }
                            else if (lookahead == "bin")
                            {
                                pila.Pop();
                                pila.Push("puntoComa");
                                pila.Push("noBin");
                                pila.Push("sigIgual");
                                pila.Push("identificador");
                                pila.Push("tipadoBin");
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("puntoComa");
                                pila.Push("noHex");
                                pila.Push("sigIgual");
                                pila.Push("identificador");
                                pila.Push("tipadoHex");
                            }

                        }
                        break;
                    case "ExprStmt":
                        {
                            pila.Pop();
                            pila.Push("puntoComa");
                            pila.Push("Expr");
                            pila.Push("expresionComienza");
                        }
                        break;
                    case "Expr":
                        {
                            pila.Pop();
                            pila.Push("ExprPrime");
                            pila.Push("Term");
                        }
                        break;
                    case "ExprPrime":
                        {
                            if (lookahead == "sigMas")
                            {
                                pila.Pop();
                                pila.Push("ExprPrime");
                                pila.Push("Term");
                                pila.Push("sigMas");
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("ExprPrime");
                                pila.Push("Term");
                                pila.Push("sigMenos");
                            }
                        }
                        break;
                    case "Term":
                        {
                            pila.Pop();
                            pila.Push("TermPrime");
                            pila.Push("Factor");
                        }
                        break;
                    case "TermPrime":
                        {
                            if (lookahead == "sigMultiplicar")
                            {
                                pila.Pop();
                                pila.Push("ExprPrime");
                                pila.Push("Term");
                                pila.Push("sigMas");
                            }
                            else if (lookahead == "sigDividir")
                            {
                                pila.Pop();
                                pila.Push("ExprPrime");
                                pila.Push("Term");
                                pila.Push("sigMenos");
                            }
                            else
                            {
                                pila.Pop();
                            }
                        }
                        break;
                    case "Factor":
                        {
                            if (lookahead == "identificador")
                            {
                                pila.Pop();
                                pila.Push("identificador");
                            }
                            else if (lookahead == "noBin")
                            {
                                pila.Pop();
                                pila.Push("noBin");
                            }
                            else if (lookahead == "noOct")
                            {
                                pila.Pop();
                                pila.Push("noOct");
                            }
                            else if (lookahead == "noHex")
                            {
                                pila.Pop();
                                pila.Push("noHex");
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("parCerrado");
                                pila.Push("Expr");
                                pila.Push("parAbierto");
                            }
                        }
                        break;
                    default:
                        throw new Exception("Simbolo no esperado ");
                }
                
            }
            if (pila.Count() > 0)
                return 0;
            else
                return 1;
        }
    }
}
