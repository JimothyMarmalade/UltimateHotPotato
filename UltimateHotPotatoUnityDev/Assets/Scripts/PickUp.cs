using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    public Rigidbody potBody;
    public SphereCollider coll;
    public Transform player, objectHolder, fpsCam;

    public TMP_Text timeText;
    public GameObject hudpanel;
    public GameObject gameoverpanel;

    public Transform PotatoSpawn;
    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public static bool playerIsHoldingObject;
    public static bool canBePickedUp = true;

    public float timeToReset = 3f;
    public float currentTimeHeld = 0;
    public float cooldownTime = 0.5f;



    public void Start()
    {
        transform.position = PotatoSpawn.position;
    }

    public void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;

        if (!playerIsHoldingObject && distanceToPlayer.magnitude <= pickUpRange && Input.GetMouseButtonDown(0) && canBePickedUp)
        {
            Pick();
        }
        else if (playerIsHoldingObject && Input.GetMouseButtonDown(0))
        {
            Drop();
        }

        if (transform.position.y <= -20)
        {
            Respawn();
        }

        if (playerIsHoldingObject)
        {
            currentTimeHeld += Time.deltaTime;
            float formatted = (timeToReset - currentTimeHeld);
            
            timeText.text = "Potato Timer: " + formatted.ToString("#.00");
        }
        else
        {
            timeText.text = "Find the Potato!";
        }

        if (currentTimeHeld >= timeToReset)
        {
            Drop();
            currentTimeHeld = 0;
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

        transform.SetPositionAndRotation(objectHolder.position, Quaternion.Euler(Vector3.zero));

        potBody.isKinematic = false;
        coll.isTrigger = false;

        potBody.velocity = player.GetComponent<CharacterController>().velocity;

        potBody.AddForce(fpsCam.forward*dropForwardForce, ForceMode.Impulse);
        potBody.AddForce(fpsCam.up*dropUpwardForce, ForceMode.Impulse);

        float random = Random.Range(-1f, -1f);
        potBody.AddTorque(new Vector3(random, random, random)*10);

        currentTimeHeld = 0;
        canBePickedUp = false;
        StartCoroutine(pickupCooldown());

    }

    public void Respawn()
    {
        StopAllCoroutines();
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
