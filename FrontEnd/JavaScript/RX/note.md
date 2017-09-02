# RX


**entry doc**
https://gist.github.com/staltz/868e7e9bc2a7b8c1f754  



**vocabulary learned**  
  
  1. variant  => different in forms, In chinese "变种" 
  2. paradigm => a typical example or pattern of something; a pattern or model, means "模板 or 范例" in chinese



**Observable**　　
  
1. A promise is an Observable
```js

    var requestStream = Rx.Observable.just('https://api.github.com/users');

    var responseMetastream = requestStream
        .map(function(requestUrl) {
            // add by jin
            // get observable from a promise
            return Rx.Observable.fromPromise(jQuery.getJSON(requestUrl));
        });

    responseStream.subscribe(function(response) {

});
```

2.  see below js code snippet,   
    observer is like a listener, which is responsible for input event stream using  
    `
     observer.onNext(response),  
     observer.onError(error) 
     observer.onCompleted()
     `
    
```js

        var responseStream = Rx.Observable.create(function (observer) {
            jQuery.getJSON(requestUrl)
            .done(function(response) { observer.onNext(response); })
            .fail(function(jqXHR, status, error) { observer.onError(error); })
            .always(function() { observer.onCompleted(); });
        });
        
        responseStream.subscribe(function(response) {
            // do something with the response
        });

```