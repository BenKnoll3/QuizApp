using QuizApp.Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace QuizApp.Api.Service
{
    public class CardService
    {
        private readonly AppDbContext _db;

        public CardService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Card?> GetCardAsync(Guid cardId)
        {
            return await _db.Cards
                .Where(c => c.CardId == cardId)
                .FirstOrDefaultAsync();
        }

        public async Task<Card> CreateCardAsync(string q, string a)
        {
            Card card = new()
            {
                Question = q,
                Answer = a,
                CardId = Guid.NewGuid()
            };
            _db.Cards.Add(card);
            await _db.SaveChangesAsync();
            return card;
        }
        public async Task<Card> UpdateCardAsync(Guid cardId, string a, string q)
        {
            var card = await _db.Cards.FindAsync(cardId);
            if (card is not null)
            {
                card.Question = q;
                card.Answer = a;
                await _db.SaveChangesAsync();
                return card;
            }
            throw new ArgumentException("Card Id not found");
        }
        public async Task<bool> DeleteCardAsync(Guid cardId)
        {
            var card = await _db.Cards.FindAsync(cardId);
            if (card != null)
            {
                _db.Remove(card);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}