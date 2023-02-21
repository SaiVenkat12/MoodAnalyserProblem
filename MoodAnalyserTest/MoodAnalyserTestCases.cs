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
            string actual = analyser.Analysemood();
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
            string actual = analyser.Analysemood();
            //Assert
            Assert.AreEqual(expeceted, actual);
        }
        [TestMethod]
        //TC3.1-Given Null Message When AnalyzingMood Should Return Custom Exception
        public void GivenNullMessage_ShouldReturnCustomException()
        {
            //Arrange
            string message = null;
            string expeceted = "Message is Null";
            //Act
            try
            {
                MoodAnalyser analyser = new MoodAnalyser(message);
                string actual = analyser.Analysemood();
                Assert.AreEqual(expeceted, actual);
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expeceted, ex.Message);
            }
        }
        [TestMethod]
        //TC3.2-Given Empty Message When AnalyzingMood Should Return Custom Exception
        public void GivenEmptyMessage_ShouldReturnCustomException()
        {
            //Arrange
            string message = "";
            string expeceted = "Message is Empty";
            //Act
            try
            {
                MoodAnalyser analyser = new MoodAnalyser(message);
                string actual = analyser.Analysemood();
                Assert.AreEqual(expeceted, actual);
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expeceted, ex.Message);
            }
        }
    }
}