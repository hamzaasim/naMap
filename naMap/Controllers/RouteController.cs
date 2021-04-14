using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace naMap.Controllers
{
    //[Produces("application/json")]
    [Route("route/{destination}")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private static readonly IDictionary<string, string[]> countrylist = new Dictionary<string, string[]>()
        {
            {"CAN", new string[] {"US", "CAN" } } ,
            {"MEX", new string[] {"US", "MEX" } } ,
            {"BLZ", new string[] {"US", "MEX", "BLZ" } } ,
            {"GTM", new string[] {"US", "MEX", "GTM" } } ,
            {"SLV", new string[] {"US", "MEX", "GTM", "SLV" } } ,
            {"HND", new string[] {"US", "MEX", "GTM", "HND" } } ,
            {"NIC", new string[] {"US", "MEX", "GTM", "HND", "NIC" } } ,
            {"CRI", new string[] {"US", "MEX", "GTM", "HND", "NIC", "CRI" } } ,
            {"PAN", new string[] {"US", "MEX", "GTM", "HND", "NIC", "CRI", "PAN" } } ,


        };

        [HttpGet]
        public string Get(string destination)
        {
            destination = destination.ToUpper();
            if (countrylist.ContainsKey(destination))
            {
                var resp = new
                {
                    Destination = destination,
                    List = countrylist[destination]
                };

                return JsonConvert.SerializeObject(resp);

            }
            else
            {
                return "Please Enter a North American Destination Country";
            }


        }

    }
}