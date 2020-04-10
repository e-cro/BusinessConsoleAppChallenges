using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01_Cafe;
using System.Collections.Generic;

namespace _01_CafeTest
{
    [TestClass]
    public class MenuRepoTests
    {
        private Menu _menu;
        private MenuRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _menu = new Menu(1, "Test Burger", "Description of test burger", "Ingredients in test burger", 1.50);
            _repo = new MenuRepo();
            _repo.AddItemToMenu(_menu);
        }

        [TestMethod]
        public void AddItemToMenu_ShouldGetCorrectBool()
        {
            //Act
            bool addResult = _repo.AddItemToMenu(_menu);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMenu_ShouldReturnMenu()
        {
            //Act 
            List<Menu> testList = _repo.GetMenu();
            bool testListHasMenu = testList.Contains(_menu);

            //Assert
            Assert.IsTrue(testListHasMenu);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            //Act
            //Menu toBeDeleted = _repo
            bool deleteResult = _repo.DeleteMenuItem(1);

            //Assert
            Assert.IsTrue(deleteResult);

        }
    }
}
