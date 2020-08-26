using GCFriendsScore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCFriendsScore
{
    class ListaAmigos
    {
        public Amigos ColetarDadosAmigos(string Id)
        {
            List<Amigos> Lista = new List<Amigos>();

            Amigos novo = new Amigos();
            novo.Id = Id;
            novo.Nome = "atual";

            Lista.Add(novo);

            return novo;
        }

        public List<Amigos> BuscarAmigos()
        {
            List<Amigos> Lista = new List<Amigos>();

            //Procurar em um CSV os amigos
            //Fazer Logica
            for (int i = 0; i < 2; i++)
            {
                Lista.Add(ColetarDadosAmigos(i.ToString()));
            }

            return Lista;
        }
    }
}
