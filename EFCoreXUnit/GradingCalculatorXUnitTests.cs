using EFCore;
using Xunit;


namespace EFCoreNUnitTest
{


    public class GradingCalculatorXUnitTests
    {

        private GradingCalculator gradingCalculator;


        /// <summary>
        /// Instanciando para uso global la clase en las pruebas unitarias.
        /// </summary>

        public GradingCalculatorXUnitTests()
        {
            gradingCalculator = new GradingCalculator();
        }


        /// <summary>
        /// Prueba de condicion A
        /// </summary>
        [Fact]
        public void GradeCalc_InputScore95Attendance90_GetAGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.Equal("A", result);
        }


        /// <summary>
        /// Prueba de condicion B
        /// </summary>
        [Fact]
        public void GradeCalc_InputScore85Attendance90_GetBGrade()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.Equal("B", result);
        }


        /// <summary>
        /// Prueba de condicione C
        /// </summary>
        [Fact]
        public void GradeCalc_InputScore65Attendance90_GetCGrade()
        {
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.Equal("C", result);
        }


        /// <summary>
        /// Prueba de condicion D
        /// </summary>
        [Fact]
        public void GradeCalc_InputScore95Attendance65_GetBGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;
            string result = gradingCalculator.GetGrade();
            Assert.Equal("B", result);
        }


        /// <summary>
        /// Pruebas de multiples escenarios
        /// </summary>
        /// <param name="score"></param>
        /// <param name="attendance"></param>
        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void GradeCalc_FailsureScenarios_GetFGrade(int score, int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;
            string result = gradingCalculator.GetGrade();
            Assert.Equal("F", result);
        }


        /// <summary>
        /// Pruebas de multiples escenarios
        /// </summary>
        /// <param name="score"></param>
        /// <param name="attendance"></param>
        /// <returns></returns>
        [Theory]
        [InlineData(95, 90,  "A")]
        [InlineData(85, 90,  "B")]
        [InlineData(65, 90,  "C")]
        [InlineData(95, 65,  "B")]
        [InlineData(95, 55,  "F")]
        [InlineData(65, 55,  "F")]
        [InlineData(50, 90,  "F")]

        public void GradeCalc_AllGradeLogicalScenarios_GradeOutput(int score, int attendance, string expectedResult)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;
            var result = gradingCalculator.GetGrade();
            Assert.Equal(expectedResult, result);
        }

    }
}
