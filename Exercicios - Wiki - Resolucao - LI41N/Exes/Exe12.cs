using System;
namespace Exercicios.Exes
{
    class A
    {
        public virtual void Foo() { }
    }
    class App1
    {
        void Main()
        {
            A a = new A();
            a.Foo();
            //ldloc.0 
            // callvirt instance void A::Foo()  // Se Foo e virtual gera sempre callvirt => Despacho dinamico
            // Se Foo nao e' virtual geral callvirt para testar this diferente null => Despacho Estatico

            // Se fizer:
            new A().Foo();
            // E Foo for nao virtual gera>
            //ldloc.0 
            // call instance void A::Foo()  // this diferente null e Despacho estatico


        }
    }

//    Para a instrução a.Foo() o compilador de C# gera: ldloc.0 callvirt instance void A::Foo()
//Alterando a definição de Foo para:
//a) F___ public void Foo() { }
//    o compilador gera: ldloc.0 call instance void A::Foo()
//b) F___ public void Foo() { }
//    o compilador gera: call instance void A::Foo()
//c) F___ public static void Foo() { }
//    e a.Foo(); alterada para A.Foo(); o compilador gera: ldloc.0 call void A::Foo()
    // ldloc esta' a mais

//d) V___ public static void Foo() { }
    //e a.Foo(); alterada para A.Foo(); o compilador gera: call void A::Foo()
}
