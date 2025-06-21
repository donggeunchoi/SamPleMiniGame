using UnityEngine;

public class GroundTile : MonoBehaviour
{

    public float tileWidth = 10f;
    public float moveSpeed = 5f;


    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("닿았데아");
        if (other.CompareTag("RespawnZone"))
        {
            Reposition();
        }
    }

    void Reposition()
    {
        float rightMost = GetRightMostX(this.gameObject);
        transform.position = new Vector3(rightMost + tileWidth, transform.position.y, transform.position.z);

        float GetRightMostX(GameObject exclude)
        {
            GroundTile[] allTiles = FindObjectsOfType<GroundTile>();
            float maxX = float.MinValue;
            foreach (var tile in allTiles)
            {
                if (tile == exclude) continue;
                if (tile.transform.position.x > maxX)
                    maxX = tile.transform.position.x;
            }

            return maxX;
        }
    }
}
