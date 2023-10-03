using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int _nextBall;
    [SerializeField] ImageManager _imageManager;
    [SerializeField] GameObject _nextBallPos;
    GameObject _nextBallImage;
    public override void AwakeFunction()
    {

    }

    public void NextBall()
    {
        Destroy(_nextBallImage);
        int i = Random.Range(0, 4);
        _nextBall = i;
        _nextBallImage = Instantiate(_imageManager._imageList[_nextBall], _nextBallPos.transform);
        Debug.Log(_nextBall);
    }

}
