using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    int frame = 0;

    [SerializeField] GameObject[] FoodPrefabs;  // 5種類のFoodプレハブを入れる
    [SerializeField] float[] probabilities = new float[5] { 0.4f, 0.25f, 0.15f, 0.1f, 0.1f };

    List<GameObject> foodList = new List<GameObject>();

    void Update()
    {
        if (frame % 30 == 0 && TimeKeeper.countDown > 0)
        {
            GameObject selectedFood = SelectFoodByProbability();
            GameObject newFood = Instantiate(selectedFood, new Vector3(Random.Range(-9f, 9f), 7, 0), Quaternion.identity);
            foodList.Add(newFood);
        }

        for (int i = foodList.Count - 1; i >= 0; i--)
        {
            if (foodList[i] == null) continue;

            if (foodList[i].transform.position.y < -9 || TimeKeeper.countDown <= 0)
            {
                Destroy(foodList[i]);
                foodList.RemoveAt(i);
            }
        }

        frame++;
    }

    GameObject SelectFoodByProbability()
    {
        float rand = Random.value; // 0～1のランダム値
        float cumulative = 0f;

        for (int i = 0; i < probabilities.Length; i++)
        {
            cumulative += probabilities[i];
            if (rand <= cumulative)
            {
                return FoodPrefabs[i];
            }
        }

        // 万が一のため最後のFoodを返す
        return FoodPrefabs[FoodPrefabs.Length - 1];
    }
}
