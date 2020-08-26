using GCFriendsScore.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCFriendsScore
{
    public class CSV_AmigosProvider
    {
        public List<Amigos> Lista = new List<Amigos>();

        private readonly string file = "Itens\\DadosAmigos.csv";

        private bool primeiraLinha = true;

        public void CarregaDados()
        {
            List<Amigos> ListaVazia = new List<Amigos>();
            Lista = ListaVazia;
            string[] linhas = File.ReadAllLines(file);

            foreach (var linha in linhas)
            {
                string[] campos = linha.Split(',');

                if (primeiraLinha)
                {
                    primeiraLinha = false;
                }
                else
                {
                    Amigos model = new Amigos();

                    model.Id = campos[0];
                    model.Nome = campos[1];

                    Lista.Add(model);
                }
            }
            primeiraLinha = true;
        }

        public void inserirlinha(string Id, string Nome)
        {
            var csv = new StringBuilder();
            var newline = string.Format("{0},{1}", Id, Nome);
            csv.AppendLine(newline);

            File.AppendAllText(file, csv.ToString());

        }
    }
}
