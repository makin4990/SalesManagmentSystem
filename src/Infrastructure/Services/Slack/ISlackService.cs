﻿using SlackAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Slack;

public interface ISlackService
{
    Task SendMessage(string message);
    Task<PostMessageResponse> SendMessagce(string team, string message);
}
