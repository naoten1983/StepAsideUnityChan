using System.Collections;
using System.Collections.Generic;
using UnityChan;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    //carPrefabを入れる
    public GameObject carPreFab;

    //coinPrefabを入れる
    public GameObject coinPreFab;

    //cornPrefabを入れる
    public GameObject cornPreFab;

    //スタート地点
    //private int startPos = 80;

    //ゴール地点
    private int goalPos = 360;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;



    //アイテム生成の間隔時間を指定
    private float span = 1.0f;

    //前回のアイテム生成からの経過時間を格納する変数
    private float delta = 0;

    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    //Unityちゃんのオブジェクトにアタッチされたスクリプト
    UnityChanController script;

    //アイテムを生成する位置
    private float itemPos;



    //アイテムを生成する処理の関数
    void ItemGenerate(float a)
    {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);

            if (num < 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject corn = Instantiate(cornPreFab);
                    corn.transform.position = new Vector3(4 * j, corn.transform.position.y, a);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);

                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);


                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPreFab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, a + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPreFab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, a + offsetZ);
                    }
                }
            }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

        //UnityちゃんのオブジェクトにアタッチされているUnityChanControllerを取得
        script = unitychan.GetComponent<UnityChanController>();

        
    }

        // Update is called once per frame
        void Update()
    {
        //delta変数に経過時間を代入
        this.delta += Time.deltaTime;

        //前回のアイテム生成からの経過時間が指定の感覚時間を超えたら…
        if (this.delta > this.span)
        {
            //delta変数をリセットする
            this.delta = 0;

            //itemPos変数にユニティちゃんの50m先の位置を代入
            this.itemPos = this.unitychan.transform.position.z + 50;


            //アイテムの生成位置がゴール地点を超えていない、かつユニティちゃんがまだ死んでないとき
            if (this.itemPos < goalPos　&& script.isEnd is false)
            {
                //ItemGenerate関数を呼び出す
                ItemGenerate(this.itemPos);
            }
            
        }
    }
}
