using MoodAnalyserProblem;
namespace MoodAnalyserTest
{
    [TestClass]
    public class MoodAnalyserTestCases
    {
        [TestMethod]
        //TC1.1-Given Sad Message in Constuctor When AnalyzingMood Should Return Sad
        public void Given_SadMessage_WhenAnalyzingMood_ShouldReturnSad()
        {
            //Arrange
            string message = "I am in Sad Mood";
            //Act
            string expeceted = "Sad";
            MoodAnalyser analyser = new MoodAnalyser(message);
            string actual = analyser.analysemood();
            //Assert
            Assert.AreEqual(expeceted, actual);
        }

        [TestMethod]
        //TC1.2-Given Any Message in Constuctor When AnalyzingMood Should Return Happy
        public void Given_AnyMessage_WhenAnalyzingMood_ShouldReturnHappy()
        {
            //Arrange
            string message = "I am in any Mood";
            //Act
            string expeceted = "Happy";
            MoodAnalyser analyser = new MoodAnalyser(message);
            string actual = analyser.analysemood();
            //Assert
            Assert.AreEqual(expeceted, actual);
        }
    }
}