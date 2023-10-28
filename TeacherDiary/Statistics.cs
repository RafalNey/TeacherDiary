namespace TeacherDiary
{
    public class Statistics
    {
        public float Sum { get; set; }
        public int Count { get; set; }

        // wartosci inicjalne
        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
        }
        public void AddGrade(float grade)
        {
            this.Count++;
            this.Sum += grade;
        }
        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }

        // Zamiana sredniej na ocene
        public string AverageGrade
        {
            get
            {
                switch (this.Average)
                {
                    case var average when average == 6:
                        return "Brawo! To najlepszy student. Ocena celujaca";
                    case var average when average >= 5.75:
                        return "Jeszcze o nim uslyszymy! Ocena: -6";
                    case var average when average >= 5.25:
                        return "Wybitny student. Ocena: 5+";
                    case var average when average >= 5:
                        return "Bardzo dobry student. Ocena: 5";
                    case var average when average >= 4.75:
                        return "Brawo! Piatka z malym minusem";
                    case var average when average >= 4.25:
                        return "Calkiem przyzwoicie. Ocena koncowa: 4+";
                    case var average when average >= 4:
                        return "Jest w porzo. Solidna czworka";
                    case var average when average >= 3.75:
                        return "Moze byc. Ocena koncowa: -4";
                    case var average when average >= 3.25:
                        return "Przecietniak. Ocena koncowa: 3+";
                    case var average when average >= 3:
                        return "Student trojkowy";
                    case var average when average >= 2.75:
                        return "Gamon zupelny. Trzy na szynach :-(";
                    case var average when average >= 2.25:
                        return "No ledwo, ledwo, ale niech ma to zaliczenie.";
                    case var average when average >= 2:
                        return "Kapa :-( ale warunkowo przepuszczamy, zeby sie z nim juz dluzej nie meczyc...";
                    case var average when average >= 1.75:
                        return "Semestr nie zaliczony! Do poprawki.";
                    case var average when average >= 1.25:
                        return "Semestr nie zaliczony! Do poprawki.";
                    case var average when average == 1:
                        return "Semestr nie zaliczony! Do poprawki.";
                    default:
                        return "Brak ocen. To jakis kompletny obibok! Wywalic na zbity ryj!";
                }
            }
        }
    }
}
