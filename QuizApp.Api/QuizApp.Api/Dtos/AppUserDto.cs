using QuizApp.Api.Data;

namespace QuizApp.Api.Dtos
{
    public class AppUserDto
    {
        public AppUserDto(AppUser user)
        {
            UserName = user.UserName;
            Decks = user.Decks;
            AppUserId = user.Id;
        }
        public string? AppUserId { get; set; }
        public string? UserName { get; set; }
        public ICollection<Deck> Decks { get; set; }
    }
}
