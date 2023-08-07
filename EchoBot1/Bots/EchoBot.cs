// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.18.1

using EchoBot1.Data;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EchoBot1.Bots
{
    public class EchoBot : ActivityHandler
    {
        private readonly AppDbContext Db;

        public EchoBot(AppDbContext db)
        {
            Db = db;
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            // LOGIC
            var replyText = "";
            try
            {
                int memberId = Int32.Parse(turnContext.Activity.Text);
                var result = Db.TeamMembers
                    .Where(x => x.MemberId == memberId)
                    .Select(x => x.MemberName)
                    .FirstOrDefault();

                if(result != null)
                {
                    replyText = "Result: " + result;
                }
                else
                {
                    replyText = memberId + " Not Found!";
                }
            }
            catch
            {
                replyText = "Enter valid number!";
            }

            await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Hello from Berry bot!........ Enter memebr number";
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }
    }
}
