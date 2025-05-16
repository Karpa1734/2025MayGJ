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
        // �����l��0�ɐݒ�
        countUp = 0;
        // �����\��
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

        // 00:00 �� ... �̌`���ŕ\���i�b : �t���[���j
        countupText.text = string.Format("{0:00}:{1:00}", seconds, frames);
    }
}
