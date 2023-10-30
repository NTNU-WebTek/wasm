# Tic-Tac-Toe in Blazor WASM
This is a simple Tic-Tac-Toe game implemented in [Blazor WebAssembly](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-7.0&WT.mc_id=dotnet-35129-website#blazor-webassembly).  

## Demo
A demo of the application can be found at [tictactoe-blazorwasm.pages.dev](https://tictactoe-blazorwasm.pages.dev/).  
If you'd like to experiment with the application locally or building it yourself, see sections [Running application locally](#Running-application-locally) and [Building for production](#Building-for-production).

## About Blazor
[Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) is a framework for building interactive client-side web UI components with .NET.  Blazor offers various hosting models,  Blazor Server, Blazor WebAssembly and Blazor Hybrid. You can read more about these [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-7.0&source=recommendations).  
This example uses [**Blazor WebAssembly**](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-7.0&WT.mc_id=dotnet-35129-website#blazor-webassembly), and we are going to focus on that. Blazor WebAssembly is a single-page app (SPA) framework, meaning the application is built into static files which can be served with any webserver.  

Blazor apps are built using *components*, similarly to popular JavaScript web frameworks.  
Components are C# classes, and are usually called *Razor/Blazor components* ( `.razor` files). Razor is a special syntax, combining C# code and HTML markup. It's almost like HTML with *superpowers*!  You can read more about Razor [here](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-7.0).

## Implementation
In this section we will take a closer look at this Tic-Tac-Toe implementation.  

As an example, let's take a look at [TicTacToe.razor](Pages/TicTacToe.razor) located in the Pages directory. This component is the page that is responsible for displaying the details about the game and the board to the user. 
The component is a simple C# class with one field, a constructor and one method. These are defined in the `@code` block.
```razor
@code {
    private TicTacToeGame game;
    
    public TicTacToe()
    {
        game = new TicTacToeGame();
    }
    
    private void HandleCellClick(int index)
    {
        game.PlayCell(index);
    }
}
```
`TicTacToeGame` class is defined in [TicTacToeGame.cs](Helpers/TicTacToeGame/TicTacToeGame.cs) located in `Helpers/TicTacToeGame/` directory. Notice that this is a regular C# file with a class definition.

Above the code block, we have familiar looking HTML markup, with some extra syntax provided by Razor. The `@` symbol is used to transition from HTML to C#. Razor supports constructs such as loops, switch cases, if statements and more.  
A switch case is used to display different  message to the user, depending on the status of the game.
```razor
<h3>Game status:</h3>
@switch (game.State)
{
    case GameState.NotFinished:
        <p>Next turn is: <b>@game.NextMove()</b>!</p>
        break;
    case GameState.Tie:
        <p>Tie!</p>
        break;
    case GameState.WinnerX:
        <p>X wins! X always wins...</p>
        break;
    case GameState.WinnerO:
        <p>O wins!</p>
        break;
}
```
The switch statement `@switch (game.State) {...}`  evaluates the expression `game.State`, which is a call to a getter for the `State` property of the `TicTacToeGame` class.  

**Note**: `NextMove()` method in the `TicTacToeGame` class returns the `CellState` corresponding to the next player's move (`X` or `O`).

If you'd like to know more about how Blazor applications can be implemented, you can inspect other files in this project as well as refer to the documentation.

## How does it work?
Wait, how exactly is C# code executed in the browser?  

### C# compilation
First, let's establish what happens when we compile our code.  
C# is normally compiled into **Common Intermediate Language** (CIL) and then **Common Language Runtime** (CLR) or **.NET runtime** is required to run the bytecode, CLR is provided by the .NET framework. This is similar to the Java virtual machine which you may be familiar with.  

### Running C# in the browser

When we compile the application, C# code is compiled into .NET assemblies.  
Blazor includes .NET runtime compiled into WASM along with your application. This way the runtime runs directly in the browser, and your code assemblies are ran on top of that.  

Blazor hides a lot of this complexity and provides a solid tool for building web applications with .NET.

## Running application locally
You will need [.NET](https://dotnet.microsoft.com/en-us/) installed on your machine.  
Clone this repository and navigate to this directory.  
Run `dotnet watch` to start the application in development mode. The application will be rebuilt when code changes are detected.  
Your browser should open automatically.  

## Building for production
Run `dotnet publish -c Release` to build the application for production.  
Static files with the application will be placed in `bin\Release\[dotnet version]\publish\wwwroot`. You can then use a webserver to host it!
