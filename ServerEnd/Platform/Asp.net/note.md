**bug resolve => how to config reverse proxy in azure web app**  
https://tomssl.com/2015/06/15/create-your-own-free-reverse-proxy-with-azure-web-apps/  
http://blchen.com/azure-webapp-reverse-proxy-configuration/  

**keep alive settings**  
https://stackoverflow.com/questions/9154599/where-or-how-is-the-keep-alive-setting-in-web-config  

**body size restrict**  
https://stackoverflow.com/questions/3853767/maximum-request-length-exceeded  



**how threadpool works in Aspnet**

https://stackoverflow.com/questions/10960998/how-different-async-programming-is-from-threads

1.  it has a "request context" for every incomplete request. ASP.NET threads come from a thread pool, and they enter the "request context" when they work on a request; when they're done, they exit their "request context" and return to the thread pool.
2. When the asynchronous operation completes, it schedules the remainder of the async method to the request context. ASP.NET grabs one of its handler threads (which may or may not be the same thread that executed the earlier part of the async method), the counter is decremented, and the thread executes the async method.