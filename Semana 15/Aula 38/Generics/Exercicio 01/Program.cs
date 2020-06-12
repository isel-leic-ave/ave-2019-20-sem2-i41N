using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Exercício_02___Converter;

namespace Exercicio_01
{
    class B<T1, T2> 
        //where T1 : class
        //where T1 : new()
    {
        public void m(T1 a) {
            //a. // apenas métodos de object
            int i = new int();
            //a = null;
            a = default(T1); // Se for class -> null;se value type -> new ctor()

            //T1 b = MyDefault<T1>(typeof(T1));
            T1 b = (T1)MyDefault<T1>();

            // e.g. new int()
            //a = new T1(); // Nao ha garantia que existe ctor T1()
        }

        // 1a Tentativa
        //public T MyDefault<T>(T obj)
        // 2a Tentativa - Funciona se passar typeof(T1)
        //public T MyDefault<T>(Type t) {
        //    return default();
        //}
        // 3a Tentativa
        public object MyDefault<T>() {
            Type t = typeof(T);
            return (t.IsValueType ? Activator.CreateInstance(t) : null);
        }

    }


    class Test {
        public static void Main1() {
            //B<int, bool> b = new B<int, bool>();
            //b.m(10);
            B<Test, bool> b = new B<Test, bool>();
            b.m(new Test());
        }
    }



    #region
    class MyList<T> : List<T> {
        public MyList(T[] arr) : base(arr) {
        }

        new public List<T> FindAll(Predicate<T> pred) {
            Console.WriteLine("MyList::FindAll");

            List<T> res = new List<T>();
            foreach (T val in this) {
                if (pred(val))
                {
                    res.Add(val);
                }
            }
            return res;
        }
    }
    #endregion


    class Program
    {
        /////////////////////////////////////
        /// a)
        public static void PrintValuesUnder10(/*List<int> l*/MyList<int> l)
        {
            List<int> res = l.FindAll(Program.Under10);
            // Ou:
            //List<int> res = l.FindAll(new Predicate<int>(Program.Under10));
            // Ou: usar lambdas
            foreach (int elem in res)
                Console.WriteLine(elem);
        }

        public static bool Under10(int elem)
        {
            return elem < 10;
        }
        #region
        //////////////////////////////////////
        /// b)
        private int limit;

        public Program(int limit) { this.limit = limit; }

        public static void PrintValuesUnderLimit(List<int> l, int limit)
        {
            //List<int> res = l.FindAll(new Predicate<int>(new Program(limit).UnderLimit));
            List<int> res = l.FindAll((elem) => elem < limit);

            foreach (int elem in res)
                Console.WriteLine(elem);

        }
        public bool UnderLimit(int elem)
        {
            return elem < limit;
        }
        ///////////////////////////////////////////
        #endregion

        public delegate bool MyPredicate<T>(T i);

        public static int CountIf<T>(T[] a, MyPredicate<T> p)
        {
            int count = 0;
            foreach (T i in a) {
                if (p(i))
                    ++count;
            }
            return count;
        }

        public static int CountIf<T>(IEnumerable<T> a, MyPredicate<T> p)
        {
            int count = 0;
            foreach (T i in a)
            {
                if (p(i))
                    ++count;
            }
            return count;
        }

        public static void TimesBy2(List<int> l)
        {
            int[] elems = l.ToArray();
            //elems = Array.ConvertAll<int, int>(elems, new System.Converter<int, int>(Program.Modify));
            elems = ArrayUtils.ConvertAll<int, int>(elems, new Exercício_02___Converter.Converter<int, int>(Program.Modify));


            foreach (int elem in elems)
                Console.WriteLine(elem);
        }

        private static int Modify(int i) {
            return i * 2;
        }


        static void Main(string[] args)
        {
            ////List<int> l = new List<int>(new int[] { 12, 2, 1, 3, 16, 9, 23 });
            MyList<int> l = new MyList<int>(new int[] { 12, 2, 1, 3, 16, 9, 23 });

            //PrintValuesUnder10(l);
            //Console.WriteLine();

            //PrintValuesUnderLimit(l, 20);
            //Console.WriteLine();

            //int c = CountIf<int>(new int[] { 12, 2, 1, 3, 16, 9, 23 }, delegate(int i) { return i >= 10;  });
            //Console.WriteLine("counted {0} elems", c);
            TimesBy2(l);
        }
    }
}





