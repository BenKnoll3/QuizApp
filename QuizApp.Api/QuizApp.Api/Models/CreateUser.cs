using QuizApp.Api.Models;

namespace QuizApp.Api.Models
{
    public class CreateUser : UserCredentials
    {
        public CreateUser(string username, string password) : base(username, password)
        {

        }

    }
}
