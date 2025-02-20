using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardController : MonoBehaviour
{
    [SerializeField] GameObject Cardprefab;
    [SerializeField] List<CardsSO> AllCardsSO;
    private List<CardsSO> selectedCards = new List<CardsSO>();

    public int NumberOfMatches;
    public int GamesPlayed;
    public bool Easy;
    public bool Normal;
    public bool Hard;
    public GameObject Restart;
    private GridLayoutGroup ObjectGrid;



    private void Start()
    {
        ObjectGrid = GetComponent<GridLayoutGroup>();
    }
    private void Update()
    {
        NumberOfMatches = GameManager.Instance.MatchNumbers;

       

        if (Easy == true && NumberOfMatches >= 2)
        {
            Restart.SetActive(true);
            GameManager.Instance.WinGame();
          
            Easy = false;

        }

        if (Normal == true && NumberOfMatches >= 3) {

            Restart.SetActive(true);
            GameManager.Instance.WinGame();
            Normal = false;

        }

        if (Hard == true && NumberOfMatches >= 15)
        {
            Restart.SetActive(true);
            GameManager.Instance.WinGame();
            Hard = false;



        }
    }

    public void EasyMode()
    {
        GameManager.Instance.CurrentScore = 0;
        ChangeGridConstraintCount(2);
        GamesPlayed++;
        GameManager.Instance.matches++;
        Easy = true;
        NumberOfMatches = 0;
        GameManager.Instance.MatchNumbers = 0;

        for (int i = 0; i < 4; i++)
        {
            selectedCards.Add(AllCardsSO[i]);
        }

       

        Shuffle(selectedCards);

      
        for (int i = 0; i < selectedCards.Count; i++)
        {
            GameObject cardInstance = Instantiate(Cardprefab, transform); 
            CardValue cardValue = cardInstance.GetComponent<CardValue>(); 
            if (cardValue != null)
            {
                cardValue.CardsSO = selectedCards[i]; 
                cardValue.CardsValue();
            }
        }
    }

   
    private void Shuffle(List<CardsSO> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count); 
            CardsSO temp = list[i]; 
            list[i] = list[randomIndex]; 
            list[randomIndex] = temp; 
        }
    }

    public void NormalMode()
    {
        GameManager.Instance.CurrentScore = 0;
        ChangeGridConstraintCount(3);



        GamesPlayed++;
        GameManager.Instance.matches++;
        Normal = true;
        NumberOfMatches = 0;
        GameManager.Instance.MatchNumbers = 0;

        for (int i = 0; i < 6; i++)
        {
            selectedCards.Add(AllCardsSO[i]);
        }



        Shuffle(selectedCards);


        for (int i = 0; i < selectedCards.Count; i++)
        {
            GameObject cardInstance = Instantiate(Cardprefab, transform);
            CardValue cardValue = cardInstance.GetComponent<CardValue>();
            if (cardValue != null)
            {
                cardValue.CardsSO = selectedCards[i];
                cardValue.CardsValue();
            }
        }

    }

    public void HardMode()
    {
        GameManager.Instance.CurrentScore = 0;
        ChangeGridConstraintCount(6);
        GameManager.Instance.matches++;
        GamesPlayed++;
        Hard = true;
        NumberOfMatches = 0;
        GameManager.Instance.MatchNumbers = 0;

        for (int i = 0; i < 30; i++)
        {
            selectedCards.Add(AllCardsSO[i]);
        }



        Shuffle(selectedCards);


        for (int i = 0; i < selectedCards.Count; i++)
        {
            GameObject cardInstance = Instantiate(Cardprefab, transform);
            CardValue cardValue = cardInstance.GetComponent<CardValue>();
            if (cardValue != null)
            {
                cardValue.CardsSO = selectedCards[i];
                cardValue.CardsValue();
            }
        }
    }

    public void PlayAgain()
    {
        GameManager.Instance.StopWinMusic();
        selectedCards.Clear();

       
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        
        NumberOfMatches = 0;
        GameManager.Instance.MatchNumbers = 0;

        
       
        Restart.SetActive(false);
    }


    public void ChangeGridConstraintCount(int newCount)
    {
        ObjectGrid.constraintCount = newCount;
    }

}
