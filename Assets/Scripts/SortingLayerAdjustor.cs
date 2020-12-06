using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class SortingLayerAdjustor : MonoBehaviour
{
    Transform t;
    SpriteRenderer sr;
    PlayerController player;

    // Use this for initialization
    void Awake()
    {
        t = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 myPos = t.position;

        if (playerPos.y > myPos.y)
        {
            sr.sortingOrder = 10;
        } else
        {
            sr.sortingOrder = 0;
        }
    }
}
