using _02_Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimUI
{
    public class ProgramUI
    {
        private ClaimRepo _repo = new ClaimRepo();

        public void Run()
        {
            SeedClaimsQueue();
            UIMenu();
        }

        private void UIMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Komodo Insurance Claims Agent Portal! \n" +
                    "\n" +
                                  "************************************************ \n" +
                                  "\n" +
                                  "Enter the number to select an option:\n" +
                                  "\n" +
                                  "1. See all claims in the queue\n" +
                                  "2. Take care of next claim\n" +
                                  "3. Enter a new claim\n" +
                                  "4. Exit");

                string userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        DisplayQueue();
                        break;

                    case "2":
                        TakeCareOfNextClaim();
                        break;

                    case "3":
                        CreateNewClaim();
                        break;

                    case "4":
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("\nPlease press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DisplayQueue()
        {
            Console.Clear();
            Queue<Claim> queueOfClaims = _repo.GetClaimQueue();
            Console.WriteLine($"{"Claim ID", -10}{"Type", -10}{"Description", -25}{"Amount", -10}{"Date of Incident", -25}{"Date of Claim", -25}{"Is Claim Valid", -25}");
            foreach(Claim claim in queueOfClaims)
            {
                Console.WriteLine($"{claim.ClaimId, -10}{claim.TypeOfClaim, -10}{claim.Description, -24} ${claim.ClaimAmount, -9}{claim.DateOfIncident, -25}{claim.DateOfClaim, -25}{claim.IsValid, -25}");
            }
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Claim nextClaim = _repo.GetClaimFromQueue();

            Console.WriteLine($"The next claim in the queue is:\n" +
                $"Claim ID: {nextClaim.ClaimId}\n" +
                $"Type: {nextClaim.TypeOfClaim}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: ${nextClaim.ClaimAmount}\n" +
                $"Date of Incident: {nextClaim.DateOfIncident}\n" +
                $"Date of Claim: {nextClaim.DateOfClaim}\n" +
                $"Is Valid: {nextClaim.IsValid}\n");

            Console.WriteLine("Do you want to deal with this claim now? (y/n):");
            string userInput = Console.ReadLine();

            if(userInput=="y")
            {
                _repo.RemoveClaimFromQueue();
                Console.WriteLine("This claim has been removed from the queue.");
            }
            else if(userInput=="n")
            {
                Console.WriteLine("This claim has NOT been removed from the queue.");
            }
            else
            {
                Console.WriteLine("\nPlease enter a valid response: y or n.");
                Console.ReadLine();
            }
        }

        //Enter a new claim
        private void CreateNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            //Claim ID
            Console.WriteLine("Enter the Claim ID Number:");
            newClaim.ClaimId = int.Parse(Console.ReadLine());

            //Claim Type
            Console.WriteLine("Enter the number for the type of claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            int claimTypeAsInt = int.Parse(Console.ReadLine());
            newClaim.TypeOfClaim = (ClaimType)claimTypeAsInt;

            //Claim Description
            Console.WriteLine("Enter the claim description:");
            newClaim.Description = Console.ReadLine();

            //Claim Amount
            Console.WriteLine("Enter the amount of the claim (XXXX.XX format):");
            newClaim.ClaimAmount = double.Parse(Console.ReadLine());

            //Date of Incident
            Console.WriteLine("Enter the date the incident occurred (Year,Month,Day format)(ex: 1991,1,3):");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            //Date of Claim
            Console.WriteLine("Enter the date the claim was created (Year,Month,Day format)(ex: 1991,1,3):");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            //Claim Is Valid
            if (newClaim.IsValid)
            {
                Console.WriteLine("The claim is valid.");
            }
            else
            {
                Console.WriteLine("The claim is invalid.");
            }

            //Add Claim to Queue
            _repo.AddClaimToQueue(newClaim);
            Console.WriteLine("The claim has been added to the queue.");
        }

        //Seed Method
        private void SeedClaimsQueue()
        {
            Claim one = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claim two = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            Claim three = new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1));

            _repo.AddClaimToQueue(one);
            _repo.AddClaimToQueue(two);
            _repo.AddClaimToQueue(three);
        }
    }
}
