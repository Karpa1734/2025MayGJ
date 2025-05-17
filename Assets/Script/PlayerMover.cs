using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float minX = -8f;
    [SerializeField] float maxX = 8f;
    public int CurrentScore = 0;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        if (CurrentScore < 10000)
        {
            float moveInput = Input.GetAxisRaw("Horizontal");
            Vector3 move = new Vector3(moveInput * speed * Time.deltaTime, 0, 0);
            transform.position += move;
            float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }

    // 2D用の衝突検出（トリガー）
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Foods"))
        {
            CurrentScore += other.GetComponent<Food>().Score;
            Destroy(other.gameObject); // ぶつかった相手だけ削除
            Debug.Log(CurrentScore);
        }
    }
}
