using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField]
    GameScoreUI score;
    //En lugar de usar Vector3.Right podemos usar una variable privada de Vector3 a la que llamamos dirección
    //De esta manera podemos elegir en el inspector hacia dónde se va a mover. eje X Y o Z.
    [SerializeField]
    private Vector3 direction;

    [SerializeField]
    float ballSpeedinitial = 1.5f;

    [SerializeField]
    float ballSpeed = 2f;

    void Start()
    {
        ballSpeed = ballSpeedinitial;

        //Le pedimos que nos genere aleatoriamente un número entre 0 y 1
        //Si ese número es mayor o menor que 0.5 realiza una acción o la otra
        if (Random.Range(0.0f, 1.0f) < 0.5f)
        {
            //que nos genere un Debug.Log y se mueva a la drcha
            //Debug.Log("El 50% de las veces pasa esto");
            direction = Vector3.right;
        }
        //si no sucede lo que acabo de decir se usa el else
        else
        {
            //que nos genere un Debug.Log y se mueva a la izq
            //Debug.Log("El otro 50% de las veces pasa esta otra cosa");
            direction = Vector3.left;

        }
       /* //Lo mismo pero para ir arriba y abajo, puedo comentar esta linea porque en el CollisionEnter2D tengo el ElseIF
        if (Random.Range(0.0f, 1.0f) < 0.7f)
        {
            Debug.Log("El 70% de las veces pasa esto");
            direction += Vector3.up;
        }
        else
        {
            Debug.Log("El otro 30% de las veces pasa esta otra cosa");
            direction += Vector3.down; 

        }*/
    }

    void Update()
    {
        //Queremos mover la pelota, asi que usamos su componente transform y modificamos su posición
        //+= significa que al valor que tiene debe añadirle (cada frame) un Vector3.Right, se mueve a la derecha.
        //Y para que no salga disparado debemos ponerle un Time.deltaTime, además así se adaptará la velocidad a todos los PC independientemente de la potencia de cada uno

        transform.position += direction * ballSpeed * Time.deltaTime;
     
    }

    //Agregamos una función para las colisiones, importante que sea 2D
    private void OnCollisionEnter2D (Collision2D collision)
    {
        //Le decimos que nos escriba cuando choque con algo y que nos indique con qué GameObject se ha chocado.
        //Debug.Log("una colisión" + collision.gameObject.name);
        //Ahora queremos que la pelota cambie de sentido y orientación al colisionar con los jugadores.
        //Para ello usamos la variable Vector3 que definimos como direction y simplemente le decimos que se multiplique por -1
        //Sin embargo si siempre le ponemos -1, va a rebotar siempre de forma cuadriculada, para ello podemos hacer que sea aleatorio con un random.

        if(collision.gameObject.CompareTag("Player"))
        {
            //otra manera de hacerlo es 
            //direction.x = -direction.x
            direction.x = direction.x * (-1);
            direction.y = Random.Range(-1f, 1f);
            //Debug.Log("cambiar dirección en eje X");
            //Debug.Log("cambiar dirección en eje Y");
            ballSpeed += 1f;
        }
        else if (collision.gameObject.CompareTag("Border"))
        {
            direction.y = direction.y * (-1);
            //Debug.Log("cambiar dirección en eje X");
            //Debug.Log("cambiar dirección en eje Y");
        }
    }
    //Podemos escribir la función manualmente para que al llegar a los Triggers del GOAL se reinicie la posición y velocidad y tal
    //o Bien podemos crear una función llamada ResetBall() que lo haga y luego lo introducimos.
    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.CompareTag("GoalZone1"))
         { 
             transform.position = Vector3.zero;
         }
         if (collision.gameObject.CompareTag("GoalZone2"))
         {
             transform.position = Vector3.zero;
         }
     }*/

     private void OnTriggerEnter2D(Collider2D collision)
     {       
        if (collision.gameObject.CompareTag("GoalZone1"))
        {
            ResetBall();
            //Para que en UI se añada el GOAL necesitamos acceso al otro script.
            score.AddGoalPlayerOne();
        }
        if (collision.gameObject.CompareTag("GoalZone2"))
        {
            ResetBall();
            score.AddGoalPlayerTwo();

        }
    }

    void ResetBall()
    {
        ballSpeed = ballSpeedinitial;
        transform.position = Vector3.zero;
        direction.x = -direction.x;
        direction.y = Random.Range(-1f, 1f);
    }


}
