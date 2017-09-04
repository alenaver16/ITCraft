using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{
    public ParticleSystem particle = null; // Representation blood's animation
    
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.touchCount == 1) 
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)); // Launch ray from point where user touched
            RaycastHit hit;
            if ((Physics.Raycast(ray, out hit, Mathf.Infinity)) && (hit.collider.name == "HeadSphere")) // When ray collision with head
            {
                ParticleSystem newParticle = Instantiate(particle, hit.point, transform.rotation, hit.transform); // Start bleeding animation
            }
        }
    }
}