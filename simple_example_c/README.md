This example is deployed at [https://simple-wasn-example-c.pages.dev/](https://simple-wasn-example-c.pages.dev/)

To compile run 
```bash
emcc -O3 -s WASM=1 -s EXPORTED_RUNTIME_METHODS='["cwrap"]' add.c -o add.js
``````

See [emscripten.org](https://emscripten.org/)