using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class MobController : MonoBehaviour, Attackable
{

    [SerializeField] Transform playerPosition;
    public float speed;


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
    }
    public void attack() {
        gameObject.SetActive(false);
    }
}
