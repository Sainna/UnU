using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Sainna.Utils
{
    public class TTL : MonoBehaviour
    {

        [SerializeField] float _Lifetime = 1.0f;


        private float StartTime;



        // Start is called before the first frame update
        void Start()
        {
            StartTime = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time - StartTime >= _Lifetime)
                Destroy(this.gameObject);
        }
    }
}