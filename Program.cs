using System.Security;

namespace Projeto;

class Program
{
    static void Main(string[] args)
    { 
        Program program = new Program();
        program.MenuInicial();
    }

    public List<Evento> LerArquivoEvento(string nomeArquivo)
    {
        string[] linhas = File.ReadAllLines(nomeArquivo);
        List<Evento> eventos = new List<Evento>();

        foreach (string linha in linhas)
        {
            Evento evento = new Evento(); 
            string[] dados = linha.Split(";");
            evento.Nome = dados[0];
            evento.Valor = int.Parse(dados[1]);
            evento.IdadeMinima = int.Parse(dados[2]);
            evento.QntIngressos = int.Parse(dados[3]);
            eventos.Add(evento);
        }
        return eventos;
    }

    public List<Usuario> LerArquivoUsuario(string nomeArquivo)
    {
        string[] linhas = File.ReadAllLines(nomeArquivo);
        List<Usuario> usuarios = new List<Usuario>();

        foreach (string linha in linhas)
        {
            Usuario usuario = new Usuario(); 
            string[] dados = linha.Split(";");
            usuario.Evento = int.Parse(dados[0]);
            usuario.Nome = dados[1];
            usuario.Idade = int.Parse(dados[2]);
            usuario.Email = dados[3];
            usuarios.Add(usuario);
        }
        return usuarios;
    }

    public bool EscreverArquivoEvento(string nomeArquivo, Evento evento)
    {
        using (StreamWriter writer = new StreamWriter(nomeArquivo, true))
        {
            string linha = string.Format("{0};{1};{2};{3}", evento.Nome, evento.Valor, evento.IdadeMinima, evento.QntIngressos);
            writer.WriteLine(linha);
        }

        return true;
    }

    public bool EscreverArquivoUsuario(string nomeArquivo, Usuario usuario)
    {
        using (StreamWriter writer = new StreamWriter(nomeArquivo, true))
        {
            string linha = string.Format("{0};{1};{2};{3}", usuario.Evento, usuario.Nome, usuario.Idade, usuario.Email);
            writer.WriteLine(linha);
        }

        return true;
    }

    public void MenuInicial() {
        string opcao = "";

        while (opcao != "0")
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("==========  Opcões do Sistema de Eventos  ==========");
            Console.WriteLine("====================================================");
            Console.WriteLine("0 - Sair.");
            Console.WriteLine("1 - Adicionar Evento");
            Console.WriteLine("2 - Comprar Ingresso");
            Console.WriteLine("3 - Imprimir Relatório de Eventos");
            Console.WriteLine("====================================================");
            Console.WriteLine("Informe a opção desejada: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "0":
                    return;
                case "1":
                    Evento evento = new Evento();

                    Console.WriteLine("Informe o nome do evento:");
                    evento.Nome = Console.ReadLine();

                    Console.WriteLine("Informe o valor do evento:");
                    evento.Valor = float.Parse(Console.ReadLine());

                    Console.WriteLine("Informe a idade mínima para participar do evento (Igual ou superior a 13 anos):");
                    evento.IdadeMinima = int.Parse(Console.ReadLine());
                    if (evento.IdadeMinima < 13) {
                        Console.WriteLine("Idade inválida! Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine("Informe a quantidade de ingressos disponíveis:");
                    evento.QntIngressos = int.Parse(Console.ReadLine());
                    
                    if (EscreverArquivoEvento("dados/eventos.txt", evento)) {
                        Console.WriteLine("\nEvento Cadastrado! Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                    } else {
                        Console.WriteLine("\nNão foi possível salvar os dados do evento! Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                    }
                break;
                case "2":
                    Evento eventoSelecionado = new Evento();
                    List<Evento> eventos = new List<Evento>();
                    Usuario usuario = new Usuario();
                    List<Usuario> ingressos = new List<Usuario>();
                    eventos = LerArquivoEvento("dados/eventos.txt");

                    Console.WriteLine("Selecione o evento:");
                    for (int i = 0; i < eventos.Count; i++) {
                        Console.WriteLine(i + 1 + "- " + eventos[i].Nome);
                    }

                    usuario.Evento = int.Parse(Console.ReadLine()) - 1;

                    for (int i = 0; i < eventos.Count; i++) {
                        if (usuario.Evento == i) {
                           eventoSelecionado = eventos[i];
                        } else if (usuario.Evento > eventos.Count) {
                            Console.WriteLine("Evento inválido! Pressione qualquer tecla para continuar.");
                            Console.ReadKey();
                            break;
                        }
                    }

                    ingressos = LerArquivoUsuario("dados/usuarios.txt");
                    ingressos = ingressos.FindAll(f => f.Evento == usuario.Evento);

                    if (eventoSelecionado.QntIngressos > ingressos.Count) {
                        Console.WriteLine("Informe o nome do usuário:");
                        usuario.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a idade do usuário:");
                        usuario.Idade = int.Parse(Console.ReadLine());
                        if (!usuario.ChecarIdadeCadastro()) {
                            Console.WriteLine("A idade mínima para compra de ingressos é 13 anos! Pressione qualquer tecla para continuar.");
                            Console.ReadKey();
                            break;
                        }

                        if(usuario.Idade < eventoSelecionado.IdadeMinima) {
                            Console.WriteLine("A idade mínima desse evento é " + eventoSelecionado.IdadeMinima + " anos! Pressione qualquer tecla para continuar.");
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("Informe o e-mail do usuário:");
                        usuario.Email = Console.ReadLine();
                        if (!usuario.ChecarEmail()) {
                            Console.WriteLine("Insira um e-mail com domínio '@hotmail.com', '@gmail.com' ou '@outlook.com'! Pressione qualquer tecla para continuar.");
                            Console.ReadKey();
                            break;
                        }

                        if (EscreverArquivoUsuario("dados/usuarios.txt", usuario)) {
                            Console.WriteLine("\nUsuário Cadastrado! Pressione qualquer tecla para continuar.");
                            Console.ReadKey();
                        } else {
                            Console.WriteLine("\nNão foi possível salvar os dados do usuário! Pressione qualquer tecla para continuar.");
                            Console.ReadKey();
                        }
                    } else {
                        Console.WriteLine("Este evento não possui mais ingressos disponíveis! Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                    }
                break;
                case "3":
                    List<Evento> eventosRelatorio = new List<Evento>();
                    eventosRelatorio = LerArquivoEvento("dados/eventos.txt");
                    List<Usuario> usuarioEventoRelatorio = new List<Usuario>();
                    usuarioEventoRelatorio = LerArquivoUsuario("dados/usuarios.txt");
                    float soma = 0;

                    Console.Clear();
                    Console.WriteLine("====================================================");
                    Console.WriteLine("=============  Relatório de Usuários  ==============");
                    Console.WriteLine("====================================================");
                    Console.WriteLine("Total de eventos cadastrados: " + eventosRelatorio.Count + " evento(s)");
                    Console.WriteLine("====================================================");
                    Console.WriteLine("Total de ingressos adquiridos por evento: ");
                    for (int i = 0; i < eventosRelatorio.Count; i++) {
                        Console.WriteLine(eventosRelatorio[i].Nome + ": " + usuarioEventoRelatorio.FindAll(f => f.Evento == i).Count() + " ingresso(s)");
                    }
                    Console.WriteLine("====================================================");
                    Console.WriteLine("Valor adquirido por evento: ");
                    for (int i = 0; i < eventosRelatorio.Count; i++) {
                        Console.WriteLine(eventosRelatorio[i].Nome + ": R$" + usuarioEventoRelatorio.FindAll(f => f.Evento == i).Count() * eventosRelatorio[i].Valor);
                        soma = soma + (usuarioEventoRelatorio.FindAll(f => f.Evento == i).Count() * eventosRelatorio[i].Valor);
                    }
                    Console.WriteLine("====================================================");
                    Console.WriteLine("Valor total adquirido: R$" + soma);

                    Console.WriteLine("Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                break;
            }
            opcao = "";
        }
    }
}