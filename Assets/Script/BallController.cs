using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //アイテム通しが当たった時の処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.gameObject.name == collision.gameObject.name)
        {
            //２つのアイテムを破棄して中間地点にアイテムを生成
            Vector3 pos;
            pos.x = (this.transform.position.x + collision.transform.position.x) / 2;
            pos.y = (this.transform.position.y + collision.transform.position.y) / 2;
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            Instantiate(collision.gameObject, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
        }
    }
}
