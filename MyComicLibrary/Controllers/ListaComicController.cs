using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyComicLibrary.Models;

namespace MyComicLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/listcomic")]
    public class ListasLeituraController : ControllerBase
    {
        private readonly MyComicContext _context;

        public ListasLeituraController(MyComicContext context)
        {
            _context = context;
        }

        private ListComic ListCreate(EListComics type,int pagina)
        {
            ListComic listComic = new ListComic();
            listComic.PageEnum = type;
            listComic.Comics = _context.Comic
                    .Where(c => c.List == type)
                    .OrderByDescending(c => c.Id);
            listComic.Comics = listComic.Comics.Skip((pagina - 1) * 4)
            .Take(4)
            .ToList();
                
            foreach(var comic in listComic.Comics){
                comic.Characters = _context.Character.Where(c => c.Comic.Id == comic.Id).ToList();
                comic.Creators = _context.Creator.Where(c => c.Comic.Id == comic.Id).ToList();
            }
            return listComic;

        }

        [HttpGet]
        public IActionResult AllLists([FromQuery] int? pagina)
        {
            var takePagina = pagina ?? 1;
            ListComic paraLer = ListCreate(EListComics.ParaLer, takePagina);
            ListComic lendo = ListCreate(EListComics.Lendo, takePagina);
            ListComic lidos = ListCreate(EListComics.Lidos, takePagina);
            ListComic emprestado = ListCreate(EListComics.Emprestados, takePagina);
            var colection = new List<ListComic> { paraLer, lendo, lidos, emprestado };
            return Ok(colection);
        }

        [HttpGet("{type}")]
        public IActionResult GetType([FromRoute]EListComics type, [FromQuery]int? pagina)
        {
            var takePagina = pagina ?? 1;
            var list = ListCreate(type,takePagina);
            return Ok(list);
        }

        [HttpGet("count/{type}")]
        public IActionResult Count([FromRoute]EListComics type)
        {
            return Ok(_context.Comic.Where(c => c.List == type).Count());
        }

    }
}