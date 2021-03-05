using System;

namespace DIO.Series
{
  public class Serie : EntidadeBase
  {
    public Serie(int id, Genero genero, string titulo, string descricao, int ano, Tipo tipo)
    {
      this.Id = id;
      this.Genero = genero;
      this.Titulo = titulo;
      this.Descricao = descricao;
      this.Ano = ano;
      this.Excluido = false;
      this.Tipo = tipo;
    }

    public override string retornaTitulo()
    {
      return this.Titulo;
    }

    public override int retornaId()
    {
      return this.Id;
    }

    public override bool retornaExcluido()
    {
      return this.Excluido;
    }

    public override void Excluir()
    {
      this.Excluido = true;
    }

    public override string ToString()
    {
      string retorno = "";
      retorno += "Gênero: " + this.Genero + Environment.NewLine;
      retorno += "Tipo: " + this.Tipo + Environment.NewLine;
      retorno += "Titulo: " + this.Titulo + Environment.NewLine;
      retorno += "Descrição: " + this.Descricao + Environment.NewLine;
      retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
      retorno += "Excluido: " + this.Excluido;
      return retorno;
    }

  }
}