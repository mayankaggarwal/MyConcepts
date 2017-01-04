using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, OPTIONS")]
    public class ProductsController : ApiController
    {
        List<TextRules> rules = new List<TextRules>{
            new TextRules{
                ID = 1,RuleName = "Must be 5 characters"
            },
            new TextRules{
                ID = 2,RuleName = "Must not be used elsewhere"
            },
            new TextRules{
                ID = 3,RuleName = "Must be cool"
            }
        };
        public ProductsController()
        {
            
        }

        public IEnumerable<TextRules> Get()
        {
            return rules;
        }

        [HttpPost]
        public IEnumerable<TextRules> PostRule([FromBody]string newRule)
        {
            int id = rules.Max(x => x.ID);
            rules.Add(new TextRules
            {
                ID = id+1,
                RuleName = newRule
            });

            return rules;
        }
    }
}
