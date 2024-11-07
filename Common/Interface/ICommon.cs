using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface ICommon
    {
        string GenerateHashKey(string? input);
        string GenerateAlphanumericRandom(int? count);
    }
}
