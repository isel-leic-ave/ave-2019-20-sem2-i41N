using System;
using System.Reflection;

namespace Exercicios.Exes
{
    class Sammy : Attribute { public int Nr { get; set; } }
    [Sammy(Nr = 71)] class Game { }
    //[Sammy(Nr = App.Foo())] class Deal { }
    public class App
    {
        public static int Foo() { return 17; }
        static void Main1()
        {
            typeof(Game).GetCustomAttribute<Sammy>().Nr = 19; // Desserializa da metadata e constroi um objecto,
            // neste caso, temporario, do tipo SammyAttribute. Depois afeta a propriedade Nr. Mas, nada e' escrito na metadata,
            // apenas no objeto atributo que existe em memoria.
            Console.WriteLine(typeof(Game).GetCustomAttribute<Sammy>().Nr);// Desserializa da metadata (novamente) e constroi um objecto,
            //(new Sammy()).Nr = 15;
        }
    }
//Para a definição dada de Sammy, Game, Deal e App:
//a) V__ a instrução da linha 3 dá erro de compilação.
//b) V__ a instrução da linha 8 retorna 71.
//c) F__ a instrução da linha 7 lança uma excepção.
//d) F__ a instrução(new Sammy()).Nr = 15; dá erro de compilação.

}
