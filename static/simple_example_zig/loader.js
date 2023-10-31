const importObject = {
    env: {
        print: function (arg) {
            console.log(arg);
        },
        
    },
  };
 let add = WebAssembly.instantiateStreaming(fetch("main.wasm"), importObject).then((results) => {
    var add = results.instance.exports.add;
    return add
  });
  

  function btnEvent(element) {
    element.addEventListener("click", function () {
      add.then((add) => {
        let a = parseInt(document.getElementById("a").value);
        let b = parseInt(document.getElementById("b").value);
        let result = add(a, b);
        document.getElementById("output").innerHTML = result;
      });
    });
  }

    btnEvent(document.getElementById("btn"));