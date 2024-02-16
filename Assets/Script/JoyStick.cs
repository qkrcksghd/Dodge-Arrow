using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform lever; //RectTransform타입의 lever변수를 선언하는 코드
    //이 변수는 조이스틱 레버의 RectTransform를 참조하여 조이스틱의 레버의 위치및 코드를 조정하는 데 사용됨
    private RectTransform rectTransform;
    [SerializeField, Range(10f, 150f)] //SerializeField는 private로 선언된 변수를 인스펙터 창에서 접근 가능하게 해준다
    private float leverRange; // lever가 이동할수있는 범위 즉 joystick위를 움직일수있는 범위
    public Player controller; // 플레이어에 있는 모든걸 가져옴
    private Vector2 inputDirection; // Vector2(x, y)왜냐면 2d이기 때문에 
    private bool isInput; // 조이스틱으로만 움직이기 때문에 선언

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // 이 스크립트가 붙여져 있는
                                                       // 즉 조이스틱의 RectTransform을 가져와서 rectTransform으로
                                                       //재선언
    }

    public void OnBeginDrag(PointerEventData eventData) // 조이스틱의 작동을 시작하면 실행되는 함수
    {
        isInput = true; // 클릭을 시작하면 캐릭터가 움직여야 하기때문
        inputDirection = Vector2.zero;  // 드래그를 시작할 때 방향값 초기화
        UpdateLever(eventData.position);  // 레버 위치 업데이트
    }

    public void OnDrag(PointerEventData eventData) // 드래그하는동안 실행되는 함수
    {
        UpdateLever(eventData.position);  // 레버 위치 업데이트
    }

    public void OnEndDrag(PointerEventData eventData) // 손을 놓았을때 실행되는 함수
    {
        isInput = false; // 움직임을 멈춰야하기때문에
        inputDirection = Vector2.zero; // 캐릭터의 움직임을 종료해야하기때문
        lever.anchoredPosition = Vector2.zero;  // 레버 위치 초기화
    }

    void Update() // 매시간마다 계속실행됨
    {
        if (isInput) // isInput이 1이면 즉 true면 
        {
            controller.Move(inputDirection); // 안에있는 Move함수를 실행해서 inputDirection값을 넘김
        }
    }

    private void UpdateLever(Vector2 inputPos)
    {
        Vector2 center = rectTransform.position;  // 조이스틱의 중심 위치
        Vector2 diff = inputPos - center; // 이벤트 포지션에다가 조이스틱의 중심위치를 빼서 이동거리 구함
        float mag = diff.magnitude; //diff의 크기
        Vector2 direction = mag < leverRange ? diff : diff.normalized * leverRange;
        // 레버 이동
        //mag가 leverRange보다 작으면 입력 위치에서 레버까지의 거리가
        //leverRange보다 작으므로 입력 위치를 그대로 반환합니다.
        //mag가 leverRange보다 크면 입력 위치와 레버 사이의 거리가 leverRange를 벗어난 것이므로, 
        //입력 위치와 레버 사이의 방향 벡터를 
        //leverRange의 크기로 조정합니다.
        //이렇게 함으로써 레버가 정해진 범위 안에서만 움직이게 됩니다.
        lever.anchoredPosition = direction;  // 레버 위치 업데이트
        inputDirection = direction.normalized;  // 입력 방향 업데이트
    }
}