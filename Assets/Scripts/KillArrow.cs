using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.U2D;

public class KillArrow : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("CharacterWeapons"))
        {
            Destroy(col.gameObject);

        }
    }

}
