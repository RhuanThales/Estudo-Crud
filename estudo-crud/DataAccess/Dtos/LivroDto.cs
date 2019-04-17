using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estudo_crud.DataAccess.Dtos
{
    public class LivroDto
    {
        public string IdLivro { get; set; }
        public string NomeLivro { get; set; }
        public string ValorLivro { get; set; }
        public string AutorLivro { get; set; }
    }
}