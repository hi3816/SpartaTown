using UnityEngine;
using UnityEngine.InputSystem.XR;

public partial class PlayerInputController
{
    public class AnimationController : MonoBehaviour
    {
        public Animator animator;
        protected TownController controller;

        protected virtual void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            controller = GetComponent<TownController>();
        }
    }
}
