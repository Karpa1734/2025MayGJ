using UnityEngine;
using UnityEngine.UI;

public class CountUpTimer : MonoBehaviour
{
    [SerializeField] Text countupText;
    [SerializeField] private falloutCount falloutCounter;
    public static int countUp = 0;
    public int seconds = 0;
    public int frames = 0;

    private void Start()
    {
        // 初期値を0に設定
        countUp = 0;
        // 初期表示
        countupText.text = "00:00";
    }

    void Update()
    {
        if (!falloutCounter.IsGameOver)
        {
            SuvaivalCount();
        }
    }

    void SuvaivalCount()
    {
        countUp++;

        seconds = countUp / 60;
        frames = countUp % 60;

        // 00:00 → ... の形式で表示（秒 : フレーム）
        countupText.text = string.Format("{0:00}:{1:00}", seconds, frames);
    }
}
