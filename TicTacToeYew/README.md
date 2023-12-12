# Tic-Tac-Toe in Rust Yew
This is a simple Tic-Tac-Toe game implemented in [Rust with Yew](https://yew.rs).  

## Demo
A demo of the application can be found at [wasm-examples-ntnu.pages.dev/tictactoeyew](https://wasm-examples-ntnu.pages.dev/tictactoeyew/).  
If you'd like to experiment with the application locally or building it yourself, see sections [Running application locally](#Running-application-locally) and [Building for production](#Building-for-production).

## About Yew
[Yew](https://yew.rs) is a framework for building interactive client-side web UI components with Rust.  

Yew apps are built using *components*, like React.  
Components are Rust functions. Yew has a special syntax, combining Rust code with HTML markup with the help of *macros*.  
It uses the same rendering model as React, a virtual DOM.  

## Implentation
Yew with the help of rust and LLVM compiles directly into webassembly, and can be imported by a javascript glue files without any modifications.  
Since Rust is a compiled language without garbage collection, there is no need for bringing an interpreter or "engine" along, so it will run directly without the need to worry about garbage collection.
