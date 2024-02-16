using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Arrow : MonoBehaviour
{
    public GameObject[] arrow;
    public GameObject[] eightArrow;
    public Vector3[] eightArrowPosition;
    public Transform Player;
    public int[] verticalY;
    public int[] horizontalX;
    public Transform bigRect;
    public Transform smallRect;
    public Rect bigRectBounds;
    public Rect smallRectBounds;
    public GameObject btn;
    public GameObject record;
    void Start()
    {
        btn.SetActive(false);
        record.SetActive(false);
        eightArrowPosition = new Vector3[eightArrow.Length];
        verticalY = new int[] { -1, 0, 1, 2, 3 };
        horizontalX = new int[] { -2, -1, 0, 1, 2 };
        for (int i = 0; i < eightArrow.Length; i++)
        {
            eightArrowPosition[i] = new Vector3(eightArrow[i].transform.position.x, eightArrow[i].transform.position.y, 0);
        }
        Vector3 bigRectMin = bigRect.position - bigRect.localScale / 2;
        Vector3 bigRectMax = bigRect.position + bigRect.localScale / 2;

        bigRectBounds = new Rect(bigRectMin.x, bigRectMin.y, bigRect.localScale.x, bigRect.localScale.y);

        // ���� ���簢�� ������ ���մϴ�.
        Vector3 smallRectMin = smallRect.position - smallRect.localScale / 2;
        Vector3 smallRectMax = smallRect.position + smallRect.localScale / 2;
        smallRectBounds = new Rect(smallRectMin.x, smallRectMin.y, smallRect.localScale.x, smallRect.localScale.y);


        //������Ʈ�� �����մϴ�.
        InvokeRepeating("SpawnObject", 0f, 3f);
        InvokeRepeating("eightmake", 7f, 7f);
        InvokeRepeating("eastmake", 20f, 10f);
        InvokeRepeating("westmake", 25f, 10f);
        InvokeRepeating("southmake", 30f, 10f);
        InvokeRepeating("northmake", 35f, 10f);
    }
    public void onObj()
    {
        btn.SetActive(true);
        record.SetActive(true);
    }
    void SpawnObject()
    {
        float x = Random.Range(bigRectBounds.xMin, bigRectBounds.xMax);
        float y = Random.Range(bigRectBounds.yMin, bigRectBounds.yMax);
        Vector2 randomPosition = new Vector2(x, y);

        // ���� ��ġ�� ���� ���簢���� ���� ���ο� �ִٸ� �ٽ� ���� ��ġ�� �����մϴ�.
        while (smallRectBounds.Contains(randomPosition))
        {
            x = Random.Range(bigRectBounds.xMin, bigRectBounds.xMax);
            y = Random.Range(bigRectBounds.yMin, bigRectBounds.yMax);
            randomPosition = new Vector2(x, y);
        }
        // ������Ʈ�� �����մϴ�.
        Instantiate(arrow[4], randomPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void eightmake()
    {
        for (int i = 0; i < eightArrowPosition.Length; i++)
        {
            Instantiate(arrow[4], eightArrowPosition[i], Quaternion.identity);
        }
    }
    private void eastmake()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(arrow[0], new Vector3(4, verticalY[i], 0), Quaternion.Euler(0, 0, 270f));
            print(verticalY[i]);
        }
    }
    private void westmake()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(arrow[1], new Vector3(-4, verticalY[i], 0), Quaternion.Euler(0, 0, 90f));
        }
    }
    private void southmake()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(arrow[2], new Vector3(horizontalX[i], -2, 0), Quaternion.Euler(0, 0, 180f));
        }
    }
    private void northmake()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(arrow[3], new Vector3(horizontalX[i], 5, 0), Quaternion.Euler(0, 0, 0));
        }
    }

    public void downreStart()
    {
        // ���� ���� �ε����� ������
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // ���� �� �ٽ� �ε�
        SceneManager.LoadScene(currentSceneIndex);
        // ���� �������� 1�� �ʱ�ȭ
        Time.timeScale = 1.0f;
    }

}
