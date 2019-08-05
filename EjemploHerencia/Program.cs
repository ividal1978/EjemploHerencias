using System;

namespace EjemploHerencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Caballos babieca = new Caballos("Trueno");
            Humano Juan = new Humano("Juan");
            Gorila Copito = new Gorila("Copito");

            IMamiferosTerrestres ImiBabieca = babieca;

            Mamiferos[] misMamiferos = new Mamiferos[3];

            misMamiferos[0] = babieca;
            misMamiferos[1] = Juan;
            misMamiferos[2] = Copito;

            for (int i = 0; i < 3; i++)
            {
                misMamiferos[i].Pensar();
            }
            //babieca.Galopar();
            //Copito.Trepar();
            //Juan.Pensar();

            //Juan.GetNombre();
            //Copito.GetNombre();
            //babieca.GetNombre();

            Ballena miBallena = new Ballena("Wally");
            miBallena.Nadar();
            Console.WriteLine( $"Numero de patas de un caballo: {ImiBabieca.NumeroPatas()}");

            ISaltoConPatas IMmiBabieca = babieca;
            Console.WriteLine($"Patas que usa para saltar: {IMmiBabieca.NumeroPatas()}");
        }

        interface IMamiferosTerrestres
        {
            int NumeroPatas();
        }
        interface IAnimalesyDeportes
        {
            string TipoDeporte();
            Boolean EsOlimpico();
        }

        interface ISaltoConPatas
        {
            int NumeroPatas();
        }

         class Mamiferos
        {

            public Mamiferos(string nombre) => nombreSerVivo = nombre;
            public void Respirtar()
            {
                Console.WriteLine("Soy capaz de respirar");
            }

            public void CuidarCrias()
            {
                Console.WriteLine("Soy capaz de cuidar mis crias hasta que se valgan por si solas");
            }

            public void GetNombre()
            {
                Console.WriteLine($"El nombre del ser vivo es {nombreSerVivo} ");
            }

            public virtual void Pensar()
            {
                Console.WriteLine("Pensamiento Basico Instintivo");
            }

            private string nombreSerVivo;
        }

        class Caballos : Mamiferos, IMamiferosTerrestres,IAnimalesyDeportes,ISaltoConPatas
        {
            public Caballos(string nombreCaballo) : base(nombreCaballo)
            { }
            public void Galopar()
            {
                Console.WriteLine("Soy capaz de galopar");
            }

            int IMamiferosTerrestres.NumeroPatas() => 4;

            public string TipoDeporte() => "Hípica";

            public Boolean EsOlimpico() => false;

            int ISaltoConPatas.NumeroPatas() => 2;
            
        }

        class Humano : Mamiferos ,IMamiferosTerrestres,IAnimalesyDeportes
        {
            public Humano(string nombreHumano) : base(nombreHumano)
            { }

            public bool EsOlimpico() => true;

            public int NumeroPatas()=> 2;

            public override void Pensar()
            {
                Console.WriteLine("Soy capaz de Pensar");
            }

            public string TipoDeporte() => "Atletismo";
            
        }

        class Gorila : Mamiferos, IMamiferosTerrestres
        {
            public Gorila(string nombreGorila) : base(nombreGorila) { }
            public void Trepar()
            {
                Console.WriteLine("Soy capaz de Trepar");
            }

            public override void Pensar()
            {
                Console.WriteLine( "Pensamiento instintivo Avanzado");

            }

            public int NumeroPatas()
            { return 2; }
        }

        class Ballena:Mamiferos
        {
            public Ballena(string nombreBallena) : base(nombreBallena) { }

            public void Nadar()
            {
                Console.WriteLine("Soy capaz de nadar");
            }
        }
    }
}
