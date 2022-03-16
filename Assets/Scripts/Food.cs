using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Food : MonoBehaviour
    {
        public GameObject foodObject;
        private Snake snake;

        private void Awake()
        {
            snake = GameObject.FindGameObjectWithTag("SnakeSpawner").GetComponent<Snake>();
        }

        public void SpawnFood(int width, int height)
        {

            Vector3 spawnPos = new Vector3(Random.Range(-width, width), Random.Range(-width, height), 0);

            while (snake.CheckEmpty(spawnPos) == false)
            {
                spawnPos = new Vector3(Random.Range(-width, width), Random.Range(-width, height), 0);
            }

            Instantiate(foodObject, spawnPos, Quaternion.identity);

        }
       
    }
}

