using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Score : MonoBehaviour
    {
        public Text score;
        private Snake snake;
        public int s;

        private void Start()
        {
            snake = GameObject.FindGameObjectWithTag("SnakeSpawner").GetComponent<Snake>();
        }

        private void Update()
        {
            s = snake.score;
            score.text = "Score\n" + s.ToString();
        }

        public void UpdateHighscore()
        {
            if (s > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", s);
            }
        }
    }
}