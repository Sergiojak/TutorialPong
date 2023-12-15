using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //Con 1 solo script podemos darle controles a 2 jugadores
    //Tan solo usamos una variable para definir

    [SerializeField]
    KeyCode buttonUp, buttonDown;

    //para mover los jugadores
    private Vector3 mov;
    float playerSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //si presiono flechita o si presiono w se realizará la siguiente acción
        transform.position += mov * Time.deltaTime * playerSpeed;

        if (Input.GetKey(buttonDown))
        {
            //Debug.Log("down" + gameObject.name);
            mov = Vector3.down;
        }
        else if (Input.GetKey(buttonUp))
        {
            //Debug.Log("up" + gameObject.name);
            mov = Vector3.up;

        }

    }
}
