using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

        [SerializeField] private MouseLook m_MouseLook;
        [SerializeField] private TextMeshProUGUI m_DeadMenuSurvivalTimeText;
        [SerializeField] private TextMeshProUGUI m_SurvivalTimeText;
        [SerializeField] private GameObject m_DeadMenu;
        private Camera m_Camera;
        private Light m_Light;

        Rigidbody m_Rigidbody;

        private float m_TimePressed = 0f;
        private float m_SurvivalTime = 0f;

        private Boolean m_IsDead = false;

        public float maxNotMovingDuration = 2f;
        public TextMeshProUGUI m_TextMeshPro;

        private void Start()
        {
            m_DeadMenu.SetActive(false);

            m_Rigidbody = GetComponent<Rigidbody>();

            m_Camera = Camera.main;
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
                m_Light = m_Camera.gameObject.transform.Find("GameObject").gameObject.GetComponent<Light>();

                if(m_Light == null)
                {
                    Debug.Log("null light");
                }
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();

            m_MouseLook.Init(transform, m_Camera.transform);
        }


        private void Update()
        {
            if (m_IsDead)
            {
                m_DeadMenu.SetActive(true);
                m_TextMeshPro.text = "";
                m_DeadMenuSurvivalTimeText.text = string.Format("Survival time: {0:0.00}s", m_SurvivalTime);
                m_Character.Move(new Vector3(0, 0, 0), true, false);
                m_MouseLook.SetCursorLock(false);

                if(m_Light != null)
                {
                    //Debug.Log("light intensity = " + m_Light.intensity);
                    m_Light.intensity = (1f - (1f / 60)) * m_Light.intensity;
                }
                return;
            }
            else
            {
                m_SurvivalTime += Time.deltaTime;
                m_SurvivalTimeText.SetText(string.Format("Survival time: {0:0.00}s", m_SurvivalTime));
            }

            RotateView();
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            if (m_IsDead)
            {
                return;
            }

            // read inputs
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);

            if(v > 0 && m_Rigidbody.velocity.magnitude > 0)
            {
                m_TimePressed = 0f;
                m_TextMeshPro.text = "";
            }
            else
            {
                m_TimePressed += Time.deltaTime;

                float remainingTime = maxNotMovingDuration - m_TimePressed;
                remainingTime = Mathf.Max(0f, remainingTime);

                m_TextMeshPro.text = string.Format("{0:0.00}", remainingTime);

                if (m_TimePressed >= maxNotMovingDuration)
                {
                    Debug.Log("hihi");
                    //m_TimePressed = 0f;
                }

                if (remainingTime == 0f)
                {
                    m_IsDead = true;
                    return;
                }
            }

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = (v > 0 ? v : 0) * m_CamForward;// + h*m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward;// + h*Vector3.right;
            }
#if !MOBILE_INPUT
			// walk speed multiplier
	        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;

            m_MouseLook.UpdateCursorLock();
        }

        private void RotateView()
        {
            m_MouseLook.LookRotation(transform, m_Camera.transform);
        }
    }
}
