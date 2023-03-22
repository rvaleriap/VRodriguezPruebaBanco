using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Banco
    {
        public static void Add()
        {
            ML.Banco banco = new ML.Banco();

            Console.WriteLine("Ingrese el Nombre del banco");
            banco.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el NoEmpleados del banco");
            banco.NoEmpleados = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el NoSucursales del banco");
            banco.NoSucursales = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el Capital del banco");
            banco.Capital = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el NoClientes del banco");
            banco.NoClientes = int.Parse(Console.ReadLine());

            banco.Pais = new ML.Pais();
            Console.WriteLine("Ingrese el IdPais del banco");
            banco.Pais.IdPais = int.Parse(Console.ReadLine());

            banco.RazonSocial = new ML.RazonSocial();
            Console.WriteLine("Ingrese el IdRazonSocial del banco");
            banco.RazonSocial.IdRazonSocial = int.Parse(Console.ReadLine());

            ML.Result result = BL.Banco.Add(banco);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            PL.Banco.Add();
        }
    }
}
