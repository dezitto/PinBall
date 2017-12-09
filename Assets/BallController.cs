
    using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //得点を表示するテキスト
    private Text Score;
    //スコアの定義
    private int score = 0;


    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        GameObject tennsuu = GameObject.Find("ScoreText");
        Score = tennsuu.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {

        //ボールが衝突した時の得点の追加
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 10;
            Score.text = "score: " + score.ToString();
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score += 50;
            Score.text = "score: " + score.ToString();
        }
        else if (other.gameObject.tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            score += 100;
            Score.text = "score: " + score.ToString();
        }
    }

}
