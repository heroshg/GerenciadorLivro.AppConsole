namespace GerenciadorLivro.AppConsole.Entities
{
    public class Livro
    {

        public Livro(string titulo, string autor, string isbn, int anoDePublicacao)
        {

            Id = Guid.NewGuid();
            Titulo = titulo;
            Autor = autor;
            Isbn = isbn;
            AnoDePublicacao = anoDePublicacao;

        }

        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }  
        public string Isbn { get; private set; }
        public int AnoDePublicacao { get; private set; }
        public string ExibirDetalhes()
        {
            return $"Identificador: {Id}, Titulo: {Titulo}, Autor: {Autor}, ISBN:{Isbn}, Ano de publicação: {AnoDePublicacao}";
        }
    }
}
