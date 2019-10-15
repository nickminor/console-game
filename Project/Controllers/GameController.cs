using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      Console.WriteLine("What's your name?");
      string playerName = Console.ReadLine();
      _gameService.Setup(playerName);

      while (true)
      {
        Print();
        GetUserInput();
      }
    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Console.WriteLine("What would you like to do?\n Type 'Help' for a list of available commands");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"
      switch (command)
      {
        case "quit":
          _gameService.Quit();
          break;
        case "look":
          _gameService.Look();
          break;
        case "help":
          _gameService.Help();
          break;
        case "go":
          _gameService.Go(option);
          break;
        case "reset":
          _gameService.Reset();
          break;
        case "take":
          _gameService.TakeItem(option);
          break;
        case "use":
          _gameService.UseItem(option);
          break;

      }
    }
    //NOTE this should print your messages for the game.
    private void Print()
    {
      Console.Clear();
      Console.WriteLine(_gameService.GetDetails());
      foreach (string message in _gameService.Messages)
      {
        System.Console.WriteLine(message);

      }

    }
  }


}