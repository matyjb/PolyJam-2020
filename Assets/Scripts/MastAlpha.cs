using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastAlpha : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Transform playerTransform;
    float alpha;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = GameManager.instance.player.transform;
        alpha = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float fadeSpeed = 5f;
        bool fadeOut = playerTransform.position.y > 0 && Mathf.Abs( playerTransform.position.x ) < 5;

        alpha = Mathf.Lerp( alpha, fadeOut ? .5f : 1f, fadeSpeed * Time.deltaTime );

        Color c = spriteRenderer.material.color;
        c.a = alpha;
        spriteRenderer.material.color = c;
    }
}
