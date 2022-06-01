using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model.Enum;

namespace AgentApplication.Model
{
    public class Reaction : Entity
    {
        public string Comment { get; set; }
        public double Wage { get; set; }
        public string InterviewImpression { get; set; }
        public Grade Grade { get; set; }
        public Job Job { get; set; }
        public User User { get; set; }
    }
}
