using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyHat : MonoBehaviour
{
    Rigidbody _rb;
    private Transform _rightControllerTransform;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rightControllerTransform = GameObject.Find("RightHand Controller").GetComponent<Transform>();
        _rb.AddForce(_rightControllerTransform.transform.forward * 400);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            ScoreManager.Instance.InrecementHit();
            Destroy(gameObject, 1);
        }
    }
}
