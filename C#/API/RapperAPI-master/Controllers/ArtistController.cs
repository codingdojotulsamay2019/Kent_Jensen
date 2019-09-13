using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace RapperAPI.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }
        
        //list of all artists
        [HttpGet("artists")]
        public JsonResult artistList(){
            IEnumerable<Artist> a = allArtists.ToList();
            return Json(a);
        }

        //list of all artists whose names contain the string parameter
        [HttpGet("artists/Name/{value}")]
        public JsonResult Name(string value) {
            var a = allArtists.Where(b => b.ArtistName.Contains(value)).ToList();
            return Json(a);
        }

        // list of all artists whose real names contain the string parameter
        [HttpGet("artists/RealName/{value2}")]

        public JsonResult RealName(string value2) {
            IEnumerable<Artist> c = allArtists.Where(d => d.RealName.Contains(value2)).ToList<Artist>();
            return Json(c);
        }


        //list of all artists whose hometown matches the string parameter
        [HttpGet("artists/Hometown/{value3}")]
        public JsonResult hTown(string value3)
        {
            IEnumerable<Artist> origins = allArtists.Where(a => a.Hometown == value3).ToList<Artist>();
            return Json(origins);

        }

        //a list of all artists who belong to the group associated with the given id
        [HttpGet("artists/GroupID/{value4}")]
        public JsonResult gID(int value4){
            IEnumerable<Artist> origins = allArtists.Where(a => a.GroupId == value4).ToList<Artist>();
            return Json(origins);
        }
    }
}