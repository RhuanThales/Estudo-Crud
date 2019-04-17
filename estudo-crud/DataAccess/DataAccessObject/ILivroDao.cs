using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using estudo_crud.DataAccess.Dtos;
using estudo_crud.DataAccess.Models;



namespace estudo_crud.DataAccess.DataAccessObject
{
    public interface ILivroDao
    {
        //Obtendo livro por id
        LivroDto ObterLivroPorId(string idLivro);
        
        //Obtendo todos os livros
        List<LivroDto> ObterTodosLivro();
        
        //Atualizando dados existentes
        void AtualizarLivro(string idLivro, LivroDto livroNew);
        
        //Deletando livro
        void DeletarLivro(string idLivro);
        
        //Inserindo, criando livro
        void InserirLivro(LivroDto livro);
    }
}