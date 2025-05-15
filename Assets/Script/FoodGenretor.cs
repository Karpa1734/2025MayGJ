using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    int frame = 0;
    [SerializeField] GameObject Food;
    List<GameObject> foodList = new List<GameObject>();

    void Update()
    {
        if (frame % 60 == 0)
        {
            GameObject newFood = Instantiate(Food, new Vector3(Random.Range(-9f, 9f), 7, 0), Quaternion.identity);
            foodList.Add(newFood);
        }

        // �eFood��y���W���`�F�b�N���āA���ȉ��Ȃ�폜
        for (int i = foodList.Count - 1; i >= 0; i--)
        {
            if (foodList[i] == null) continue;

            if (foodList[i].transform.position.y < -9)
            {
                Destroy(foodList[i]);
                foodList.RemoveAt(i); // List������폜
            }
        }

        frame++;
    }
}
