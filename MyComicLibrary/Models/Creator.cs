using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyComicLibrary.Models
{
    [Table("creator")]    
    public class Creator
    {
        [Column("id")]    
        public int Id { get; set; }

        [Column("name")]
        [Required]    
        public string Name { get; set; }

        [Column("role")]
        [Required]    
        public string Role { get; set; }

        [ForeignKey("id_comic")]
        public Comic Comic { get; set; }
    }
    public class CreatorSearch
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
