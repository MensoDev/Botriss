using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace EchoBotriss.EchoBot.Bots;

public class TrissEchoBot : ActivityHandler
{
    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
    {
        var echoMessage = $"ECHO: {turnContext.Activity.Text}";
        await turnContext.SendActivityAsync(MessageFactory.Text(echoMessage, echoMessage), cancellationToken);
    }

    protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
    {
        const string welcomeMessage = "Hello {0}, Nice to mete you";
        foreach (var member in membersAdded)
        {
            if (member.Id == turnContext.Activity.Recipient.Id) continue;
            
            //var message = MessageFactory.Text(string.Format(welcomeMessage, member.Name), welcomeMessage);
            var options = new List<string>()
            {
                "Get ont signal!",
                "Get client status"
            };
            var message = MessageFactory.SuggestedActions(
                options,
                string.Format(welcomeMessage, member.Name));
            
            await turnContext.SendActivityAsync(message, cancellationToken);
        }
    }
}