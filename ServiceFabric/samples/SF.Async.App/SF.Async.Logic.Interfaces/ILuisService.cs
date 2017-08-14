using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Logic.Interfaces
{
    public interface ILuisService
    {
        Task<dynamic> GetIntention(string text);
    }
}
