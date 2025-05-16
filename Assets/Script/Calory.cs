using UnityEngine;
using UnityEngine.UI;

public class Calory : MonoBehaviour
{
    [SerializeField] Text scoreText;               // �\������Text�iUI�j��ݒ�
    [SerializeField] PlayerMover playerMove;       // PlayerMove�̎Q�Ƃ�ݒ�
    [SerializeField] float scoreSpeed = 1000;      // 1�b������̉��Z���x�i�����\�j

    private float displayedScore = 0f;

    void Update()
    {
        if (playerMove == null || scoreText == null) return;

        float targetScore = playerMove.CurrentScore;

        // �����X�R�A�ɋ߂Â���i�t���[�����Ԃɉ����āj
        if (displayedScore < targetScore)
        {
            displayedScore += scoreSpeed * Time.deltaTime;

            if (displayedScore > targetScore)
            {
                displayedScore = targetScore; // ��������s�^�b�Ǝ~�߂�
            }
        }

        // �\���͐����l��OK�i�[���؂�̂āj
        scoreText.text = Mathf.FloorToInt(displayedScore).ToString() + "kcal";
    }
}
