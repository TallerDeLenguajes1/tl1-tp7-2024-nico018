using System;
using System.Collections.Generic;

public enum Cargos
{
    Auxiliar,
    Administrativo,
    Ingeniero,
    Especialista,
    Investigador
}

public class Empleado
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public char EstadoCivil { get; set; }
    public DateTime FechaIngreso { get; set; }
    public double SueldoBasico { get; set; }
    public Cargos Cargo { get; set; }

    public int CalcularAntiguedad()
    {
        return DateTime.Now.Year - FechaIngreso.Year;
    }

    public int CalcularEdad()
    {
        return DateTime.Now.Year - FechaNacimiento.Year;
    }

    public int AnosParaJubilarse()
    {
        return 65 - CalcularEdad();
    }

    public double CalcularSalario()
    {
        int antiguedad = CalcularAntiguedad();
        double adicional = 0;

        if (antiguedad <= 20)
        {
            adicional = SueldoBasico * 0.01 * antiguedad;
        }
        else
        {
            adicional = SueldoBasico * 0.25;
        }

        if (Cargo == Cargos.Ingeniero || Cargo == Cargos.Especialista)
        {
            adicional *= 1.5;
        }

        if (EstadoCivil == 'C')
        {
            adicional += 150000;
        }

        return SueldoBasico + adicional;
    }

    public override string ToString()
    {
        return $"{Nombre} {Apellido}, Edad: {CalcularEdad()}, Antigüedad: {CalcularAntiguedad()}, Años para Jubilarse: {AnosParaJubilarse()}, Salario: {CalcularSalario()}";
    }
}

public class Program
{
    public static void Main()
    {
        Empleado[] empleados = new Empleado[3];

        empleados[0] = new Empleado
        {
            Nombre = "Juan",
            Apellido = "Pérez",
            FechaNacimiento = new DateTime(1980, 5, 15),
            EstadoCivil = 'C',
            FechaIngreso = new DateTime(2005, 3, 20),
            SueldoBasico = 650000,
            Cargo = Cargos.Ingeniero
        };

        empleados[1] = new Empleado
        {
            Nombre = "María",
            Apellido = "Gómez",
            FechaNacimiento = new DateTime(1990, 7, 22),
            EstadoCivil = 'S',
            FechaIngreso = new DateTime(2010, 8, 1),
            SueldoBasico = 500000,
            Cargo = Cargos.Administrativo
        };

        empleados[2] = new Empleado
        {
            Nombre = "Carlos",
            Apellido = "Rodríguez",
            FechaNacimiento = new DateTime(1975, 1, 30),
            EstadoCivil = 'C',
            FechaIngreso = new DateTime(2000, 12, 15),
            SueldoBasico = 700000,
            Cargo = Cargos.Especialista
        };

        double montoTotalSalarios = 0;
        Empleado masProximoAJubilarse = empleados[0];

        foreach (var empleado in empleados)
        {
            Console.WriteLine(empleado);
            montoTotalSalarios += empleado.CalcularSalario();

            if (empleado.AnosParaJubilarse() < masProximoAJubilarse.AnosParaJubilarse())
            {
                masProximoAJubilarse = empleado;
            }
        }

        Console.WriteLine($"\nMonto Total de Salarios: {montoTotalSalarios}");
        Console.WriteLine($"\nEmpleado más próximo a jubilarse:\n{masProximoAJubilarse}");
    }
}
