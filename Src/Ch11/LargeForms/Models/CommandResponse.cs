//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch11 - Posting Data from Client-side
//   LargeForms
//

using System;

namespace Ch11.LargeForms.Models
{
    public class CommandResponse
    {
        public static CommandResponse Ok = new CommandResponse(true);
        public static CommandResponse Fail = new CommandResponse();

        public CommandResponse(bool success = false, string message = "")
        {
            Success = success;
            Message = message;
            RedirectUrl = String.Empty;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
        public string Key { get; private set; }
        public string ExtraData { get; private set; }
        public string RedirectUrl { get; private set; }

        public CommandResponse AddMessage(string message)
        {
            Message = message;
            return this;
        }

        public CommandResponse AddKey(string key)
        {
            Key = key;
            return this;
        }

        public CommandResponse AddRedirectUrl(string url)
        {
            RedirectUrl = url;
            return this;
        }

        public CommandResponse AddExtra(string data)
        {
            ExtraData = data;
            return this;
        }
    }
}