using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField, Header("左側の最大値")] float _posLeft;
    [SerializeField, Header("右側の最大値")] float _posRight;
    [SerializeField] ItemManager itemManager;
    [SerializeField] float _speed = 0.1f;
    int _ballCount;
    int _next;
    GameObject _nowBall;
    Rigidbody2D _rd;
    // Start is called before the first frame update
    void Start()
    {
        //NextBall();

        ChangeBall();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetMouseButtonDown(0))
        {
            //オブジェクトを発射させる
            _rd.gravityScale = 1;
            this.gameObject.transform.DetachChildren();
            ChangeBall();
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        this.transform.position = new Vector3(transform.position.x + (x * _speed), transform.position.y, 0);
        if (_posLeft > transform.position.x)
        {
            transform.position = new Vector3(_posLeft, transform.position.y, 0);
        }
        if (_posRight < transform.position.x)
        {
            transform.position = new Vector3(_posRight, transform.position.y, 0);
        }
    }

    private void ChangeBall()
    {
        int i = _next;
        _nowBall = Instantiate(itemManager._ballObject[i], transform.position, Quaternion.identity, this.transform);
        _rd = _nowBall.GetComponent<Rigidbody2D>();
        _rd.gravityScale = 0; 
        NextBall();
    }

    private void NextBall()
    {
        int i = Random.Range(0, 4);
        _next = i;
        Debug.Log(_next);
    }
}
