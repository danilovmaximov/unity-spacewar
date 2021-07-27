using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Components
{
    public class MovementComponent : MonoBehaviour
    {
        // Буферы для хранения промежуточных значений
        private float bufferPosX;
        private float bufferPosY;
        private float deltaPosX;
        private float deltaPosY;

        // Переменные для определения скорости объекта
        public float movementSpeed = 5.0f;
        public float rotationSpeed = 0.01f;

        // Переменные для определения сил, прилагаемых к объекту
        public float movementForce = 1.0f;
        public float frictionForce = 1.0f;



        // Метод для поворота игрового объекта
        public void Turn(float acceleration)
        {
            if(Time.deltaTime != 0)
            {
                transform.Rotate(0.0f, 0.0f, -acceleration * rotationSpeed / Time.deltaTime);
            }
        }

        // Метод для движения игрового объекта вперед
        public void Throttle(float acceleration)
        {
            if(Time.deltaTime != 0)
            {
                transform.Translate(0.0f, acceleration * movementSpeed * Time.deltaTime, 0.0f);
            }
        }
    }
}
