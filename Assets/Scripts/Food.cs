using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Food : MonoBehaviour
    {
        public GameObject foodObject;

        public void SpawnFood(int width, int height)
        {

            Vector3 spawnPos = new Vector3(Random.Range(-width, width), Random.Range(-width, height), 0);


            Instantiate(foodObject, spawnPos, Quaternion.identity);

        }
       
    }
}

