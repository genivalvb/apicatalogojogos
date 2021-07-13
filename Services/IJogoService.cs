using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCatalogoJogos.ViewModel;
using ApiCatalogoJogos.InputModel;
using System;

namespace ApiCatalogoJogos.Services
{
    public interface IJogoService : IDisposable
    {

        Task<List<JogoViewModel>> Obter(int pagina, int quantidade);
        Task<JogoViewModel> Obter(Guid id);
        Task<JogoViewModel> Inserir(JogoInputModel jogo);
        Task Atualizar(Guid id, JogoInputModel jogo);
        Task Atualizar(Guid id, double preco);
        Task Remover(Guid id);
    }
}
