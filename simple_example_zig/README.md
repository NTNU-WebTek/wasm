# Wasm example with zig

Get zig [here](https://ziglang.org/learn/getting-started/#package-managers) to compile the webassembly!

### Building the webassembly
```bash
zig build-lib -O ReleaseSmall -target wasm32-freestanding .\src\main.zig -dynamic -rdynamic
```

If you have python installed you could simply run
```bash
python -m http.server
``` 
to serve the project