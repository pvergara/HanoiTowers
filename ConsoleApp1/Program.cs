using System.Text;
using static System.ConsoleKey;

namespace ConsoleApp1;

internal static class Program
{
    private static void Main()
    {
        const int maxRadius = 5;
        var selectedTower = 1;

        ConsoleKeyInfo key = new ConsoleKeyInfo();
        do
        {
            
            if (key.Key == LeftArrow)
            {
                if (selectedTower == 1)
                    selectedTower = 3;
                else
                    selectedTower--;
            }
            if (key.Key == RightArrow)
            {
                if (selectedTower == 3)
                    selectedTower = 1;
                else
                    selectedTower++;
            }
            

            List<List<int>> values =
            [
                [0, 0, 0, 0, 5],
                [0, 0, 0, 1, 2],
                [0, 0, 0, 3, 4]
            ];
            var j = 0;
            foreach (var innerValues in values)
            {
                var i = 0;
                
                Console.SetCursorPosition(5 + (j * 18), 8);
                Console.Write("     |");
                Console.SetCursorPosition(5 + (j * 18), 9);
                Console.Write("     |");
                foreach (var diskValue in innerValues)
                {
                    Console.SetCursorPosition(5 + (j * 18), 10 + i++);
                    Console.Write(" ".Repeat(maxRadius - diskValue));
                    Console.Write("*".Repeat(diskValue));
                    Console.Write("|");
                    Console.Write("*".Repeat(diskValue));
                    Console.Write(" ".Repeat(maxRadius - diskValue));
                }

                Console.SetCursorPosition(3 + (j * 18), 15);
                Console.Write("_______|_______");
                if (j+1 == selectedTower)
                {
                    Console.SetCursorPosition(10 + (j * 18), 5);
                    Console.Write("l");    
                }
                j++;
            }
            key = Console.ReadKey();
            Console.Clear();
        } while (key.Key != DownArrow );
    }

    private static string Repeat(this string input, int count)
    {
        if (string.IsNullOrEmpty(input) || count < 1)
            return "";

        var builder = new StringBuilder(input.Length * count);

        for (var i = 0; i < count; i++) builder.Append(input);

        return builder.ToString();
    }
}