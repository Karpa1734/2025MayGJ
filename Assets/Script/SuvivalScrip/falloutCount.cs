using UnityEngine;
using System;

public class falloutCount : MonoBehaviour
{
    private int falloutObjectCount = 0;
    public static event Action OnGameOver; // イベント

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Foods"))
        {
            falloutObjectCount++;
            Debug.Log($"触れました！ falloutcount: {falloutObjectCount}");

            // 10回以上でゲームオーバー
            if (falloutObjectCount >= 10)
            {
                OnGameOver?.Invoke();
            }
        }
    }
}