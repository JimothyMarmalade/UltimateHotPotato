using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Potato : MonoBehaviour
{
    public Rigidbody potBody;
    public SphereCollider coll;
    public Transform player1, player2, fpsCam1, fpsCam2;
    public Transform player1Holder, player2Holder;

    public TMP_Text timeText1;
    public TMP_Text timeText2;
    public GameObject hudpanel;
    public GameObject gameoverpanel;

    public Transform PotatoSpawn;
    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public static bool playerIsHoldingObject;
    public static bool canBePickedUp = true;
    public int playerHoldingPotato = 0;

    public float timeToReset = 3f;
    public float currentTimeHeld = 0;
    public float cooldownTime = 0.5f;
    public void Start()
    {
        transform.position = PotatoSpawn.position;
    }

    public void Update()
    {
        if (transform.position.y <= -10)
        {
            Respawn();
        }

        if (playerHoldingPotato == 1)
        {
            currentTimeHeld += Time.deltaTime;
            float formatted = (timeToReset - currentTimeHeld);

            timeText1.text = "Potato Timer: " + formatted.ToString("#.00");
            timeText2.text = "Grab the Potato!";

        }
        else if (playerHoldingPotato == 2)
        {
            currentTimeHeld += Time.deltaTime;
            float formatted = (timeToReset - currentTimeHeld);

            timeText1.text = "Grab the Potato!";
            timeText2.text = "Potato Timer: " + formatted.ToString("#.00");
        }
        else
        {
            timeText1.text = "Grab the Potato!";
            timeText2.text = "Grab the Potato!";
        }

        if (currentTimeHeld >= timeToReset)
        {
            Drop();
            currentTimeHeld = 0;
        }
    }

    public void TryPickUp(int pnum)
    {
        Debug.Log("Running TryPickUp() with pnum " + pnum);
        if (pnum == 1)
        {
            if (!playerIsHoldingObject && Vector3.Distance(transform.position, player1.position) <= pickUpRange && canBePickedUp)
            {
                PickUp(pnum);
            }
            else if (playerIsHoldingObject)
            {
                Drop();
            }
        }
        else if (pnum == 2)
        {
            if (!playerIsHoldingObject && Vector3.Distance(transform.position, player2.position) <= pickUpRange && canBePickedUp)
            {
                PickUp(pnum);
            }
            else if (playerIsHoldingObject)
            {
                Drop();
            }
        }
    }

    public void PickUp(int pnum)
    {
        playerHoldingPotato = pnum;
        playerIsHoldingObject = true;

        switch(pnum)
        {
            case 1: 
                transform.SetParent(player1Holder);
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.Euler(Vector3.zero);
                break;
            case 2: 
                transform.SetParent(player2Holder);
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.Euler(Vector3.zero);
                break;
        }

        potBody.isKinematic = true;
        coll.isTrigger = true;
    }

    public void Drop()
    {
        playerIsHoldingObject = false;

        transform.SetParent(null);

        switch(playerHoldingPotato)
        {
            case 1: 
                transform.SetPositionAndRotation(player1Holder.position, Quaternion.Euler(Vector3.zero));
                potBody.isKinematic = false;
                coll.isTrigger = false;
                potBody.velocity = player1.GetComponent<CharacterController>().velocity;
                potBody.AddForce(fpsCam1.forward * dropForwardForce, ForceMode.Impulse);
                potBody.AddForce(fpsCam1.up * dropUpwardForce, ForceMode.Impulse);
                break;
            case 2:
                transform.SetPositionAndRotation(player2Holder.position, Quaternion.Euler(Vector3.zero));
                potBody.isKinematic = false;
                coll.isTrigger = false;
                potBody.velocity = player2.GetComponent<CharacterController>().velocity;
                potBody.AddForce(fpsCam2.forward * dropForwardForce, ForceMode.Impulse);
                potBody.AddForce(fpsCam2.up * dropUpwardForce, ForceMode.Impulse);
                break;
        }

        float random = Random.Range(-1f, -1f);
        potBody.AddTorque(new Vector3(random, random, random) * 10);

        playerHoldingPotato = 0;
        currentTimeHeld = 0;
        canBePickedUp = false;
        StartCoroutine(pickupCooldown());

    }

    public void Respawn()
    {
        Drop();
        StopAllCoroutines();
        currentTimeHeld = 0;
        canBePickedUp = true;

        potBody.angularDrag = 50000f;

        transform.SetParent(PotatoSpawn);
        potBody.velocity = Vector3.zero;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.SetParent(null);
        potBody.angularDrag = 0.05f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PotatoReset")
        {
            Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinalPlatform")
        {
            if (playerIsHoldingObject)
            {
                timeToReset = 500.0f;
                Cursor.lockState = CursorLockMode.None;
                hudpanel.SetActive(false);
                gameoverpanel.SetActive(true);
            }
        }
    }

    IEnumerator pickupCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canBePickedUp = true;
    }
}
