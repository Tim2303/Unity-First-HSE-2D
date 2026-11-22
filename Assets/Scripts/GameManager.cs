using System;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text numberText;
    public TMP_Text scoreText;
    public TMP_Text bestText;

    private int _currentNumber;
    private int _score = 0;
    private int _best = 0;

    void Start()
    {
        GenerateNumber();
        UpdateUI();
    }

    void GenerateNumber()
    {
        _currentNumber = Random.Range(1, Int32.MaxValue);

        numberText.text = "Is digital root of this number even or odd?\n\nNumber: " + _currentNumber;
    }
    
    int GetDigitalRoot(int number)
    {
        return number == 0 ? 0 : 1 + (number - 1) % 9;
    }
    
    public void CheckAnswer(bool playerSaysEven)
    {
        int root = GetDigitalRoot(_currentNumber);

        bool isEven = root % 2 == 0;

        if (playerSaysEven == isEven)
        {
            _score++;
            _best = Math.Max(_score, _best);
        }
        else
        {
            _score = 0;
        }

        UpdateUI();
        GenerateNumber();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + _score;
        bestText.text = "Best: " + _best;
    }
    
    public void AnswerEven()
    {
        CheckAnswer(true);
    }

    public void AnswerOdd()
    {
        CheckAnswer(false);
    }
}
