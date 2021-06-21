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
    public class ValorantCommands : BaseCommandModule
    {
        private string[] _maps = { "Bind", "Haven", "Split", "Ascent", "Icebox", "Breeze" };
        private string[] _modes = { "Derecesiz", "Dereceli", "Spike'a Hücum", "Ölüm Maçı", "Kopya" };
        private List<string> _players = new List<string>();
        private List<string> _team1 = new List<string>();
        private List<string> _team2 = new List<string>();
        private DiscordEmbedBuilder _eb;
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
                _eb = new DiscordEmbedBuilder()
                {
                    Color = DiscordColor.Blue,
                    Title = "Oyuncular",
                    Description = ctx.User.Username
                };
                await ctx.Channel.SendMessageAsync(_eb);
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
                _eb.Description = empty;
                await _message.DeleteAsync();
                await ctx.Channel.SendMessageAsync(_eb);
                _message = (await ctx.Channel.GetMessagesAsync(1))[0];
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
            _eb.Description = empty;
            await _message.DeleteAsync();
            await ctx.Channel.SendMessageAsync(_eb);
            _message = (await ctx.Channel.GetMessagesAsync(1))[0];
        }

        [Command("çık")]
        public async Task Cik(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            if (_players.Contains(ctx.User.Username))
            {
                empty = "";
                _players.Remove(ctx.User.Username);
                if (_players.Count != 0)
                {
                    foreach (var i in _players)
                    {
                        empty += i + ", ";
                    }
                    empty = empty.Remove(empty.Length - 2);
                }
                _eb.Description = empty;
                await _message.DeleteAsync();
                await ctx.Channel.SendMessageAsync(_eb);
                _message = (await ctx.Channel.GetMessagesAsync(1))[0];
            }
        }

        [Command("belirle")]
        public async Task Belirle(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            Random rnd = new Random();
            int playerCount = _players.Count;
            if (playerCount == 0)
            {
                await ctx.Channel.SendMessageAsync("Yeteri kadar oyuncu yok!");
            }
            else
            {
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
                _eb = new DiscordEmbedBuilder()
                {
                    Color = DiscordColor.Purple,
                    Title = "TAKIMLAR",
                };
                _eb.AddField("Takım1", team1, false);
                _eb.AddField("Takım2", team2, false);
                await _message.Channel.SendMessageAsync(_eb);

                //temizleme
                _players = new List<string>();
                _team1 = new List<string>();
                _team2 = new List<string>();
                _eb = new DiscordEmbedBuilder();
                first = true;
            }
        }

        [Command("sıfırla")]
        public async Task Sifirla(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            _players = new List<string>();
            _team1 = new List<string>();
            _team2 = new List<string>();
            _eb = new DiscordEmbedBuilder();
            first = true;
            await _message.DeleteAsync();
            await ctx.Channel.SendMessageAsync("Oyuncular sıfırlandı!");
        }
    }
}
