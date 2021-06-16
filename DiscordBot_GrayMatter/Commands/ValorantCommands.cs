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
    public class ValorantCommands : BaseCommandModule
    {
        private string[] _maps = { "Bind", "Haven", "Split", "Ascent", "Icebox", "Breeze" };
        private string[] _modes = { "Derecesiz", "Dereceli", "Spike'a Hücum", "Ölüm Maçı", "Kopya" };
        private List<string> _players = new List<string>();
        private List<string> _team1 = new List<string>();
        private List<string> _team2 = new List<string>();
        private DiscordMessage _message;
        private string empty;
        private bool first = true;

        [Command("map")]
        public async Task Map(CommandContext ctx, params string[] maps)
        {
            await ctx.Message.DeleteAsync();
            Random rnd = new Random();
            string map = _maps[rnd.Next(_maps.Length)];

            while (maps.Contains(map))
            {
                map = maps[rnd.Next(maps.Length)];
            }
            await ctx.Channel.SendMessageAsync("Map: " + map).ConfigureAwait(false);
        }

        [Command("mode")]
        public async Task Mode(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            Random rnd = new Random();
            await ctx.Channel.SendMessageAsync("Mod: " + _modes[rnd.Next(_modes.Length)]);
        }

        [Command("katıl")]
        public async Task Katil(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();

            if (first)
            {
                _players.Add(ctx.User.Username);
                await ctx.Channel.SendMessageAsync("Oyuncular: " + ctx.User.Username);
                _message = (await ctx.Channel.GetMessagesAsync(1))[0];
                first = false;
            }
            else
            {
                if (_players.Contains(ctx.User.Username))
                    return;

                empty = "";
                _players.Add(ctx.User.Username);
                foreach (var i in _players)
                {
                    empty += i + ", ";
                }
                empty = empty.Remove(empty.Length - 2);
                await _message.ModifyAsync("Oyuncular: " + empty);
            }
        }
        [Command("katıl")]
        public async Task Katil(CommandContext ctx, string player)
        {
            await ctx.Message.DeleteAsync();
            if (first)
            {
                await ctx.Channel.SendMessageAsync("Önce kendin katıl sonra başkasını ekle!");
                return;
            }
            if (_players.Contains(player))
                return;

            _players.Add(player);
            empty = "";
            foreach (var i in _players)
            {
                empty += i + ", ";
            }
            empty = empty.Remove(empty.Length - 2);
            await _message.ModifyAsync("Oyuncular: " + empty);
        }

        [Command("belirle")]
        public async Task Belirle(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            Random rnd = new Random();
            int playerCount = _players.Count;
            for (int i = 0; i < playerCount / 2; i++)
            {
                string a = _players[rnd.Next(_players.Count)];
                _team1.Add(a);
                _players.Remove(a);
            }

            foreach (var i in _players)
            {
                _team2.Add(i);
            }

            _players.Clear();
            string team1 = "";
            string team2 = "";
            foreach (var i in _team1)
            {
                team1 += i + ", ";
            }
            foreach (var i in _team2)
            {
                team2 += i + ", ";
            }
            team1 = team1.Remove(team1.Length - 2);
            team2 = team2.Remove(team2.Length - 2);
            await _message.Channel.SendMessageAsync("Takım1: " + team1 + "\nTakım2: " + team2);

            //temizleme
            _players = new List<string>();
            _team1 = new List<string>();
            _team2 = new List<string>();
            first = true;
        }

        [Command("sıfırla")]
        public async Task Sifirla(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            _players = new List<string>(); 
            _team1 = new List<string>(); 
            _team2 = new List<string>();
            first = true;
            await _message.DeleteAsync();
            await ctx.Channel.SendMessageAsync("Oyuncular sıfırlandı!");
        }

    }
}
