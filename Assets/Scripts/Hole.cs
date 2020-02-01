using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public bool fixedHole;
    public bool walkable;

    SpriteRenderer spriteRenderer;
    public Sprite holeSprite;
    public Sprite fixedHoleSprite;

    CircleCollider2D collider;
    

    void Start()
    {
        fixedHole = false;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = holeSprite;

        collider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        // Temporary
        if( fixedHole ) Fix();
        else Break();
    }

    public void Fix()
    {
        fixedHole = true;
        spriteRenderer.sprite = fixedHoleSprite;
        collider.enabled = false;
    }

    public void Break()
    {
        fixedHole = false;
        spriteRenderer.sprite = holeSprite;
        collider.enabled = true;
    }
}
