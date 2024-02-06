using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCenterPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Center = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.root.gameObject == transform.gameObject)
        {
            
            if (transform.childCount > 0)
            {
                var allChildren = transform.gameObject.GetComponentsInChildren(Transform);
                foreach (Transform child in allChildren)
                {
                    Center += child.transform.position;
                }
                Center /= (allChildren.length);
            }
        }
    }
}
