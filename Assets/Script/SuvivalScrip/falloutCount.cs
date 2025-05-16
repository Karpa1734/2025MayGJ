// falloutCount.cs
using UnityEngine;

public class falloutCount : MonoBehaviour
{
    private int falloutObjectCount = 0;
    private bool IsGameOver = false;

    // �C�x���g�̐錾
    public delegate void GameOverEvent();
    public static event GameOverEvent OnGameOver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Foods"))
        {
            falloutObjectCount++;
            Debug.Log("�G��܂����I falloutcount: " + falloutObjectCount);

            if (falloutObjectCount >= 10 && !IsGameOver)
            {
                IsGameOver = true;
                // �C�x���g�𔭍s
                OnGameOver?.Invoke();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            falloutObjectCount++;
            Debug.Log("�Փ˂��܂����I falloutcount: " + falloutObjectCount);

            if (falloutObjectCount >= 10 && !IsGameOver)
            {
                IsGameOver = true;
                // �C�x���g�𔭍s
                OnGameOver?.Invoke();
            }
        }
    }
}