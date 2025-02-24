using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class activationcodes : MonoBehaviour
{
    public TMP_InputField iField;
    GameObject adminB;
    string admin;
    // Start is called before the first frame update
    void Start()
    {
        adminB = MainManager.Instance.adminB;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Admin()
    {

        admin = iField.text;
        if(admin == "NIMDA")
        {
            adminB.SetActive(true);
        }
    }
}
