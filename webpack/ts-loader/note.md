# tsconfig.json to see Compiler Options usage
**List of path mapping entries for module names to locations relative to the baseUrl. See Module Resolution documentation for more details.**  
```json
{
      "compilerOptions": {
        "baseUrl": ".",
        /*
            List of path mapping entries for module names to locations relative to the baseUrl. See Module Resolution documentation for more details.
        */
        "paths": {
            "*": [
                "src/appsource/*",
                "src/shared/*",
                "src/server/appsource/*"
            ]
        },
        "target": "es5",
        "sourceMap": true,
        "module": "commonjs",
        "moduleResolution": "node",
        "jsx": "react",
        "allowSyntheticDefaultImports": true,
        "noLib": false,
        "declaration": false,
        "noImplicitAny": true,
        "suppressImplicitAnyIndexErrors": true,
        "experimentalDecorators": true,
        "noEmitOnError": true
      },
      "exclude": [
        "node_modules",
        "external_artifacts",
        "typings"
      ]
}
```