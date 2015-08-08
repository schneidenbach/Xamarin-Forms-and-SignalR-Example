using System;
using Microsoft.AspNet.SignalR.Client;
using System.Threading.Tasks;

namespace XamarinSignalRExample
{
	public class SignalRClient
	{
		private HubConnection Connection;
		private IHubProxy ChatHubProxy;

		public delegate void MessageReceived(string username, string message);
		public event MessageReceived OnMessageReceived;

		public SignalRClient(string url)
		{
			Connection = new HubConnection(url);

			ChatHubProxy = Connection.CreateHubProxy("chat");
			ChatHubProxy.On<string, string>("MessageReceived", (username, text) => {
				OnMessageReceived?.Invoke(username, text);
			});
		}

		public void SendMessage(string username, string text)
		{

		}

		public Task Start()
		{
			return Connection.Start();
		}

		public static async Task<SignalRClient> CreateAndStart(string url)
		{
			var client = new SignalRClient(url);
			await client.Start();
			return client;
		}
	}
}

