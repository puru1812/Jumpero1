using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolItem : MonoBehaviour
{
    public Pool poolParent;
    public bool setInActiveOnMargin = false;
    public bool setInActiveOnCollision = false;
    public new Vector3 margin = new Vector3(0, 0, 0);
    public GameObject player;
    public float distanceInBetween = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.name+"distance" + Vector3.Distance(player.transform.position, transform.position));
        if(setInActiveOnMargin==true&&Vector3.Distance(player.transform.position, transform.position)< distanceInBetween)
        {
          
            poolParent.resourceFreed(this); //gameObject.SetActive(false);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //Ouput the Collision to the console
        Debug.Log("Collision : " + collision.gameObject.name);
        if (setInActiveOnCollision == true&&collision.gameObject==player)
        {
            
            poolParent.resourceFreed(this);
            player.GetComponent<Player>().collide(gameObject);
            //   gameObject.SetActive(false); gameObject.SetActive(false);
        }
        else if(setInActiveOnCollision == true && collision.gameObject.name =="Bullet")
        {
            GameManager.instance.AddScore(100);
            poolParent.resourceFreed(this);
        }
    }

    //Detect when there is are ongoing Collisions
    void OnCollisionStay(Collision collision)
    {
        //Output the Collision to the console
       // Debug.Log("Stay : " + collision.gameObject.name);
    }

    
}
