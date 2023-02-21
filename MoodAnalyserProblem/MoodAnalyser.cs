using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    public class MoodAnalyser
    {
        public string message;
        public MoodAnalyser(string message) 
        {
            this.message=message;
        }

        public string Analysemood()
        {
            try
            {
                message = message.ToLower();
                if (message.Contains("sad"))
                {
                    return "Sad";
                }
                else if(message.Equals(string.Empty))
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.EMPTY_MOOD,"Message is Empty");
                }
                else
                    return "Happy";
            }
            catch(NullReferenceException ex)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NULL_MOOD, "Message is Null");
            }
        }
    }
}
