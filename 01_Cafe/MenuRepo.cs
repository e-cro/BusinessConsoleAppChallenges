using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuRepo
    {//Create a Program file that allows the cafe manager to add, delete, and see all items in the menu list.

        protected readonly List<Menu> _menuList = new List<Menu>();

        //CREATE/Add

        public bool AddItemToMenu(Menu menu)
        {
            int startingCount = _menuList.Count;
            _menuList.Add(menu);
            bool wasAdded = (_menuList.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //READ/See All

        public List<Menu> GetMenu()
        {
            return _menuList;
        }

        //DELETE

        public bool DeleteMenuItem(int userInput)
        {
            foreach (Menu menuItem in _menuList)
            {
                if (userInput == menuItem.MealNumber)
                {
                    bool deleteResult = _menuList.Remove(menuItem);
                    return deleteResult;
                }

            }
            return false;
        }

    }
}
