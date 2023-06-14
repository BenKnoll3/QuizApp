using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Data;
using QuizApp.Api.Dtos;
using QuizApp.Api.Service;

namespace QuizApp.Api.Controllers;

[ApiController]
[Route("Deck")]
public class DeckController : ControllerBase
{
    private readonly DeckService _deckService;
    public DeckController(DeckService deckService)
    {
        _deckService = deckService;
    }

    [HttpGet]
    public async Task<ActionResult<DeckDto>> GetCardAsync(Guid deckId)
    {
        Deck? deck = await _deckService.GetDeckAsync(deckId);

        if (deck is not null)
        {
            return new DeckDto(deck);
        }
        return BadRequest("Could not find deck");
    }
}

