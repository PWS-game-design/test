using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private void Start()
    {
        Playermovement.Instance.SetPlayerPos(transform.position);
    }
}
