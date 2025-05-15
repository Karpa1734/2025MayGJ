using UnityEngine;
using UnityEngine.UI;

public class TimeKeeper : MonoBehaviour
{
    [SerializeField] Text timerText; // UIのTextをインスペクターでセット
    public static int countDown = 30 * 60; // 30秒 × 60フレーム = 1800カウント
    private void Start()
    {
        // 初期値を設定
        countDown = 30 * 60; // 30秒 × 60フレーム = 1800カウント

    }

    void Update()
    {
        if (countDown > 0)
        {
            countDown--;

            int seconds = countDown / 60;
            int frames = countDown % 60;

            // 30:00 → 00:00の形式で表示（秒 : フレーム）
            timerText.text = string.Format("{0:00}:{1:00}", seconds, frames);
        }
        else
        {
            timerText.text = "00:00";
        }
    }
}
