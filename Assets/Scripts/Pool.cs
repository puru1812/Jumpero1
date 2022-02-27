using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    // Start is called before the first frame update
    public List<PoolItem> items=new List<PoolItem>();
    public Vector3 distance = new Vector3(0, 0, 0);
     Vector3 lastPosition = new Vector3(0, 0, 0);
    void Start()
    {
        lastPosition = items[0].gameObject.transform.position;
        for (int i = 0; i < items.Count; i++)
        {
            items[i].gameObject.transform.position= lastPosition + distance;
            lastPosition = items[i].gameObject.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void resourceFreed(PoolItem item)
    {
      //  item.gameObject.active = true;
        item.gameObject.transform.position = lastPosition + distance;
        lastPosition = item.gameObject.transform.position;
    }
}
