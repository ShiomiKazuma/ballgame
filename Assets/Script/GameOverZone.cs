using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverZone : MonoBehaviour
{
    [SerializeField] Text _text;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�Q�[���I�[�o�[���̏���
        _text.text = "Game Over";
        
    }
}
