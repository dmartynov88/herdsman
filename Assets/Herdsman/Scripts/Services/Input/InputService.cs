using Adic;
using GameEntities.Movement;
using Services.Camera;
using UnityEngine;

namespace Services.InputSystem
{
//Simple as possible input handling for single player test only!
   public class InputService : MonoBehaviour
   {
      private CameraService cameraService;
      private ITargetPointReceiver targetPointReceiver;
      private Plane plane;
      
      private void Awake()
      {
         plane = new Plane(Vector3.up, Vector3.zero);
      }

      public void Initialize(CameraService cameraService)
      {
         this.cameraService = cameraService;
      }

      public void RegisterMovementController(ITargetPointReceiver targetPointReceiver)
      {
         this.targetPointReceiver = targetPointReceiver;
      }

      public void ClearPositionReceiver()
      {
         targetPointReceiver = null;
      }
      
      private void Update()
      {
         if (targetPointReceiver != null && Input.GetMouseButtonDown(0))
         {
            Ray ray = cameraService.MainCamera.ScreenPointToRay(Input.mousePosition);
            float distance;

            if (plane.Raycast(ray, out distance))
            {
               Vector3 clickPoint = ray.GetPoint(distance);
               targetPointReceiver.SetTargetPoint(new Vector3(clickPoint.x, 0, clickPoint.z));
            }
         }
      }
   }
}
