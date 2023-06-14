using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Service;
using QuizApp.Api.Data;
using QuizApp.Api.Dtos;

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
}