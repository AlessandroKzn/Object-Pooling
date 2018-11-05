using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolShooter : MonoBehaviour
{
    public float fireRate = 1f;

    float timer;

    int state;

    float force = 200;

    public Transform target,spawn;
  

    private void Update()
    {
        

        print(1f / Time.deltaTime);
        timer += Time.deltaTime;

        if (timer>0.2f)
        {
            timer = 0;

            state = Random.Range(0, 1);

            Fire();

        }
        spawn.transform.Rotate(0, 0, 8);

        transform.rotation = Quaternion.LookRotation(target.position-transform.position);
    }


    void Fire()
    {
        GameObject obj = PoolerScript.current.GetPooledObject();

        if (obj == null) return;


        if (state == 1)
        {
            obj.transform.rotation = transform.rotation;
            force = 200f;
        }
        else if (state == 0)
        {
            obj.transform.rotation = transform.rotation;
            transform.rotation = Quaternion.identity;
            force = 500f;
        }


        obj.transform.position = transform.position;
        obj.SetActive(true);
        if (obj.GetComponent<Rigidbody>().velocity == Vector3.zero)
            obj.GetComponent<Rigidbody>().AddForce(transform.up * force);



    }
}
