using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgeRepo
    {

        private Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        //CREATE - Create a badge/Add a new badge

        public bool CreateBadge(Badge badge)
        {
            _badgeDictionary.Add(badge.BadgeId, badge.ListOfDoorNames);

            if (_badgeDictionary.ContainsKey(badge.BadgeId))
            {
                return true;
            }
            return false;
        }

        //READ - Get list of all badges & doors
        public Dictionary<int, List<string>> GetDictionaryOfBadgesAndDoors()
        {
            return _badgeDictionary;
        }

        //READ - Get KeyValuePair by Badge ID
        public Badge GetBadgeDoorPairingByBadgeId(int badgeId)
        {
            foreach (KeyValuePair<int, List<string>> badgeDoorPairing in _badgeDictionary)
            {
                if (badgeDoorPairing.Key == badgeId)
                {
                    return new Badge(badgeDoorPairing.Key, badgeDoorPairing.Value);
                }
            }
            return null;
        }

        //UPDATE - Add or remove a door to list of doors for existing badge
        public bool AddValueToKeyValuePairByKey(int badgeId, string doorId)
        {
            foreach (KeyValuePair<int, List<string>> badgeDoorPairing in _badgeDictionary)
            {
                if (badgeDoorPairing.Key == badgeId)
                {
                    badgeDoorPairing.Value.Add(doorId);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveValueFromKeyValuePairByKey(int badgeId, string doorId)
        {
            foreach (KeyValuePair<int, List<string>> badgeDoorPairing in _badgeDictionary)
            {
                if (badgeDoorPairing.Key == badgeId)
                {
                    badgeDoorPairing.Value.Remove(doorId);
                    return true;
                }
            }
            return false;
        }
    }
}
