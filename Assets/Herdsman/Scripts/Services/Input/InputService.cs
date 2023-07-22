using Adic;
using GameEntities.Movement;
using Services.Camera;
using UnityEngine;

namespace Services.InputSystem
{
//Simple as possible input handling for single player test only!
   public class InputService : MonoBehaviour
   {
      [Inject] [field: SerializeField] private CameraService CameraService { get; set; }
      private IMovementController movementController;
      private Plane plane;
      
      private void Awake()
      {
         plane = new Plane(Vector3.up, Vector3.zero);
      }
      
      public void RegisterMovementController(IMovementController positionReceiver)
      {
         if (this.movementController != positionReceiver)
         {
            this.movementController = positionReceiver;
         }
      }

      public void ClearPositionReceiver()
      {
         this.movementController = null;
      }
      
      private void Update()
      {
         if (movementController != null && Input.GetMouseButtonDown(0))
         {
            Ray ray = CameraService.MainCamera.ScreenPointToRay(Input.mousePosition);
            float distance;

            if (plane.Raycast(ray, out distance))
            {
               Vector3 clickPoint = ray.GetPoint(distance);
               movementController.MoveTo(new Vector3(clickPoint.x, 0, clickPoint.z));
            }
         }
      }
   }
}
