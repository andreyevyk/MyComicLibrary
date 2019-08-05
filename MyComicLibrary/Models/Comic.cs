using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyComicLibrary.Models
{
    [Table("comic")]    
    public class Comic
    {

        [Column("id")]    
        public int Id { get; set; }

        [Column("title")]
        [Required]    
        public string Title { get; set; }

        [Column("page_count")]
        public int PageCount { get; set; }
        
        [Column("description")]
        public string Description { get; set; }

        [Column("image_cover")]
        public string ImageCover { get; set; }

        [Column("list")]
        public EListComics List { get; set; }

        public List<Character> Characters { get; set; }

        public List<Creator> Creators { get; set; }
    }

     public class ComicApi
    {  

        public ComicApi(){
            Characters = new List<Character>();
            Creators = new List<CreatorSearch>();
        }
        public int IdComicAPI { get; set; }
        public string Title { get; set; }

        public int PageCount { get; set; }
         
        public string Description { get; set; }

        public string ImageCover { get; set; }
        public EListComics? List { get; set; }

        public List<Character> Characters{ get; set;}

        public List<CreatorSearch> Creators { get; set;}

    }
}
