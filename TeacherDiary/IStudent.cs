namespace TeacherDiary
{
    // Interface Studenta.
    // Goly szkielet, ktory mowi nam tylko "CO" powinno byc w koncowym pliku.
    public interface IStudent
    {
        string Name { get; }
        string Surname { get; }

        void AddGrade(float grade);
        void AddGrade(string grade);

        Statistics GetStatistics();
    }
}