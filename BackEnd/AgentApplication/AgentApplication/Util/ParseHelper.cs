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

        public static Grade gradeString(string grade)
        {
            if(grade == "One")
            {
                return Grade.One;
            }

            else if(grade == "Two")
            {
                return Grade.Two;
            }
            else if (grade == "Three")
            {
                return Grade.Three;
            }
            else if (grade == "Four")
            {
                return Grade.Four;
            }
            else 
            {
                return Grade.Five;
            }
        }



    }
}
