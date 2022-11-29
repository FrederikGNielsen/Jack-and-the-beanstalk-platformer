using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBean : MonoBehaviour
{
    private float fallTime;
    public Rigidbody2D rb;
    private bool sleeping;

    public GameObject specialBean;



    void Start()
    {
        rb.mass = 10.0f;
        sleeping = false;
        fallTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (fallTime > 1.0f)
        {
            if (sleeping)
            {
                rb.WakeUp();
                Debug.Log("wakeup");
            }
            else
            {
                rb.Sleep();
                Debug.Log("sleep");
                SpawnSpecialBean();
                Destroy(this.gameObject);

            }

            sleeping = !sleeping;

            fallTime = 0.0f;
        }

        fallTime += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
    }

    public void SpawnSpecialBean()
    {
        Vector3 SpawnPosition = new Vector3(transform.position.x, transform.position.y - 10f, transform.position.z);
        GameObject specialBeanGO = Instantiate(specialBean, transform.position, Quaternion.identity);
    }

}
