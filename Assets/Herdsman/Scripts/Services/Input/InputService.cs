using System;
using Services.Camera;
using UnityEngine;

namespace Services.InputSystem
{
//Simple as possible input handling for single player test only!
   public class InputService : MonoBehaviour
   {
      /// <summary>
      /// How often keyboard will be sent
      /// </summary>
      [SerializeField] private float inputSendRate = 15;
      public event Action<Vector3> MouseMovementReceived;
      public event Action<Vector3> KeyboardMovementReceived;
      
      private CameraService cameraService;
      private Plane plane;
      private float sendInputTime = 0;

      private void Awake()
      {
         plane = new Plane(Vector3.up, Vector3.zero);
      }

      public void Initialize(CameraService cameraService)
      {
         this.cameraService = cameraService;
      }

      private void Update()
      {
         if (Input.GetMouseButtonDown(0))
         {
            Ray ray = cameraService.MainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (plane.Raycast(ray, out float distance))
            {
               Vector3 clickPoint = ray.GetPoint(distance);
               MouseMovementReceived?.Invoke(new Vector3(clickPoint.x, 0, clickPoint.z));
            }
         }

         sendInputTime += Time.deltaTime;

         if (sendInputTime >= inputSendRate / 60 && KeyboardMovementReceived != null)
         {
            sendInputTime = 0;
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            
            var position = new Vector3(horizontal, 0, vertical);
            if (position.sqrMagnitude > 0)
            {
               KeyboardMovementReceived.Invoke(position);
            }
         }
      }
   }
}
