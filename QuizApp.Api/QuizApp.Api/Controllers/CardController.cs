using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Service;
using QuizApp.Api.Data;
using QuizApp.Api.Dtos;
using Microsoft.IdentityModel.Tokens;

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
    public async Task<ActionResult<CardDto>> GetCardAsync(Guid cardId)
    {
        Card? card = await _cardService.GetCardAsync(cardId);

        if (card is not null)
        {
            return new CardDto(card);
        }
        return BadRequest("Could not find card");
    }

    [HttpPost]
    public async Task<ActionResult<CardDto>> CreateCardAsync(CardDto newCard)
    {
        if (newCard.Answer is not null && newCard.Question is not null)
        {
            Card card = await _cardService.CreateCardAsync(newCard.Question.Trim(), newCard.Answer.Trim());
            return new CardDto(card);

        }
        return BadRequest("failed to create card");
    }

    [HttpPost("UpdateCard")]
    public async Task<ActionResult<CardDto>> UpdateCardAsync(CardDto newCard)
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