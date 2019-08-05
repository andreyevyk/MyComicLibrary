using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyComicLibrary.Models
{
    public class ListComic
    {
        public EListComics PageEnum {get; set;}
        public IEnumerable<Comic> Comics { get; set; }
    }
}
