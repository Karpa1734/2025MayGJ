using UnityEngine;
using System;

public class falloutCount : MonoBehaviour
{
    private int falloutObjectCount = 0;
    private static event Action OnGameOver; // イベント
    public bool IsGameOver = false;

    void Start()
    {
        falloutCount.OnGameOver += () => { IsGameOver = true; };
    }

    void OnDestroy()
    {
        falloutCount.OnGameOver -= () => { IsGameOver = true; };
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Foods"))
        {
            falloutObjectCount++;
            Debug.Log($"触れました！ falloutcount: {falloutObjectCount}");

            // 10回以上でゲームオーバー
            if (falloutObjectCount >= 10)
            {
                Debug.Log("GameOver");
                OnGameOver?.Invoke();
            }
        }
    }
}