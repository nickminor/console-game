using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    public string GetDetails()
    {
      return _game.CurrentRoom.GetTemplate() + System.Environment.NewLine + _game.CurrentPlayer.GetTemplate();
    }
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();

    }
    public void Go(string direction)
    {
      Messages.Clear();
      //change destination
      string from = _game.CurrentRoom.Name;
      _game.CurrentRoom = _game.CurrentRoom.Go(direction);
      string to = _game.CurrentRoom.Name;
      //if failed to go anywhere stops code
      if (from == to)
      {
        Messages.Add("Invalid Destination");
        return;
      }
    }
    public void Help()
    {
      Messages.Add("'Go' plus direction where doors are available will let you travel to different rooms\n 'Quit' will stop the game\n 'Look' will reprint the description of the room you are in\n 'Reset' starts the game over\n 'Take' plus item in room will add item to your inventory\n 'Use' plus an item in inventory will let you use it");
    }

    public void Inventory()
    {
      //FIXME Iterate through the players inventory and add the item name to the messages
      _game.CurrentPlayer.Inventory.ForEach(item =>
      {
        Messages.Add($"{item.Name}");
      });
    }

    public void Look()
    {

      Messages.Add("Description: " + _game.CurrentRoom.Description);
    }

    public void Quit()
    {
      Environment.Exit(0);
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      _game.CurrentPlayer.Inventory.Clear();
      System.Console.WriteLine("What was your name?");
      Setup(Console.ReadLine());
    }

    public void Setup(string playerName)
    {
      _game.Setup();
      Messages.Add($"Hey {playerName},");
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      Messages.Clear();
      if (_game.CurrentRoom.Items.Count == 0)
      {
        Messages.Add("Nothing in here to take");
        return;
      }
      _game.CurrentPlayer.Inventory.AddRange(_game.CurrentRoom.Items);
      _game.CurrentRoom.Items.Clear();
      //FIXME Look at the _game.CurrentRoom.Items 
      // Find the item by the itemName
      // if the item is found add it to the _game.CurrentPlayer.Inventory
      // remove the item from the room
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      //FIXME Make sure you find the item in the _game.currentPlayer.Inventory
      // use that item

      var room = _game.CurrentRoom.Name.ToString();

      if (room == "Room2")
      {
        Messages.Clear();
        Messages.Add("it's unlocked!");
        _game.UnlockedRoom(_game.CurrentRoom, "north", "Room4");
        _game.UnlockedRoom(_game.CurrentRoom, "south", "Room3");


      }
      Messages.Add("");
    }
  }
}