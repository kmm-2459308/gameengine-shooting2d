using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    float time = 70.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.timerText = GameObject.Find("Time");
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;

        if (this.timerText != null) // nullチェック
        {
            this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");
        }
        else
        {
            Debug.LogWarning("Timer text object not found!");
        }

        if (time <= 0)
        {
            string nextSceneName = "BossScene";
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
