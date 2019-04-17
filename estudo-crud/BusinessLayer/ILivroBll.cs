using estudo_crud.DataAccess.Dtos;
using estudo_crud.DataAccess.DataAccessObject;
using estudo_crud.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace estudo_crud.BusinessLayer
{
    public interface ILivroBll
    {
        //
        List<LivroDto> ObterTodosLivro();
        
        LivroDto ObterLivroPorId(string idLivro);
        
        void InserirLivro(LivroDto livro);
        
        void AtualizarLivro(string idLivro, LivroDto livroNew);
        
        void DeletarLivro(string idLivro);
    }

}