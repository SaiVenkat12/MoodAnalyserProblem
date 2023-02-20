using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MoodAnalyser Test Problem");
            MoodAnalyser analyser= new MoodAnalyser();
            Console.WriteLine(analyser.analysemood("I am in Sad Mood"));
            Console.ReadLine();
        }
    }
}
