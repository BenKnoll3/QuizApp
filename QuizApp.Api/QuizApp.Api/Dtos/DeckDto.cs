using QuizApp.Api.Data;

namespace QuizApp.Api.Dtos
{
    public class DeckDto
    {
        public DeckDto() { }
        public DeckDto(Deck deck) 
        {
            DeckId = deck.DeckId;
            DeckName = deck.DeckName;
            Cards = deck.Cards;
        }
        public Guid? DeckId { get; set; }
        public string? DeckName { get; set;}
        public ICollection<Card>? Cards { get; set;}
    }
}
