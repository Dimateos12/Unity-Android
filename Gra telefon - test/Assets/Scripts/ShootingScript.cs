using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    // public GameObject bolt;

    private Vector3 target;

    public GameObject boltPrefab;
    public GameObject boltSpawnPoint;
    public float boltSpeed = 60.0f;

    private int boltsAvailable = 4;
    public bool needToReload = false;

    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Vector3 difference = target - boltSpawnPoint.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + 90.0f;

        if (boltsAvailable <= 0)
        {
            needToReload = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if (Input.GetMouseButtonDown(0) && !needToReload)
        {
            // fire bullet
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            FireBullet(direction, rotationZ);
            boltsAvailable--;
        }
    }

    private void FireBullet(Vector2 direction, float rotationZ)
    {
            GameObject b = Instantiate(boltPrefab);
            b.transform.position = boltSpawnPoint.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * boltSpeed;
    }   

    private void Reload()
    {
        boltsAvailable = 4;
        needToReload = false;
    }
}

