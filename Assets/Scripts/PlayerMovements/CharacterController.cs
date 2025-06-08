using UnityEngine;

namespace player.Inputs
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private float speed;

        private float translation;
        private float straffe;
        private bool activeMovement;

        private void Start()
        {
            OnOffCursor(false);
            activeMovement = true;
        }

        private void Update()
        {
            straffe = Input.GetAxis(GloabalStringVars.horizontalAxis);
            translation = Input.GetAxis(GloabalStringVars.verticalAxis);
            
            straffe = straffe * speed * Time.deltaTime;
            translation = translation * speed * Time.deltaTime; 
        }

        private void FixedUpdate()
        {
            if (activeMovement)
            {
                transform.Translate(straffe, 0, translation);
            }
        }

        public void OnOffCursor(bool active)
        {
            if (active == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        public void ActivatorMovement(bool active)
        {
            activeMovement = active;
        }
    }
}
