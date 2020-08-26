using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Executor
    {
        private string file = "DadosUsuarios.csv";

        public bool ResetarCsv()
        {
            File.Create(file);

            return true;
        }

        public void ResetarCsvPT2()
        {
            var csv = new StringBuilder();
            var newline = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", "Id", "Nome", "KDA", "ADR", "Matou", "Morreu", "KAST", "MultiKills", "FirstKills", "Clutches", "Hs", "Precisao", "BombasPlan", "BombasDef", "UltAtualizacao");
            csv.AppendLine(newline);

            File.AppendAllText(file, csv.ToString());
        }
    }
}
