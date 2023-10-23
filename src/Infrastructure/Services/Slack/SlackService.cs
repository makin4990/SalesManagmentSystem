using SlackAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Slack
{
    public class SlackService : ISlackService
    {
        private readonly SlackTaskClient _client;

        public SlackService()
        {
            //_client = new SlackTaskClient(TOKEN);
        }
        public async Task<PostMessageResponse> SendMessagce(string team, string message)
        {
            var imagePath = message;
            string[] channels = { "general" };
            byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
            var resp = await _client.UploadFileAsync(imageBytes, "Hellöööö", channels);
            //var response = await _client.PostMessageAsync(team, message);
            return null;
        }

        public Task SendMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
