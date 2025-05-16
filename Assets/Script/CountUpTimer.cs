using UnityEngine;
using UnityEngine.UI;

public class CountUpTimer : MonoBehaviour
{
    [SerializeField] Text countupText;
    public static int countUp = 0;

    private void Start()
    {
        // �����l��0�ɐݒ�
        countUp = 0;
        // �����\��
        countupText.text = "00:00";
    }

    void Update()
    {
        // ��ɃJ�E���g�A�b�v
        countUp++;

        int seconds = countUp / 60;
        int frames = countUp % 60;

        // 00:00 �� ... �̌`���ŕ\���i�b : �t���[���j
        countupText.text = string.Format("{0:00}:{1:00}", seconds, frames);
    }
}