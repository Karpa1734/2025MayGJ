using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] int FoodCode = 1;
    public int Score { get; private set; } // 他から読み取り可能、書き換え不可

    /*
    1. ポテト         
    2. 唐揚げ         
    3. コロッケ       
    4. 串カツ         
    5. バター揚げ     
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
