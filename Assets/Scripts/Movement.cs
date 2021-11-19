using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class Movement : MonoBehaviour
    {
        public Vector3 gridMoveDir;
        private Vector3 gridPos;
        private float gridMoveTimer;
        private float gridMoveTimerMax;
        private Vector3 bodyPos;

        private Snake snakeSpawner;
        private Food foodSpawner;
        private GameHandler gh;
        private Score score;

        private void Start()
        {
            gh = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
            foodSpawner = GameObject.FindGameObjectWithTag("FoodSpawner").GetComponent<Food>();
            snakeSpawner = GameObject.FindGameObjectWithTag("SnakeSpawner").GetComponent<Snake>();
            score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        }


        private void Awake()
        {
            gridPos = new Vector3(0, 0);
            gridMoveTimerMax = 0.1f;
            gridMoveTimer = gridMoveTimerMax;
            gridMoveDir = new Vector3(1, 0);
        }

        void Update()
        {
            HandleInput();
            HandleGridMovement();
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (gridMoveDir.y != -1)
                {
                    gridMoveDir.x = 0;
                    gridMoveDir.y = 1;
                }

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (gridMoveDir.y != 1)
                {
                    gridMoveDir.x = 0;
                    gridMoveDir.y = -1;
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (gridMoveDir.x != -1)
                {
                    gridMoveDir.x = 1;
                    gridMoveDir.y = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (gridMoveDir.x != 1)
                {
                    gridMoveDir.x = -1;
                    gridMoveDir.y = 0;
                }
            }
        }
        private void HandleGridMovement()
        {
            gridMoveTimer += Time.deltaTime;
            if (gridMoveTimer >= gridMoveTimerMax)
            {

                gridPos += gridMoveDir;
                gridMoveTimer -= gridMoveTimerMax;

                if (snakeSpawner.count > 1)
                {
                    snakeSpawner.MoveBody();
                }
                
                transform.position = new Vector3(gridPos.x, gridPos.y);
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Wall"))
            {
                score.UpdateHighscore();
                SceneManager.LoadScene("Menu");
                Debug.Log("Dead");
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Food"))
            {
                Destroy(collision.gameObject);
                foodSpawner.SpawnFood(gh.levelGrid.width, gh.levelGrid.height);
                snakeSpawner.SpawnBody();
            }
            else if(collision.CompareTag("Body"))
            {
                score.UpdateHighscore();
                SceneManager.LoadScene("Menu");
                Debug.Log("Dead");
            }
        }

    }
}

