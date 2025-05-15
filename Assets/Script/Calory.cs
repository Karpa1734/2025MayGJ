using UnityEngine;
using UnityEngine.UI;

public class Calory : MonoBehaviour
{
    [SerializeField] Text scoreText;              // �\������Text�iUI�j��ݒ�
    [SerializeField] PlayerMover playerMove;       // PlayerMove�̎Q�Ƃ�ݒ�

    void Update()
    {
        if (playerMove != null && scoreText != null)
        {
            scoreText.text = playerMove.CurrentScore.ToString() + "cal";
        }
    }
}
