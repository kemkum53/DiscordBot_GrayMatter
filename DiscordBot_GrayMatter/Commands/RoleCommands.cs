using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_GrayMatter.Commands
{
    class RoleCommands : BaseCommandModule
    {
        [Command("a")]
        public async Task aaa(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("a");
        }
    }
}
