using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Interfaces.Organizer
{
    /// <summary>
    ///  EntryComponents interface 
    /// </summary>
    public interface IEntryComponents
    {
        /// <summary>
        /// method for adding middleware operation services to services gropus
        /// </summary>
        /// <param name="middleware">service middleware</param>
        /// <returns></returns>
        IEntryComponents Use(Func<MessageWrapperDelegate, MessageWrapperDelegate> middleware);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        MessageWrapperDelegate BuildComponents();
    }
}
