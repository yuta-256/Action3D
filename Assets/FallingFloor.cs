using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    private Vector3 initialPosition;// 初期位置
    private bool Falling;// 落ちるか落ちないか判定する変数
    private int FallingSpeed = 10;// 落ちるスピード

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;// initialPositionに初期位置を代入
    }

    // Update is called once per frame
    void Update()
    {
        if (Falling == true)// もし、Fallingがtrueなら、
        {
            transform.position -= new Vector3(0, FallingSpeed * Time.deltaTime, 0);// 床を落とす
        }

        if (transform.position.y <= -10)// もし、床の座標が-10以下なら
        {
            transform.position = initialPosition;// 座標を初期位置に戻す
            Falling = false;// Fallingをfalseにする
        }
    }

    private void OnCollisionEnter(Collision collision)// 衝突した時の処理
    {
        if (collision.gameObject.tag == "Player")// もし触れたオブジェクトのタグがPlayerなら、
        {
            Falling = true;// Fallingをtrueにする
        }
    }
}