using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpecialBean : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject specialBean;

    public bool PointLeft;

    public LayerMask layer;

    void Start()
    {
        rb.mass = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude < 0.15f)
        {
            if(Physics2D.OverlapCircle(transform.position, 0.1f, layer)) 
            {
                rb.Sleep();
                SpawnSpecialBean(GameObject.FindWithTag("Player").GetComponent<LookAtMouse>().PointLeft);
                Destroy(this.gameObject);
            }
        }
    }

    

    public void SpawnSpecialBean(bool isPointingLeft)
    {
        PointLeft = isPointingLeft;
        Vector3 SpawnPosition = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
        GameObject specialBeanGO = Instantiate(specialBean, SpawnPosition, Quaternion.identity);
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
