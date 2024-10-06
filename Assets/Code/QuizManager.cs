using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{

    public int currentQuestionIndex;
    public List<QuizQuestion> questions;
    public TextMeshProUGUI questionTextBox;
    public List<TextMeshProUGUI> anwsersTextBoxes;

    public int correntAnswerIndex = 0;

    private void Start()
    {
        questions = new List<QuizQuestion>
        {
            new QuizQuestion(
                "Quick refresher: What is an exoplanet?",
                "A planet that orbits a star outside our solar system",
                "A planet within our solar system",
                "A natural satellite like the Moon"
            ),
            new QuizQuestion(
                "What is the equilibrium temperature of this planet?",
                "300 to 400 Kelvin",
                "200 to 300 Kelvin",
                "400 to 500 Kelvin"
            ),
            new QuizQuestion(
                "Is the atmosphere likely to be dense?",
                "Yes, its likely to be dense",
                "No, its likely to be thin",
                "It is not dense nor thin."
            ),
            new QuizQuestion(
                "Is this planet suitable for life?",
                "No, its not suitable for life.",
                "Yes, it is suitable for life",
                "Maybe"
            ),
        };

        currentQuestionIndex = 0;

        LoadQuestion(questions[currentQuestionIndex]);
    }

    public void LoadQuestion(QuizQuestion question, bool afterCorrect=false)
    {
        questionTextBox.text = question.question;

        foreach (TextMeshProUGUI textBox in anwsersTextBoxes)
        {
            textBox.text = string.Empty;
        }

        if (GameManager.i.DescriptiveAudioOn)
        {
            string before = string.Empty;

            if (afterCorrect)
            {
                before = "Correct answer. Next question: ";
            }

            TextToSpeechManager.instance.TextToSpeechReal(before + question.question, true);
        }

        // This code is to randomize the answer's order
        correntAnswerIndex = Random.Range(0, 3);
        anwsersTextBoxes[correntAnswerIndex].text = question.correctAwnser;
        List<int> otherIndexes = new List<int>{0, 1, 2};
        otherIndexes.Remove(correntAnswerIndex);
        int firstWrong = otherIndexes[Random.Range(0, 2)];
        otherIndexes.Remove(firstWrong);
        anwsersTextBoxes[firstWrong].text = question.falseAnwser1;
        anwsersTextBoxes[otherIndexes[0]].text = question.falseAnwser2;

        // Make a 2 answer question
        if (currentQuestionIndex + 1 == questions.Count) { anwsersTextBoxes[otherIndexes[0]].transform.parent.gameObject.SetActive(false); }

    }

    public void Anwser(int boxIndex)
    {
        if (boxIndex == correntAnswerIndex)
        {
            Correct();
        }
        else
        {
            Wrong();
        }
    }

    public void Correct()
    {
        Debug.Log("Correct");
        currentQuestionIndex += 1;

        if (currentQuestionIndex < questions.Count)
        {

            if (currentQuestionIndex == 1)
            {
                string t ="Correct, an exoplanet is any planet that orbits a star other than the Sun. Most of the exoplanets discovered are hundreds or thousands of light years away, offering unique insights into different planetary systems.";
                TextToSpeechManager.instance.TextToSpeechReal(t, true);
                gameObject.SetActive(false);
            }
            LoadQuestion(questions[currentQuestionIndex], true);
        }
        else
        {
            TextToSpeechManager.instance.TextToSpeechReal("Correct answer.", true);
            gameObject.SetActive(false);
        }
    }

    public void Wrong()
    {
        Debug.Log("Wrong");
        TextToSpeechManager.instance.TextToSpeechReal("Wrong answer. Try again: " + questions[currentQuestionIndex].question);
    }

}

public class QuizQuestion
{
    public string question;
    public string correctAwnser;
    public string falseAnwser1;
    public string falseAnwser2;

    public QuizQuestion(string question, string correct, string false1, string false2)
    {
        this.question = question;
        this.correctAwnser = correct;
        this.falseAnwser1 = false1;
        this.falseAnwser2 = false2;
    }
}