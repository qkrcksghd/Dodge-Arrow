using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text_Timer;
    public TextMeshProUGUI nowRecord;
    public Arrow asd;
    private float time_start;
    private float time_current;

    private void Start()
    {
        GameObject obj = GameObject.Find("BackGround");
        asd = obj.GetComponent<Arrow>();
        time_start = Time.time;
        time_current = 0;
    }
    void Update()
    {
        Check_Timer();
    }

    private void Check_Timer()
    {
        time_current = Time.time - time_start;
        text_Timer.text = $"{time_current:N2}";
        nowRecord.text = $"{time_current:N2}";
    }

}
