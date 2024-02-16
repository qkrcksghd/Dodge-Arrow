using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform lever; //RectTransformŸ���� lever������ �����ϴ� �ڵ�
    //�� ������ ���̽�ƽ ������ RectTransform�� �����Ͽ� ���̽�ƽ�� ������ ��ġ�� �ڵ带 �����ϴ� �� ����
    private RectTransform rectTransform;
    [SerializeField, Range(10f, 150f)] //SerializeField�� private�� ����� ������ �ν����� â���� ���� �����ϰ� ���ش�
    private float leverRange; // lever�� �̵��Ҽ��ִ� ���� �� joystick���� �����ϼ��ִ� ����
    public Player controller; // �÷��̾ �ִ� ���� ������
    private Vector2 inputDirection; // Vector2(x, y)�ֳĸ� 2d�̱� ������ 
    private bool isInput; // ���̽�ƽ���θ� �����̱� ������ ����

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // �� ��ũ��Ʈ�� �ٿ��� �ִ�
                                                       // �� ���̽�ƽ�� RectTransform�� �����ͼ� rectTransform����
                                                       //�缱��
    }

    public void OnBeginDrag(PointerEventData eventData) // ���̽�ƽ�� �۵��� �����ϸ� ����Ǵ� �Լ�
    {
        isInput = true; // Ŭ���� �����ϸ� ĳ���Ͱ� �������� �ϱ⶧��
        inputDirection = Vector2.zero;  // �巡�׸� ������ �� ���Ⱚ �ʱ�ȭ
        UpdateLever(eventData.position);  // ���� ��ġ ������Ʈ
    }

    public void OnDrag(PointerEventData eventData) // �巡���ϴµ��� ����Ǵ� �Լ�
    {
        UpdateLever(eventData.position);  // ���� ��ġ ������Ʈ
    }

    public void OnEndDrag(PointerEventData eventData) // ���� �������� ����Ǵ� �Լ�
    {
        isInput = false; // �������� ������ϱ⶧����
        inputDirection = Vector2.zero; // ĳ������ �������� �����ؾ��ϱ⶧��
        lever.anchoredPosition = Vector2.zero;  // ���� ��ġ �ʱ�ȭ
    }

    void Update() // �Žð����� ��ӽ����
    {
        if (isInput) // isInput�� 1�̸� �� true�� 
        {
            controller.Move(inputDirection); // �ȿ��ִ� Move�Լ��� �����ؼ� inputDirection���� �ѱ�
        }
    }

    private void UpdateLever(Vector2 inputPos)
    {
        Vector2 center = rectTransform.position;  // ���̽�ƽ�� �߽� ��ġ
        Vector2 diff = inputPos - center; // �̺�Ʈ �����ǿ��ٰ� ���̽�ƽ�� �߽���ġ�� ���� �̵��Ÿ� ����
        float mag = diff.magnitude; //diff�� ũ��
        Vector2 direction = mag < leverRange ? diff : diff.normalized * leverRange;
        // ���� �̵�
        //mag�� leverRange���� ������ �Է� ��ġ���� ���������� �Ÿ���
        //leverRange���� �����Ƿ� �Է� ��ġ�� �״�� ��ȯ�մϴ�.
        //mag�� leverRange���� ũ�� �Է� ��ġ�� ���� ������ �Ÿ��� leverRange�� ��� ���̹Ƿ�, 
        //�Է� ��ġ�� ���� ������ ���� ���͸� 
        //leverRange�� ũ��� �����մϴ�.
        //�̷��� �����ν� ������ ������ ���� �ȿ����� �����̰� �˴ϴ�.
        lever.anchoredPosition = direction;  // ���� ��ġ ������Ʈ
        inputDirection = direction.normalized;  // �Է� ���� ������Ʈ
    }
}