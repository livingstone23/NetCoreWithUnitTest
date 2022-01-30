using EFCore;
using NUnit.Framework;

namespace EFCoreNUnitTest
{

    [TestFixture]
    public class GradingCalculatorNUnitTests
    {

        private GradingCalculator gradingCalculator;


        /// <summary>
        /// Instanciando para uso global la clase en las pruebas unitarias.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            gradingCalculator = new GradingCalculator();
        }


        /// <summary>
        /// Prueba de condicion A
        /// </summary>
        [Test]
        public void GradeCalc_InputScore95Attendance90_GetAGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("A"));
        }


        /// <summary>
        /// Prueba de condicion B
        /// </summary>
        [Test]
        public void GradeCalc_InputScore85Attendance90_GetBGrade()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("B"));
        }


        /// <summary>
        /// Prueba de condicione C
        /// </summary>
        [Test]
        public void GradeCalc_InputScore65Attendance90_GetCGrade()
        {
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("C"));
        }


        /// <summary>
        /// Prueba de condicion D
        /// </summary>
        [Test]
        public void GradeCalc_InputScore95Attendance65_GetBGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("B"));
        }


        /// <summary>
        /// Pruebas de multiples escenarios
        /// </summary>
        /// <param name="score"></param>
        /// <param name="attendance"></param>
        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        public void GradeCalc_FailsureScenarios_GetFGrade(int score, int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("F"));
        }


        /// <summary>
        /// Pruebas de multiples escenarios
        /// </summary>
        /// <param name="score"></param>
        /// <param name="attendance"></param>
        /// <returns></returns>
        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]

        public string GradeCalc_AllGradeLogicalScenarios_GradeOutput(int score, int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;
            return gradingCalculator.GetGrade();
        }

    }
}
