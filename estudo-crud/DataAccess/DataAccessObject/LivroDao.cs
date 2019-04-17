using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estudo_crud.DataAccess.DataAccessObject;
using estudo_crud.DataAccess.Dtos;
using estudo_crud.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace estudo_crud.DataAccess.DataAccessObject
{
    public class LivroDao : ILivroDao
    {
        //VERIFICAÇÃO DE TESTES UNITARIOS
        public string Teste = "teste";
        private readonly IMongoContext _context;

        //INJEÇÃO DE DEPENDECIAS
        public LivroDao(IMongoContext context)
        {
            _context = context;
        }

        //OTEM TODOS OS LIVROS QUE ESTEJAM SALVOS NO BANCO
        public List<LivroDto> ObterTodosLivro()
        {
            List<LivroDto> livros = new List<LivroDto>();

            var resultado = _context.CollectionLivro.Find(livro => true).ToList() ;

           foreach (var item in resultado)
            {
                LivroDto c = new LivroDto{
                    IdLivro = item.IdLivro,
                    Nome = item.NomeLivro,
                    Valor = item.ValorLivro,
                    Tipo = item.TipoLivro,
                    Autor = item.AutorLivro
                };

                livros.Add(c);
            }
            
            return livros;
        }

        //OBTEM O LIVRO SALVO NO BANCO QUE TENHA O ID INFORMADO
        public LivroDto ObterLivroPorId(string idLivro)
        {
            var resultado = _context.CollectionLivro.Find<Livro>(livro => livro.IdLivro == idLivro).FirstOrDefault();

            if(idLivro != null)
            {
                LivroDto livroDto = new LivroDto{
                    IdLivro = resultado.IdLivro,
                    Nome = resultado.NomeLivro,
                    Valor = resultado.ValorLivro,
                    Tipo = resultado.TipoLivro,
                    Autor = resultado.AutorLivro
                };

                return livroDto;
            }
            this.Teste = "Falha ao executar o metodo";
            return null;
        }

        //ADICIONA UM NOVO LIVRO AO BANCO DE DADOS
        public void InserirLivro(LivroDto livro)
        {
            if(livro != null)
            {
                Livro livroNovo = new Livro{
                    Nome = livro.NomeLivro,
                    Valor = livro.ValorLivro,
                    Tipo = livro.TipoLivro,
                    Autor = livro.AutorLivro
                };
            
                _context.CollectionLivro.InsertOne(livroNovo);
            }
            this.Teste = "Falha ao executar o metodo";
        }

        //ATUALIZA OS DADOS DE UM LIVRO SALVO, ATRAVEZ DE SEU ID
        public void AtualizarLivro(string idLivro, LivroDto livroNew)
        {
            if((idLivro != null)&&(livroNew != null))
            {
                Livro livroNovo = new Livro{
                    IdLivro = idLivro,
                    Nome = livroNew.NomeLivro,
                    Valor = livroNew.ValorLivro,
                    Tipo = livroNew.TipoLivro,
                    Autor = livroNew.AutorLivro
                };

                _context.CollectionLivro.ReplaceOne(livro => livro.IdLivro == idLivro, livroNovo);
            }
            this.Teste = "Falha ao executar o metodo";
        }

        //DELETA UM LIVRO DO BANCO, ATRAVEZ DO SEU ID
        public void DeletarLivro(string idLivro)
        {   
            if(idLivro != null)
            {
                _context.CollectionLivro.DeleteOne(livro => livro.IdLivro == idLivro);
            }
            this.Teste = "Falha ao executar o metodo";
        }
    }
}    