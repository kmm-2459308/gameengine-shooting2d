using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // Start is called before the first frame update
    public float scrollSpeed = 2.0f; // 背景のスクロール速度
    public Transform[] backgrounds;  // 背景タイルの配列
    private float backgroundHeight;  // 背景の高さ

    private void Start()
    {
        // 最初の背景の高さを取得
        backgroundHeight = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {
        // 背景を縦に移動させる
        foreach (Transform background in backgrounds)
        {
            background.position += Vector3.down * scrollSpeed * Time.deltaTime;

            // 背景が画面外に出たら再配置
            if (background.position.y <= -backgroundHeight)
            {
                background.position += Vector3.up * (backgroundHeight * backgrounds.Length);
            }
        }
    }
}
