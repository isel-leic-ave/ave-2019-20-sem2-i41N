using System;
namespace Exercicios.Exes13
{
    //Escreva em IL o código do construtor e do método InvokeAll da classe B.

    delegate object Func(int p);

    abstract class A
    {
        protected Func Handlers { get; set; }
        protected int MaxNumHandlers { get; set; }
        protected A(int maxNumHandlers)
        {
            this.MaxNumHandlers = maxNumHandlers;
        }
    }
    class B : A
    {
        public B() : base(10) { 
            Handlers = Bundle; 

            // Nota:
            //Quando se cria um objeto e' usado newobj => cria espaco + invocao ctor
            // Dentro dum ctor, quando se chama outro ctor => e' apenas feito um call
/* IL:
 //base(10)
           
ldarg.0 // this
ldc.i4 10
call instance void A::ctor(int)

// Handlers = Bundle; 
ldarg.0 // this necessario para o set_Handlers
ldarg.0 // this
ldftn instance object B::Bundle(int32)
newobj instance void Func::ctor(object, native int)
// Set 'a propriedade Handlers
call instance void A::set_Handlers(Func)
ret
*/
        }

        private object Bundle(int p) { return p; }

        public object InvokeAll(object parameter)
        {
            return Handlers((int)parameter);
/*

// Get 'a propriedade Handlers
ldarg.0 // this necessario para o get_Handlers
call instance Func A::get_Handlers()
// Neste ponto, tenho o delegate no stack
ldarg.1
unbox_any int32
// Neste ponto, tenho o delegate + args no stack
// Invoke:
callvirt instance object Func::Invoke(int32)
ret
*/ 

        }
    }
}
