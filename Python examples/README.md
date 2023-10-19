To be able to use Python as a front-end framework you can use Pyscript : https://pyscript.net/
Be careful because it is still in phases of development so everything is not likely to be possible.
Pyscript permits to build apps using Python and JavaScript programming languages. It can run Python code and projects in a web browser and use Python functions from JavaScript, and vice versa.

PyScript web framework is compiled and made through CPython Interpreter from the following:
-	Emscripten : https://emscripten.org/ . It is the same as used for C language
-	WebAssembly : https://webassembly.org/
-	
PyScript web framework is developed by the following technology stacks:
-	TypeScript with JavaScript, which is used via the Svelte Framework
-	Tailwind CSS framework which is used for styling
-	Roolup.js framework which is used for program bundling.
-	
Web components, Python scripts, and custom elements are defined in PyScript, such as :
-	`<py-button>` : Used to make a button.
-	`<py-env>` : To use external Python libraries.
-	`<py-script>` : To insert python code into web.
It is possible to directly place the code into the HTML to display the content on the browser.

It requires very simple step and to make it work you have to use a script and PyScript CSS to trigger PyScript : 
- `<link rel="stylesheet" href="https://pyscript.net/latest/pyscript.css"/>`
- `<script defer src="https://pyscript.net/latest/pyscript.js"></script>`
The presence of pyscript.css enables the HTML tags to print the correct information saved in the HTML document and only opened in the web browser
