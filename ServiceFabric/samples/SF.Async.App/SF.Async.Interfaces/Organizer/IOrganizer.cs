using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Interfaces.Organizer
{
    public interface IOrganizer
    {
        /// <summary>
        /// method for adding middleware operation services to services gropus
        /// </summary>
        /// <param name="middleware">service middleware</param>
        /// <returns></returns>
        IOrganizer Use(Func<MessageWrapperDelegate, MessageWrapperDelegate> middleware);

        /// <summary>
        /// method for adding middleware connecttitng services to services gropus
        /// </summary>
        /// <param name="middleware"></param>
        /// <returns></returns>
        IOrganizer Connect(Func<MessageWrapperDelegate, MessageWrapperDelegate> middleware);


        /// <summary>
        /// send message to other sf-services with this entry method
        /// </summary>
        /// <param name="message">content for sending</param>
        /// <returns></returns>
        IOrganizer SetMessage(MessageWrapper message);

        /// <summary>
        /// call connecting delegate to link outter services
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        IOrganizer SetConnecting(MessageWrapper message);


        /// <summary>
        /// builds the delegate used by method  <see cref="SetMessage"/> 
        /// </summary>
        /// <returns></returns>
        MessageWrapperDelegate BuildComponents();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        MessageWrapperDelegate BuildConnecttings();

    }
}
