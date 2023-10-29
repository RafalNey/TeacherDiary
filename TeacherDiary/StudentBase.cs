namespace TeacherDiary
{
    // Bazowa klasa abstarakcyjna Studenta.
    // Struktura, ktora mowi nam ogolnie "JAK" wypelnic miesniami szkielet interface'u.
    public abstract class StudentBase : IStudent
    {
        public StudentBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public abstract void AddGrade(float grade);
        public abstract void AddGrade(string grade);
        public abstract Statistics GetStatistics();
    }
}