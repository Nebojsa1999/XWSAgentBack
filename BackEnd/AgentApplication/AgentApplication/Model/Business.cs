using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentApplication.Model
{
    public class Business : Entity
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string JobDescription { get; set; }
        public string JobCulture { get; set; }
        public bool Activated { get; set; }
        public User Owner { get; set; }
    }
}
