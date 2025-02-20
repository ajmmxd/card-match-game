using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int matches;
    public int MatchNumbers;
    public int HighScore;
    public int CurrentScore;
    public int CardA;
    public int CardB;
    public bool SelectCardA;
    public bool SelectCardB;
    public bool RightMatch;
    public bool Notmatch;




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }


        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        CardA = 0;
        CardB = 0;
    }


    private void Update()
    {
        if (CurrentScore > HighScore) { 
        
            HighScore = CurrentScore;
        
        }

        



    }

    public void CheckCards()
    {
        
        if (CardA == CardB && SelectCardB == true)
        {
            RightMatch = true;
            SelectCardB = false;
            CurrentScore++;
            MatchNumbers = MatchNumbers + 1;
            StartCoroutine(Values());
        }
        else
        {
           Notmatch = true;  
            StartCoroutine(Values());

        }
    }


    private IEnumerator Values()
    {
        yield return new WaitForSeconds(0.1f);

        CardA = 0;
        CardB = 0;
        SelectCardA = false;
        SelectCardB = false;
    }
}