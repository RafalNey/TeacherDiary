namespace TeacherDiary
{
    public class Student
    {
        private List<float> grades = new List<float>();
        public Student(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public static int result = 7;
        public void AddGrade(float grade)
        {
            this.grades.Add(grade);
        }
        public Statistics GetStatistics()
        {
            var statistics = new Statistics();
            //
            return statistics;

        }
    }
}