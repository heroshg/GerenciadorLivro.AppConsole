using GerenciadorLivro.AppConsole.Entities;

Console.WriteLine("Bem Vindo ao Gerenciador de Livros");

List<Livro> livros = new List<Livro>()
{
    new Livro("O Senhor dos Anéis: A Sociedade do Anel", "J.R.R. Tolkien", "978-0-618-00222-8", 1954),
                new Livro("1984", "George Orwell", "978-0-452-28423-4", 1949),
                new Livro("Dom Casmurro", "Machado de Assis", "978-85-209-2083-0", 1899),
                new Livro("Orgulho e Preconceito", "Jane Austen", "978-0-19-953556-9", 1813),
                new Livro("Cem Anos de Solidão", "Gabriel García Márquez", "978-0-06-088328-7", 1967)
};

List<Usuario> usuarios = new List<Usuario>
{
                new Usuario("José", "jose@gmail.com"),
                new Usuario("João", "joao@gmail.com"),
                new Usuario("Henrique", "henrique@gmail.com"),
                new Usuario("Julio", "julio@gmail.com"),
                new Usuario("Vitor", "vitor@gmail.com")
};
List<Emprestimo> emprestimos = new List<Emprestimo>();

while (true)
{
    
    Console.WriteLine("Selecione uma das opções:");
    Console.WriteLine("1 - Cadastrar um Livro");
    Console.WriteLine("2 - Consultar Todos os Livros");
    Console.WriteLine("3 - Consultar um Livro");
    Console.WriteLine("4 - Remover um Livro");
    Console.WriteLine("5 - Cadastrar um Usuário");
    Console.WriteLine("6 - Cadastrar um Empréstimo");
    Console.WriteLine("7 - Devolver um Livro");

    var opcao = Console.ReadLine();

    switch(opcao)
    {
        case "1":
            
            Console.WriteLine("Por favor digite o Título do Livro");
            var tituloLivroASerAdicionado = Console.ReadLine();
            if(string.IsNullOrEmpty(tituloLivroASerAdicionado))
            {
                throw new Exception($"Ocorreu um erro pois você digitou um título vazio!");
            }

            Console.WriteLine("Por favor digite o Autor do Livro");
            var autorLivroASerAdicionado = Console.ReadLine();
            if (string.IsNullOrEmpty(autorLivroASerAdicionado))
            {
                throw new Exception($"Ocorreu um erro pois você digitou um título vazio!");
            }

            Console.WriteLine("Digite o ISBN");
            var ISBNLivroASerAdicionado = Console.ReadLine();

            if(string.IsNullOrEmpty(ISBNLivroASerAdicionado))
            {
               throw new Exception($"Ocorreu um erro pois você digitou um título vazio");
            }

            Console.WriteLine("Digite o ano de publicação");
            var anoPublicacaoASerAdicionado = Console.ReadLine();

            if(!int.TryParse(anoPublicacaoASerAdicionado, out var anoConvertido))
            {
               throw new Exception("Ocorreu um erro ao digitar o ano de publicação");
            }

            var livroASerAdicionado = new Livro(tituloLivroASerAdicionado, autorLivroASerAdicionado, ISBNLivroASerAdicionado, anoConvertido);
            livros.Add(livroASerAdicionado);
            Console.WriteLine("Livro adicionado com sucesso!");
            
            
            break;
        case "2":

            foreach(var livro in livros)
            {
                Console.WriteLine(livro.ExibirDetalhes());
            }
            break;

        case "3":

            Console.WriteLine("Digite o identificador do livro que deseja buscar!");
            var idLivroASerConsultado = Console.ReadLine();
            if (string.IsNullOrEmpty(idLivroASerConsultado))
            {
                throw new Exception("Ocorreu um erro ao buscar o id porque ele está vazio.");
            }
            var livroConsultado = livros.Find(l => l.Id.ToString() == idLivroASerConsultado);
            if (livroConsultado is null)
            {
                Console.WriteLine("Livro não encontrado");
                break;
            }

            Console.WriteLine($"Livro encontrado: {livroConsultado.ExibirDetalhes()}"); 
            break;

        case "4":

            Console.WriteLine("Digite o identificador do livro que deseja remover!");
            var idLivroASerRemovido = Console.ReadLine();
            if(string.IsNullOrEmpty(idLivroASerRemovido))
            {
                throw new Exception("Ocorreu um erro ao buscar o id porque ele está vazio.");
            }
             var livroASerRemovido = livros.Find(l => l.Id.ToString() == idLivroASerRemovido);

             if (livroASerRemovido is null)
             {
                Console.WriteLine("Livro não encontrado"); 
                break;
             }

             livros.Remove(livroASerRemovido);
            Console.WriteLine("Livro removido com sucesso!"); 

            break;

        case "5":

            Console.WriteLine("Digite o nome do usuário que deseja registrar!");
            var nomeUsuarioASerAdicionado = Console.ReadLine();
            if(string.IsNullOrEmpty(nomeUsuarioASerAdicionado))
            {
                throw new Exception("Ocorreu um erro pois o nome do usuário está vazio.");
            }
            Console.WriteLine("Digite o email do usuário que deseja registrar");
            var emailDoUsuarioASerAdicionado = Console.ReadLine();
            if(string.IsNullOrEmpty(emailDoUsuarioASerAdicionado))
            {
                throw new Exception("Ocorreu um erro pois o email do usuário está vazio.");
            }
            Usuario usuarioASerAdicionado = new Usuario(nomeUsuarioASerAdicionado, emailDoUsuarioASerAdicionado);
            usuarios.Add(usuarioASerAdicionado);
            break;

        case "6":

            Console.WriteLine("Digite o identificador do usuário que irá fazer o empréstimo.");
            var idUsuarioAEmprestar = Console.ReadLine();
            if(string.IsNullOrEmpty(idUsuarioAEmprestar))
            {
                throw new Exception("Ocorreu um erro pois o identificador do usuário está vazio.");
            }
            var usuarioConsultadoPorEmprestimo = usuarios.Find(u => u.Id.ToString() == idUsuarioAEmprestar);
            if(usuarioConsultadoPorEmprestimo is null)
            {
                Console.WriteLine("Usuário não encontrado");
                break;
            }
            Console.WriteLine("Digite o identificador do livro que será emprestado.");
            var idLivroAEmprestar = Console.ReadLine();
            if (string.IsNullOrEmpty(idLivroAEmprestar))
            {
                throw new Exception("Ocorreu um erro pois o identificador do usuário está vazio.");
            }
            var livroConsultadoPorEmprestimo = livros.Find(l => l.Id.ToString() == idLivroAEmprestar);
            if (livroConsultadoPorEmprestimo is null)
            {
                Console.WriteLine("Livro não encontrado");
                break;
            }
            Console.WriteLine("Digite a data de devolução do empréstimo no formato DD/MM/YYYY:");
            var dataDevolucaoEmprestimo = Console.ReadLine();

            DateTime.TryParseExact(
                    dataDevolucaoEmprestimo,
                    "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime dataDevolucaoEmprestimoConvertida);
            

            Emprestimo emprestimoASerFeito = new Emprestimo(Guid.Parse(idUsuarioAEmprestar), Guid.Parse(idLivroAEmprestar), dataDevolucaoEmprestimoConvertida);
            break;

        case "7":

            Console.WriteLine("Digite o identificador do empréstimo");
            var idEmprestimoASerBuscado = Console.ReadLine();
            var emprestimoRealizado = emprestimos.Find(l => l.Id.ToString() == idEmprestimoASerBuscado);
            if (emprestimoRealizado is null)
            {

                Console.WriteLine("Empréstimo não encontrado");
                break;
            }

            emprestimos.Remove(emprestimoRealizado);

            if (emprestimoRealizado.DataDeDevolucao < DateTime.Today)
            {
                Console.WriteLine($"Livro devolvido com {emprestimoRealizado.DataDeDevolucao - DateTime.Today} dias de atraso");
                break;
            }

            Console.WriteLine("Livro devolvido em dia");
            break;
            
    }
  
}
