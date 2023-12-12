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

## Running application locally
To run the application locally, you can use a rust tool called [trunk](https://trunkrs.dev).  
It lets you run it locally and rebuild it on save, so you don't have to rebuild the entire app again.  
It can be started with either `trunk watch` to simply watch for changes and rebuild, or `trunk serve` to spawn a web browser along with watching.  

## Building for production
To Build the app for production you can simply run the command `trunk build`.  
It build the app and bundles it into a dist folder in the root directory of the rust project.
