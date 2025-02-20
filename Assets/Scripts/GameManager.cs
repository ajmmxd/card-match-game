using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public TextMeshProUGUI Matchesplayed;
    public TextMeshProUGUI PlayerHighScore;
    public TextMeshProUGUI PlayerCurrentScore;
    private AudioSource AudioSource;
    public AudioClip RightAnswer;
    public AudioClip WrongAnswer;
    public AudioClip Over;
    public AudioClip Shuffle;
    public AudioClip Win;
    private bool isCheckingCards = false;





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
        LoadGame();
        AudioSource = GetComponent<AudioSource>();
        CardA = 0;
        CardB = 0;
    }


    private void Update()
    {
        if (CurrentScore > HighScore)
        {

            HighScore = CurrentScore;

        }

     

        PlayerHighScore.text = "High Score: " + HighScore.ToString();
        PlayerCurrentScore.text = "Score: " + CurrentScore.ToString();
        Matchesplayed.text = "Matches :" + matches.ToString();


       





    }

    public void CheckCards()
    {
        if (isCheckingCards)
            return;

        isCheckingCards = true;


        if (CardA == CardB && SelectCardB == true)
        {
            RightMatch = true;
            SelectCardB = false;
            CurrentScore++;
            MatchNumbers = MatchNumbers + 1;           
            StartCoroutine(Values());
            AudioSource.PlayOneShot(RightAnswer);
            SaveGame();
        }
        else
        {
            Notmatch = true;
            AudioSource.PlayOneShot(WrongAnswer);
            StartCoroutine(Values());

        }
    }


    private IEnumerator Values()
    {

        yield return new WaitForSeconds(0.5f);


        CardA = 0;
        CardB = 0;
        SelectCardA = false;
        SelectCardB = false;
        Notmatch = false;
        RightMatch = false;

        isCheckingCards = false;
    }

    public void OverSound()
    {
        AudioSource.PlayOneShot(Over);
    }

    public void ShuffleSound()
    {


        AudioSource.PlayOneShot(Shuffle);
    }


    public void SaveGame()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.SetInt("matches", matches); 
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            HighScore = PlayerPrefs.GetInt("HighScore");
        }

        if (PlayerPrefs.HasKey("matches")) 
        {
            matches = PlayerPrefs.GetInt("matches");
        }
    }

    public void WinGame()
    {
        AudioSource.PlayOneShot(Win);
    }

    public void StopWinMusic()
    {
        AudioSource.Stop();
    }


    public void QuitGame()
    {
        
        Application.Quit();

       
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}