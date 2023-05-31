using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject Normal;
    public GameObject PauseScreen;
    public GameObject SelectCharacter;
    public GameObject MiddleText;
    public GameObject LosingScreen;
    public GameObject WinningScreen;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Coroutine1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
        Normal.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        Normal.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        Normal.SetActive(true);
        SelectCharacter.SetActive(false);
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");

    }
    public void Lose()
    {
        StartCoroutine(DefeatCoroutine());
    }
    public void Win()
    {
        Time.timeScale = 0;
        Normal.SetActive(false);
        MiddleText.SetActive(false);
        WinningScreen.SetActive(true);
    }
    public void AlmostWin()
    {
        MiddleText.SetActive(true);
        MiddleText.GetComponent<Text>().text = "Defeat all remaining enemies!";

    }
    IEnumerator Coroutine1()
    {
        yield return new WaitForSecondsRealtime(2);
        MiddleText.SetActive(false);
        SelectCharacter.SetActive(true);
    }
    IEnumerator DefeatCoroutine()
    {
        Normal.SetActive(false);
        yield return new WaitForSecondsRealtime(1.5f);
        Time.timeScale = 0;
        LosingScreen.SetActive(true);
    }
}
