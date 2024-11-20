namespace GerenciadorLivro.AppConsole.Entities
{
    public class Usuario
    {

        public Usuario(string nome, string email)
        {

            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;

        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string ExibirDetalhes()
        {
            return $"Identificador: {Id}, Nome: {Nome}, Email: {Email}";
        }
    }
}
