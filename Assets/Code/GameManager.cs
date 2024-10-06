using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Instance
    public static GameManager i;

    // Systems
    public NoteManager noteSystem;
    public QuizManager quizSystem;

    // Minigame
    public GameObject minigame;
    public Transform canvasTransform;

    // Descriptive Audio
    public bool DescriptiveAudioOn = true;

    // Planets & Visualization
    public Exoplanet currentPlanet;
    public Image mainScreen;
    public TextMeshProUGUI screenBottomText;

    // Buttons
    public GameObject map;
    public GameObject arrows;
    public TextMeshProUGUI descriptiveAudioTextbox;

    private void Awake()
    {
        i = this;
    }

    private void Start()
    {
        LoadPlanet(currentPlanet);
        StartCoroutine(GameStart());
    }

    public IEnumerator GameStart()
    {
        // Adrian, Sergio me dijo que queria poner un audio antes de que iniciara el "Juego"
        // Si te lo piden a ti (y estoy zzz), nomas pones aqui la funcion que le ponga play al audio.
        yield return new WaitForSeconds(0f); // Y aqui en vez de 0f pones lo que dure el audio

        yield return new WaitForEndOfFrame();
        EnterQuiz();
    }

    public void LoadPlanet(Exoplanet planet)
    {
        currentPlanet = planet;
        currentPlanet.Reset();
        UpdateScreen();
        AudioManager.instance.PlanetSelectSong();
    }

    public void ExitLocation()
    {
        if (currentPlanet != null)
        {
            AudioManager.instance.PlanetSelectSong();
            currentPlanet.ExitLocation();
        }

        UpdateScreen();
    }

    public void GoToLocation(int index)
    {
        if (currentPlanet != null)
        {
            AudioManager.instance.PlayMenuSelect();
            AudioManager.instance.PlayLavaLoop();
            currentPlanet.GoLocation(index);
            UpdateScreen();
        }
    }

    public void LookAround(int dir)
    {
        AudioManager.instance.PlayMenu3();
        if (dir == -1)
        {
            currentPlanet.currentLocation.Left();
        }
        else if (dir == 1)
        {
            currentPlanet.currentLocation.Right();
        }

        UpdateScreen();
    }

    public void UpdateScreen()
    {
        if (currentPlanet != null)
        {
            mainScreen.sprite = currentPlanet.GetCurrentImage();

            map.SetActive(!currentPlanet.InLocation());
            arrows.SetActive(currentPlanet.InLocation());

            if (currentPlanet.InLocation())
            {
                screenBottomText.text = currentPlanet.currentLocation.GetDescription();

                if (DescriptiveAudioOn)
                {
                    TextToSpeechManager.instance.TextToSpeechReal(screenBottomText.text);
                }
            }
            else
            {
                screenBottomText.text = "";
            }

        }
    }

    public void EnterQuiz()
    {
        AudioManager.instance.PlayMenu2();
        quizSystem.gameObject.SetActive(true);
        if (quizSystem.questions != null)
        {
            if (quizSystem.questions.Count > quizSystem.currentQuestionIndex)
            {
                quizSystem.LoadQuestion(quizSystem.questions[quizSystem.currentQuestionIndex]);
            }
        }
    }

    public void LaunchMinigame(string objective)
    {
        GameObject minigameInstance = Instantiate(minigame, canvasTransform);
        MinigameFind myGame = minigameInstance.GetComponent<MinigameFind>();
        myGame.finding = objective;
    }

    public void DescritiveAudioToggle()
    {
        DescriptiveAudioOn = !DescriptiveAudioOn;
        Debug.Log($"Descriptive Audio: {DescriptiveAudioOn}");

        if (DescriptiveAudioOn)
        {
            TextToSpeechManager.instance.TextToSpeechReal("Descriptive Audio was activated");
            descriptiveAudioTextbox.text = "Deactivate Descriptive Audio";
        }
        else
        {
            TextToSpeechManager.instance.TextToSpeechReal("Descriptive Audio was deactivated");
            descriptiveAudioTextbox.text = "Activate Descriptive Audio";
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
