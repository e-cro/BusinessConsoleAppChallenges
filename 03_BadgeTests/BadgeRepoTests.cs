using System;
using System.Collections.Generic;
using _03_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_BadgeTests
{
    [TestClass]
    public class BadgeRepoTests
    {
        [TestMethod]
        public void CreateBadge_Test()
        {
            int testBadgeIdOne = 11111;
            string testDoorIdOne = "A";
            List<string> testListOfDoors = new List<string>();
            testListOfDoors.Add(testDoorIdOne);
            Badge testBadge = new Badge(testBadgeIdOne, testListOfDoors);
            BadgeRepo testRepo = new BadgeRepo();

            bool created = testRepo.CreateBadge(testBadge);

            Assert.IsTrue(created);
        }

        [TestMethod]
        public void GetDictionary_Test()
        {
            int testBadgeIdOne = 11111;
            string testDoorIdOne = "A";
            List<string> testListOfDoors = new List<string>();
            testListOfDoors.Add(testDoorIdOne);
            Badge testBadge = new Badge(testBadgeIdOne, testListOfDoors);
            BadgeRepo testRepo = new BadgeRepo();

            Dictionary<int, List<string>> testDictionary = testRepo.GetDictionaryOfBadgesAndDoors();
            bool dictionaryHasBadges = testDictionary.ContainsKey(testBadgeIdOne);

            Assert.IsTrue(dictionaryHasBadges);
        }
    }
}
