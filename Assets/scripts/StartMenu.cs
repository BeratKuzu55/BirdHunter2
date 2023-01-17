using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("topScore").GetComponent<TextMeshProUGUI>().text = "Top Score : " + PlayerPrefs.GetInt("topScore").ToString();
        
        if(PlayerPrefs.GetInt("topScore") == 0)
        {
            GameObject.Find("Devam").GetComponent<Button>().enabled = false;
        }

    }

    void Update()
    {
        GameObject.Find("topScore").GetComponent<TextMeshProUGUI>().text = "Top Score : " + PlayerPrefs.GetInt("topScore").ToString();
    }

    public void yeni_oyun()
    {
        GameObject.Find("puan").GetComponent<puan_sc>().puan = 0;
        StartCoroutine(yeni_oyuna_gec());
    }

    public void devam()
    {
        int sahneindex=PlayerPrefs.GetInt("sahne",0);
        //print(sahneindex);
        SceneManager.LoadScene(sahneindex);
    }

    IEnumerator yeni_oyuna_gec()
    {
        yield return new WaitForSeconds(1.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
