using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 0f;
    [SerializeField] private GameObject asteroidDeathEffect;
    private Vector3 rotationDirection;

    private void Awake()
    {
        // TODO: Replace the GameObject find for a static reference
        target = GameObject.Find("VRCamera").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        var x = Random.Range(0f, 360f);
        var y = Random.Range(0f, 360f);
        var z = Random.Range(0f, 360f);
        
        rotationDirection = new Vector3(x, y, z);
        speed = Random.Range(5, 15);
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;

        Transform currentTansform = this.transform;
        currentTansform.Rotate(rotationDirection*Time.deltaTime, Space.Self);

        currentTansform.position = Vector3.MoveTowards(currentTansform.position, target.position, step);
    }
    
    // TODO: Random rotation functions either by material or shader

    private void OnParticleTrigger()
    {
        Debug.Log("Hit by particle");
    }

    private void OnParticleCollision(GameObject other)
    {
        var currentTransform = transform;
        Instantiate(asteroidDeathEffect, currentTransform.position, currentTransform.rotation);
        Destroy(gameObject);
    }
}
