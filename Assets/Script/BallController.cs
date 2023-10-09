using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    static int _totalNumber = 0;
    public int SelfNumber { get; set; } = 0;
    [SerializeField] int _level = 0;
    [SerializeField] int _levelMax = 0;
    bool _gameOverJudge = false;
    [SerializeField] GameObject _text;
    [SerializeField] GameObject _gameOverZone;
    ScoreManager _scoreManager;
    void Awake()
    {
        _totalNumber++;
        SelfNumber = _totalNumber;
        _scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void Update()
    {
        if(!(_gameOverJudge) && _gameOverZone.transform.position.y >= this.transform.position.y)
        {
            _gameOverJudge = true;
        }
        if (_gameOverZone.transform.position.y <= this.transform.position.y && _gameOverJudge)
        {
            Debug.Log("ゲームオーバー");
        }
    }
    //アイテム通しが当たった時の処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(!(_gameOverJudge))
        //{
        //    _gameOverJudge = true;
        //}
        //ItemManager.Instance.BallObject[0];
        if(collision.transform.TryGetComponent(out BallController ball) && ball.SelfNumber < SelfNumber)
        {
            if(_level == ball._level && !(_level == _levelMax))
            {
                //２つのアイテムを破棄して中間地点にアイテムを生成
                _scoreManager.AddScore(_level);
                Vector3 pos;
                pos.x = (this.transform.position.x + collision.transform.position.x) / 2;
                pos.y = (this.transform.position.y + collision.transform.position.y) / 2;
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
                Instantiate(ItemManager.Instance.BallObject[_level + 1], new Vector3(pos.x, pos.y, 0), Quaternion.identity);
            }        
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (_gameOverJudge && collision.gameObject.tag == "GameOver")
    //    {
    //        // ゲームオーバー時の処理
    //        //Text text = _text.GetComponent<Text>();
    //        //text.text = "Game Over";
    //        //_text.SetActive(true);
    //        //Time.timeScale = 0;
    //        Debug.Log("ゲームオーバー");
    //    }
    //}
}
