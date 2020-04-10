using System;
using _02_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _02_ClaimsTests
{
    [TestClass]
    public class ClaimRepoTests
    {
        ClaimRepo _repoTest = new ClaimRepo();
        public Queue<Claim> _queueTest
            = new Queue<Claim>();

        [TestMethod]
        public void GetClaimQueue_Test()
        {
            //Arrange
            Claim testClaim = new Claim();
            ClaimRepo testClaimRepo = new ClaimRepo();
            testClaimRepo.AddClaimToQueue(testClaim);

            //Act
            Queue<Claim> testQueue = testClaimRepo.GetClaimQueue();
            bool queueHasClaims = testQueue.Contains(testClaim);

            //Assert
            Assert.IsTrue(queueHasClaims);
        }

        [TestMethod]
        public void GetClaimFromQueue_Test()
        {
            //Arrange
            Claim testClaim = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            ClaimRepo testClaimRepo = new ClaimRepo();
            testClaimRepo.AddClaimToQueue(testClaim);

            //Act
            Claim searchResult = testClaimRepo.GetClaimFromQueue();

            //Assert
            Assert.AreEqual(searchResult, testClaim);

        }

        [TestMethod]
        public void RemoveClaimFromQueue_Test()
        {
            //Arrange
            
            Claim one = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claim two = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            ClaimRepo testClaimRepo = new ClaimRepo();
            testClaimRepo.AddClaimToQueue(one);
            testClaimRepo.AddClaimToQueue(two);

            //Act
             bool removeResult = testClaimRepo.RemoveClaimFromQueue();
            Claim toBeRemoved = testClaimRepo.GetClaimFromQueue();

            Assert.AreEqual(one, testClaimRepo.RemoveClaimFromQueue());
        }

        [TestMethod]
        public void AddClaimToQueue_Test()
        {
            //Arrange
            Claim testClaim = new Claim();
            ClaimRepo testRepo = new ClaimRepo();
            //Queue<Claim> testQueue = new Queue<Claim>();

            //Act
            bool addResult = testRepo.AddClaimToQueue(testClaim);

            //Assert
            Assert.IsTrue(addResult);
        }
    }
}
