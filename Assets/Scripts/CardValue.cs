using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardValue : MonoBehaviour
{
    public CardsSO CardsSO;
    public Image CardFront;
    public Image CardBack;
    public int CardNumberValue;
    public float rotationDuration = 1f;
    private Animator CardAnimator;


    private void Start()
    {
        CardAnimator = GetComponent<Animator>();
    }


    private void Update()
    {



    }


    public void CardsValue()
    {
        CardFront.sprite = CardsSO.CardImage;
        CardBack.sprite = CardsSO.CardBack;
        CardNumberValue = CardsSO.CardValue;

    }


    public void SelectCardA()
    {
        CardAnimator.SetBool("rotate", true);
        CardAnimator.SetBool("back", false);


        if (GameManager.Instance.CardA == 0)
        {

            GameManager.Instance.SelectCardA = true;
            CardFront.enabled = true;
            CardBack.enabled = false;
            GameManager.Instance.CardA = CardNumberValue;


            StartCoroutine(WaitForCardB());


        }


    }


    public void SelectCardB()
    {

        CardAnimator.SetBool("rotate", true);
        CardAnimator.SetBool("back", false);

        if (GameManager.Instance.CardA != 0)
        {



            if (GameManager.Instance.SelectCardA == true && GameManager.Instance.CardB == 0)
            {
                GameManager.Instance.SelectCardB = true;
                CardFront.enabled = true;
                CardBack.enabled = false;
                GameManager.Instance.CardB = CardNumberValue;

                StartCoroutine(CardMatch());



            }
        }
        else
        {
            SelectCardA();
        }
    }


    private IEnumerator WaitForCardB()
    {
        yield return new WaitUntil(() => GameManager.Instance.CardB != 0);
        GameManager.Instance.CheckCards();

        if (GameManager.Instance.RightMatch)
        {
            CardAnimator.SetBool("rotate", false);
            Debug.Log("RightMatch");
        }
        else
        {
            yield return new WaitUntil(() => GameManager.Instance.Notmatch);

            StartCoroutine(FlipCardsBack());
        }

        Debug.Log("INICIO");
    }

    private IEnumerator FlipCardsBack()
    {
        
        yield return new WaitForSeconds(0.1f);

        CardAnimator.SetBool("back", true);
        CardAnimator.SetBool("rotate", false);

        yield return new WaitForSeconds(1);
        CardFront.enabled = false;
        CardBack.enabled = true;
    }

    private IEnumerator CardMatch()
    {
        yield return new WaitUntil(() => GameManager.Instance.CardB != 0);

        GameManager.Instance.CheckCards();

        if (GameManager.Instance.RightMatch)
        {
            CardAnimator.SetBool("rotate", false);
            Debug.Log("RightMatch");
        }
        else
        {
            yield return new WaitUntil(() => GameManager.Instance.Notmatch);

            StartCoroutine(FlipCardsBack());
        }

        Debug.Log("SecondCard");
        






}
}
