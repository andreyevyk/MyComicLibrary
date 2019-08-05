using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

using Microsoft.Extensions.Configuration;
using MyComicLibrary.Models;
using Newtonsoft.Json;

namespace MyComicLibrary.Services
{
    public interface IMarvelApiService{
        dynamic searchById(int id);
        int countByName(string name);
        dynamic searchByName(string name,int pagina);

    }

    public class MarvelApi : IMarvelApiService
    {
        private readonly MyComicContext _context;
        private readonly IConfiguration _config;

        public MarvelApi(MyComicContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public int countByName(string name)
        {
            using (var client = new HttpClient())
            {
             client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string ts = DateTime.Now.Ticks.ToString();
                string publicKey = _config.GetSection("MarvelComicsAPI:PublicKey").Value;
                string hash = GerarHash(ts, publicKey,
                    _config.GetSection("MarvelComicsAPI:PrivateKey").Value);
                
                HttpResponseMessage response = client.GetAsync(
                _config.GetSection("MarvelComicsAPI:BaseURL").Value +
                $"comics?ts={ts}&apikey={publicKey}&hash={hash}&" +
                $"title={Uri.EscapeUriString(name)}&" +
                $"limit=4&"
                ).Result;

                response.EnsureSuccessStatusCode();
                string conteudo =
                    response.Content.ReadAsStringAsync().Result;

                dynamic resultados = JsonConvert.DeserializeObject(conteudo);

                int count = resultados.data.total;

                return count;
            }
        }

        public dynamic searchById(int id){
            
            using (var client = new HttpClient())
            {
             client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string ts = DateTime.Now.Ticks.ToString();
                string publicKey = _config.GetSection("MarvelComicsAPI:PublicKey").Value;
                string hash = GerarHash(ts, publicKey,
                    _config.GetSection("MarvelComicsAPI:PrivateKey").Value);
                
                HttpResponseMessage response = client.GetAsync(
                _config.GetSection("MarvelComicsAPI:BaseURL").Value +
                $"comics/{id}?ts={ts}&apikey={publicKey}&hash={hash}"
                ).Result;

                response.EnsureSuccessStatusCode();
                string conteudo =
                    response.Content.ReadAsStringAsync().Result;

                dynamic resultados = JsonConvert.DeserializeObject(conteudo);

                return resultados;
            }
        }

        public dynamic searchByName(string name, int pagina)
        {
            using (var client = new HttpClient())
            {
             client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string ts = DateTime.Now.Ticks.ToString();
                string publicKey = _config.GetSection("MarvelComicsAPI:PublicKey").Value;
                string hash = GerarHash(ts, publicKey,
                    _config.GetSection("MarvelComicsAPI:PrivateKey").Value);
                
                HttpResponseMessage response = client.GetAsync(
                _config.GetSection("MarvelComicsAPI:BaseURL").Value +
                $"comics?ts={ts}&apikey={publicKey}&hash={hash}&" +
                $"title={Uri.EscapeUriString(name)}&" +
                $"limit=4&"+
                $"offset={(pagina*4) - 4}"
                ).Result;

                response.EnsureSuccessStatusCode();
                string conteudo =
                    response.Content.ReadAsStringAsync().Result;

                dynamic resultados = JsonConvert.DeserializeObject(conteudo);

                return resultados;
            }
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