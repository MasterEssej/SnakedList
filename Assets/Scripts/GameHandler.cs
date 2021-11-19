using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameHandler : MonoBehaviour
    {

        public LevelGrid levelGrid;
        private int foodSpawns;

        private void Start()
        {
            foodSpawns = PlayerPrefs.GetInt("FoodSpawns", 1);

            levelGrid = new LevelGrid(9, 9, foodSpawns);
        }
    }
}

