using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform mytransform;
    void Update()
    {
        mytransform.position=transform.position;
    }

}
