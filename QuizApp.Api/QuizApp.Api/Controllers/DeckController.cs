using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Data;
using QuizApp.Api.Dtos;
using QuizApp.Api.Identity;
using QuizApp.Api.Service;
using System.Security.Claims;

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
    public async Task<ActionResult<DeckDto>> GetDeckAsync(string deckId)
    {
        Guid gDeckId = Guid.Parse(deckId);
        Deck? deck = await _deckService.GetDeckAsync(gDeckId);

        if (deck is not null)
        {
            return new DeckDto(deck);
        }
        return BadRequest("Could not find deck");
    }
    [HttpGet("Search")]
    public async Task<ActionResult<DeckDto>> SearchDeckAsync(string deckName)
    {
        Deck? deck = await _deckService.GetDeckSearchAsync(deckName);

        if (deck is not null)
        {
            return new DeckDto(deck);
        }
        return BadRequest("Could not find deck");
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<DeckDto>> CreateDeckAsync([FromBody]string deckTitle)
    {
        var userId = HttpContext.User.FindFirstValue(Claims.UserId);
        if (userId is not null)
        {
            Deck deck = await _deckService.CreateDeckAsync(deckTitle, userId);
            return new DeckDto(deck);
        }
        return BadRequest("Failed to get userId from token");
    }

    [HttpDelete]
    [Authorize]
    public async Task<ActionResult<bool>> DeleteDeckAsync(string deckId)
    {
        Guid gDeckId = Guid.Parse(deckId);
        var userId = HttpContext.User.FindFirstValue(Claims.UserId);
        if (userId is not null)
        {
            bool del = await _deckService.DeleteDeckAsync(gDeckId, userId);
            return del;
        }
        return BadRequest("Failed to get userId from token");
    }
    [HttpGet("GetManyDecks")]
    public async Task<IEnumerable<Deck>> GetManyDecks(int? count)
    {
        return await _deckService.GetSeveralDecksAsync(count);
    }

    [HttpPost("AddCardToDeck")]
    [Authorize]
    public async Task<ActionResult<Deck>> AddCardToDeckAsync([FromBody]string deckId, string cardId)
    {
        Guid gDeckId = Guid.Parse(deckId);
        Guid gCardId = Guid.Parse(cardId);
        var updatedDeck = await _deckService.AddCardToDeckAsync(gDeckId, gCardId);
        if (updatedDeck is not null)
        {
            return updatedDeck;
        }
        return BadRequest("Failed to add Card to Deck");
    }

    [HttpPost("RemoveCardFromDeck")]
    [Authorize]
    public async Task<ActionResult<Deck>> RemoveCardFromDeckAsync([FromBody] string deckId, string cardId)
    {
        Guid gDeckId = Guid.Parse(deckId);
        Guid gCardId = Guid.Parse(cardId);
        var updatedDeck = await _deckService.RemoveCardFromDeckAsync(gDeckId, gCardId);
        if (updatedDeck is not null)
        {
            return updatedDeck;
        }
        return BadRequest("Failed to remove Card to Deck");
    }
}

