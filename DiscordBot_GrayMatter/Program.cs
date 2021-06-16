using System;
using System.Threading.Tasks;
using DSharpPlus;
namespace Discord_GrayMatter_Bot
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
