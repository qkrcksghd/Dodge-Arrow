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
        // �ٸ� ������Ʈ�� ȸ����ų ������Ʈ ������ ���͸� ����մϴ�.
        Vector3 direction = targetObject.transform.position - transform.position;
        // ���� ������ ������ �������� ȸ����ų ������Ʈ�� forward ���Ϳ��� ������ ����մϴ�.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ���� ������ŭ ȸ����ų ������Ʈ�� ȸ���մϴ�.
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90f);
        Destroy(gameObject, 6.0f);
    }
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

    }

}