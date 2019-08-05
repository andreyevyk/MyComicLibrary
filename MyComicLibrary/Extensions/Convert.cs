
namespace MyComicLibrary.Models
{
    public static class Convertion
    {
        
        public static Creator ToCreator(this CreatorSearch creatorSearch){
            return new Creator {
                Name = creatorSearch.Name,
                Role = creatorSearch.Role
            };
        }

        // public static Comic ToComic(this ComicApi comicApi){
        //     return new Comic {
        //         Title = comicApi.Title,
        //         Description = comicApi.Description,
        //         ImageCover = comicApi.ImageCover,
        //         PageCount = comicApi.PageCount,
        //         List = comicApi.List

        //     };
        // }

        // public static ComicApi ToComicApi(this Comic comic){
        //     return new ComicApi {
        //         Title = comic.Title,
        //         Description = comic.Description,
        //         ImageCover = comic.ImageCover,
        //         PageCount = comic.PageCount,
        //         List = comic.List
        //     };
        // }

        

    }

}

