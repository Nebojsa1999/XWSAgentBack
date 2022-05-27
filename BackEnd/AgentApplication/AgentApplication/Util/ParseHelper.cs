using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model.Enum;

namespace AgentApplication.Util
{
    public class ParseHelper
    {
        public static Gender genderString(string gender)
        {
            if (gender == "0")
            {
                return Gender.Male;
            }

            else
            {
                return Gender.Female;
            }
        }



    }
}
