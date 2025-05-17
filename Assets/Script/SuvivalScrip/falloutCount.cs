using UnityEngine;
using System;
using KanKikuchi.AudioManager;
using UnityEngine.UI;

public class falloutCount : MonoBehaviour
{
    private int falloutObjectCount = 0;
    [SerializeField] Text FO;
    private static event Action OnGameOver; // イベント
    public bool IsGameOver = false;
    [SerializeField] bool isSurvivel = false; // サバイバルモードかどうか


    void Start()
    {
        if (isSurvivel)
        {
            FO.text = "食べ残し:" + falloutObjectCount.ToString() + "/10";
        }
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
            switch (other.GetComponent<Food>().FoodCode)
            {
                case 5:
                case 6:
                    break;
                default:
                    falloutObjectCount++;
                    if (isSurvivel)
                    {
                        FO.text = "食べ残し:" + falloutObjectCount.ToString() + "/10";
                    }
                    break;
            }
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