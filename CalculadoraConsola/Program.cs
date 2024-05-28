using System;
using EspacioCalculadora;

class Program
{
    static void Main(string[] args)
    {
        Calculadora calc = new Calculadora();
        string comando;
        double valor;

        Console.WriteLine("Bienvenido a la Calculadora. Ingrese comandos para operar o 'salir' para finalizar.");

        while (true)
        {
            Console.WriteLine($"Resultado actual: {calc.Resultado}");
            Console.Write("Ingrese una operación (sumar, restar, multiplicar, dividir, limpiar) seguida de un valor, o 'salir' para finalizar: ");
            comando = Console.ReadLine();

            if (comando.ToLower() == "salir")
            {
                break;
            }

            string[] partes = comando.Split(' ');

            if (partes.Length == 2 && double.TryParse(partes[1], out valor))
            {
                switch (partes[0].ToLower())
                {
                    case "sumar":
                        calc.Sumar(valor);
                        break;
                    case "restar":
                        calc.Restar(valor);
                        break;
                    case "multiplicar":
                        calc.Multiplicar(valor);
                        break;
                    case "dividir":
                        calc.Dividir(valor);
                        break;
                    case "limpiar":
                        calc.Limpiar();
                        break;
                    default:
                        Console.WriteLine("Comando no reconocido. Intente nuevamente.");
                        break;
                }
            }
            else if (partes[0].ToLower() == "limpiar")
            {
                calc.Limpiar();
            }
            else
            {
                Console.WriteLine("Formato no válido. Intente nuevamente.");
            }
        }
    }
}
