using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Permissions;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.transform.SetParent(transform);
    }
    public void OnCollisionExit2D(Collision2D other)
    {
        other.gameObject.transform.SetParent(null);
    }

}