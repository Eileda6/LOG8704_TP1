using UnityEngine;
using System.Collections;

public class BlinkOnTeleport : MonoBehaviour
{
    public BlinkFade blinkFade;
    public Component teleportInteractor; // au lieu de TeleportControllerInteractor

    private void OnEnable()
    {
        // On tente de récupérer l'event via reflection ou UnityEvent
        var field = teleportInteractor.GetType().GetField("WhenTeleportRequested");
        if (field != null)
        {
            var evt = field.GetValue(teleportInteractor) as System.Action;
            if (evt != null)
                evt += HandleTeleport;
        }
    }

    private void OnDisable()
    {
        var field = teleportInteractor.GetType().GetField("WhenTeleportRequested");
        if (field != null)
        {
            var evt = field.GetValue(teleportInteractor) as System.Action;
            if (evt != null)
                evt -= HandleTeleport;
        }
    }

    private void HandleTeleport()
    {
        if (blinkFade != null)
            StartCoroutine(blinkFade.DoBlink(() => { }));
    }
}
