using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();
           while (opcaoUsuario.ToUpper() != "X")
           {
               switch (opcaoUsuario)
               {
                   case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
               }
               opcaoUsuario = ObterOpcaoUsuario();
           }
           Console.WriteLine("Obrigado por utilizar nosso servico");
           Console.ReadLine();           
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie Cadastrada");
                return;                
            }
            foreach (var series in lista)
            {
                var excluido = series.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", series.retornaId(), series.retornaTitulo(), (excluido ? "Excluido" : ""));
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i,Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Genero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descricao da Serie: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da Serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i,Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Genero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descricao da Serie: ");
            string entradaDescricao = Console.ReadLine();
            Series atualizaSerie = new Series(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ExcluirSerie()
        {
            Console.Write("Digite o Id da Serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());
           
            repositorio.Exclui(indiceSerie);
        }
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da Serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorID(indiceSerie);
            Console.WriteLine(serie);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series Bem Vindo");
            Console.WriteLine("Informe a opcao desejada");

            Console.WriteLine("1- Listar Series");
            Console.WriteLine("2- Inserir nova Serie");
            Console.WriteLine("3- Atualizar Serie");
            Console.WriteLine("4- Excluir Serie");
            Console.WriteLine("5- Visualizar Serie");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
