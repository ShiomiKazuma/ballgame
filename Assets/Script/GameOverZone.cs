using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOverZone : MonoBehaviour
{
    [SerializeField] GameObject _text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ゲームオーバー時の処理
        Text text = _text.GetComponent<Text>();
        text.text = "Game Over";
        _text.SetActive(true);
        Time.timeScale = 0;
    }
}
