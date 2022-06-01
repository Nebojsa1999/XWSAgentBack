using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentApplication.Model
{
    public class ApiKey : Entity
    {
        public string ApiKeyString { get; set; }
        public User Owner { get; set; }
    }
}
