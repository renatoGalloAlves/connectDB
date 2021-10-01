using System;

namespace conectDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Produtos objProduto = new Produtos();
            var ListaProdutos = objProduto.Selecionar();

            foreach(var item in ListaProdutos)
            {
                Console.WriteLine($"Código de Produto: {item.CodProduto}, Nome: {item.Nome}, Valor: {item.Valor}, Estoque {item.Estoque} ");
            }

        }
    }
}
