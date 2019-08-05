using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyComicLibrary.Models;
using MyComicLibrary.Services;
using Newtonsoft.Json;


namespace MyComicLibrary.Api.Controllers
{
    [Route("api/comic")]
    [ApiController]
    public class ComicController : ControllerBase
    {
        private readonly MyComicContext _context;
        private readonly IConfiguration _config;
        private readonly IMarvelApiService _serviceApi;



        public ComicController(MyComicContext context,[FromServices]IConfiguration config,IMarvelApiService serviceApi )
        {
            _context = context;
            _config = config;
            _serviceApi = serviceApi;
        }

        // GET: api/HQ
        [HttpGet]
        public ActionResult<IEnumerable<Comic>> GetComics()
        {
            var comics = _context.Comic.ToList();
            foreach(var comic in comics){
                comic.Characters = _context.Character.Where(c => c.Comic.Id == comic.Id).ToList();
                comic.Creators = _context.Creator.Where(c => c.Comic.Id == comic.Id).ToList();
            }
            return comics;
        }

        // GET: api/HQ/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comic>> GetComic([FromRoute]int id)
        {
            var comic = await _context.Comic.FindAsync(id);
            comic.Characters = _context.Character.Where(c => c.Comic.Id == id).ToList();
            comic.Creators = _context.Creator.Where(c => c.Comic.Id == id).ToList();


            if (comic == null)
            {
                return NotFound();
            }

            return comic;
        }

        // PUT: api/HQ/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComic([FromRoute]int id,[FromBody] Comic comic)
        {
            if (id != comic.Id)
            {
                return BadRequest();
            }

            _context.Entry(comic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Comic> PostComic([FromBody]Comic comic)
        {
            _context.Comic.Add(comic);
            _context.SaveChanges();

            return CreatedAtAction("GetComic", new { id = comic.Id }, comic);
        }

        // DELETE: api/HQ/5
        [HttpDelete("{id}")]
        public ActionResult<Comic> DeleteComic([FromRoute]int id)
        {
            var comic = _context.Comic.Find(id);
        
            if (comic == null)
            {
                return NotFound();
            }

            var creatorsComic = _context.Creator.Where(c => c.Comic.Id == id).ToList();
            var charactersComic = _context.Character.Where(c => c.Comic.Id == id).ToList();

            foreach(var creator in creatorsComic){
                _context.Creator.Remove(creator);
            }
            foreach(var character in charactersComic){
                _context.Character.Remove(character);
            }
            
            _context.Comic.Remove(comic);
            _context.SaveChanges();

            return comic;
        }

        [HttpGet("search")]
        public ActionResult SearchComics([FromQuery]string name,int? pagina){
            
            int takePagina = pagina ?? 1;
            

            dynamic resultados = _serviceApi.searchByName(name, takePagina );

            List<ComicApi> comicList = new List<ComicApi>();
            ComicApi comic;
            CreatorSearch creators;
            Character characters;
            int total  = resultados.data.total;

            foreach(var result in resultados.data.results){
                comic = new ComicApi();
                comic.IdComicAPI = result.id;
                comic.Title = result.title;
                comic.PageCount = result.pageCount;
                comic.Description = result.description;
                comic.ImageCover = $"{result.thumbnail.path}.{result.thumbnail.extension}";

                foreach(var creatorResult in result.creators.items){
                    if(creatorResult != null){
                        creators = new CreatorSearch();
                        creators.Name = creatorResult.name;
                        creators.Role = creatorResult.role;   
                        comic.Creators.Add(creators);
                    }
                }
            
                foreach(var characterResult in result.characters.items){
                    if(characterResult != null){
                        characters = new Character();
                        characters.Name = characterResult.name;
                        comic.Characters.Add(characters);
                    }
                }
                
                comicList.Add(comic);
                
            }

            return Ok(comicList);                
        }

        
        [HttpGet("search/comic")]
        public ActionResult SearchComics([FromQuery]int id){
            
            dynamic resultados = _serviceApi.searchById(id);

            ComicApi comic = new ComicApi();
            CreatorSearch creators;
            Character characters;

            var result = resultados.data.results[0];
            comic.Title = result.title;
            comic.PageCount = result.pageCount;
            comic.Description = result.description;
            comic.ImageCover = $"{result.thumbnail.path}.{result.thumbnail.extension}";

            foreach(var creatorResult in result.creators.items){
                if(creatorResult != null){
                    creators = new CreatorSearch();
                    creators.Name = creatorResult.name;
                    creators.Role = creatorResult.role;   
                    comic.Creators.Add(creators);
                }
            }
        
            foreach(var characterResult in result.characters.items){
                if(characterResult != null){
                    characters = new Character();
                    characters.Name = characterResult.name;
                    comic.Characters.Add(characters);
                }
            }
        return Ok(comic);                
        }

        [HttpGet("search/count")]
        public ActionResult getTotalSearch([FromQuery]string name){

            int count =  _serviceApi.countByName(name);

            return Ok(count);

        }

        private bool ComicExists(long id)
        {
            return _context.Comic.Any(e => e.Id == id);
        }
        
        private string GerarHash(
            string ts, string publicKey, string privateKey)
        {
            byte[] bytes =
                Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            var gerador = MD5.Create();
            byte[] bytesHash = gerador.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash)
                .ToLower().Replace("-", String.Empty);
        }
    }
}
