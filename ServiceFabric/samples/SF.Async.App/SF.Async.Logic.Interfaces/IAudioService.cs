using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Logic.Interfaces
{
    public interface IAudioService
    {
        Task<byte[]> Silk2Pcm(byte[] silkBytes);

        Task<byte[]> Pcm2Wav(byte[] pcmBytes);
    }
}
