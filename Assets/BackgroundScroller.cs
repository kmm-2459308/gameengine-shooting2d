using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // Start is called before the first frame update
    public float scrollSpeed = 2.0f; // ”wŒi‚ÌƒXƒNƒ[ƒ‹‘¬“x
    public Transform[] backgrounds;  // ”wŒiƒ^ƒCƒ‹‚Ì”z—ñ
    private float backgroundHeight;  // ”wŒi‚Ì‚‚³

    private void Start()
    {
        // Å‰‚Ì”wŒi‚Ì‚‚³‚ğæ“¾
        backgroundHeight = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {
        // ”wŒi‚ğc‚ÉˆÚ“®‚³‚¹‚é
        foreach (Transform background in backgrounds)
        {
            background.position += Vector3.down * scrollSpeed * Time.deltaTime;

            // ”wŒi‚ª‰æ–ÊŠO‚Éo‚½‚çÄ”z’u
            if (background.position.y <= -backgroundHeight)
            {
                background.position += Vector3.up * (backgroundHeight * backgrounds.Length);
            }
        }
    }
}
