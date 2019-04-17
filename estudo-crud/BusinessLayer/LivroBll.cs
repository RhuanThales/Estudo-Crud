using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estudo_crud.DataAccess.Dtos;
using estudo_crud.DataAccess.DataAccessObject;
using estudo_crud.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace estudo_crud.BusinessLayer
{
    public class LivroBll : ILivroBll
    {
        //VERIFICAÇÃO DE TESTES UNITARIOS
        public string Teste = "teste";
        public readonly ILivroDao _livroDao;

        //INJEÇÃO DE DEPENDENCIAS
        public LivroBll(ILivroDao livroDao)
        {
            _livroDao = livroDao;
        }

        //OBTEM OS LIVROS DE ACORDO COM AS REGRAS DE NEGOCIO
        //CHAMA A FUNÇÃO DE ACESSO DE DADOS, LIVROSDAO-ObterTodosLivros
        public List<LivroDto> ObterTodosLivro()
        {
            var verifica = _livroDao.ObterTodosLivro();

            if(verifica == null){ return null; }
            
            this.Teste = "Metodo executado corretamente";
            
            return verifica;
        }

        //OBTEM OS LIVROS DE ACORDO COM AS REGRAS DE NEGOCIO
        //CHAMA A FUNÇÃO DE ACESSO DE DADOS, LIVROSDAO-ObterLivrosPorId
        public LivroDto ObterLivroPorId(string idLivro)
        {
            if((idLivro != null)&&(idLivro != ""))
            {
               return _livroDao.ObterLivroPorId(idLivro); 
            }
            return null;
        }

        //OBTEM OS LIVROS DE ACORDO COM AS REGRAS DE NEGOCIO
        //CHAMA A FUNÇÃO DE ACESSO DE DADOS, LIVROSDAO-InserirLivro
        public void InserirLivro(LivroDto livro)
        {
            if((livro != null)&&(livro.NomeLivro != null))
            {
                _livroDao.InserirLivro(livro);
            }
            this.Teste = "Falha na execucao do metodo";
        }

        //OBTEM OS LIVROS DE ACORDO COM AS REGRAS DE NEGOCIO
        //CHAMA A FUNÇÃO DE ACESSO DE DADOS, LIVROSDAO-AtualizarLivro
        public void AtualizarLivro(string idLivro, LivroDto livroNew)
        {
            if((idLivro != null)&&(livroNew != null))
            {
                _livroDao.AtualizarLivro(idLivro, livroNew);
            }
            this.Teste = "Falha na execucao do metodo";
        }

        //OBTEM OS LIVROS DE ACORDO COM AS REGRAS DE NEGOCIO
        //CHAMA A FUNÇÃO DE ACESSO DE DADOS, LIVROSDAO-DeletarLivro
        public void DeletarLivro(string idLivro)
        {
            if((idLivro != null)&&(idLivro != ""))
            {
                _livroDao.DeletarLivro(idLivro);
            }
            this.Teste = "Falha na execucao do metodo";
        }
    }
}