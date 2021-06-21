 using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace DiscordBot_GrayMatter.Commands
{
    public class UsualCommands : BaseCommandModule
    {
        [Command("dice")]
        public async Task Dice(CommandContext ctx, int dice)
        {
            Random rnd = new Random();
            await ctx.Channel.SendMessageAsync("Result: " + rnd.Next(dice).ToString()).ConfigureAwait(false);
        }

        [Command("clear")]
        public async Task Clear(CommandContext ctx, int a)
        {
            var messages = await ctx.Channel.GetMessagesAsync(a + 1);
            await ctx.Channel.DeleteMessagesAsync(messages);
        }

        //[Command("deneme")]
        //public async Task deneme(CommandContext ctx)
        //{
        //    await ctx.Channel.SendMessageAsync("a");
        //}
    }
}
