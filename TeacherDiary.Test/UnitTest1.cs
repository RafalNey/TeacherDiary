namespace TeacherDiary.Test
{
    public class Tests
    {
        static void Main() { }
        [Test]
        public void AddingOneStudentsWithFewGrades_ShouldReturnCorrectMax()
        {
            //arrange
            var student = new Student("Adam", "Kamizelich");
            student.AddGrade(2);
            student.AddGrade(3);
            student.AddGrade(4);
            student.AddGrade(5);

            //act
            var statistics = student.GetStatistics();

            //assert
            Assert.That(statistics.Max, Is.EqualTo(5));
        }

        [Test]
        public void AddingOneStudentsWithFewGrades_ShouldReturnCorrectMin()
        {
            //arrange
            var student = new Student("Adam", "Kamizelich");
            student.AddGrade(2);
            student.AddGrade(3);
            student.AddGrade(4);
            student.AddGrade(5);

            //act
            var statistics = student.GetStatistics();

            //assert
            Assert.That(statistics.Min, Is.EqualTo(2));
        }

        [Test]
        public void AddingOneStudentsWithFewGrades_ShouldReturnCorrectAverage()
        {
            //arrange
            var student = new Student("Adam", "Kamizelich");
            student.AddGrade(2);
            student.AddGrade(3);
            student.AddGrade(4);
            student.AddGrade(5);

            //act
            var statistics = student.GetStatistics();

            //assert
            Assert.That(statistics.Average, Is.EqualTo(3.50));
        }
    }

}
