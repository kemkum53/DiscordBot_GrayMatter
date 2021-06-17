using System;
using System.Threading.Tasks;
using DSharpPlus;
namespace DiscordBot_GrayMatter
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
