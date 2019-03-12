using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NynneMoth : MonoBehaviour
{
    public GameObject player;
    public GameObject lightObject;
    public GameObject[] lights;

    public bool lightOn;
    public float moveSpeed = 0.2f;
    public float minDistLight = 0.5f;
    public float maxDistPlayer = 4f;

    private Rigidbody rb;
    private int lightIndex;

    // Use this for initialization
    void Start()
    {
        // Call Idle() on Start
        Idle();

        player.gameObject.GetComponent<Rigidbody>().useGravity = false;

        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {

        // If no lights are on, and the player is out of range, call Idle()
        if (!lightOn && Vector3.Distance(transform.position, player.transform.position) > maxDistPlayer)
        {
            Idle();
        }
        // else if no lights are on, and the player is in range, call FollowPlayer()
        else if (!lightOn && Vector3.Distance(transform.position, player.transform.position) < maxDistPlayer)
        {
            FollowPlayer();
        }

        // If a light is on, and the moths are not within the minimum distance to the light, call FollowLight()
        if (lightOn && Vector3.Distance(transform.position, lightObject.transform.position) > minDistLight)
        {
            FollowLight(lights[lightIndex]);
        }
        // Else if a light is on, and the moths are within the minimum distance to the light, call Idle()
        else if (lightOn && Vector3.Distance(transform.position, lightObject.transform.position) < minDistLight)
        {
            // Later change this to call a function that make the moths fly around the light
            Idle();
        }

    }

    void FollowPlayer()
    {
        transform.LookAt(player.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    void FollowLight(GameObject light)
    {
        transform.LookAt(light.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, light.transform.position, moveSpeed * Time.deltaTime);
    }

    void Idle()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("OnTriggerEnter");
        // If the moth collide with an object with the name "player", it will print the
        // collision message 
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Moth Collided with Player!");
        }
    }

    // Called when the lightOn bool should be set to true
    void LightOn()
    {
        lightOn = true;
    }

    // Called when the lightOn bool should be set to false
    void LightsOff()
    {
        lightOn = false;
    }

    // This should be called before LightsOn() from Liz script
    void GetLightIndex(int i)
    {
        lightIndex = i;
    }
}