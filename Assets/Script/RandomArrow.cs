using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArrow : MonoBehaviour
{
    private GameObject targetObject;
    private int speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.Find("player");
        // 다른 오브젝트와 회전시킬 오브젝트 사이의 벡터를 계산합니다.
        Vector3 direction = targetObject.transform.position - transform.position;
        // 계산된 벡터의 방향을 기준으로 회전시킬 오브젝트의 forward 벡터와의 각도를 계산합니다.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 계산된 각도만큼 회전시킬 오브젝트를 회전합니다.
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90f);
        Destroy(gameObject, 6.0f);
    }
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

    }

}