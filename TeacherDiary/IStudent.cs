namespace TeacherDiary
{
    public interface IStudent
    {
        string Name { get; }
        string Surname { get; }
        string Sex { get; }
        void AddGrade(float grade);
        void AddGrade(int grade);
        void AddGrade(string grade);
        Statistics GetStatistics();
    }
}