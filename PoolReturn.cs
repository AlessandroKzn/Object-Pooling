using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturn : MonoBehaviour
{
    public Transform player;

    public float speed;

    Rigidbody rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

    }


    private void OnEnable()
    {
        Invoke("HideMe", 2f);
    }

    void HideMe()
    {
        rig.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
