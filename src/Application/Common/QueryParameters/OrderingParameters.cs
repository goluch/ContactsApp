using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.QueryParameters
{
    public sealed class OrderingParameters
    {
        public string OrderBy { get; set; } = "Id";

        public bool Desc { get; set; } = true;
    }
}
