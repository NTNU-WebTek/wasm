# To use python with WASM it only requires 2 very simple steps.
# This is possible thanks to Pyscript : https://pyscript.net/, which is basically based on pyodide which means "port of CPython to web assembly/Emscripten" project.
# It uses the same tools "Emscripten" as needed for C but it can be directly implemented without downloading or transforming anything.

# The code can be executed in VS or directly into the browser : https://pyscript.com/ .

# 1 - The first step is to add the following piece of code that refers to css and js tools : 
    "<link rel="stylesheet" href="https://pyscript.net/latest/pyscript.css" />
    <script defer src="https://pyscript.net/latest/pyscript.js"></script>"

# 2 - The second is to replace the usual html "<script>" by "<py-script>".
