using System;
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
      private IPositionReceiver positionReceiver;
      private Plane plane;
      
      private void Awake()
      {
         plane = new Plane(Vector3.up, Vector3.zero);
      }
      
      public void RegisterPositionReceiver(IPositionReceiver positionReceiver)
      {
         if (this.positionReceiver != positionReceiver)
         {
            this.positionReceiver = positionReceiver;
         }
      }

      public void ClearPositionReceiver()
      {
         this.positionReceiver = null;
      }
      
      private void Update()
      {
         if (positionReceiver != null && Input.GetMouseButtonDown(0))
         {
            Ray ray = CameraService.MainCamera.ScreenPointToRay(Input.mousePosition);
            float distance;

            if (plane.Raycast(ray, out distance))
            {
               Vector3 clickPoint = ray.GetPoint(distance);
               positionReceiver.SetPosition(clickPoint);
            }
         }
      }
   }
}
