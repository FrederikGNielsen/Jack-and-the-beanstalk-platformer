using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpecialBean : MonoBehaviour
{
    private float fallTime;
    public Rigidbody2D rb;
    private bool sleeping;

    public GameObject specialBean;

    public bool PointLeft;



    void Start()
    {
        rb.mass = 10.0f;
        sleeping = false;
        fallTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude < 0.05f)
        {
            rb.Sleep();
            Debug.Log("sleep");
            SpawnSpecialBean();
            Destroy(this.gameObject);
        }
    }



    public void SpawnSpecialBean()
    {
        Vector3 SpawnPosition = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
        GameObject specialBeanGO = Instantiate(specialBean, SpawnPosition, Quaternion.identity);
        GameObject player = GameObject.Find("Player");
        PointLeft = player.GetComponent<LookAtMouse>().PointLeft;
        if (PointLeft == true)
        {
            Vector3 localScale = specialBeanGO.transform.localScale;
            localScale.x = 1f;
            specialBeanGO.transform.localScale = localScale;
        }
        if (PointLeft == false)
        {
            Vector3 localScale = specialBeanGO.transform.localScale;
            localScale.x = -1f;
            specialBeanGO.transform.localScale = localScale;
        }
        Destroy(specialBeanGO, 6f);
    }
}
