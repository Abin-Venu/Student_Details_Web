using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Std.Common.Models
{
    public class ResultModel
    {
        public string ErrorText { get; set; }
        public bool IsSuccess { get; set; }
        public bool HasError { get; set; }
        public dynamic Data { get; set; }
        public object RouteData { get; set; }

    }
}