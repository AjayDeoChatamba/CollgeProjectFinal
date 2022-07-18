using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject lvlBG;
    public static PauseMenu instance;
    [SerializeField] GameObject lvlEndMenu;
    [SerializeField] GameObject retryWhenDie;
    
    // Start is called before the first frame update
    void Start()
    {
        lvlBG.SetActive(true);
        retryWhenDie.SetActive(false);
        instance = this;
        lvlEndMenu.SetActive(false);
    }
  

    public void NextLvl()
    {
        AudioManager.instance.Play("button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Restart()
    {
        AudioManager.instance.Play("button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


   public void  TurnOnPanel()   //lvl end panel
    {
        lvlEndMenu.SetActive(true);
    }

    public void ToMainMenu()
    {
        AudioManager.instance.Play("button");
        SceneManager.LoadScene("MainMenu");  
    }

   
    public void WhenPlayerDies()
    {
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        retryWhenDie.SetActive(true);
    }
    
    public void LVL_BG()
    {
        lvlBG.SetActive(false);
    }
}
