using KanKikuchi.AudioManager;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float minX = -8f;
    [SerializeField] float maxX = 8f;
    private int FreezeFrame = 0;
    public int dumbbellcnt = 0;
    public int CurrentScore = 0;

    private void Start()
    {
        dumbbellcnt = 0;
        BGMManager.Instance.Play(BGMPath.STAGE);
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        if (TimeKeeper.countDown > 0 && FreezeFrame <= 0)
        {
            float moveInput = Input.GetAxisRaw("Horizontal");
            Vector3 move = new Vector3(moveInput * speed * Time.deltaTime, 0, 0);
            transform.position += move;
            float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
        if (FreezeFrame>0) { FreezeFrame--; }
    }

    // 2D用の衝突検出（トリガー）
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Foods"))
        {
            CurrentScore += other.GetComponent<Food>().Score;
            switch (other.GetComponent<Food>().FoodCode)
            {
                case 4:
                    SEManager.Instance.Play(SEPath.BUTTER);
                    break;
                case 6:
                    dumbbellcnt++;
                    SEManager.Instance.Play(SEPath.DUMBBELL);
                    FreezeFrame = 30;
                    break;
                default:
                    SEManager.Instance.Play(SEPath.ITEM);
                    break;
            }
            Destroy(other.gameObject); // ぶつかった相手だけ削除
            Debug.Log(CurrentScore);
        }
    }
}
