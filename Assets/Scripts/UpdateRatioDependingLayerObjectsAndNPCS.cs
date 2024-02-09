using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRatioDependingLayerObjectsAndNPCS : MonoBehaviour
{
    private float _currentLayerIndex;

    void Start()
    {
        _currentLayerIndex = gameObject.layer;
    }

    public static void UpdateFastLayer(GameObject theGameObject,int CurrentLayerIndex,float multiplicator )
    {
        float ratio = (CurrentLayerIndex - 6f) * multiplicator;
        theGameObject.layer = CurrentLayerIndex;
        theGameObject.transform.Translate(Vector3.down * (theGameObject.layer - CurrentLayerIndex));
        theGameObject.transform.localScale = new Vector3(theGameObject.transform.localScale.x + 1 * ratio, theGameObject.transform.localScale.y + 1 * ratio, theGameObject.transform.localScale.z + 1 * ratio);

    }
}
