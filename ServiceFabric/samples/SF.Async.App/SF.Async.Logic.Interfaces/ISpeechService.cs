using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Logic.Interfaces
{
    public interface ISpeechService
    {
        Task<Object> SendAudio(byte[] wavBytes, int length);
    }
}
