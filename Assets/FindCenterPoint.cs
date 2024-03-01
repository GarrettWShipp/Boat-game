using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FindCenterPoint : MonoBehaviour
{
    public BoxCollider center;
    public List<Transform> children = new List<Transform>();
    Vector3 avgVec;
    public int childCounter = 0;
    public int counter = 0;
    private float maxX = 0, maxY = 0, maxZ = 0, minX = 0, minY = 0, minZ = 0;
    Vector3 disVec;
    
    // Start is called before the first frame update
    void Start()
    {
        center.size = Vector3.zero;
        center.center = Vector3.zero;
        avgVec = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        children = transform.Cast<Transform>().ToList();
        
        childCounter = children.Count;

        if (childCounter != counter)
        {
            //find center
            avgVec = Vector3.zero;
            foreach (Transform pos in children)
            {

                avgVec.x += pos.localPosition.x;
                avgVec.y += pos.localPosition.y;
                avgVec.z += pos.localPosition.z;

            }
            center.center = (avgVec / children.Count);

            //adjust box collider
            foreach (Transform child in children)
            {
                if (child.localPosition.x > maxX)
                {
                    maxX = child.localPosition.x;
                }

                if (child.localPosition.x < minX)
                {
                    minX = child.localPosition.x;
                }

                if (child.localPosition.y > maxY)
                {
                    maxY = child.localPosition.y;
                }

                if (child.localPosition.y < minY)
                {
                    minY = child.localPosition.y;
                }

                if (child.localPosition.z > maxZ)
                {
                    maxZ = child.localPosition.z;
                }

                if (child.localPosition.z < minZ)
                {
                    minZ = child.localPosition.z;
                }

                disVec.x = Mathf.Sqrt(Mathf.Exp(2) + (maxX - minX));
                disVec.y = Mathf.Sqrt(Mathf.Exp(2) + (maxY - minY));
                disVec.z = Mathf.Sqrt(Mathf.Exp(2) + (maxZ - minZ));
                center.size = disVec;
            }
            if (childCounter <= counter)
            {
                counter--;
            }
            if(childCounter >= counter)
            {
                counter++;
            }
        }
    }
}
