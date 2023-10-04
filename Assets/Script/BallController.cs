using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    static int _totalNumber = 0;
    public int SelfNumber { get; set; } = 0;
    [SerializeField] int _level = 0;
    [SerializeField] int _levelMax = 0;
    void Awake()
    {
        _totalNumber++;
        SelfNumber = _totalNumber;
    }
    //アイテム通しが当たった時の処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ItemManager.Instance.BallObject[0];
        if(collision.transform.TryGetComponent(out BallController ball) && ball.SelfNumber < SelfNumber)
        {
            if(_level == ball._level && !(_level == _levelMax))
            {
                //２つのアイテムを破棄して中間地点にアイテムを生成
                Vector3 pos;
                pos.x = (this.transform.position.x + collision.transform.position.x) / 2;
                pos.y = (this.transform.position.y + collision.transform.position.y) / 2;
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
                Instantiate(ItemManager.Instance.BallObject[_level + 1], new Vector3(pos.x, pos.y, 0), Quaternion.identity);
            }        
        }
    }
}
