using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    Text _text;
    int _score = 0;
    
    public void AddScore(int _level)
    {
        _score += _level * 5;
        _text.text = "Score:" + _score.ToString();
    }
}
