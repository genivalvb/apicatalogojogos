using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiCatalogoJogos.Repositories;
using ApiCatalogoJogos.Entities;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>(){
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), 
            new Jogo{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), 
            Nome = "Fifa 21", Produtora= "EA", Preco = 200}},

            {Guid.Parse("eba314a5-9282-45d8-92c3-2985f2a9fd04"), 
            new Jogo{ Id = Guid.Parse("eba314a5-9282-45d8-92c3-2985f2a9fd04"), 
            Nome = "Fifa 20", Produtora= "EA", Preco = 190}},

            {Guid.Parse("5ea314a5-9282-45d8-92c3-2985f2a9fd04"), 
            new Jogo{ Id = Guid.Parse("5ea314a5-9282-45d8-92c3-2985f2a9fd04"), 
            Nome = "Fifa 19", Produtora= "EA", Preco = 180}},

            {Guid.Parse("daa314a5-9282-45d8-92c3-2985f2a9fd04"), 
            new Jogo{ Id = Guid.Parse("daa314a5-9282-45d8-92c3-2985f2a9fd04"), 
            Nome = "Fifa 18", Produtora= "EA", Preco = 170}},

            {Guid.Parse("92a314a5-9282-45d8-92c3-2985f2a9fd04"), 
            new Jogo{ Id = Guid.Parse("92a314a5-9282-45d8-92c3-2985f2a9fd04"), 
            Nome = "Street Fighter V", Produtora= "Capcom", Preco = 80}}
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade){
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id){
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora){
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task Inserir(Jogo jogo){
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo){
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id){
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose(){
            //Fechar conexão com o banco
        }
    }
}
