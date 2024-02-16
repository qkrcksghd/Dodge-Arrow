using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnController : MonoBehaviour
{
    public GameObject Panel;
    public GameObject btn;
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
        btn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void btnStart()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void btnExplanation()
    {
        Panel.SetActive(true);
        btn.SetActive(true);
    }
}
