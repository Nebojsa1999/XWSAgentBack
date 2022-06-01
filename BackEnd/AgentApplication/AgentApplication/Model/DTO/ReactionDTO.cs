using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentApplication.Model.DTO
{
    public class ReactionDTO
    {
        public string Comment { get; set; }
        public double Wage { get; set; }
        public string InterviewImpression { get; set; }
        public string Grade { get; set; }
        public Job Job { get; set; }
        public User User { get; set; }
    }
}
