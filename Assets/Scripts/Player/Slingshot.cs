using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Slingshot : MonoBehaviour
{
    public GameObject Player;
    public GameObject Projectile;
    public float projectileForce;
    public Transform projectilePoint;
    Vector2 direction;

    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;


    void Start()
    {
        points = new GameObject[numberOfPoints];
        for(int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, projectilePoint.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Player.transform.position;
        //Slingshot rotation
        Vector2 slingshotPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - slingshotPos;
        transform.right = direction;

        //Force calculation
        float Distance = Vector2.Distance(mousePos, slingshotPos);
        projectileForce = Distance * 2.25f;
        projectileForce = Mathf.Clamp(projectileForce, 0, 10);
        Debug.Log(Distance);


        //Shooting
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }
        //Trajectory
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
    }

    public void Shoot()
    {
        GameObject newProjectile = Instantiate(Projectile, projectilePoint.position, projectilePoint.rotation);
        newProjectile.GetComponent<Rigidbody2D>().velocity = transform.right * projectileForce;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 pos = (Vector2)projectilePoint.transform.position + (direction.normalized * projectileForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return pos;
    }
}