# try to debug webpack bunlde using vscode debug  

**waste so much time unitl got this page**  
https://stackoverflow.com/questions/36470946/debug-webpack-bundled-node-ts-with-visual-studio-code  
**chrome dev tools seems a good tool if i can make full use of that as vs code has so many bugs**  
chrome://inspect 
https://github.com/webpack/webpack/issues/2612  
https://medium.com/@paul_irish/debugging-node-js-nightlies-with-chrome-devtools-7c4a1b95ae27  

# use vscode to debug nodejs  

https://github.com/Microsoft/vscode-chrome-debug  
https://github.com/Microsoft/vscode-node-debug2  

**use sourceMapPathOverrides if sourceMap is out from webpack2**  
```json
{
    "sourceMapPathOverrides": {
    "webpack:///./*":   "${cwd}/*", // Example: "webpack:///./src/app.js" -> "/users/me/project/src/app.js"
    "webpack:///*":     "*",        // Example: "webpack:///C:/project/app.ts" -> "C:/project/app.ts"
    "meteor://💻app/*": "${cwd}/*"  // Example: "meteor://💻app/main.ts" -> "c:/code/main.ts"
}
```
