using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Controller : MonoBehaviour
{

    private void Awake()
    {
        // Turn off all hand rays
        PointerUtils.SetHandRayPointerBehavior(PointerBehavior.AlwaysOff);

        //Turn off spatial mapping system
        CoreServices.SpatialAwarenessSystem.Disable();
    }

}
