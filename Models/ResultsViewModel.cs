namespace TestMvcApp.Models
{
    public class ResultsViewModel
    {
        public int CorrectCount { get; set; }
        public int TotalQuestions { get; set; }
        public Dictionary<int, string> Answers { get; set; }
        public Dictionary<int, string> CorrectAnswers { get; set; }
    }
}
