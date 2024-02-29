using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class FindCenterPoint : MonoBehaviour
{
    public BoxCollider center;
    public List<Transform> children = new List<Transform>();
    Vector3 avgVec;
    
    // Start is called before the first frame update
    void Start()
    {
        center.center = Vector3.zero;
        avgVec = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.childCount > 0)
        {
            avgVec = Vector3.zero;
            foreach (Transform pos in children)
            {

                avgVec.x += pos.localPosition.x;
                avgVec.y += pos.localPosition.y;
                avgVec.z += pos.localPosition.z;

            }
            center.center = (avgVec / children.Count);
            
            children = transform.gameObject.GetComponentsInChildren<Transform>().ToList<Transform>();
            /*foreach (Transform child in children)
            {
                if (child.name == gameObject.name)
                {
                    children.Remove(child);
                }
                center.size += child.transform.position;
            }*/
            //center.center = children.Average();
            //Center.size /= (Children.Length);
            

        }
    }
}
