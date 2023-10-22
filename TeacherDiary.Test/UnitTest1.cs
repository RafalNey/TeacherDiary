namespace TeacherDiary.Tests
{
    public class Tests
    {
        [Test]
        public void TestOfAdding()
        {
            //arrange
            var age1 = 10;
            var age2 = Student.result;

            //act
            var kumys = age1 + age2;
            //assert
            Assert.That(kumys, Is.EqualTo(17));
        }
    }
}