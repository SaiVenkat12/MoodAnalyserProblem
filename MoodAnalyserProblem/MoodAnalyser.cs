using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    public class MoodAnalyser
    {
        public string analysemood(string message)
        { 
            message=message.ToLower();
            if (message.Contains("sad"))
            {
                return "Sad";
            }
            else
                return "Happy";

        }
    }
}
