# react

**key in react components**
https://facebook.github.io/react/docs/lists-and-keys.html
1. Keys help React identify which items have changed, are added, or are          removed. Keys should be given to the elements inside the array to give the    elements a stable identity:
2. use it when the components is out from Array Map scenario.(no care about the name of component)
```js
        function Blog(props) {
            const sidebar = (
                <ul>
                {props.posts.map((post) =>
                    <li key={post.id}>
                    {post.title}
                    </li>
                )}
                </ul>
        );
```


**Context**  
https://facebook.github.io/react/docs/context.html  

1. Not recommended in react programming
2. https://facebook.github.io/react/docs/context.html#referencing-context-in-lifecycle-methods

3. Referencing Context in Lifecycle Methods
If contextTypes is defined within a component, the following lifecycle methods will receive an additional parameter, the context object:

        a. constructor(props, context)  
        b. componentWillReceiveProps(nextProps, nextContext)  
        c. shouldComponentUpdate(nextProps, nextState, nextContext)  
        d. componentWillUpdate(nextProps, nextState, nextContext)  
        e. componentDidUpdate(prevProps, prevState, prevContext)  