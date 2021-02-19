using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Rigidbody potBody;
    public SphereCollider coll;
    public Transform player, objectHolder, fpsCam;

    public Transform PotatoSpawn;
    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public static bool playerIsHoldingObject;


    public void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;

        if (!playerIsHoldingObject && distanceToPlayer.magnitude <= pickUpRange && Input.GetMouseButtonDown(0))
        {
            Pick();
        }
        else if (playerIsHoldingObject && Input.GetMouseButtonDown(0))
        {
            Drop();
        }

        if (transform.position.y <= -20)
        {
            potBody.angularDrag = 50000f;

            transform.SetParent(PotatoSpawn);
            potBody.velocity = Vector3.zero;

            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.SetParent(null);
            potBody.angularDrag = 0.05f;

        }

    }
    public void Pick()
    {
        playerIsHoldingObject = true;

        transform.SetParent(objectHolder);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);


        potBody.isKinematic = true;
        coll.isTrigger = true;
    }
    public void Drop()
    {
        playerIsHoldingObject = false;

        transform.SetParent(null);

        potBody.isKinematic = false;
        coll.isTrigger = false;

        potBody.velocity = player.GetComponent<Rigidbody>().velocity;

        potBody.AddForce(fpsCam.forward*dropForwardForce, ForceMode.Impulse);
        potBody.AddForce(fpsCam.up*dropUpwardForce, ForceMode.Impulse);

        float random = Random.Range(-1f, -1f);
        potBody.AddTorque(new Vector3(random, random, random)*10);



    }


}
