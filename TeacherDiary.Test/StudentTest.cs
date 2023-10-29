namespace TeacherDiary.Test
{
    public class Tests
    {
        static void Main() { }

        [Test]
        public void AddingOneStudentsWithOneGrade_ShouldReturnCorrectAverage()
        {
            //arrange
            var student = new StudentInMemory("Adam", "Kamizelich");
            student.AddGrade(1);

            //act
            var statistics = student.GetStatistics();

            //assert
            Assert.That(statistics.Average, Is.EqualTo(1));
        }

        [Test]
        public void AddingOneStudentsWithFewGrades_ShouldReturnCorrectAverage()
        {
            //arrange
            var student = new StudentInMemory("Adam", "Kamizelich");
            student.AddGrade(4);
            student.AddGrade(3);
            student.AddGrade(4);
            student.AddGrade(5);

            //act
            var statistics = student.GetStatistics();

            //assert
            Assert.That(statistics.Average, Is.EqualTo(4));
        }

        [Test]
        public void AddingOneStudentsWithFewGrades_ShouldReturnCorrectAverageGrade()
        {
            //arrange
            var student = new StudentInMemory("Adam", "Kamizelich");
            student.AddGrade(4);
            student.AddGrade(3);
            student.AddGrade(4);
            student.AddGrade(5);

            //act
            var statistics = student.GetStatistics();

            //assert
            Assert.That(statistics.AverageGrade, Is.EqualTo("Gosc jest w porzo. Solidna czworka."));
        }

        [Test]
        public void AddingOneStudentsWithoutAnyGrades_ShouldReturnCorrectAverageGrade()
        {
            //arrange
            var student = new StudentInMemory("Adam", "Kamizelich");

            //act
            var statistics = student.GetStatistics();

            //assert
            Assert.That(statistics.AverageGrade, Is.EqualTo("Brak ocen. To jakis obibok! Nie patyczkowac sie! Wywalic na zbity pysk!"));
        }
    }
}
