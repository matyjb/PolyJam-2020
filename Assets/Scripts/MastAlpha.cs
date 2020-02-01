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
        if( playerTransform.position.y < 0 || Mathf.Abs(playerTransform.position.x) > 5 )
            alpha = 1f;
        else
            alpha = .5f;

        Color c = spriteRenderer.material.color;
        c.a = alpha;
        spriteRenderer.material.color = c;
    }
}
