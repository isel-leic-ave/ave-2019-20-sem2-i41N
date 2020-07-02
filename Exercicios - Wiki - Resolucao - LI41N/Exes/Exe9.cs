using System;
namespace Exercicios.Exes
{
    interface IBean
    {
        void Set(int v);
        int Get();
    }
    struct S : IBean
    {
        public int x;
        public void Set(int v) { this.x = v; }
        public int Get() { return this.x; }
    }

//Dadas as variáveis s e i definidas pelas expressões: S s = new S(); IBean i = s;
//a) F__ A execução de ((IBean) s).Set(11); Console.WriteLine(s.x); tem o output 11.
//b) F__ A execução de ((S) i).Set(11); Console.WriteLine(i.Get()); tem o output 11.
//c) F__ A execução de s.x = 11; Console.WriteLine(i.Get()); tem o output 11.
//d) F__ A execução de s.Set(11); Console.WriteLine(i.Get()); tem o output 11.

    public class Exe9
    {
        public static void Main1() {
            S s = new S(); 
            IBean i = s; // Box => cria novo objeto no heap do tipo boxed type de S, que 
            // passa a ser referido por i. A struct s e' copiada para esse boxed object
            // a)
            ((IBean) s).Set(11); // Box + set de x no heap
            Console.WriteLine(s.x); // 0 pois imprime s que esta' no stack

            // b)
            ((S)i).Set(11); // Unbox e set de x da variavel temporaria unboxed
            Console.WriteLine(i.Get()); // Ler o que esta' no heap => s.x boxed == 0

            // c)
            s.x = 11; 
            Console.WriteLine(i.Get()); // Ler o que esta' no heap => s.x boxed == 0

            // d)
            s.Set(11); 
            Console.WriteLine(i.Get()); // Idem


            i.Set(100); // Alterar s.x que esta' no heap
            Console.WriteLine(i.Get()); // 100

        }
    }
}




















