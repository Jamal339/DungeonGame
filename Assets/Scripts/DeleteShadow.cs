using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteShadow : MonoBehaviour
{
     

    public void deleteShadow()
    {
        //GameObject shadow = GameObject.Find("Grid/EntryRoom_Shadow");
        GameObject parent = transform.parent.gameObject;
        Destroy(parent.transform.GetChild(3).gameObject);
    }

}
