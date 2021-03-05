using System;

namespace DIO.Series
{
  class Program
  {
    static SerieRepositorio repositorioSerie = new SerieRepositorio();
    static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
    static void Main(string[] args)
    {
      string opcaoUsuario = Menu();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            Listar();
            break;

          case "2":
            Inserir();
            break;

          case "3":
            Atualizar();
            break;

          case "4":
            Excluir();
            break;

          case "5":
            Visualizar();
            break;

          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = Menu();

      }

    }

    private static void Excluir()
    {
      Tipo tipo = Tipo.Filme;

      Console.Write("Digite o id: ");
      int indice = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("\n1- Filme"
                      + "\n2- Serie");
      tipo = (Tipo)Convert.ToInt32(Console.ReadLine());
      Console.WriteLine();

      if (tipo.Equals(Tipo.Filme))
      {
        repositorioFilme.Excluir(indice);
      }
      else
      {
        repositorioSerie.Excluir(indice);
      }

    }

    private static void Visualizar()
    {
      Tipo tipo = Tipo.Filme;
      Console.Write("Digite o id: ");
      int indice = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("\n1- Filme"
                      + "\n2- Serie");
      tipo = (Tipo)Convert.ToInt32(Console.ReadLine());
      Console.WriteLine();

      if (tipo.Equals(Tipo.Filme))
      {
        var filme = repositorioFilme.RetornaPorId(indice);
        Console.WriteLine(filme);
      }
      else
      {
        var serie = repositorioSerie.RetornaPorId(indice);
        Console.WriteLine(serie);
      }

    }

    private static void Atualizar()
    {
      Console.Write("Digite o id: ");
      int indiceSerie = Convert.ToInt32(Console.ReadLine());

      string[] entradaElementos = Preencher();

      if (entradaElementos[1] == "1")
      {
        Filme atualizaFilme = new Filme(id: indiceSerie,
                    genero: (Genero)Convert.ToInt32(entradaElementos[0]),
                    tipo: (Tipo)Convert.ToInt32(entradaElementos[1]),
                    titulo: entradaElementos[2],
                    ano: Convert.ToInt32(entradaElementos[3]),
                    descricao: entradaElementos[4]);

        repositorioFilme.Atualiza(indiceSerie, atualizaFilme);
      }
      else
      {
        Serie atualizaSerie = new Serie(id: indiceSerie,
            genero: (Genero)Convert.ToInt32(entradaElementos[0]),
            tipo: (Tipo)Convert.ToInt32(entradaElementos[1]),
            titulo: entradaElementos[2],
            ano: Convert.ToInt32(entradaElementos[3]),
            descricao: entradaElementos[4]);

        repositorioSerie.Atualiza(indiceSerie, atualizaSerie);
      }

    }

    private static void Inserir()
    {
      Console.WriteLine("Inserir Nova Série/Filme\n");

      string[] entradaElementos = Preencher();

      foreach (var item in entradaElementos)
      {
        Console.WriteLine($"Saida {item}");
      }
      // Verifica se o Tipo é igual a Filme (Enum - Filme = 1)  
      if (entradaElementos[1] == "1")
      {
        Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
                    genero: (Genero)Convert.ToInt32(entradaElementos[0]),
                    tipo: (Tipo)Convert.ToInt32(entradaElementos[1]),
                    titulo: entradaElementos[2],
                    ano: Convert.ToInt32(entradaElementos[3]),
                    descricao: entradaElementos[4]);

        repositorioFilme.Insere(novoFilme);
        Console.WriteLine("Item Inserido");
      }
      else
      {
        Serie novaSerie = new Serie(id: repositorioSerie.ProximoId(),
            genero: (Genero)Convert.ToInt32(entradaElementos[0]),
            tipo: (Tipo)Convert.ToInt32(entradaElementos[1]),
            titulo: entradaElementos[2],
            ano: Convert.ToInt32(entradaElementos[3]),
            descricao: entradaElementos[4]);

        repositorioSerie.Insere(novaSerie);
      }

    }

    private static void Listar()
    {
      Console.WriteLine("Listar Séries/Filmes");

      var filme = repositorioFilme.Lista();
      var serie = repositorioSerie.Lista();
      var controleFilme = true;
      var controleSerie = true;


      if (filme.Count == 0)
      {
        Console.WriteLine("\nNenhum filme cadastrado.");
        controleFilme = false;
      }

      if (serie.Count == 0)
      {
        Console.WriteLine("Nenhuma Série cadastrado.");
      }

      if (controleFilme)
      {
        Console.WriteLine("\nListando Filmes ...\n");
        foreach (var item in filme)
        {
          var excluido = item.retornaExcluido();
          Console.WriteLine("#ID {0}: - {1} {2}", item.retornaId(), item.retornaTitulo(), (excluido ? "*Excluído*" : ""));
        }
        Console.WriteLine("\nFim da listagem.");
      }

      if (controleSerie)
      {
        Console.WriteLine("\nListando Séries ...\n");
        foreach (var item in serie)
        {
          var excluido = item.retornaExcluido();
          Console.WriteLine("#ID {0}: - {1} {2}", item.retornaId(), item.retornaTitulo(), (excluido ? "*Excluído*" : ""));
        }
        Console.WriteLine("\nFim da listagem.");
      }

    }

    private static string[] Preencher()
    {
      string[] elemento = new string[5];

      int controle = 0;

      while (controle < 5)
      {
        switch (controle)
        {

          case 0:
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
              Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("\nDigite o gênero entre as opções acima: ");
            elemento[controle] = Console.ReadLine();
            Console.WriteLine();
            break;

          case 1:
            foreach (int i in Enum.GetValues(typeof(Tipo)))
            {
              Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
            }

            Console.Write("\nDigite o tipo entre as opções acima: ");
            elemento[controle] = Console.ReadLine();
            break;

          case 2:
            Console.Write("\nDigite o Título: ");
            elemento[controle] = Console.ReadLine();
            break;

          case 3:

            Console.Write("Digite o Ano de Início: ");
            elemento[controle] = Console.ReadLine();
            break;


          case 4:

            Console.Write("Digite a Descrição: ");
            elemento[controle] = Console.ReadLine();
            break;

        }

        controle++;
      }

      return elemento;
    }

    private static string Menu()
    {

      Console.WriteLine("\nDIO Séries e Filmes a seu dispor!!!"
                        + "\nInforme a opções desejada: "
                        + "\n\n1- Listar Séries/Filmes"
                        + "\n2- Inserir nova Série/Filme"
                        + "\n3- Atualizar Série/Filme"
                        + "\n4- Excluir Série/Filme"
                        + "\n5- Visualizar Série/Filme"
                        + "\nC- Limpar Tela"
                        + "\nX- Sair");
      Console.WriteLine();
      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;

    }

  }
}
