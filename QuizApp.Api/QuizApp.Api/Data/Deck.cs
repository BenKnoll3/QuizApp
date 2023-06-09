﻿namespace QuizApp.Api.Data
{
    public class Deck
    {
        public Guid DeckId { get; set; }
        public required string DeckName { get; set; }
        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}