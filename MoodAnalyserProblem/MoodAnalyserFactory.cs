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
        public static object CreateParameterizedMoodAnalyser(string className, string constructorName,string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructor = type.GetConstructor(new[] { typeof(string) });
                    object instance = constructor.Invoke(new object[] {message});
                    return instance;
                }
                else
                {                   
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Method Not Found");
                }
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
            }
        }
    }
}
