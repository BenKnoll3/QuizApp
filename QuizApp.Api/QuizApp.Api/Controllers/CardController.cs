using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Service;
using QuizApp.Api.Data;
using QuizApp.Api.Dtos;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace QuizApp.Api.Controllers;

[ApiController]
[Route("Card")]
public class CardController : ControllerBase
{
    private readonly CardService _cardService;
    public CardController(CardService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet]
    public async Task<ActionResult<CardDto>> GetCardAsync(string cardId)
    {
        Guid gCardId = Guid.Parse(cardId);
        Card? card = await _cardService.GetCardAsync(gCardId);

        if (card is not null)
        {
            return new CardDto(card);
        }
        return BadRequest("Could not find card");
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CardDto>> CreateCardAsync([FromBody] CardDto newCard)
    {
        if (newCard.Answer is not null && newCard.Question is not null)
        {
            Card card = await _cardService.CreateCardAsync(newCard.Question.Trim(), newCard.Answer.Trim());
            return new CardDto(card);

        }
        return BadRequest("failed to create card");
    }

    [HttpPost("UpdateCard")]
    [Authorize]
    public async Task<ActionResult<CardDto>> UpdateCardAsync([FromBody] CardDto newCard)
    {
        if (newCard.Answer is not null && newCard.Question is not null && newCard.CardId is not null)
        {
            Card card = await _cardService.UpdateCardAsync((Guid) newCard.CardId, newCard.Question.Trim(), newCard.Answer.Trim());
            return new CardDto(card);

        }
        return BadRequest("failed to update card");
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<CardDto>>> SearchCards(string query)
    {
        var cards = await _cardService.SearchForCardAsync(query);

        if (!cards.IsNullOrEmpty())
        {
            var cardDtos = cards.Select(card => card != null ? new CardDto(card) : null)
                            .Where(dto => dto != null);

            return Ok(cardDtos);
        }

        return BadRequest("Could not find card via query");
    }
}