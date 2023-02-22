using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    public class MoodAnalyserFactory
    {
        public MoodAnalyserFactory() 
        {
            
        }
        public static object CreateMoodAnalyser(string className, string constructorName)
        {
            string pattren = @"." + constructorName + "$";
            if (Regex.IsMatch(className, pattren))
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    var result = Activator.CreateInstance(moodAnalyserType);
                    return result;
                }
                catch
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Method not found");
        }
    }
}
