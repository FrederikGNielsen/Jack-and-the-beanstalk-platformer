using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Slingshot : MonoBehaviour
{
    public int Stones;
    public int maxStones;

    public GameObject Player;
    public GameObject Projectile;
    public float projectileForce;
    public Transform projectilePoint;
    Vector2 direction;

    public float chargeTime;
    public float totalTime;

    //UI
    public TMPro.TMP_Text stoneText;
    

    //Trajectory
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

        //Force calculation     mouse distance = amount of force
        //float Distance = Vector2.Distance(mousePos, slingshotPos);
        //projectileForce = Distance * 2.25f;
        //projectileForce = Mathf.Clamp(projectileForce, 5, 10);



        //Shooting
        //if (Input.GetMouseButtonDown(1))
        //{
        //    if(Stones > 0)
        //    {
        //        chargeTime = Time.time;
        //        Debug.Log(chargeTime);
        //    }
        //}

        //Slingshot charge
        if(Stones > 0)
        {
            if (Input.GetMouseButton(1))
            {
                chargeTime += Time.deltaTime;
                projectileForce = chargeTime * 3.5f + 2;
                projectileForce = Mathf.Clamp(projectileForce, 2, 10);
            }
            if (Input.GetMouseButtonUp(1))
            {
                Shoot();
                chargeTime = 0.0f;
                projectileForce = chargeTime;
            }
        }

        


        //Trajectory
        for (int i = 0; i < numberOfPoints; i++)
        {
            if(projectileForce > 0)
            {
                points[i].gameObject.SetActive(true);
                points[i].transform.position = PointPosition(i * spaceBetweenPoints);
            }   else
            {
                points[i].gameObject.SetActive(false);
            }

        }
    }

    public void Shoot()
    {
        GameObject newProjectile = Instantiate(Projectile, projectilePoint.position, projectilePoint.rotation);
        newProjectile.GetComponent<Rigidbody2D>().velocity = transform.right * projectileForce;
        Stones--;
        updateUI();

    }

    Vector2 PointPosition(float t)
    {
        Vector2 pos = (Vector2)projectilePoint.transform.position + (direction.normalized * projectileForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return pos;
    }

    public void updateUI()
    {
        stoneText.text = "Stones: " + Stones;
    }
}