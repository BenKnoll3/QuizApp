using Microsoft.AspNetCore.Identity;

namespace QuizApp.Api.Data
{
    public class AppUser: IdentityUser
    {
        public ICollection<Deck> Decks { get; set; } = null!;
    }
}