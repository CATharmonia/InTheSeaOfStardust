using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chara_Move : MonoBehaviour
{
    public Camera mainCamera;
    public Text testText;

    private const float MAXSPEED = 15;
    public Rigidbody2D rig2D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //各インプットから角度を算出
        Vector2 moveVector = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            moveVector += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVector += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVector += Vector2.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVector += Vector2.left;
        }
        //メインカメラのローカルに直す
        moveVector = mainCamera.transform.TransformVector(moveVector).normalized;
        //力を加える
        if (rig2D.velocity.magnitude < MAXSPEED)
        {
            rig2D.AddForce(moveVector * 2);
        }
        else
        {
            rig2D.AddForce(Vector2.zero - rig2D.velocity);
        }
        var screenPos = Input.mousePosition;

        // スクリーン座標をワールド座標に変換
        var worldPos = mainCamera.ScreenToWorldPoint(screenPos);


        Quaternion lookRotation = Quaternion.LookRotation(worldPos - transform.position, Vector3.forward);

        lookRotation.x = 0;
        lookRotation.y = 0;
        //マウスの方向に向ける
        transform.rotation = lookRotation;
        //向き補正
        transform.Rotate(new Vector3(0, 0, 120));
    }
}
