using System.Collections.Generic;
using estudo_crud.BusinessLayer;
using estudo_crud.DataAccess.Models;
using estudo_crud.DataAccess.DataAccessObject;
using estudo_crud.DataAccess.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace estudo_crud.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroBll _livroBll;

        //INJEÇÃO DE DEPENDENCIAS
        public LivrosController(ILivroBll livroBll)
        {
            _livroBll = livroBll;
        }

        //CONTROLA A OBTENÇÃO DE TODOS OS LIVROS CADASTRADOS
        //CHAMA A FUNÇÃO DE VALIDAÇÃO, LIVROSBLL-ObterTodosLivros 
        [HttpGet("ObterTodosLivro")]
        public ActionResult<List<Livro>> ObterTodosLivro()
        {
            try
            {
                return Ok(_livroBll.ObterTodosLivro());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //CONTROLA A OBTENÇÃO DE TODOS OS LIVROS CADASTRADOS, POR ID
        //CHAMA A FUNÇÃO DE VALIDAÇÃO, LIVROSBLL-ObterLivrosPorId
        [HttpGet("ObterLivroPorId/{idLivro}")]
        public ActionResult<Livro> ObterLivroPorId(string idLivro)
        {
            try
            {
                return Ok(_livroBll.ObterLivroPorId(idLivro));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
               

        //CONTROLA A ADÇÃO DE LIVROS
        //CHAMA A FUNÇÃO DE VALIDAÇÃO, LIVROSBLL-InserirLivro
        [HttpPost("InserirLivro")]
        public ActionResult<Livro> InserirLivro(LivroDto livro)
        {
            try
            {
                _livroBll.InserirLivro(livro);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //CONTROLA A ATUALIZAÇÃO DE LIVROS
        //CHAMA A FUNÇÃO DE VALIDAÇÃO, LIVROSBLL-AtualizarLivro
        [HttpPut("AtualizarLivro/{idLivro}")]
        public IActionResult AtualizarLivro(string idLivro, LivroDto livroNew)
        {
            try
            {
                _livroBll.AtualizarLivro(idLivro, livroNew);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //CONTROLA A EXCLUSÃO DE LIVROS CADASTRADOS, POR ID
        //CHAMA A FUNÇÃO DE VALIDAÇÃO, LIVROSBLL-DeletarLivro
        [HttpDelete("DeletarLivro/{idLivro}")]
        public IActionResult DeletarLivro(string idLivro)
        {
            try
            {
                _livroBll.DeletarLivro(idLivro);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

