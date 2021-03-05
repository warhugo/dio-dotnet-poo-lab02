using System;

namespace DIO.Series
{
  public abstract class EntidadeBase
  {
    public int Id { get; protected set; }
    public Genero Genero { get; protected set; }
    public string Titulo { get; protected set; }
    public string Descricao { get; protected set; }
    public int Ano { get; protected set; }
    public bool Excluido { get; protected set; }

    public Tipo Tipo { get; protected set; }

    public abstract string retornaTitulo();

    public abstract int retornaId();

    public abstract bool retornaExcluido();

    public abstract void Excluir();
  }

}