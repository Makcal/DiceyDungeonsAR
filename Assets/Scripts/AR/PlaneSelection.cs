﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace DiceyDungeonsAR.AR
{
    public class PlaneSelection : MonoBehaviour
    {
        ARRaycastManager raycastManager;
        ARPlaneManager planeManager;
        Camera arcamera;
        public GameObject level, player;
        GameObject placed = null;

        // Start is called before the first frame update
        void Start()
        {
            raycastManager = GetComponent<ARRaycastManager>();
            planeManager = GetComponent<ARPlaneManager>();
            arcamera = transform.Find("AR Camera").GetComponent<Camera>();
            //Instantiate(player);
            //Instantiate(level, new Vector3(0, 0, 0), Quaternion.identity);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 tPos = touch.position;

                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = arcamera.ScreenPointToRay(tPos);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        //Destroy(hit.transform.gameObject);

                        ISelectableObject selected = hit.transform.gameObject.GetComponent<ISelectableObject>();

                        if (selected != null)
                        {
                            if (selected.IsSelected == false)
                                selected.OnSelectEnter();
                            else
                                selected.OnSelectExit();

                            selected.IsSelected = !selected.IsSelected;
                        }
                    }
                }

                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                if (raycastManager.Raycast(tPos, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose pose = hits[0].pose;

                    if (placed == null)
                    {
                        placed = Instantiate(player);
                        placed = Instantiate(level, pose.position, Quaternion.identity);

                        planeManager.planePrefab = null;
                        foreach (var plane in planeManager.trackables)
                            plane.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
