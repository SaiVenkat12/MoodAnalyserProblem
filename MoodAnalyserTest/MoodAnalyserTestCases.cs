using MoodAnalyserProblem;
using System.Reflection;

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
            Object actual = MoodAnalyserReflector.CreateMoodAnalyser(className, constructorName);
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
                Object actual = MoodAnalyserReflector.CreateMoodAnalyser("MoodAnalyserProblem.Analyse", "Analyse");
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
                Object actual = MoodAnalyserReflector.CreateMoodAnalyser("MoodAnalyserProblem.MoodAnalyser", "Analyse");
                //Assert
                actual.Equals(expectedObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        //TC5.1- Given Using Reflections MoodAnalyser ClassName Should Return MoodAnalyser Object using Parameterised Constructor
        public void Given_MoodAnalyser_With_Parameterised_Constructor_ShouldReturnMoodAnalyserObject()
        {
            //Arrange
            string message = "Happy Mood";
            //Act
            Object expected = new MoodAnalyser(message);
            Object actual = MoodAnalyserReflector.CreateParameterizedMoodAnalyser("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", message);
            //Assert
            actual.Equals(expected);
        }
        [TestMethod]
        //TC5.2- Given Improper ClassName Should Return Custom Exception using Parameterised Constructor
        public void GivenImproperClassName_ShouldReturnException_using_Parameterised_Constructor()
        {
            //Arrange
            string message = "Happy";
            string expectedMsg = "Class Not Found";
            //Act
            try
            {
                Object expected = new MoodAnalyser(message);
                Object actual = MoodAnalyserReflector.CreateParameterizedMoodAnalyser("MoodAnalyserProblem.Customer", "MoodAnalyser", message);
                //Assert
                actual.Equals(expected);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMsg, ex.Message);
            }
        }
        [TestMethod]
        //TC5.3- Given Improper ClassName Should Return Custom Exception using Parameterised Constructor
        public void Given_Improper_ConstuctorName_ShouldReturn_Exception_using_Parameterised_Constructor()
        {
            //Arrange
            string message = "Happy";
            string expectedMsg = "Method Not Found";
            //Act
            try
            {
                Object expected = new MoodAnalyser(message);
                Object actual = MoodAnalyserReflector.CreateParameterizedMoodAnalyser("MoodAnalyserProblem.MoodAnalyser", "Analyse", message);
                //Assert
                actual.Equals(expected);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMsg, ex.Message);
            }
        }
        [TestMethod]
        //TC6.1- Given Happy Message with Reflector Should Return HAPPY
        public void Given_Happy_Message_With_Reflector_Should_Return_HappyMood()
        {
            //Arrange
            string expected = "Happy";
            string message = "I am in Happy Mood";
            //Act
            string actual = MoodAnalyserReflector.InvokedAnalyseMood(message, "Analysemood");
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        //TC6.2- Given Happy with Reflector Improper Method With Reflector Should Return Exception
        public void Given_Happy_Improper_Method_With_Reflector_Should_Return_Exception()
        {
            //Arrange
            string expected = "Happy";
            string expectedMsg = "Method Not Found";
            string message = "I am in Happy Mood";
            try
            {
                //Act
                string actual = MoodAnalyserReflector.InvokedAnalyseMood(message, "Analysermood");
                //Assert
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMsg, ex.Message);
            }
        }
    }    
}