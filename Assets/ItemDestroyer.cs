using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    //Unityちゃんとカメラの距離
    private float differrence;

    //最初に設定した高さ
    private float posY;




    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");


        //Unityちゃんと位置（z座標）の差を求める
        this.differrence = unitychan.transform.position.z - this.transform.position.z;


        //最初に設定した高さを代入
        posY = this.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの位置に合わせて位置を移動
        this.transform.position = new Vector3(0, this.posY, this.unitychan.transform.position.z - differrence);

    }

    //***************************************************************************
    //ユニティちゃんが通り過ぎて画面外に出たアイテムを直ちに破棄
    //***************************************************************************
    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag" || other.gameObject.tag == "CoinTag")
        {
            //衝突相手のゲームオブジェクトを破棄
            Destroy(other.gameObject);
        }

            
    }
}
