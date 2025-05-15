using UnityEngine;
using UnityEngine.UI;

public class TimeKeeper : MonoBehaviour
{
    [SerializeField] Text timerText; // UI��Text���C���X�y�N�^�[�ŃZ�b�g
    public static int countDown = 30 * 60; // 30�b �~ 60�t���[�� = 1800�J�E���g
    private void Start()
    {
        // �����l��ݒ�
        countDown = 30 * 60; // 30�b �~ 60�t���[�� = 1800�J�E���g

    }

    void Update()
    {
        if (countDown > 0)
        {
            countDown--;

            int seconds = countDown / 60;
            int frames = countDown % 60;

            // 30:00 �� 00:00�̌`���ŕ\���i�b : �t���[���j
            timerText.text = string.Format("{0:00}:{1:00}", seconds, frames);
        }
        else
        {
            timerText.text = "00:00";
        }
    }
}
