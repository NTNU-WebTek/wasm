# Simple example C

This example contains a simple C program, [add.c](add.c).  
If you'd like to see the example in action, see [https://wasm-examples-ntnu.pages.dev/simple_example_c/](https://wasm-examples-ntnu.pages.dev/simple_example_c/)  

```c
#include <emscripten.h>

EMSCRIPTEN_KEEPALIVE
int add(int num1, int num2)
{
    return num1 + num2;
}

EMSCRIPTEN_KEEPALIVE
char *hello()
{
    return "Hello from C!";
}
```
In the C code, there are two function definitions, `add` and `hello`.  
`int add(int num1, int num2)` takes two integers as parameters and returns their sum.  
`char *hello()` returns a pointer to a string.  
`EMSCRIPTEN_KEEPALIVE` is a declaration that tells the compiler to not remove the function even though it is not used in the C code.  

In order to compile the C code to WebAssembly, we use [emscripten](https://emscripten.org/).  
To compile run 
```bash
emcc -O3 -s WASM=1 -s EXPORTED_RUNTIME_METHODS='["cwrap"]' add.c -o add.js
```
This produces two files, `add.js` and `add.wasm`.  `add.js` is a JavaScript file that is responsible for loading the WebAssembly module and exposing the interface to JavaScript.  `add.wasm` is the WebAssembly module.  

See [index.html](index.html) for example usage of the WebAssembly module.  