using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EastArrow : MonoBehaviour
{
    public float speed = 2.0f; // 이동 속도
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = -speed * Time.deltaTime;

        // 현재 위치
        Vector3 currentPosition = transform.position;

        // x축 방향으로 이동할 위치 계산
        Vector3 newPosition = new Vector3(currentPosition.x + distance, currentPosition.y, currentPosition.z);

        // 이동
        transform.position = newPosition;

        Destroy(gameObject, 6.0f);
    }
}
