using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Executor Exec = new Executor();
            //Console.WriteLine("0:Apagar 1:ColocarCabecalho");
            //int op = int.Parse(Console.ReadLine());

            //if (op == 0)
            //{
            //    Exec.ResetarCsv();
            //}
            //else
            //{
            //    Exec.ResetarCsvPT2();
            //}


            Console.WriteLine("Apagando...");
            Exec.ResetarCsv();
            //Console.WriteLine("Escrevendo...");
            //Exec.ResetarCsvPT2();
        }
    }
}
