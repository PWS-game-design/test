using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorway : MonoBehaviour
{
    public static doorway Instance;
    public GameObject ParamL;
    public GameObject ParamR;
    public string Nextscene;
    
    // Start is called before the first frame update
    void Start()
    {
       Instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(ParamL.transform.position, 0.2f);
        Gizmos.DrawWireSphere(ParamR.transform.position, 0.2f);
    }
}
