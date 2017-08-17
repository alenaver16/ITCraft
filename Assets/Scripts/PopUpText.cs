using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class PopUpText : MonoBehaviour, ITrackableEventHandler
{
    [SerializeField]
    private Text _text = null;
    private TrackableBehaviour mTrackableBehaviour;

    void Start()
    {

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
           _text.text = "";
        }
        else
        {
            _text.text = "Please put mobile\ncamera on a marker";
        }
        
    }
}

