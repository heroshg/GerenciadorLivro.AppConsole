using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.AppConsole.Entities
{
    public class Emprestimo
    {

        public Emprestimo(Guid idUsuario, Guid idLivro, DateTime dataDeDevolucao)
        {
            Id = Guid.NewGuid();
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            DataEmprestimo = DateTime.Now;
            DataDeDevolucao = dataDeDevolucao;
        }

        public Guid Id { get; private set; }
        public Guid IdUsuario { get; private set; }
        public Guid IdLivro { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataDeDevolucao { get; private set; }

        public string ExibirDetalhes()
        {
            return $"Identificador: {Id}, Identificador do Usuário: {IdUsuario}, Identificador do Livro: {IdLivro}, Data de Empréstimo:{DataEmprestimo}, Data de Devolução: {DataDeDevolucao}";
        }
    }
}
