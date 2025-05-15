using UnityEngine;
using UnityEngine.UI;

public class Calory : MonoBehaviour
{
    [SerializeField] Text scoreText;              // 表示するText（UI）を設定
    [SerializeField] PlayerMover playerMove;       // PlayerMoveの参照を設定

    void Update()
    {
        if (playerMove != null && scoreText != null)
        {
            scoreText.text = playerMove.CurrentScore.ToString() + "cal";
        }
    }
}
