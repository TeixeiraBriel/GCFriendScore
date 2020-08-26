using GCFriendsScore.Entidades;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCFriendsScore
{

    public class CSV_UsuariosProvider
    {

        public List<Usuario> Lista = new List<Usuario>();

        private readonly string file = "Itens\\DadosUsuarios.csv";

        private bool primeiraLinha = true;

        public void CarregaDados()
        {
            List<Usuario> ListaVazia = new List<Usuario>();
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
                    Usuario model = new Usuario();

                    model.Id = campos[0];
                    model.Nome = campos[1];
                    model.KDA = campos[2];
                    model.ADR = campos[3];
                    model.Matou = campos[4];
                    model.Morreu = campos[5];
                    model.KAST = campos[6];
                    model.MultiKills = campos[7];
                    model.FirstKills = campos[8];
                    model.Clutches = campos[9];
                    model.Hs = campos[10];
                    model.Precisao = campos[11];
                    model.BombasPlan = campos[12];
                    model.BombasDef = campos[13];
                    model.UltAtualizacao = campos[14];

                    Lista.Add(model);
                }
            }
            primeiraLinha = true;
        }
    }
}
