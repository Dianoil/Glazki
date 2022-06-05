using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glazki.Model;
namespace Glazki.Class
{
    public class AgentExtension
    {
        public static GlazkiEntities glazkiEntities = new GlazkiEntities();

        public static List<Agent> GetAgents()
        {
            return glazkiEntities.Agent.ToList();
        }
        public static List<Product> GetProducts()
        {
            return glazkiEntities.Product.ToList();
        }
        public static Model.User User1 { get; set; }

        public static List<AgentType> GetAgentTypes()
        {
            return glazkiEntities.AgentType.ToList();
        }
    }
}
