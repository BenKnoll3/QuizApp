using QuizApp.Api.Data;
using Microsoft.EntityFrameworkCore;
using QuizApp.Api.Dtos;

namespace QuizApp.Api.Service
{
    public class DeckService
    {
        private readonly AppDbContext _db;

        public DeckService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Deck?> GetDeckAsync(Guid deckId)
        {
            return await _db.Decks
                .Where(d => d.DeckId == deckId)
                .FirstOrDefaultAsync();
        }
        public async Task<Deck?> GetDeckAsync(string deckTitle)
        {
            return await _db.Decks
                .Where(d => d.DeckName == deckTitle)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Deck>> GetSeveralDecksAsync(int? count)
        {
            count ??= 6;
            var totalCount = await _db.Decks.CountAsync();
            totalCount -= count.Value;
            int index = new Random().Next(totalCount);
            var decks = await _db.Decks
              .Skip(index)
              .Take(count.Value)
              .ToListAsync();
            return decks;
        }

        public async Task<Deck> CreateDeckAsync(string deckName, string userId)
        {
            AppUser? user = await _db.Users.FindAsync(userId) ?? throw new ArgumentException("Failed to find userId in Table");
            Deck deck = new()
            {
                DeckName = deckName,
                DeckId = Guid.NewGuid(),
                Cards = new List<Card>(),
                AppUserId = user.Id
            };
            user.Decks.Add(deck);
            _db.Decks.Add(deck);
            await _db.SaveChangesAsync();
            return deck;
        }
        public async Task<bool> DeleteDeckAsync(Guid deckId, string userId)
        {
            AppUser? user = await _db.Users.FindAsync(userId) ?? throw new ArgumentException("Failed to find userId in Table");
            var deck = await _db.Decks.FindAsync(deckId);
            if (deck != null)
            {
                if (deck.AppUserId != user.Id)
                {
                    throw new ArgumentException("User doesn't have permission to delete this deck");
                }
                user.Decks.Remove(deck);
                _db.Decks.Remove(deck);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<Deck> AddCardToDeckAsync(Guid deckId, Guid cardId)
        {
            var card = await _db.Cards.FindAsync(cardId);
            var deck = await _db.Decks.FindAsync(deckId);
            if (card is not null && deck is not null)
            {
                deck.Cards.Add(card);
                await _db.SaveChangesAsync();
                return deck;
            }
            throw new ArgumentException("Card Id or Deck Id not found");
        }

        public async Task<Deck> RemoveCardFromDeckAsync(Guid deckId, Guid cardId)
        {
            var card = await _db.Cards.FindAsync(cardId);
            var deck = await _db.Decks.FindAsync(deckId);
            if (card is not null && deck is not null)
            {
                if (!deck.Cards.Remove(card))
                {
                    throw new ArgumentException("Card failed to be removed or is not in list");
                }
                await _db.SaveChangesAsync();
                return deck;
            }
            throw new ArgumentException("Card Id or Deck Id not found");
        }
    }
}