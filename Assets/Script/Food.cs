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
            case 2: Score = 150; break;
            case 3: Score = 250; break;
            case 4: Score = 350; break;
            case 5: Score = 500; break;
            default: Score = 0; break;
        }
    }
}
