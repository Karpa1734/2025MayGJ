// falloutCount.cs
using UnityEngine;

public class falloutCount : MonoBehaviour
{
    private int falloutObjectCount = 0;
    private bool IsGameOver = false;

    // イベントの宣言
    public delegate void GameOverEvent();
    public static event GameOverEvent OnGameOver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Foods"))
        {
            falloutObjectCount++;
            Debug.Log("触れました！ falloutcount: " + falloutObjectCount);

            if (falloutObjectCount >= 10 && !IsGameOver)
            {
                IsGameOver = true;
                // イベントを発行
                OnGameOver?.Invoke();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            falloutObjectCount++;
            Debug.Log("衝突しました！ falloutcount: " + falloutObjectCount);

            if (falloutObjectCount >= 10 && !IsGameOver)
            {
                IsGameOver = true;
                // イベントを発行
                OnGameOver?.Invoke();
            }
        }
    }
}