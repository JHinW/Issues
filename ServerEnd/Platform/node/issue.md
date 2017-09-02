
# got build error when install gulp-resx2  using npm
  resove this pro when i saw this page : https://github.com/libxmljs/libxmljs/issues/421

  **enable https when using node**  
  https://nodejs.org/api/https.html  


  **event loop timers and nexttick**  
  https://nodejs.org/en/docs/guides/event-loop-timers-and-nexttick/  

  1. when no more calls are in the queue the event loop will see that the threshold of the soonest timer has been reached then wrap back to the timers phase to execute the timer's callback 
   
     a. timers: this phase executes callbacks scheduled by setTimeout() and     setInterval().  

     b. I/O callbacks: executes almost all callbacks with the exception of      close callbacks, the ones scheduled by timers, and setImmediate().

     c. idle, prepare: only used internally.

     d. poll: retrieve new I/O events; node will block here when appropriate.

     e. check: setImmediate() callbacks are invoked here.

     f. close callbacks: e.g. socket.on('close', ...).


  2. If the poll queue is empty, one of two more things will happen:
  If scripts have been scheduled by setImmediate(), the event loop will end the poll phase and continue to the check phase to execute those scheduled scripts.
  If scripts have not been scheduled by setImmediate(), the event loop will wait for callbacks to be added to the queue, then execute them immediately.

  3. process.nextTick() will cause your I/O suffering starve.  
      It just takes a callback with no time bound, 
      since it will be executing in the next iteration of the Event Loop.
     the nextTickQueue will be processed after the current operation completes  
     https://medium.com/@amanhimself/how-process-nexttick-works-in-node-js-cb327812e083  



  **how to understand promise**  
  https://developer.mozilla.org/en/docs/Web/JavaScript/Reference/Global_Objects/Promise  
1. status => pending, fulfilled, rejected
2. callBack => resolve, reject
3. thenable => callback queue, callback func. should be called only once