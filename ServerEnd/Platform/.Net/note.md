# .net

**how to run delegate in async way without using Task (async/await) dll**  
https://stackoverflow.com/questions/1712741/why-does-asynchronous-delegate-method-require-calling-endinvoke  

**get result from IAsyncResult Interface**  
https://msdn.microsoft.com/en-us/library/system.iasyncresult(v=vs.110).aspx  

**how do events excute async or sync?**  
https://stackoverflow.com/questions/7106454/are-c-sharp-events-synchronous  


**thread pool**  
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/threading/how-to-use-a-thread-pool  


**Tasks, Monads, and LINQ**
https://blogs.msdn.microsoft.com/pfxteam/2013/04/03/tasks-monads-and-linq/

 
1. As both Wes and Eric highlight, a monad is a triple    consisting of a type, a Unit function (often called    Return), and a Bind function. If the type in           question is Task<T>, what are its Unit and Bind        functions?

2. Await is like a unary operator: it takes a single      argument, an awaitable (an “awaitable” is an           asynchronous operation).

3. read this link: https://ericlippert.com/2013/02/21/monads-part-one/


**semaphoreslim**  
https://msdn.microsoft.com/en-us/library/system.threading.semaphoreslim(v=vs.110).aspx  
1. Represents a lightweight alternative to Semaphore that limits the number of threads that can access a resource or pool of resources concurrently.  


**manualresetevent**
https://msdn.microsoft.com/en-us/library/system.threading.manualresetevent(v=vs.110).aspx  
1. Notifies one or more waiting threads that an event has occurred. This class cannot be inherited.

2. Reset(): Sets the state of the event to nonsignaled, causing threads to block.(Inherited from EventWaitHandle.)

3. Set(): Sets the state of the event to signaled, allowing one or more waiting threads to proceed.
