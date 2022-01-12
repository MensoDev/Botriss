using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;

namespace EchoBotriss.EchoBot.Controllers;

[Route("api/messages")]
[ApiController]
public class BotrissController : ControllerBase
{
    private readonly IBotFrameworkHttpAdapter _adapter;
    private readonly IBot _bot;

    public BotrissController(IBot bot, IBotFrameworkHttpAdapter adapter)
    {
        _bot = bot;
        _adapter = adapter;
    }

    [HttpGet, HttpPost]
    public async Task PostAsync()
    {
        await _adapter.ProcessAsync(Request, Response, _bot);
    }
}