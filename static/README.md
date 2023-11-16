# Running the static files with docker
In case you want to run the static files with docker, you can use the following commands.

## Build the image
```bash
docker build -t static:latest .
```
## Run the image
```bash
docker run -it --rm --init -p 3000:3000 static:latest
```


# Live example available here:
https://wasm-examples-ntnu.pages.dev/
