
using System;

namespace IdentityAndEquality
{

    // A natureza do tipo (se é Tipo valor ou Tipo referência) influencia o comportamento do código
    // quando se utiliza o operador ==

    // public struct Point2D
    public class Point2D
    {
        private int x, y;

        public Point2D(int x, int y) { this.x = x; this.y = y; }

        //// Overload do operator==
        //public static bool operator==(Object o, Point2D p)
        //{            
        //     Console.WriteLine("[Point2D] calling operator==");
        //     return false; // not correctly implemented
        //}
        //public static bool operator !=(Object o, Point2D p)
        //{
        //    return !(o == p);
        //}
    }

    class OpEqualityTest
    {
        static void Main1(string[] args)
        {
            object o1 = new object();
            object o2 = new object();
            bool res1 = o1 == o2; // ceq -> false

            Point2D p1 = new Point2D(1, 2);
            Point2D p2 = new Point2D(1, 2);
            // Instrucao IL ceq (compare if equal) => desempilha parametros e compara a igualdade

            Console.WriteLine(p1 == p1); // Se tipo class, e se operator== nao definido. ceq -> true
                                         // Se operator== definido, invoca operator==
                                         // Se tipo struct, Erro, se operator== não estiver definido
            Console.WriteLine(p1 == p2); // Se tipo class, e se operator== nao definido. ceq -> false
                                         // Se operator== definido, invoca operator==
                                         // Se tipo struct, Erro, se operator== não estiver definido
        }
    }
}