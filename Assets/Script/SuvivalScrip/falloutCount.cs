using UnityEngine;
using System;

public class falloutCount : MonoBehaviour
{
    private int falloutObjectCount = 0;
    public static event Action OnGameOver; // �C�x���g

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Foods"))
        {
            falloutObjectCount++;
            Debug.Log($"�G��܂����I falloutcount: {falloutObjectCount}");

            // 10��ȏ�ŃQ�[���I�[�o�[
            if (falloutObjectCount >= 10)
            {
                OnGameOver?.Invoke();
            }
        }
    }
}