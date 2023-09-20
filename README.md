# wasm-specialization-course

### What problem or challenge led to Web Assembly?
- Ability to run non-javascript code in the browser.

### What is Web Assembly? Are there different definitions and understandings, or are people united in what it entails
- WASM describes a standard, it is essentially a binary format which is a compilation target for languages such as C, C++, Rust.

### Who owns or maintains it?
- It is maintained by [W3C](https://www.w3.org/community/webassembly/)  group, meaning there are maintainers from all major browsers implementing features in their browsers and developing the standard.

### Is it a standard or an implementation? Who maintains the standard? Who implements it?
- W3C sub-group maintains the standard, 4 (3) major browsers implement WASM, meaning WASM can run in them.

### Which browsers support it?
- All major, firefox, safari and chromium based

###A hello-world example in WebAssembly

### What can one do with WebAssembly?
- Mostly everything you can do with javascript. Algorithms ran with near-native performance.

### Is there something one can’t do?
- Compiling garbage collected languages seem to be a problem, MORE RESEARCH HERE...

### Which languages are supported?
- Easily? C, C++, rust
- Other non-garbage collected languages might work perfectly fine
- There are frameworks in languages that are garbage collected (go, c#...) that can compile(?) to wasm, LOOK INTO IT.
### Is WebAssembly running in the browser only, or can it run on backend?
WASM can be run on the backend the same way as javascript can be run on the backend. There are frameworks that allow you to do that, such as [wasmer](https://wasmer.io/).

### How does the architecture look like, the pipeline? How does it look like technically?
Architeture as in instruction set etc?  
What is meant by pipeline? compilation pipeline??  

### What happens when an HTML page is reloaded?
Program specific state is lost (variables in code), it can however be saved to local storage in the browser or cookies. Just like javascript!

### Can WebAssembly access cookies?
IF a cookie can be accessed by JS, it can be accessed from WASM (using JS interfaces (FACT CHECK THAT))

### Can one use JS libraries and call JS functions from WebAssembly? How about the other way around?
Yes, and YES. Do some examples maybe?
### How can one get started?
Find your usecase.  
Decide what language you'd like to use, or more specifically what framework you'd like to use.  
Check the documentation for further information!
#### What tools are necessary? Compilers? Transpilers? Interpreters?
Again, depends on the language and framework used. Framerowks like Blazor (.NET) can easily be built and ran, and all you need is dotnet installed (which you need for any c# project anyway)  
When it comes to languages like C, C++ or Rust, where you can execute your code without a special framework, all you need to do is setup your compiler with the correct compilation target. Check ompiler documentation for that.

### Which operating systems are supported?
Any operating system that can run a modern browser can run WASM.

### Garbage collection
Add a section about it, 
### What would be a good use-case / example for Web Assembly?
Here id look at some benchmarks. Im assuming some algorithms will run quicker in WASM than in JS, thus it may be advantagious to use WASM.  
AS far as were aware atm, webapps written in frameworks compiled to WASM generally run slower than JS framweorks, probably because of the translation layer between languages to wasm (no native garbage colleciton in wasm, must be implemented in the language if thats what the language relies on). But frameworks are getting faster and more optimized. As applications grow, languages like C# may be a good choice, levereging type-safety and large eco-system.  
Also allows to write webapps with no need to learn javascript/typescript.  

### Describe that example.



### Implement that example in different languages.
lets do a simple webapp with tictactoe in leptos and blazor