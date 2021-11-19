using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class LevelGrid
    {
        public int width;
        public int height;
        private Food foodSpawner;

        public LevelGrid(int width, int height, int spawns)
        {
            this.width = width;
            this.height = height;

            foodSpawner = GameObject.FindGameObjectWithTag("FoodSpawner").GetComponent<Food>();
            for (int i = 0; i < spawns; i++)
            {
                foodSpawner.SpawnFood(this.width, this.height);
            }
        }
    }
}

