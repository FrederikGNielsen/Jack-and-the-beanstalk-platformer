using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    public GameObject canvas;
    public LayerMask playerLayer;
    public int LevelSwitch;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.OverlapCircle(transform.position, 2f, playerLayer)) {
            GameObject.Find("Slingshot").GetComponent<Slingshot>().canShoot= false;
            canvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("GM").GetComponent<PlayerData>().saveData();
                Debug.Log("Open door");
                SceneManager.LoadScene(LevelSwitch);
            }
        } else
        {
            GameObject.Find("Slingshot").GetComponent<Slingshot>().canShoot = true;
            canvas.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.SetActive(false);
    }
}
