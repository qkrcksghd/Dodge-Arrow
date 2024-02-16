using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EastArrow : MonoBehaviour
{
    public float speed = 2.0f; // �̵� �ӵ�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = -speed * Time.deltaTime;

        // ���� ��ġ
        Vector3 currentPosition = transform.position;

        // x�� �������� �̵��� ��ġ ���
        Vector3 newPosition = new Vector3(currentPosition.x + distance, currentPosition.y, currentPosition.z);

        // �̵�
        transform.position = newPosition;

        Destroy(gameObject, 6.0f);
    }
}
