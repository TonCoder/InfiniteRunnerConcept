using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GizmosHelper : MonoBehaviour {

    public Color color;

    [ValueDropdown("_gizmoTypeList")]
    public string GizmoType;

    [ShowIf("GizmoType", "WireCube")]
    public bool GetParentSize;

    [ShowIf("GizmoType", "WireCube")]
    public Vector3 CubeSize;

    [ShowIf("GizmoType", "WireSphere")]
    public int SphereRadius;

    public bool DisplaySidePlacement;
    [ShowIf("DisplaySidePlacement")]
    public float divideBy = 2;

    // The selectable values for the dropdown, with custom names.
    private ValueDropdownList<string> _gizmoTypeList = new ValueDropdownList<string>()
    {
        "WireCube",
        "WireSphere"
    };


    void OnDrawGizmos()
    {
        color.a = 1;
        Gizmos.color = color;
        if (GizmoType == "WireSphere")
        {
            Gizmos.DrawWireSphere(transform.position, SphereRadius);
        }
        else if (GizmoType == "WireCube")
        {
            if (GetParentSize)
            {
                CubeSize = transform.localScale;
            }

            Gizmos.DrawWireCube(transform.position, CubeSize);
        }

        if (DisplaySidePlacement)
        {
            var minPos = transform.TransformPoint(Vector3.left / divideBy);
            var maxPos = transform.TransformPoint(Vector3.right / divideBy);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(minPos, 1);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(maxPos, 1);
        }

    }
}
