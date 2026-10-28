using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

namespace Santum
{
    [RequireComponent(typeof(CharacterController))]
    public class FPController : MonoBehaviour
    {
        [Header("Movement Parameters")]
        [SerializeField] float Acceleration = 20f;

        [SerializeField] float WalkSpeed = 3.5f;
        [SerializeField] float SprintSpeed = 8f;

        private float MaxSpeed => SprintInput ? SprintSpeed : WalkSpeed;

        [Space(15)]
        [Tooltip("This is how high the character can jump.")]
        [SerializeField] float jumpHeight = 2f;

        private int timesJumped = 0;
        [SerializeField] bool CanDoubleJump = true;

        public bool Sprinting
        {
            get
            {
                return SprintInput && CurrentSpeed > 0.1f;
            }
        }

        [Header("Look Parameters")]
        public Vector2 LookSensitivity = new Vector2(0.1f, 0.1f);

        public float PitchLimit = 85f;

        [SerializeField] float currentPitch = 0f;

        public float CurrentPitch
        {
            get => currentPitch;

            set
            {
                currentPitch = Mathf.Clamp(value, -PitchLimit, PitchLimit);
            }
        }

        [Header("Camera Parameters")]
        [SerializeField] float CameraNormalFOV = 60f;
        [SerializeField] float CameraSprintFOV = 80f;
        [SerializeField] float CameraFOVSmoothing = 1f;

        [Header("Input")]
        public Vector2 MoveInput;
        public Vector2 LookInput;
        public bool SprintInput;

        /// <summary>When false, movement / look / jump input is ignored (e.g. while a UI panel is open).</summary>
        public bool InputEnabled { get; set; } = true;

        [Header("Components")]
        [SerializeField] CinemachineCamera fpCamera;
        [SerializeField] CharacterController characterController;

        [Header("Physics Parameters")]
        private float gravityClampFactor = -3f; // Small constant downward force that keeps the controller planted on the ground and stairs

        [SerializeField] float gravityScale = 3f;

        public float VerticalVelocity = 0f;

        public Vector3 CurrentVelocity { get; private set; }
        public float CurrentSpeed { get; private set; }

        public bool IsGrounded => characterController.isGrounded;
        private bool wasGrounded = false;

        [Header("Events")]
        public UnityEvent Landed;

        #region Unity Methods

        private void OnValidate()
        {
            if (characterController == null)
            {
                characterController = GetComponent<CharacterController>();
            }

            if (fpCamera == null)
            {
                fpCamera = GetComponentInChildren<CinemachineCamera>();
            }
        }

        private void Update()
        {
            if (!InputEnabled)
            {
                MoveInput = Vector2.zero;
                LookInput = Vector2.zero;
                SprintInput = false;
            }

            MoveUpdate();
            LookUpdate();
            CameraUpdate();

            if (!wasGrounded && IsGrounded)
            {
                timesJumped = 0;
                Landed?.Invoke();
            }
            else if (wasGrounded && !IsGrounded && timesJumped == 0)
            {
                // Walked off a ledge without jumping — consume the grounded jump
                timesJumped = 1;
            }

            wasGrounded = IsGrounded;
        }

        #endregion

        #region Controller Methods

        public void TryJump()
        {
            if (!InputEnabled)
            {
                return;
            }

            int maxJumps = CanDoubleJump ? 2 : 1;

            if (timesJumped >= maxJumps)
            {
                return;
            }

            VerticalVelocity = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y * gravityScale);

            timesJumped++;
        }

        private void MoveUpdate()
        {
            Vector3 motion = transform.forward * MoveInput.y + transform.right * MoveInput.x;
            motion.y = 0f;
            motion.Normalize();

            if (motion.sqrMagnitude >= 0.01f)
            {
                CurrentVelocity = Vector3.MoveTowards(CurrentVelocity, motion * MaxSpeed, Acceleration * Time.deltaTime);
            }
            else
            {
                CurrentVelocity = Vector3.MoveTowards(CurrentVelocity, Vector3.zero, Acceleration * Time.deltaTime);
            }

            if (IsGrounded && VerticalVelocity <= 0.01f)
            {
                VerticalVelocity = gravityClampFactor;
            }
            else
            {
                VerticalVelocity += Physics.gravity.y * gravityScale * Time.deltaTime;
            }

            Vector3 fullVelocity = new Vector3(CurrentVelocity.x, VerticalVelocity, CurrentVelocity.z);

            CollisionFlags flags = characterController.Move(fullVelocity * Time.deltaTime);

            if ((flags & CollisionFlags.Above) != 0 && VerticalVelocity > 0.01f)
            {
                VerticalVelocity = 0f;
            }

            //Updating speed
            CurrentSpeed = CurrentVelocity.magnitude;
        }

        private void LookUpdate()
        {
            Vector2 input = new Vector2(LookInput.x * LookSensitivity.x, LookInput.y * LookSensitivity.y);

            // Looking up and down
            CurrentPitch -= input.y;

            if (fpCamera != null)
            {
                fpCamera.transform.localRotation = Quaternion.Euler(CurrentPitch, 0f, 0f);
            }

            // Looking left and right
            transform.Rotate(Vector3.up * input.x);
        }

        private void CameraUpdate()
        {
            if (fpCamera == null)
            {
                return;
            }

            float targetFOV = CameraNormalFOV;

            if (Sprinting)
            {
                float speedRatio = CurrentSpeed / SprintSpeed;

                targetFOV = Mathf.Lerp(CameraNormalFOV, CameraSprintFOV, speedRatio);
            }

            fpCamera.Lens.FieldOfView = Mathf.Lerp(fpCamera.Lens.FieldOfView, targetFOV, CameraFOVSmoothing * Time.deltaTime);
        }

        #endregion
    }
}
