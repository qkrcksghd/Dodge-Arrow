using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Arrow arrow;
    public AudioSource bgm;
    float centerX = 0f;
    float centerY = 1f;
    float radius = 2f;
    private float speed = 2f;
    private Vector2 inputDirection;
    void Start()
    {
        GameObject obj = GameObject.Find("BackGround");
        arrow = obj.GetComponent<Arrow>();
    }

    void Update()
    {
        Move(inputDirection);
    }

    void LateUpdate()
    {
        // 이동 제한
        LimitToMove();
    }

    public void Move(Vector2 inputDirection)
    {
        Vector3 _moveHoizontal = transform.up * inputDirection.y;
        Vector3 _moveVertial = -transform.right * -inputDirection.x;
        Vector3 move = (_moveVertial + _moveHoizontal).normalized * speed;
        transform.position += move * Time.deltaTime * speed;
    }

    void LimitToMove()
    {
        // 현재 위치를 원 내부로 제한
        float distance = Mathf.Clamp(Vector2.Distance(new Vector2(centerX, centerY), transform.position), 0, radius);
        Vector3 direction = (transform.position - new Vector3(centerX, centerY, 0f)).normalized;
        transform.position = new Vector3(centerX, centerY) + direction * distance;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        // 충돌한 게임 오브젝트가 플레이어라면 게임 종료
        if (collider.gameObject.tag == "Arrow")
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            bgm.Stop();
            Time.timeScale = 0.0f;
            arrow.onObj();
        }
    }
}