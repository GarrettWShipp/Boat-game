using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Floater : MonoBehaviour
{
    public Transform[] floaters;

    public Rigidbody rb;
    public float underWaterDrag;
    public float underWaterAngularDrag;
    public float airDrag;
    public float airAngularDrag;
    public float floatingPower;
    public WaterSurface water;
    WaterSearchParameters Search;
    WaterSearchResult SearchResult;

    bool underwater;
    int floatersUnderwater;

    private void FixedUpdate()
    {
        water.FindWaterSurfaceHeight(Search, out SearchResult);
        floatersUnderwater = 0;
        for (int i = 0; 1 < floaters.Length ; i++)
        {
            float difference = floaters[i].position.y - SearchResult.height;

            if (difference < 0)
            {
                rb.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), floaters[i].position, ForceMode.Force);
                if (!underwater)
                {
                    underwater = true;
                    SwitchState(true);
                }
            }
        }
        if (underwater && floatersUnderwater == 0)
        {
            underwater = false;
            SwitchState(false);
        }

    }

    void SwitchState(bool isUnderwater)
    {
        if (isUnderwater)
        {
            rb.drag = underWaterDrag;
            rb.angularDrag = underWaterAngularDrag;
        }
        else
        {
            rb.drag = airDrag;
            rb.angularDrag = airAngularDrag;
        }
    }
}
