using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_GrayMatter.Commands
{
    class FunCommands : BaseCommandModule
    {
        public string[] words = new string[] { "31", "sj", "s ve j", "mi-mi-mizah şow" };

        [Command("sj")]
        public async Task sj(CommandContext ctx)
        {
            Random rnd = new Random();
            await ctx.Channel.SendMessageAsync(words[rnd.Next(words.Length)]);
        }
        [Command("31")]
        public async Task sj2(CommandContext ctx)
        {
            Random rnd = new Random();
            await ctx.Channel.SendMessageAsync(words[rnd.Next(words.Length)]);
        }
        [Command("kavdesim")]
        public async Task Kavdesim(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("kavdesim hevikoptev pat pat");
        }
    }
}
