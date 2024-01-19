using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Infraestructure.Factories
{
	public class TelegramService
	{
		private readonly ITelegramBotClient client;
		private readonly long chatId = -1001301508001;
		private readonly string? telegramApiKey;
		public TelegramService(IConfiguration apiKeysFactory)
		{
			this.telegramApiKey = apiKeysFactory["ApiKeys:Telegram"];
			client = new TelegramBotClient(telegramApiKey!)!;
		}

		public async Task<Message> SendMessage(string message)
		{
			try
			{
				return await client.SendTextMessageAsync(chatId, message);
			}
			catch (Exception ex)
			{
				throw new Exception($"Error Telegram send: {ex}");
			}
		}
	}
}
