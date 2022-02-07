using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapReturn : MonoBehaviour
{
    public GameObject releasedObject;
    public Transform snapTransform;

    public void ReleaseObject()
    {
        releasedObject.transform.position = snapTransform.position;
        releasedObject.transform.rotation = snapTransform.rotation;
    }
}
