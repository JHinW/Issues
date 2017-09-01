using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Interfaces.Organizer
{
    /// <summary>
    ///  Connectting interface
    /// </summary>
    public interface ILinker
    {
        /// <summary>
        /// method for adding middleware connecttitng services to services gropus
        /// </summary>
        /// <param name="middleware"></param>
        /// <returns></returns>
        ILinker Connect(Func<MessageWrapperDelegate, MessageWrapperDelegate> middleware);

         /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
        MessageWrapperDelegate BuildLinker();
    }
}
