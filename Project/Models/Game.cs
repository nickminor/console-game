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
      Room Room1 = new Room("Room1", "Room1 Desc");
      Room Room2 = new Room("Room2", "Room2 Desc");
      Room Room3 = new Room("Room3", "Room3 Desc");
      Room Room4 = new Room("Room4", "Room4 Desc");
      Room Room5 = new Room("Room5", "Room5 Desc");
      Room Room6 = new Room("Room6", "You died");



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