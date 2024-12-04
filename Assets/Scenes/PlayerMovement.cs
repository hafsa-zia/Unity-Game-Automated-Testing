using UnityEngine;

namespace PlayerMovementNamespace
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 5f;

        void Update()
        {
            
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            
            
            Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
            
            
            transform.Translate(movement);
        }
    }
}
