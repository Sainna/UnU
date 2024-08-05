using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sainna.Utils
{
    [RequireComponent(typeof(Collider))]
    public class CollisionBlock : MonoBehaviour
    {

        void OnCollisionStay(Collision col)
        {
            if (col.rigidbody)
            {
                col.rigidbody.velocity /= 2;
                col.rigidbody.angularVelocity /= 2;
                col.rigidbody.useGravity = false;
            }
        }

        void OnCollisionExit(Collision col)
        {
            if (col.rigidbody)
            {
                col.rigidbody.useGravity = true;
            }
        }


    }
}