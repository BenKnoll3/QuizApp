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
    public async Task<ActionResult<DeckDto>> GetDeckAsync(Guid deckId)
    {
        Deck? deck = await _deckService.GetDeckAsync(deckId);

        if (deck is not null)
        {
            return new DeckDto(deck);
        }
        return BadRequest("Could not find deck");
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteDeckAsync(Guid deckId, string userId)
    {
        bool del = await _deckService.DeleteDeckAsync(deckId, userId);
        return del;
    }
    [HttpGet("GetManyDecks")]
    public async Task<IEnumerable<Deck>> GetManyDecks(int? count)
    {
        return await _deckService.GetSeveralDecksAsync(count);
    }

    [HttpPost("AddCardToDeck")]
    public async Task<ActionResult<Deck>> AddCardToDeckAsync(Guid deckId, Guid cardId)
    {
        var updatedDeck = await _deckService.AddCardToDeckAsync(deckId, cardId);
        if (updatedDeck is not null)
        {
            return updatedDeck;
        }
        return BadRequest("Failed to add Card to Deck");
    }

    [HttpPost("RemoveCardFromDeck")]
    public async Task<ActionResult<Deck>> RemoveCardFromDeckAsync(Guid deckId, Guid cardId)
    {
        var updatedDeck = await _deckService.RemoveCardFromDeckAsync(deckId, cardId);
        if (updatedDeck is not null)
        {
            return updatedDeck;
        }
        return BadRequest("Failed to remove Card to Deck");
    }
}

