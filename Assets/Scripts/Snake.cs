using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Snake : MonoBehaviour
    {
        public GameObject head;
        public GameObject body;
        public int score;
        public int count;
        private LList<GameObject> snake = new LList<GameObject>();
        private Movement move;

        private void Start()
        {
            Vector3 spawn = new Vector3(0, 0, 0);

            snake.Add(Instantiate(head, spawn, Quaternion.identity));
            move = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        }

        public void SpawnBody()
        {
            //Vector3 bSpawn = new Vector3(x, y, 0);
            Vector3 spawnPos = snake.tail.member.transform.position;
            if (snake.Count <= 1)
            {
                spawnPos = snake.tail.member.transform.position - move.gridMoveDir;
            }
            snake.Add(Instantiate(body, spawnPos, Quaternion.identity));

            count = snake.Count;

            score = count - 1;
        }

        public void MoveBody()
        {
            
            LList<GameObject>.ListNode tempNode = snake.head;
            Vector3 temp = snake.head.member.transform.position;
            while (tempNode.NextNode != null)
            {
                (tempNode.NextNode.member.transform.position, temp) = (temp, tempNode.NextNode.member.transform.position);

                tempNode = tempNode.NextNode;
            }
        }

        public bool CheckEmpty(Vector3 location)
        {
            LList<GameObject>.ListNode check = snake.head;

            while (check != null)
            {
                if (location == check.member.transform.position)
                {
                    return false;
                }

                check = check.NextNode;
            }
            return true;
        }
    }
}

