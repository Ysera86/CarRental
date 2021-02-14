using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
