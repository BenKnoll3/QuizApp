using QuizApp.Api.Data;

namespace QuizApp.Api.Dtos
{
    public class CardDto
    {
        public CardDto() { }
        public CardDto(Card card) 
        {
            CardId = card.CardId;
            Question = card.Question;
            Answer = card.Answer;
        }
        public Guid? CardId { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
    }   
}