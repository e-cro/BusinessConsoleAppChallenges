using _03_Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeUI
{
    public class ProgramUI
    {
        private BadgeRepo _repo = new BadgeRepo();

        public void Run()
        {
            SeedBadgeDictionary();
            UIMenu();
        }

        private void UIMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to the Badge Access Portal! \n" +
                "\n" +
                "**********************************\n" +
                "\n" +
                "Enter the number for the option you'd like to do:\n" +
                "\n" +
                "1. List all badges\n" +
                "2. Add a badge\n" +
                "3. Edit a badge\n" +
                "4. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ListAllBadges();
                        break;
                    case "2":
                        AddBadge();
                        break;

                    case "3":
                        EditBadge();
                        break;

                    case "4":
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number (1-4).");
                        break;
                }

                Console.WriteLine("\nPlease press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //List all badges
        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> dictionaryOfBadges = _repo.GetDictionaryOfBadgesAndDoors();
            Console.WriteLine($"{"Badge ID",-10}{"Door Access",-20}");
            foreach (KeyValuePair<int, List<string>> badgeDoorPairing in dictionaryOfBadges)
            {
                Console.WriteLine($"{badgeDoorPairing.Key,-10}{badgeDoorPairing.Value,-20}");
            }
        }

        //Add a badge
        private void AddBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();

            //Badge ID
            Console.WriteLine("Enter the Badge ID Number:");
            newBadge.BadgeId = int.Parse(Console.ReadLine());

            //List of Doors for Badge ID
            Console.WriteLine("Enter a door to be accessed by Badge ID Number:");
            string newDoorId = Console.ReadLine();
            newBadge.ListOfDoorNames.Add(newDoorId);

            Console.WriteLine("Add another door? (y/n)");
            string userInput = Console.ReadLine();

            do
            {
                Console.WriteLine("Enter next door to be accessed by Badge ID Number:");
            }
            while (userInput == "y");

            if (userInput == "n")
            {
                Console.WriteLine("\nPlease press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            return;
        }

        //Edit a badge
        private void EditBadge()
        {
            Console.Clear();
            Badge badge = new Badge();
            Console.WriteLine("What is the Badge ID Number?");
            int badgeId = int.Parse(Console.ReadLine());
            _repo.GetBadgeDoorPairingByBadgeId(badgeId);
            Console.WriteLine($"{ badgeId} has access to doors: {badge.ListOfDoorNames}.\n" +
                $"\n" +
                $"Enter the number of the option you'd like to select:\n" +
                $"1. Remove a door\n" +
                $"2. Add a door\n");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                //Remove a door from badge
                case "1":

                    Console.WriteLine("Enter the door to remove:");
                    string doorIdToRemove = Console.ReadLine();
                    bool removed = _repo.RemoveValueFromKeyValuePairByKey(badgeId, doorIdToRemove);
                    if (removed)
                    {
                        Console.WriteLine($"Door {doorIdToRemove} removed.\n" +
                            $"{badgeId} has access to door(s): {badge.ListOfDoorNames}.");
                    }
                    else
                    { Console.WriteLine("Something went wrong. Door not removed."); }
                    break;

                //Add a door to badge
                case "2":
                    Console.WriteLine("Enter the door to add:");
                    string doorIdToAdd = Console.ReadLine();
                    bool added = _repo.AddValueToKeyValuePairByKey(badgeId, doorIdToAdd);
                    if (added)
                    {
                        Console.WriteLine($"Door {doorIdToAdd} added.\n" +
                            $"{badgeId} has access to door(s) {badge.ListOfDoorNames}.");
                    }
                    break;

                default:
                    Console.WriteLine("Please enter a valid number.");
                    break;
            }
        }

        //Seed Method
        private void SeedBadgeDictionary()
        {
            //Badge one 12345 A7
            List<string> listOne = new List<string>();
            string doorOne = "A7";
            listOne.Add(doorOne);
            int badgeIdOne = 12345;
            Badge one = new Badge(badgeIdOne, listOne);

            //Badge two 22345 A1,A4,B1,B2
            List<string> listTwo = new List<string>();
            string doorTwo = "A1";
            string doorThree = "A4";
            string doorFour = "B1";
            string doorFive = "B2";
            listTwo.Add(doorTwo);
            listTwo.Add(doorThree);
            listTwo.Add(doorFour);
            listTwo.Add(doorFive);
            int badgeIdTwo = 22345;
            Badge two = new Badge(badgeIdTwo, listTwo);

            //Badge three 32345 A4,A5
            List<string> listThree = new List<string>();
            string doorSix = "A4";
            string doorSeven = "A5";
            listThree.Add(doorSix);
            listThree.Add(doorSeven);
            int badgeIdThree = 32345;
            Badge three = new Badge(badgeIdThree, listThree);

            _repo.CreateBadge(one);
            _repo.CreateBadge(two);
            _repo.CreateBadge(three);
        }
    }
}
