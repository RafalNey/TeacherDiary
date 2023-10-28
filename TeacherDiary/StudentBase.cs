namespace TeacherDiary
{
    public abstract class StudentBase : IStudent
    {
        public StudentBase(string name, string surname, string sex)
        {
            this.Name = name;
            this.Surname = surname;
            this.Sex = sex;
        }
        public StudentBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
            this.Sex = "M";
        }
        public StudentBase(string name)
        {
            this.Name = name;
            this.Surname = "noSurname";
            this.Sex = "M";
        }
        public StudentBase()
        {
            this.Name = "noName";
            this.Surname = "noSurname";
            this.Sex = "M";
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Sex { get; private set; }
        public abstract void AddGrade(float grade);
        public abstract void AddGrade(int grade);
        public abstract void AddGrade(string grade);
        public abstract void AddGrade(char grade);

        public abstract Statistics GetStatistics();
    }
}