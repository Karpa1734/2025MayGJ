using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    int frame = 0;

    [SerializeField] GameObject[] FoodPrefabs;  // 5種類のFoodプレハブを入れる
    [SerializeField] float[] probabilities = new float[5] { 0.4f, 0.25f, 0.15f, 0.1f, 0.1f };
    [SerializeField] float spawnRangeX = 4f; // 前の食べ物からどれだけ離れて良いか

    List<GameObject> foodList = new List<GameObject>();
    float lastFoodX = 0f; // 直前の食べ物のX位置

    void Update()
    {
        if (frame % 30 == 0 && TimeKeeper.countDown > 0)
        {
            GameObject selectedFood = SelectFoodByProbability();

            // 最初の一回だけ完全ランダム
            if (foodList.Count == 0)
            {
                lastFoodX = Random.Range(-8f, 8f);
            }
            else
            {
                float minX = Mathf.Max(-8f, lastFoodX - spawnRangeX);
                float maxX = Mathf.Min(8f, lastFoodX + spawnRangeX);
                lastFoodX = Random.Range(minX, maxX);
            }

            Vector3 spawnPos = new Vector3(lastFoodX, 7, 0);// Food生成部分に以下を追加
            GameObject newFood = Instantiate(selectedFood, spawnPos, Quaternion.identity);

            // 重力スケールをランダムに設定（例：0.5 ～ 1.5）
            Rigidbody2D rb = newFood.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = Random.Range(0.5f, 1.5f);
            }
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
        float rand = Random.value;
        float cumulative = 0f;

        for (int i = 0; i < probabilities.Length; i++)
        {
            cumulative += probabilities[i];
            if (rand <= cumulative)
            {
                return FoodPrefabs[i];
            }
        }

        return FoodPrefabs[FoodPrefabs.Length - 1];
    }
}
