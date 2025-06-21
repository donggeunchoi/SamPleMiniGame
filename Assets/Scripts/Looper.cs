using UnityEngine;

public class Looper : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float resetX = -20f; // 왼쪽 벗어나는 기준
    public float startX = 40f;  // 오른쪽 재배치 위치

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < resetX)
        {
            transform.position = new Vector3(startX, transform.position.y, transform.position.z);
        }
    }
}
