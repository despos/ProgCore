using System;
using Microsoft.AspNetCore.Blazor.Browser.Interop;

namespace xxx
{
    public class ExampleJsInterop
    {
        public static string Prompt(string message)
        {
            return RegisteredFunction.Invoke<string>(
                "xxx.ExampleJsInterop.Prompt",
                message);
        }
    }
}
