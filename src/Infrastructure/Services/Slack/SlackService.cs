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
            const string TOKEN = "xoxb-5806342235698-5842375040339-EsgJZNNbsSRBcSF6q1YwODVf";
            _client = new SlackTaskClient(TOKEN);
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
