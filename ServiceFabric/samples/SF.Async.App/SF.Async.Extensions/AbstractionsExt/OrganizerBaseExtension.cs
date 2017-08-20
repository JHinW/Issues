using SF.Async.Abstractions;
using SF.Async.Interfaces.Organizer;
using System;

namespace SF.Async.Extensions.AbstractionsExt
{
    public static class OrganizerBaseExtension
    {
        public static IOrganizer UseParellelBase(this OrganizerBase organizer, Type type)
        {
            return organizer.Use(next => 
            {
                return message =>
                {

                    return next(message);
                };
            });
        }
    }
}
