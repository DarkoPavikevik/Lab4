using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesGameOver : MonoBehaviour
{
    public GameObject takeMistakes;
    public GameObject CanvasObject;
    public Sprite gameover;
    int numberOfMistakes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfMistakes = takeMistakes.GetComponent<ChangeFlag>().GetNumberOfMistakes();
        if (numberOfMistakes >= 3){
            takeMistakes.GetComponent<ChangeFlag>().setGameOver(gameover);
            CanvasObject.GetComponent<Canvas> ().enabled = false;
            StartCoroutine(waiter());
        }
    }
    IEnumerator waiter()
    {
    //Wait for 4 seconds
    yield return new WaitForSeconds(2);
    SceneManager.LoadScene("GameOver");

    }
}
