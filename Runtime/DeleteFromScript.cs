using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFromScript : MonoBehaviour
{
    public void AskDelete()
    {
        Destroy(gameObject);
    }
}
