using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public string namePlayer;
    public Text nameInput;
    public Text validator;
    // Start is called before the first frame update
    void Start()
    {
         validator.enabled=false;
    }

    // Update is called once per frame
    public void LivesGame(){
        namePlayer = nameInput.text;
        PlayerPrefs.SetString("KeyName", namePlayer);
        if (namePlayer.Length == 0){
            validator.enabled=true;
        }
        else{
        
        SceneManager.LoadScene("LivesGame");
        }
    }
    public void TimeGame(){
        namePlayer = nameInput.text;
        PlayerPrefs.SetString("KeyName", namePlayer);
         if (namePlayer.Length == 0){
            validator.enabled=true;
        }
        else{
        
        SceneManager.LoadScene("TimesGame");
        }
    }
}
