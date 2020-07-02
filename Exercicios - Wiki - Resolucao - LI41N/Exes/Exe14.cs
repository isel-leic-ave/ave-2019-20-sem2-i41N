using System;
using System.Collections.Generic;

namespace Exercicios.Exes
{

    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> seq, Predicate<T> pred) {
            IEnumerator<T> enumerator = seq.GetEnumerator();

            while (enumerator.MoveNext())
            {
                yield return Aux(enumerator, pred);
            }
        }

        private static IEnumerable<T> Aux<T>(IEnumerator<T> enumerator, Predicate<T> pred) {
            // Quando entra no metodo, ja' esta' no primeiro (no inicio)
            // NAO FUNCIONA
            //while (enumerator.MoveNext())
            //{
            //    if (!pred(enumerator.Current))
            //    {
            //        yield return enumerator.Current;
            //    }
            //    else {
            //        yield return enumerator.Current;
            //        break; // Quebrar este ciclo
            //    }
            //}

            //do
            //{
            //    if (!pred(enumerator.Current))
            //    {
            //        yield return enumerator.Current;
            //    }
            //    else
            //    {
            //        yield return enumerator.Current;
            //        break; // Quebrar este ciclo
            //    }
            //}
            //while (enumerator.MoveNext());

            //do
            //{
            //    yield return enumerator.Current;

            //    if (pred(enumerator.Current))
            //    {
            //        break; // Quebrar este ciclo
            //    }
            //}
            //while (enumerator.MoveNext());

            do
            {
                yield return enumerator.Current;
            }
            while (!pred(enumerator.Current) && enumerator.MoveNext());

        }

    }

    public class Exe14
    {
        public static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<IEnumerable<int>> chunked = numbers.Chunk(v => v % 2 == 0);
            foreach (IEnumerable<int> s in chunked)
            {
                Console.WriteLine(String.Join(",", s));
            }
        
            
        }
    }
}

/*
Output:
1,2
3,4
5,6
7,8
9,10 

 */ 