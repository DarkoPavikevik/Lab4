using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeFlag : MonoBehaviour
{
    public AudioClip[] audioClipArray;
    public AudioSource audioSource;
    public Sprite[] flags;
    public string[] flagNames;
    public GameObject[] hearts;
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Button buttonD;
    public Text pointsCounter;
    int indexRealAnswer;
    public int numberOfMistakes=0;
    int [] realAnswersIndex; 
    int points = 0;
    int brojac = 0;
    // Start function is called on each new game, in an array of size of the flags, real answers are enterted and then shuffled
    // and start game funciton is called for the first 0 index true answer 
    void Start()
    {
        realAnswersIndex = new int[flags.Length];
        for (int i = 0; i < flags.Length; i++)
        {
            flagNames[i] = flags[i].name;
            realAnswersIndex[i]=i;
        }

        Shuffle(realAnswersIndex);
        StartGame(realAnswersIndex[brojac]);
    }

    
    public void StartGame(int realIndex)
    {
        //indexRealAnswer = Random.Range(0, flags.Length);
        indexRealAnswer=realIndex;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = flags[indexRealAnswer];

        string vistinkoIme = flags[indexRealAnswer].name;
        
        
        string[] Names = new string[4];

        // generiraj random lista od indeksite na site mozni znaminja bez vistinskio index 
         // generiraj random lista od 3 lazni odgovori .

        
        List<int> differentAnswers = new List<int>();
        for (int runs = 0; runs < flags.Length; runs++)
        {   
            if (runs != indexRealAnswer){
                 differentAnswers.Add(runs);
            } 
           
        }

    
        int[] indexFakeAnwers = differentAnswers.ToArray();
      
        Shuffle(indexFakeAnwers);
       


        Names[0] = vistinkoIme;
        Names[1] = flagNames[indexFakeAnwers[0]];
        Names[2] = flagNames[indexFakeAnwers[1]];
        Names[3] = flagNames[indexFakeAnwers[2]];
        // ['mkd','aa','ss','aa']

        int [] shuffleList = {0,1,2,3};
        Shuffle(shuffleList);
        // shuffle na fake i real answer 
       // na buttonso se dodavat iminjata
        buttonA.GetComponentInChildren<Text>().text = Names[shuffleList[0]];
        buttonB.GetComponentInChildren<Text>().text = Names[shuffleList[1]];
        buttonC.GetComponentInChildren<Text>().text = Names[shuffleList[2]];
        buttonD.GetComponentInChildren<Text>().text = Names[shuffleList[3]];


    }
    public void Shuffle(int []decklist) {
         int tempGO;
         for (int i = 0; i < decklist.Length; i++) {
             int rnd = Random.Range(0, decklist.Length);
             tempGO = decklist[rnd];
             decklist[rnd] = decklist[i];
             decklist[i] = tempGO;
         }
    }

    public void CountPoints(){
        // take the clicked button answer
        string ClickedButtonName = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        int indexOfClickedButtonName = 0;
        
        for (int i= 0;i<flagNames.Length;i++)
        {
            if (ClickedButtonName == flagNames[i]){
                indexOfClickedButtonName=i;
                break;
            }
        }
        //print(indexOfClickedButtonName);
        if (indexRealAnswer == indexOfClickedButtonName)
        {
            audioSource.PlayOneShot(audioClipArray[0]);
            points++;
            pointsCounter.text = points.ToString();
        }
        else{
            audioSource.PlayOneShot(audioClipArray[2]);
            hearts[numberOfMistakes].SetActive(false);
            numberOfMistakes++;
        }
        brojac++;
        print(brojac);
        print(realAnswersIndex.Length);
        if(brojac == realAnswersIndex.Length){
            numberOfMistakes=3;
        }
        StartGame(realAnswersIndex[brojac]);
    }
    public int GetNumberOfMistakes(){
        return numberOfMistakes;
    }
    public void setGameOver(Sprite gameover){
        PlayerPrefs.SetInt("KeyPoints", points);
        int highestpoints = PlayerPrefs.GetInt("KeyHighestPoints", 0);
        if (points > highestpoints){
            PlayerPrefs.SetInt("KeyHighestPoints", points);
        }
        this.gameObject.GetComponent<SpriteRenderer>().sprite = gameover;
    }
    
}
