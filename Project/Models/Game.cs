using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      Room Room1 = new Room("Room1", "You awake in an unknown dark room, time to escape.");
      Room Room2 = new Room("Room2", "As you enter this room you see two exits. One to the north, and one to the south. Choose wisely");
      Room Room3 = new Room("Room3", "As you enter this room you detect a faint smell of something cooking, you can either go check it out or return north to the previous room");
      Room Room4 = new Room("Room4", "As you enter this room, there's a faint smell of something cooking, you can either go check it out or return south to the previous room");
      Room Room5 = new Room("Room5", "The room was filled with freshly baked cookies. You win");
      Room Room6 = new Room("Room6", "The room was on fire, you died");



      Room1.Exits.Add("east", Room2);

      Room2.Exits.Add("west", Room1);
      Room2.Exits.Add("north", Room4);
      Room2.Exits.Add("south", Room3);

      Room3.Exits.Add("north", Room2);
      Room3.Exits.Add("west", Room6);

      Room4.Exits.Add("south", Room2);
      Room4.Exits.Add("west", Room5);

      Item key = new Item("Key", "You can unlock stuff with it");
      Item lightswitch = new Item("Lightswitch", "It helps you see");

      CurrentRoom = Room1;
    }

    public Game()
    {
      CurrentPlayer = new Player();
      CurrentRoom = CurrentRoom;
      Setup();
    }
  }
}