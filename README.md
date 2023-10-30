# wasm-specialization-course

## What problem or challenge led to Web Assembly?
- WASM solve two major issues : Portability & Interoperability. Portability because it offers developers to use other languages than JavaScript in the browser. Interoperability because it permits to coordinate connections and communication between differents system, apps, ....

## What is Web Assembly? Are there different definitions and understandings, or are people united in what it entails
- Web Assembly abreviate as WASM is a standard. It is essentially binary instructions which exploitable for languages such as C, C++, Rust, python and more.

## Who owns or maintains it?
- WASM is maintained by World Wide Web Consortium : [W3C](https://www.w3.org/community/webassembly/). That means that there are maintainers from all major browsers implementing new features in their browsers and developing standards.

## Is it a standard or an implementation? Who maintains the standard? Who implements it?
- The standard is maintains by a W3C sub-group. 4 (3) major browsers implement WASM, meaning WASM can run in them.

## Which browsers support it?
- All majors browser support WASM. Firefox, safari and chromium based. https://caniuse.com/wasm

## What can one do with WebAssembly?
- WASM can be used to do anything as using JavaScript. WASM performances are estimated at near-native performance.

## Is there something one can’t do?
- ?? WASM do not include the compiling garbage collected option of languages which seems to be a problem, MORE RESEARCH HERE... ??

## Which languages are supported?
- Here is a list of every languages supported by WASM and their status : https://github.com/appcypher/awesome-wasm-langs.
- We can note some used languages such as : C, C++, rust, python...
- ?? There are frameworks in languages that are garbage collected (go, c#...) that can compile(?) to wasm, LOOK INTO IT. ??

## Is WebAssembly running in the browser only, or can it run on backend?
- WASM can be run on the backend the same way as javascript can be run on the backend. There are frameworks that allow you to do that, such as [wasmer](https://wasmer.io/).

## How does the architecture look like, the pipeline? How does it look like technically?
- ?? Architeture as in instruction set etc?  ??
- ?? What is meant by pipeline? compilation pipeline??  ??

## What happens when an HTML page is reloaded?
- It is similar to JavaScript. The program specific state (variables) is lost, it can however be saved to local storage in the browser or by using cookies.

## Can WebAssembly access cookies?
- ?? If a cookie can be accessed by JS, it can be accessed from WASM (using JS interfaces (FACT CHECK THAT)) ??

## Can one use JS libraries and call JS functions from WebAssembly? How about the other way around?
Yes, and YES. Do some examples maybe?
## How can one get started?
Find your usecase.  
Decide what language you'd like to use, or more specifically what framework you'd like to use.  
Check the documentation for further information!
## What tools are necessary? Compilers? Transpilers? Interpreters?
Again, depends on the language and framework used. Framerowks like Blazor (.NET) can easily be built and ran, and all you need is dotnet installed (which you need for any c# project anyway)  
When it comes to languages like C, C++ or Rust, where you can execute your code without a special framework, all you need to do is setup your compiler with the correct compilation target. Check ompiler documentation for that.

## Which operating systems are supported?
Any operating system that can run a modern browser can run WASM.

## Garbage collection
Add a section about it, 
## What would be a good use-case / example for Web Assembly?
Here id look at some benchmarks. Im assuming some algorithms will run quicker in WASM than in JS, thus it may be advantagious to use WASM.  
AS far as were aware atm, webapps written in frameworks compiled to WASM generally run slower than JS framweorks, probably because of the translation layer between languages to wasm (no native garbage colleciton in wasm, must be implemented in the language if thats what the language relies on). But frameworks are getting faster and more optimized. As applications grow, languages like C# may be a good choice, levereging type-safety and large eco-system.  
Also allows to write webapps with no need to learn javascript/typescript.  

## Describe that example.

## A hello-world example in WebAssembly

## Implement that example in different languages.
lets do a simple webapp with tictactoe in leptos and blazor
