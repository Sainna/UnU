using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sainna.Utils
{
    public class SyncTransform : MonoBehaviour
    {
        [SerializeField] Transform SyncPoint = null;

        [SerializeField] bool _SyncY = false;

        // Update is called once per frame
        void Update()
        {
            Vector3 lol = SyncPoint.position;
            Quaternion rot = SyncPoint.rotation;

            rot.eulerAngles = new Vector3(0, rot.eulerAngles.y, 0);
            if (!_SyncY)
            {
                lol.y = transform.position.y;
            }

            transform.rotation = rot;
            transform.position = lol;
        }
    }
}