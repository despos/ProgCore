//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   BLAZOR demos
// 


namespace Forms.Shared
{
    public class CommandResponse
    {
        public static CommandResponse Ok = new CommandResponse(true);
        public static CommandResponse Fail = new CommandResponse(false);

        public bool Success { get; private set; }
        public string Message { get; set; }
        public string ReturnUrl { get; set; }

        // JSON-deserializable
        public CommandResponse()
        {
            
        }

        public CommandResponse(bool success)
        {
            Success = success;
        }

        public CommandResponse AddMessage(string message)
        {
            Message = message;
            return this;
        }

        public CommandResponse AddRedirectUrl(string url)
        {
            ReturnUrl = url;
            return this;
        }
    }
}