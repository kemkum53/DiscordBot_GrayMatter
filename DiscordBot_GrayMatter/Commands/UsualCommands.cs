using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace Discord_GrayMatter_Bot.Commands
{
    public class UsualCommands : BaseCommandModule
    {
        //[Command("ping")]
        //public async Task Ping(CommandContext ctx)
        //{
        //    await ctx.Channel.SendMessageAsync("pong").ConfigureAwait(false);
        //}

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

        //[Command("reactiontorole")]
        //public async Task Role(CommandContext ctx, DiscordChannel ch, string msg)




        [Command("deneme")]
        public async Task deneme(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("a");
        }
    }
}
