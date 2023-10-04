# Tic-Tac-Toe in Blazor WASM
This is a simple Tic-Tac-Toe game implemented in [Blazor WASM](https://docs.microsoft.com/aspnet).  
The game logic is written entirely in C# and is execute within the browser using WASM.

## Demo
A demo of the application can be found at [tictactoe-wasm.pages.dev](https://tictactoe-wasm.pages.dev/).

## Running application locally
You will need [.NET](https://dotnet.microsoft.com/en-us/) installed on your machine.  
Clone this repository and navigate to this directory.  
Run `dotnet watch` to start the application in development mode. The application will be rebuilt when code changes are detected.  
Your browser should open automatically.  

## Building for production
Run `dotnet publish -c Release` to build the application for production.