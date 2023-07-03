static class Game
{
  static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
  static int player = 1;
  static int choice;

  static int flag = 0;

  public static void Start()
  {
    do
    {
      Console.Clear();
      Console.WriteLine("Player 1 : X and Player 2 : O \n");
      if (player % 2 == 0)
      {
        Console.WriteLine("Player 2 turn");
      }
      else
      {
        Console.WriteLine("Player 1 turn");
      }
      Console.WriteLine("\n");
      GenerateBoard();
      Console.Write("\n Choose a number: ");
      choice = int.Parse(Console.ReadLine());
      if (arr[choice] != 'X' && arr[choice] != 'O')
      {
        if (player % 2 == 0)
        {
          arr[choice] = 'O';
          player++;
        }
        else
        {
          arr[choice] = 'X';
          player++;
        }
      }
      else
      {
        Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
        Console.WriteLine("\n");
        Console.WriteLine("Please wait 2 second board is loading again.....");
        Thread.Sleep(3500);
      }
      flag = CheckWin();
    } while (flag != 1 && flag != -1);

    Console.Clear();
    GenerateBoard();
    if (flag == 1)
    {
      Console.WriteLine($"Player {(player % 2) + 1} has won \n");
    }
    else
    {
      Console.WriteLine("Draw game :( \n");
    }
    Console.WriteLine("Press enter to exit");
    Console.ReadLine();
  }
  private static void GenerateBoard()
  {
    Console.WriteLine("     |     |      ");
    Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
    Console.WriteLine("_____|_____|_____ ");
    Console.WriteLine("     |     |      ");
    Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
    Console.WriteLine("_____|_____|_____ ");
    Console.WriteLine("     |     |      ");
    Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
    Console.WriteLine("     |     |      ");
  }

  private static int CheckWin()
  {
    // Winning Condition For Rows
    for (int i = 1; i <= 7; i += 3)
    {
      if (arr[i] == arr[i + 1] && arr[i + 1] == arr[i + 2])
      {
        return 1;
      }
    }
    // Winning Condition For Columns
    for (int i = 1; i <= 3; i++)
    {
      if (arr[i] == arr[i + 3] && arr[i + 3] == arr[i + 6])
      {
        return 1;
      }
    }
    // Winning Condition For Diagonals
    if (arr[1] == arr[5] && arr[5] == arr[9])
    {
      return 1;
    }
    else if (arr[3] == arr[5] && arr[5] == arr[7])
    {
      return 1;
    }
    // Checking For Draw Game
    if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
    {
      return -1;
    }
    return 0;
  }

}
