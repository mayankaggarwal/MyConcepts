using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperaWebSites.Models
{
    public class OperaDynamicNodeProvider:DynamicNodeProviderBase
    {
        OperaDB context = new OperaDB();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            List<DynamicNode> nodes = new List<DynamicNode>();
            var operas = context.Operas.ToList();
            foreach(var opera in operas)
            {
                DynamicNode newNode = new DynamicNode
                {
                    Title = opera.Title,
                    ParentKey = "AllOperas"
                };

                newNode.RouteValues.Add("id", opera.OperaID);
                nodes.Add(newNode);
            }

            return nodes;
        }
    }
}