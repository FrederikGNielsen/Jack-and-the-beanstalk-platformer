using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrajectoryTransparent : MonoBehaviour
{
    public GameObject Point;
    public GameObject Player;

    public float transparency;
    void Start()
    {
        Vector2 PointPos = new Vector2(Point.transform.position.x, Point.transform.position.y);
        Vector2 PlayerPos = new Vector2(Player.transform.position.x, Player.transform.position.y);
        float distance = Vector2.Distance(PointPos, PlayerPos);
        transparency = distance *= 2.5f;
        this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, transparency);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
