# wasm-specialization-course
This repository is a result of work done in [IDATA2506 - Computer science, specialization course](https://www.ntnu.edu/studies/courses/IDATA2506#tab=omEmnet) at [NTNU](https://www.ntnu.edu/).  
Specialization chosen is **Web Assembly** and the following is a result of our exploration of the topic. It is an overview with some deeper dives and examples.  

The abbreviation **WASM** is used throughout this document to refer to **Web Assembly**.  

## What problem or challenge led to Web Assembly?
Web Assembly solves multiple problens. The most notable ones are language diversity and performance. WASM allows developers to use other languages than JavaScript in the browser, thus breaking the monopoly of JavaScript. Additionally WASM runs at near-native performance, which is in a lot of cases an improvement over JavaScript.

## What is Web Assembly?
Web Assembly is essentially a low-level assembly-like language, with binary instruction foramt.  
It is a compilation target for languages such as C, C++, Rust and more.

## Who owns or maintains it?
WASM is maintained by [WebAssembly Working Group](https://www.w3.org/groups/wg/wasm/) at World Wide Web Consortium : [W3C](https://www.w3.org/). This means there are maintainers from all major browsers defining the specifications for WASM, and implementing it consistently in their browsers.

## Which browsers support it?
All majors browser support WASM. Firefox, Safari and Chromium based browsers (Chrome, Edge, etc).  

## What can one do with WebAssembly?
The biggest usecase for WASM is to use other languages than JavaScript to build your next web application. It is made rather easy by various framwerosks, which is covered in a later section.  
WASM is designed to run alongside JavaScript, and can be called from JavaScript. At the same time, JavaScript can be called from WASM. This allows for interoperability between the two. Thus you can access all the browser APIs from WASM.  

## Which languages are supported?  
As mentioned earlier, WASM serves as a compilation target for languages such as C, C++ or Rust. What is *special* about these languages is that the developers manage the memory. Higher level languages such as C# or Java use garbage collection which is not yet supported in WASM.

Here is a list of languages officailly supported by WASM: https://github.com/appcypher/awesome-wasm-langs.  

## Garbage collection
As of now, garbege collector is not supported. This means, the WASM code has to manage its memory. This is normal in languages such as C, C++ or Rust.  
But garbage collected languages such as C# are supported... How?  
This is achieved by compiling the necessary runtime into WASM, and then executing the code on top of that. We can see this in action in the [TicTacToeBlazor](/TicTacToeBlazor) example. Here is a short explanation of how it works:  
First of all, C# is compiled into CIL (Common Intermediate Language, equivalent to Java bytecode). CIL is run on the .NET runtime (equivalent to Java Virtual Machine), which is a virtual machine with a garbage collector. The way C# is run is by compiling the necesary runtime into WASM, and then running the CIL on top of that. This way the runtime runs directly in the browser, as an abstraction layer between the WASM and the C# code.

## Is WebAssembly running in the browser only, or can it run on backend?
WASI (WebAssembly System Interface) is a specification for running WASM outside of the browser. It is a system interface for WASM, allowing it to interact with the host operating system. It is maintained by the [Wasmtime project](https://wasmtime.dev/), same project responsible for Warmtime, a runtime for WASM - making it possible to running WASM outside of the browser!
WASI is designed with portability and [security](https://github.com/bytecodealliance/wasmtime/blob/main/docs/security.md) in mind, making it a viableoption for running WASM on the backend.  
Other projects worth mentioning:  
    - [Wasmer](https://wasmer.io/)  
    - [WasmEdge](https://wasmedge.org/)  
    - [WAMR](https://bytecodealliance.github.io/wamr.dev/) (WebAssembly Micro Runtime)  

## How does the architecture look like, the pipeline? How does it look like technically?
WebAssembly's (WASM) architecture is a low-level, stack-based virtual machine using a binary instruction format. Its technical pipeline involves compilation from source languages like C, C++, Rust, into WASM bytecode, followed by optimization stages for efficiency and size reduction. Browsers load and execute WASM modules within their runtime environments, translating them into machine code for near-native performance. WASM seamlessly interoperates with JavaScript, allowing function calls between both languages. The pipeline encompasses compilation, optimization, loading, and execution stages. Similar to JavaScript, reloading an HTML page with WASM resets specific program states, though data persitance can be made possible through browser storage mechanisms, like local storage. 

## What happens when an HTML page is reloaded?
It is similar to JavaScript. The program specific state (variables) is lost, it can however be saved to local storage in the browser or by using cookies.  

## How can one get started?
Find your usecase.  
Decide what language you'd like to use, or more specifically what framework you'd like to use.  
Check the documentation for further information!

## What tools are necessary? Compilers? Transpilers? Interpreters?
Again, depends on the language and framework used. Framerowks like Blazor (.NET) can easily be built and ran, and all you need is dotnet installed (which you need for any c# project anyway).  
When it comes to languages like C, C++ or Rust, where you can execute your code without a special framework, all you need to do is setup your compiler with the correct compilation target. Check compiler documentation for that.


## Use-cases
WASM can be used for a variaty of applications.  
Notibly, some algorithms leverage the near-native performance of WASM, thus making it a good choice for computationally heavy applications. (Image and video processing, games, encryption, etc).  
Additionally, WASM allows developers to use other languages than JavaScript to build web applications. This opens up the web to developers who are not familiar with JavaScript, or those who value type-safety and productivity of other languages.

## Examples
We have prepared a few examples to showcase the capabilities of WASM. You can explore the examples [here](https://wasm-examples-ntnu.pages.dev/).  
For more details about them, check the README in each example folder.  
- [Hello World in C](/simple_example_c)
- [Hello World in Zig](/simple_example_zig)
- [Running Python in the browser](/python_examples)
- [TicTacToe web app in C# (Blazor framework)](/TicTacToeBlazor)
- [TicTacToe web app in Rust (Yew framework)](/TicTacToeYew)
