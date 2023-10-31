namespace TeacherDiary
{
    public class Statistics
    {
        public int Count { get; set; }
        public float Sum { get; set; }
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
        public string AverageGrade
        {
            get
            {
                switch (this.Average)
                {
                    case var average when average == 6.00:
                        return "Brawo! Brawo! Brawissimo! To najlepszy student jakiego mamy. Ocena celujaca.";
                    case var average when average >= 5.75:
                        return "Jeszcze o nim uslyszymy! Ocena celujaca z minusem.";
                    case var average when average >= 5.25:
                        return "Student wybitny. Piatka z duzym plusem.";
                    case var average when average >= 5.00:
                        return "Bardzo dobry student. Piatka.";
                    case var average when average >= 4.75:
                        return "Brawo! Piatka z malym minusem.";
                    case var average when average >= 4.25:
                        return "Calkiem przyzwoicie. Zasluzona czworka z plusem.";
                    case var average when average >= 4.00:
                        return "Gosc jest w porzo. Solidna czworka.";
                    case var average when average >= 3.75:
                        return "Moze byc. Ocena koncowa: cztery minus.";
                    case var average when average >= 3.25:
                        return "Przecietniak, ale przynajmniej sie stara. Zasluguje na 3+";
                    case var average when average >= 3.00:
                        return "Uczen trojkowy. Przepuszczamy.";
                    case var average when average >= 2.75:
                        return "Gamon zupelny. Trzy na szynach :-(";
                    case var average when average >= 2.25:
                        return "No ledwo, ledwo, ale niech ma juz to zaliczenie. Nie chesz sie z Nim dalej meczyc...";
                    case var average when average >= 2.00:
                        return "Lipa, panie totalna lipa. Przepuszczamy na warunku.";
                    case var average when average >= 1.00:
                        return "Semestr nie zaliczony! Do poprawki.";
                    default:
                        return "Brak ocen. To jakis obibok! Nie patyczkowac sie! Wywalic na zbity pysk!";
                }
            }
        }
    }
}