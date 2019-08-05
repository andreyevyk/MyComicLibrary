using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;


namespace MyComicLibrary.Models
{
    [Table("characters")]
    public class Character
    {
        [Column("id")]    
        public int Id { get; set; }

        [Column("name")]
        [Required]    
        public string Name { get; set; }

        [ForeignKey("id_comic")]
        public Comic Comic { get; set; }

    }
}
