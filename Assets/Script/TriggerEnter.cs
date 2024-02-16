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
        // 충돌한 게임 오브젝트가 플레이어라면 게임 종료
        if (collider.gameObject.tag == "Player")
        {
            AudioSource audioSource = GetComponent <AudioSource>();
            audioSource.Play();
            Time.timeScale = 0.0f;
            asd.onObj();
        }

    }
}
