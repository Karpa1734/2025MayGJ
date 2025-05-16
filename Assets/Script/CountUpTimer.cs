using UnityEngine;
using UnityEngine.UI;

public class CountUpTimer : MonoBehaviour
{
    [SerializeField] Text countupText;
    public static int countUp = 0;

    private void Start()
    {
        // 初期値を0に設定
        countUp = 0;
        // 初期表示
        countupText.text = "00:00";
    }

    void Update()
    {
        // 常にカウントアップ
        countUp++;

        int seconds = countUp / 60;
        int frames = countUp % 60;

        // 00:00 → ... の形式で表示（秒 : フレーム）
        countupText.text = string.Format("{0:00}:{1:00}", seconds, frames);
    }
}