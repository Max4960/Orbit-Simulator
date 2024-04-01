using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body : MonoBehaviour
{
    private GameObject sphere;
    private SphereCollider sphere_Collider;

    // Attributes
    public float radius;
    public float mass;
    public int body_id;
    public Vector3 initial;
    public Vector3 force;

    public body[] bodies;

    void Start(){
        sphere_Collider = transform.GetComponent<SphereCollider>(); // Scales the collider
                                                                    // so it matches the scale of the shape
        sphere_Collider.radius = radius;
        transform.localScale = new Vector3(radius,radius,radius); // Scales the whole object by a factor of 'radius'
        bodies = FindObjectsOfType<body>();
    }
 
    void FixedUpdate(){                             // This loops through the array        
                                                    // of bodies, and calls the getGravity function on them.
        
        foreach (body current in bodies)
        {
            if (current != this){                   // This prevents the logic error of a 
                                                    //planet calculating a force to itself
                getGravity(current);
            }
        }
        
    }

    void getGravity(body target){
        initial+=force;     // This line applies the initial force.
        Vector3 direction = transform.position - target.transform.position;    // Is a vector of the change in distance        
        float distance = direction.magnitude;                                  // The distance is the magnitude
                                                                               // (length) of the direction
        float forceBetween = (mass * target.mass) / (distance * distance);     // This uses Newton's law of Universal Gravitation 
                                                                               //to find the value of the force between the two planets.        
        force = direction * forceBetween;                                      // This assigns the 'force' the direction to act in
        target.transform.position += initial;                                  // This updates the position of the planet it is acting 
                                                                               //upon, both planets do this, resulting in both moving

    }
}