using _01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeUI
{
    public class ProgramUI
    {
        private readonly MenuRepo _menuRepo = new MenuRepo();

        public void Run()
        {
            SeedMenuList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Cafe Menu Controller! \n" +
                    "\n" +
                    "******************************************* \n" +
                    "\n" +
                    "Enter the number of the option you'd like to select: \n" +
                    "1. See all current menu items \n" +
                    "2. Add a new menu item \n" +
                    "3. Delete an existing menu item \n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            //Show all menu items
                            ShowMenu();
                            break;
                        }

                    case "2":
                        {
                            //Add new menu item
                            AddNewItem();
                            break;
                        }

                    case "3":
                        {
                            //Delete a menu item
                            DeleteItem();
                            break;
                        }

                    case "4":
                        {
                            //Exit
                            continueToRun = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        //Helper method: display all items

        private void DisplayMenu(Menu menuItem)
        {
            Console.WriteLine($"Meal Number {menuItem.MealNumber} \n" +
                $"{menuItem.MealName} \n" +
                $"{menuItem.MealDescription} \n" +
                $"Ingredients: {menuItem.MealIngredients} \n" +
                $"${menuItem.MealPrice} \n");
        }

        //Show all menu items
        private void ShowMenu()
        {
            Console.Clear();
            List<Menu> listOfItems = _menuRepo.GetMenu();
            foreach (Menu menuItem in listOfItems)
            {
                DisplayMenu(menuItem);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        //Add a new menu item
        private void AddNewItem()
        {
            Console.Clear();
            Menu menuItem = new Menu();
            //public int MealNumber { get; set; }
            //public string MealName { get; set; }
            //public string MealDescription { get; set; }
            //public string MealIngredients { get; set; }
            //public decimal MealPrice { get; set; }
            Console.Write("What is the new Meal Number?: ");
            string mealNumber = Console.ReadLine();
            menuItem.MealNumber = int.Parse(mealNumber);

            Console.Write("What is the new Meal Name?: ");
            menuItem.MealName = Console.ReadLine();

            Console.Write("What is the new Meal Description?: ");
            menuItem.MealDescription = Console.ReadLine();

            Console.Write("What are the new Meal Ingredients?: ");
            menuItem.MealIngredients = Console.ReadLine();

            Console.Write("What is the new Meal Price? (Enter as: X.XX, e.g.: 5.99): ");
            string mealPrice = Console.ReadLine();
            menuItem.MealPrice = double.Parse(mealPrice);

            bool added = _menuRepo.AddItemToMenu(menuItem);
            if (added)
            {
                List<Menu> listOfItems = _menuRepo.GetMenu();
                foreach (Menu item in listOfItems)
                {
                    DisplayMenu(item);
                }
                Console.WriteLine("Your meal has been added. \n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("There was an error. Please try again.");
                Console.ReadKey();
            }
        }

        //Delete item
        private void DeleteItem()
        {
            Console.Clear();
            List<Menu> listOfItems = _menuRepo.GetMenu();
            foreach (Menu menuItem in listOfItems)
            {
                DisplayMenu(menuItem);
            }
            Console.Write("Which Meal Number would you like to remove?: ");
            int userInput = int.Parse(Console.ReadLine());
            bool wasRemoved = _menuRepo.DeleteMenuItem(userInput);
            if (wasRemoved == true)
            {
               
                Console.WriteLine($"Meal Number {userInput} has been removed.");
            }
            else
            {
                Console.WriteLine("No Meal found with that number. Meal not removed.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }



        private void SeedMenuList()
        {
            Menu californiaWrap = new Menu(1, "California Wrap", "Whole wheat wrap with avocado and fake bacon", "Whole wheat wrap, avocado, fake bacon, lettuce, diced tomato, spicy veganaise dressing", 5.99);
            _menuRepo.AddItemToMenu(californiaWrap);
            Menu burger = new Menu(2, "Deluxe Burger", "Brioche bun with Impossible Burger and all the fixings", "Brioche bun, Impossible Burger patty, lettuce, sliced tomato, red onions, pickles, vegan cheddar slices, vegan Thousand Island dressing", 6.99);
            _menuRepo.AddItemToMenu(burger);
            Menu chiliFries = new Menu(3, "Chili Cheese Fries", "Thick steak fries smothered with spicy vegan chili, vegan cheddar, and fake bacon bits", "Steak fries, spicy vegan chili, shredded vegan cheddar, fake bacon bits", 4.99);
            _menuRepo.AddItemToMenu(chiliFries);
            Menu pbnb = new Menu(4, "Fried Peanut Butter & Banana Sandwich", "Buttery Texas Toast with chunky peanut butter and banana slices", "Texas toast buttered with Earth Balance vegan spread, chunky peanut butter, sliced banana", 2.99);
            _menuRepo.AddItemToMenu(pbnb);
        }
    }
}
