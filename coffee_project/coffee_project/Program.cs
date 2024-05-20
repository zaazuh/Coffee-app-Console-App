using System.Text;

namespace coffee_project
{
    class Program
    {
        static string name, milk;
        static int menu, opt, numC, numM;
        static int cupSize, milkOption;
        static double priceSmall = 13.50;
        static double priceMedium = 18.50;
        static double priceLarge = 25.50;
        static double priceMilk = 1.50;
        static double discount = 0.1;
        static int attempts = 0;
        static int add = 4;
        static int totalNumC = 0;

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("".PadLeft(Console.WindowWidth - 40) + "( ) ( ) ( ) ( )( )");
                Console.WriteLine("".PadLeft(Console.WindowWidth - 40) + ") ) ) ( ) ) ( )( ) ");
                Console.WriteLine("".PadLeft(Console.WindowWidth - 40) + "...................");
                Console.WriteLine("".PadLeft(Console.WindowWidth - 40) + "||                  || ==");
                Console.WriteLine("".PadLeft(Console.WindowWidth - 40) + "||   Lady Bug       ||   ||");
                Console.WriteLine("".PadLeft(Console.WindowWidth - 40) + "||     Brew         ||===|| ");
                Console.WriteLine("".PadLeft(Console.WindowWidth - 40) + "\\                 //");
                Console.WriteLine("".PadLeft(Console.WindowWidth - 40) + " =================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("".PadLeft(Console.WindowWidth - 35) + "LADY BUG's BREW BZZzz!!!");
                Console.ResetColor();
                Console.WriteLine();

                ShowIntroduction();

                // After exiting the program, immediately display the message to start the order
                Console.WriteLine("\nPress any key to start your order...");

                // Wait for any key to be pressed
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static void ShowIntroduction()
        {
            Console.WriteLine("************Good day, Welcome to LadyBug Cafe!!!!!************");
            Console.WriteLine();
            Console.Write("Please enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine();

            StartOrder();
        }

        static void StartOrder()
        {
            StringBuilder Receipt = new StringBuilder();
            bool AddOrder = true;

            double totalPrice = 0;

            while (AddOrder)
            {

                // Menu selection
                add = 4;
                attempts = 0;

                while (true)
                {
                    try
                    {
                        add--;
                        attempts++;

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"{name}, what would you like to order?\n\nDISCLAIMER: If you buy more than 20 cups of coffee you get 10% off your total order.\n\nYou have {add} attempts left.\n\nMENU:");

                        Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════||");
                        Console.WriteLine("Choice  ||         Description         || Choice ||  Description                 ||");
                        Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════||");
                        Console.WriteLine("    1   ||    Brew Master Espresso     || 2      ||Liberty Blend Americano Craft ||");
                        Console.WriteLine("--------||-----------------------------||--------||------------------------------||");
                        Console.WriteLine("    3   ||    VelvetWave Latte         || 4      ||Foamcraft Cappuccino          ||");
                        Console.WriteLine("        ||       Master                ||        || Wizard                       ||");
                        Console.WriteLine("--------||-----------------------------||--------||------------------------------||");
                        Console.WriteLine("    5   ||    Blend Mocha Maestro      || 0      || EXIT                         ||");
                        Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════||");
                        Console.WriteLine();

                        menu = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        if (menu < 0 || menu > 5)
                        {
                            if (attempts < 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid choice. Please select a valid option (0-5).\n");
                                Console.ResetColor();
                                continue;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("That was your last attempt, the program will now restart.");
                                Console.ResetColor();
                                Console.WriteLine();
                                return;
                            }
                        }

                        if (menu == 0)
                        {
                            Console.WriteLine("Exiting the program...");
                            Console.Clear();
                            return;
                        }
                    }
                    catch (FormatException) // 
                    {
                        if (attempts != 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine();
                            Console.WriteLine("Invalid input. Please enter a number between 0 to 5.\n");
                            Console.ResetColor();
                        }

                        if (attempts == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("That was your last attempt, the program will now restart.");
                            Console.ResetColor();
                            Console.WriteLine();
                            //Console.Clear();
                            return;
                        }
                        continue;
                    }
                    break;
                }

                // Cup size selection
                add = 4;
                attempts = 0;
                while (true)
                {
                    try
                    {
                        add--;
                        attempts++;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"{name}, what size cup would you like? \n\nYou have {add} attempts left.");
                        Console.WriteLine();
                        Console.WriteLine("CUP SIZE MENU");
                        Console.WriteLine("||=======================================================||");
                        Console.WriteLine("||Choice||      Description      ||         Price        ||");
                        Console.WriteLine("||=======================================================||");
                        Console.WriteLine("||  1   ||      Small            ||        R13.50        ||");
                        Console.WriteLine("||  2   ||      Medium           ||        R18.50        ||");
                        Console.WriteLine("||  3   ||      Large            ||        R25.50        ||");
                        Console.WriteLine("||=======================================================||");
                        Console.WriteLine();
                        Console.ResetColor();

                        cupSize = int.Parse(Console.ReadLine()); // Parse cupSize as int
                        Console.WriteLine();
                       
                        if (cupSize < 1 || cupSize > 3)
                        {
                            if (attempts < 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInvalid choice. Please select a valid cup size (1/2/3).\n");
                                Console.ResetColor();
                                continue;
                            }
                            else // PROBLEM - REMOVE AS IT DOES NOT APPEAR IN FIRST PROMPT (try small - medium - 9)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nThat was your last attempt, the program will now restart.");
                                Console.ResetColor();
                                return;
                            }
                        }
                        break;
                    }
                    catch (FormatException)
                    {
                        if (attempts != 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid input. Please enter a number between 1 to 3.\n");
                            Console.ResetColor();
                        }
                        if (attempts == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nThat was your last attempt, the program will now restart.");
                            Console.ResetColor();
                            Console.WriteLine();
                            return;
                        }
                        continue;
                    }
                }

                // Quantity of cups
                add = 4;
                attempts = 0;
                while (true)
                {
                    try
                    {
                        add--;
                        attempts++;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"{name}, how many cups of {getCupSizeName(cupSize)} {GetCoffeeName(menu)} do you want?\n\nYou have {add} attempts left.");
                        Console.ResetColor();

                        numC = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine();
                        totalNumC += numC;

                        if (numC <= 0)
                        {
                            if (attempts < 3) // change to 2
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInvalid input. Please enter a valid quantity.");
                                Console.ResetColor();
                                continue;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nThat was your last attempt, the program will now restart.");
                                Console.ResetColor();
                                return;
                            }
                        }
                        break;
                    }
                    catch (FormatException)
                    {
                        if (attempts != 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid input. Please enter a valid number.");
                            Console.ResetColor();
                        }
                        if (attempts == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nThat was your last attempt, the program will now restart.");
                            Console.ResetColor();
                            Console.WriteLine();
                            return;
                        }
                        continue;
                    }
                }

                // Ask if the user wants milk
                add = 4;
                attempts = 0;
                while (true)
                {
                    try
                    {
                        add--;
                        attempts++;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Would you like extra milk with your {getCupSizeName(cupSize)} {GetCoffeeName(menu)} at an additional cost of R1.50?\nYou have {add} attempts left\n1. Yes\n2. No");
                        Console.ResetColor();

                        milkOption = int.Parse(Console.ReadLine());

                        Console.WriteLine();

                        if (milkOption != 1 && milkOption != 2)
                        {
                            if (attempts < 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInvalid choice. Please select a valid option (1/2).");
                                Console.ResetColor();
                                continue;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nThat was your last attempt, the program will now restart.");
                                Console.ResetColor();
                                return;
                            }
                        }
                        break;
                    }
                    catch (FormatException)
                    {
                        if (attempts != 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid input. Please enter either 1 or 2.");
                            Console.ResetColor();
                        }
                        if (attempts == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nThat was your last attempt, the program will now restart.");
                            Console.ResetColor();
                            Console.WriteLine();
                            return;
                        }
                        continue;
                    }
                }

                try
                {
                    if (milkOption == 1)
                    {
                        // Quantity of cups with additional milk
                        add = 4;
                        attempts = 0;
                        while (true)
                        {
                            try
                            {
                                add--;
                                attempts++;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"How many cups of {numC} {getCupSizeName(cupSize)} {GetCoffeeName(menu)} would you like to add milk to?\nYou have {add} attempts left.");
                                Console.ResetColor();
                                numM = int.Parse(Console.ReadLine());
                                Console.WriteLine();
                                if (numM > numC)
                                {
                                    if (attempts < 3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input. The number of cups with milk cannot exceed the total number of cups ordered.");
                                        Console.ResetColor();
                                        continue;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\nThat was your last attempt, the program will now restart.");
                                        Console.ResetColor();
                                        return;
                                    }
                                }
                                break;
                            }
                            catch (FormatException)
                            {
                                if (attempts != 3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid input.");
                                    Console.ResetColor();
                                }
                                if (attempts == 3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nThat was your last attempt, the program will now restart.");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    return;
                                }
                                continue;
                            }
                        }
                    }
                    else
                    {
                        numM = 0;
                    }
                    if (numC >= 16 && numC <= 20)
                    {
                        Console.WriteLine($"If you buy more than 20 cups of coffee you get 10% off your total order.\nDo you want to add to your order or proceed to checkout?");
                    }
                    else if (numC > 21)
                    {
                        Console.WriteLine($"Congratulations! You qualify for a 10% discount off your total order.");
                    }
                }
                catch (FormatException)
                {
                    if (attempts != 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter the right number.");
                        Console.ResetColor();
                    }
                    if (attempts == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That was your last attempt, the program will now restart.");
                        Console.ResetColor();
                        Console.WriteLine();
                        return;
                    }
                    continue;
                }

                // Calculate current price
                double currentPrice = CalculateCurrentPrice(menu, cupSize, numC, numM);
                totalPrice += currentPrice;
                Receipt.AppendLine($"{numC}X {getCupSizeName(cupSize)} {GetCoffeeName(menu)}, {numM} cup(s) with extra milk Current Price: R{currentPrice}.");
                Console.WriteLine($"Current Price for {numC} cup(s) of {GetCoffeeName(menu)} and {numM} cup(s) with extra milk in cup size {getCupSizeName(cupSize)}: R{currentPrice}"); 
                Console.WriteLine();

                // Check if the user wants to proceed with the order, add more, or restart
                add = 4;
                attempts = 0;
                try
                {
                    add--;
                    attempts++;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{name} would you like to:");
                    Console.WriteLine();
                    Console.WriteLine("1. Proceed to checkout");
                    Console.WriteLine("2. Add more to your order");
                    Console.WriteLine("3. Restart your order");
                    Console.ResetColor();
                    opt = int.Parse(Console.ReadLine());
                    Console.Clear();
                    if (opt == 2)
                    {
                        // Add more items to the order
                        Console.WriteLine("Adding more to your order...");
                        Console.WriteLine();
                        continue;
                    }
                    else if (opt == 1)
                    {
                        Console.WriteLine(Receipt.ToString());
                        if (totalNumC >= 21)
                        {
                            Console.WriteLine($"Your total price is: R{totalPrice}");
                            Console.WriteLine($"10% discount applied. Updated Price: R{CalculateTotalPrice(totalPrice, discount)}");
                        }
                        else
                        {
                            Console.WriteLine($"Your total price is: R{totalPrice}\n");
                        }
                        Console.WriteLine();
                        ShowThankYouMessage();
                        return;
                    }
                    else if (opt != 1 && opt != 2 && opt != 3)
                    {
                        if (attempts <= 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Invalid input. Please enter the correct choice (1/2/3).\nYou have {add} attempts left.");
                            Console.ResetColor();
                            continue;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("This is your last chance to select the correct option before the program restarts.");
                            Console.ResetColor();
                            Console.WriteLine();
                            return;
                        }
                    }
                    else if (opt == 3)
                    {
                        // Restart the order
                        Console.WriteLine("Restarting your order...");
                        Console.WriteLine();
                        Console.Clear();
                        ShowIntroduction();
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input. Please enter a valid number.");
                    }
                }
                catch (FormatException)
                {
                    if (attempts != 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Invalid input. Please enter the correct choice (1/2/3).\nYou have {add} attempts left.");
                        Console.ResetColor();
                    }
                    if (attempts == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That was your last attempt, the program will now restart.");
                        Console.ResetColor();
                        Console.WriteLine();
                        return;
                    }
                    continue;
                }
            }
            ShowThankYouMessage();
        }

        public static void ShowThankYouMessage()
        {
            Console.WriteLine("THANK YOU FOR PURCHASING AT LADYBUG MORCHA CAFFE");
            Console.WriteLine("ENJOY THE BUG OF OUR COFFEE BZZzzz");
            Console.ReadKey();
        }

        static double CalculateCurrentPrice(int menu, int cupSize, int numC, int numM)
        {
            double cupSizePrice = 0;
            switch (cupSize)
            {
                case 1: // Small
                    cupSizePrice = priceSmall;
                    break;
                case 2: // Medium
                    cupSizePrice = priceMedium;
                    break;
                case 3: // Large
                    cupSizePrice = priceLarge;
                    break;
            }
            double totalCoffeePrice = cupSizePrice * numC;
            double totalMilkPrice = priceMilk * numM;
            return totalCoffeePrice + totalMilkPrice;
        }

        static double CalculateTotalPrice(double currentPrice, double discount)
        {
            return currentPrice - (currentPrice * discount);
        }

        static string getCupSizeName(int cupSize)
        {
            switch (cupSize)
            {
                case 1:
                    return "Small";
                case 2:
                    return "Medium";
                case 3:
                    return "Large";
                default:
                    throw new ArgumentOutOfRangeException(nameof(cupSize), "Invalid cup size.");
            }
        }

        static string GetCoffeeName(int coffeeType)
        {
            switch (coffeeType)
            {
                case 1:
                    return "Espresso";
                case 2:
                    return "Americano";
                case 3:
                    return "Latte";
                case 4:
                    return "Cappuccino";
                case 5:
                    return "Mocha";
                default:
                    throw new ArgumentOutOfRangeException(nameof(coffeeType), "Invalid coffee type.");
            }
        }
    }
}