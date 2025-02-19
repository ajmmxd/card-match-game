using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] GameObject Cardprefab;
    [SerializeField] List<CardsSO> AllCardsSO;
    private List<CardsSO> selectedCards = new List<CardsSO>();



    public void EasyMode()
    {
       
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

    }

    public void HardMode()
    {

    }
}
