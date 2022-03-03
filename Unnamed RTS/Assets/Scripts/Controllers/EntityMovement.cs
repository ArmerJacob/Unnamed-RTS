using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class EntityMovement
    {

        public Vector3 MoveEntity(Vector3 target, Transform transform, float offSet, float speed)
        {
            if (target.x > transform.position.x + offSet)
            {
                transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            }
            else if (target.x < transform.position.x - offSet)
            {
                transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            }

            if (target.z > transform.position.z + offSet)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
            }
            else if (target.z < transform.position.z - offSet)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
            }

            return transform.position;
        }

    }
}
