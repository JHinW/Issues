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