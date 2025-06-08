using UnityEngine;

namespace player.Inputs
{
    public class MouseCamLook : MonoBehaviour
    {
        [SerializeField] private GameObject character;
        [SerializeField] private float sensitivity = 5.0f;
        [SerializeField] private float smoothing = 2.0f;
        [SerializeField] private CharacterController characterController;

        private Vector2 mouseLook;
        private Vector2 smoothV;

        private bool activeLookCursor;

        private void Start()
        {
            character = transform.parent.gameObject;
            activeLookCursor = true;
        }

        private void Update()
        {
            if (activeLookCursor)
            {
                var md = new Vector2(Input.GetAxisRaw(GloabalStringVars.mouseAxisX), Input.GetAxisRaw(GloabalStringVars.mouseAxisY));
                md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

                smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
                smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

                mouseLook += smoothV;

                transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
                character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
            } 
        }

        private void ActivatorLookCursor(bool active)
        {
            activeLookCursor = active;
        }

        public void OnCursor()
        {
            ActivatorLookCursor(false);
            characterController.OnOffCursor(true);
        }
        public void OffCursor()
        {
            ActivatorLookCursor(true);
            characterController.OnOffCursor(false);
        }
    }
}
