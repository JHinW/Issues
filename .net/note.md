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
