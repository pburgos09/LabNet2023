using MVC.Models;
using System.Collections.Generic;

namespace Practica7_WebAPI.Models
{
    public class TmdbResponseModel
    {
        public int page { get; set; }
        public List<TmdbViewModel> results { get; set; }
    }
}