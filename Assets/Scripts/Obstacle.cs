using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Obstacle")] 
    public GameObject[] obstaclePrefabs;
    public Transform spawnPoint;
    public float spawnInterval = 1.5f;

    void Start()
    {
        if (obstaclePrefabs[0] == null || obstaclePrefabs.Length == 0)
        {
            Debug.LogError("❌ obstaclePrefabs가 비어있습니다!");
            return;
        }

        if (spawnPoint == null)
        {
            Debug.LogError("❌ spawnPoint가 null입니다!");
            return;
        }
       
        StartCoroutine(SpawnRoutine());
        Debug.Log(obstaclePrefabs);
    }

    IEnumerator SpawnRoutine()
    {
        while (!DinoMiniGame.Instance.isGameOver)
        {
            int index = Random.Range(0, obstaclePrefabs.Length);
            GameObject obstacle = Instantiate(obstaclePrefabs[index], spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }


}
