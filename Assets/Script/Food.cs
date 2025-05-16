using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] int FoodCode = 1;
    public int Score { get; private set; } // ������ǂݎ��\�A���������s��

    /*
    1. �|�e�g         
    2. ���g��         
    3. �R���b�P       
    4. ���J�c         
    5. �o�^�[�g��     
    */

    void Start()
    {
        switch (FoodCode)
        {
            case 1: Score = 100; break;
            case 2: Score = 200; break;
            case 3: Score = 300; break;
            case 4: Score = 500; break;
            case 5: Score = -200; break;
            case 6: Score = 0; break;
            default: Score = 0; break;
        }
    }
}
