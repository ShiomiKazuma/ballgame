using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField, Header("¶‘¤‚ÌÅ‘å’l")] float _posLeft;
    [SerializeField, Header("‰E‘¤‚ÌÅ‘å’l")] float _posRight;
    [SerializeField] ItemManager itemManager;
    [SerializeField] float _speed = 0.1f;
    int _ballCount;
    int _next;
    GameObject _nowBall;
    // Start is called before the first frame update
    void Start()
    {
        //NextBall();

        ChangeBall();
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        this.transform.position = new Vector3 (transform.position.x + (x * _speed), transform.position.y, 0);
        if(_posLeft > transform.position.x)
        {
            transform.position = new Vector3(_posLeft, transform.position.y, 0);
        }
        if(_posRight < transform.position.x)
        {
            transform.position = new Vector3(_posRight, transform.position.y, 0);
        }

        if(Input.GetMouseButtonDown(0))
        {

        }
    } 

    private void ChangeBall()
    {
        int i = Random.Range(0, 4);
        _nowBall = Instantiate(itemManager._ballObject[i], transform.position, Quaternion.identity, this.transform);
        //_nowBall = Rigidbody2D
    }

    //private void NextBall()
    //{
    //    int i = Random.Range(0, 4);
    //    _next = i;
    //}
}
