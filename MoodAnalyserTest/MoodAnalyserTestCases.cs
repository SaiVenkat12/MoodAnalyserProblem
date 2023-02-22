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
        [TestMethod]
        //TC4.1- Using Reflections Given MoodAnalyser ClassName Should Return MoodAnalyser Object
        public void GivenMoodAnalyserClassName_ShouldReturnMoodAnalyserObject()
        {
            //Arrange
            string className = "MoodAnalyserProblem.MoodAnalyser";
            string constructorName = "MoodAnalyser";
            //Act
            Object expected = new MoodAnalyser();
            Object actual = MoodAnalyserFactory.CreateMoodAnalyser(className, constructorName);
            //Assert
            actual.Equals(expected);  //determines both objects are equal or not
        }
        [TestMethod]
        //TC4.2-Using Reflections Given Improper ClassName Should Return Custom Exception
        public void GivenImproperClassName_ShouldReturnException()
        {
            //Arrange
            string expected = "Class not found";
            try
            {
                //Act
                Object expectedObject = new MoodAnalyser();
                Object actual = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyserProblem.Analyse", "Analyse");
                //Assert
                actual.Equals(expectedObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        //TC4.3-Using Reflections Given Improper ClassName Should Return Custom Exception
        public void GivenImproperConstuctorName_ShouldReturnException()
        {
            //Arrange
            string expected = "Method not found";
            try
            {
                //Act
                Object expectedObject = new MoodAnalyser();
                Object actual = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyserProblem.MoodAnalyser", "Analyse");
                //Assert
                actual.Equals(expectedObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}