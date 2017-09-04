# Functional
https://medium.com/javascript-scene/master-the-javascript-interview-what-is-functional-programming-7f218c68b3a0  

1. Pure functions  
2. Function composition  
3. Avoid shared state  
4. Avoid mutating state  

```js
    const a = Object.freeze({
    foo: 'Hello',
    bar: 'world',
    baz: '!'
    });

    a.foo = 'Goodbye';
    // Error: Cannot assign to read only property 'foo' of object Object
```


```js
    const a = Object.freeze({
    foo: { greeting: 'Hello' },
    bar: 'world',
    baz: '!'
    });

    a.foo.greeting = 'Goodbye';

    console.log(`${ a.foo.greeting }, ${ a.bar }${a.baz}`);
```

         a.  the top level primitive properties of a frozen object can’t change, but any property which is also an object (including arrays, etc…) can still be mutated — so even frozen objects are not immutable unless you walk the whole object tree and freeze every object property.

5. Avoid side effects 

    a. This is the reason that most front-end frameworks encourage users to manage state and component rendering in separate, loosely coupled modules.
