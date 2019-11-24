using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RapperAPI.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }
    //returns a list of all groups
    [HttpGet("groups")]
    public JsonResult groupList(){
        IEnumerable<Group> a = allGroups.ToList();
        return Json(a);
    }

    //list of all groups whose names contain the string paramter
    [HttpGet("groups/Name/{value1}")]
    public JsonResult GroupName(string value1) {
        var c = allGroups.Where(d => d.GroupName.Contains(value1)).ToList();
        return Json(c);
    }

    // the group whose id matches the specified value
    [HttpGet("groups/GroupId/{value2}")]
    public JsonResult gID(int value2){
        IEnumerable<Group> origins = allGroups.Where(e => e.Id == value2).ToList<Group>();
        return Json(origins);
    }
}
}