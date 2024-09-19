using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject2D : MonoBehaviour
{
    private Vector3 offset;      // オブジェクトと入力位置のオフセット
    private Camera cam;          // カメラ
    private bool isDragging;     // ドラッグ中かどうかのフラグ

    void Start()
    {
        // メインカメラを取得
        cam = Camera.main;
    }

    void Update()
    {
        // マウスボタンまたはタッチの検出
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            Vector2 inputPosition = Input.mousePosition;
            if (Input.touchCount > 0)
            {
                // タッチの場合
                inputPosition = Input.GetTouch(0).position;
            }

            // スクリーン座標からワールド座標に変換
            Vector3 worldPosition = cam.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, cam.nearClipPlane));
            Vector2 touchPosition = new Vector2(worldPosition.x, worldPosition.y);

            // オブジェクトがタッチまたはクリックされた場合
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null && collider.OverlapPoint(touchPosition))
            {
                isDragging = true;
                offset = transform.position - new Vector3(touchPosition.x, touchPosition.y, transform.position.z);
            }
        }

        // ドラッグ中の処理
        if (isDragging)
        {
            Vector2 inputPosition = Input.mousePosition;
            if (Input.touchCount > 0)
            {
                // タッチの場合
                inputPosition = Input.GetTouch(0).position;
            }

            // スクリーン座標からワールド座標に変換
            Vector3 worldPosition = cam.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, cam.nearClipPlane));
            Vector2 touchPosition = new Vector2(worldPosition.x, worldPosition.y);

            // オブジェクトの位置を更新
            transform.position = new Vector3(touchPosition.x, touchPosition.y, transform.position.z) + offset;

            // マウスボタンまたはタッチが終了した場合
            if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                isDragging = false;
            }
        }
    }
}
