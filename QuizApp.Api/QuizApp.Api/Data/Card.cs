namespace QuizApp.Api.Data
{
    public class Card
    {
        public Guid CardId { get; set; }
        public required string Question { get; set; }
        public required string Answer { get; set; }

    }
}
