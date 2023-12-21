using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Security.Cryptography;
using UnityEngine;

public class Buckys : MonoBehaviour
{
    [SerializeField]
    int time_hovered = 0;
    [SerializeField]
    Material hover_mat;
    [SerializeField]
    Material normal_mat;
    [SerializeField]
    GameObject right_hand;

    public bool start_count = false;
    // Start is called before the first frame update
    void Start()
    {
        normal_mat = gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(start_count)
        {
            Count();
        }

        if(time_hovered > 200)
        {
            StartCoroutine(doFunThing());
            public_resetTime();
        }
        

    }

    void OnTriggerEnter(Collider other)
    {
        start_count = true;
        gameObject.GetComponent<MeshRenderer>().material = hover_mat;
    }

    void OnTriggerExit(Collider other)
    {
        start_count = false;
        gameObject.GetComponent<MeshRenderer>().material = normal_mat;
        public_resetTime();
    }

    void Count()
    {
        time_hovered++;
    }

    void checkForWave()
    {


    }

    IEnumerator doFunThing()
    {
        UnityEngine.Debug.Log("I made it");
        transform.Rotate(0f, 3f, 0f, Space.Self);
        gameObject.GetComponent<MeshRenderer>().material = normal_mat;
        yield return new WaitForSeconds(0.5f);
    }

    public void setStart(bool b)
    {
        start_count = b;
    }

    public void public_resetTime()
    {
        StartCoroutine(resetTime());
    }
    IEnumerator resetTime()
    {
        yield return new WaitForSeconds(.5f);
        time_hovered = 0;
        setStart(false);
    }

    IEnumerator sayHello()
    {
        UnityEngine.Debug.Log("Hi!");
        transform.localScale = new Vector3(4f, 4f, 4f);
        gameObject.GetComponent<MeshRenderer>().material = normal_mat;
        yield return new WaitForSeconds(2f);
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}

