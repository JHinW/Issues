using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Logic.Interfaces
{
    public interface IAudioService
    {
        byte[] Silk2Pcm(byte[] silkBytes);

        byte[] Pcm2Wav(byte[] pcmBytes);
    }
}
