using  System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace conectDB
{
  public class Produtos
  {
    private MySqlConnection Conn{ get; set;}

    public int CodProduto { get; set;}
    public string Nome { get; set;}
    public decimal Valor { get; set;}
    public decimal Estoque { get; set;}

    public Produtos()
      {
        this.Conn = new MySqlConnection("Server=localhost;Database=demodb;Uid=root;Pwd=mysql;SSL Mode=None");
      }

      public List<Produtos> Selecionar ()
      {

        List<Produtos> ListaProdutos = new List<Produtos>();

        try
        {
          this.Conn.Open();
          MySqlCommand command = new MySqlCommand();
          command.Connection = this.Conn;
          command.CommandText = "select * from produtos";

          var dr = command.ExecuteReader();

          while(dr.Read()){
					Produtos objeto = new Produtos();

          objeto.CodProduto = Convert.ToInt32(Convert.ToString(dr["codproduto"]));
					objeto.Nome = Convert.ToString(dr["nome"]);
					objeto.Valor = Convert.ToDecimal(Convert.ToString(dr["valor"]));
					objeto.Estoque = Convert.ToDecimal(Convert.ToString(dr["estoque"]));
				  ListaProdutos.Add(objeto);
	
          }
        }
        catch(Exception ex)
        {
          Console.WriteLine("Erro: " + ex.Message);
        }
      return ListaProdutos;
      }

  }
}