using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    private Arrow asd;
    void Start()
    {
        GameObject obj = GameObject.Find("BackGround");
        asd = obj.GetComponent<Arrow>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        // �浹�� ���� ������Ʈ�� �÷��̾��� ���� ����
        if (collider.gameObject.tag == "Player")
        {
            AudioSource audioSource = GetComponent <AudioSource>();
            audioSource.Play();
            Time.timeScale = 0.0f;
            asd.onObj();
        }

    }
}
