using Adic;
using GameEntities.Movement;
using Services.Camera;
using UnityEngine;

namespace Services.Input
{
//Simple as possible input handling for single player test only!
   public class InputService : MonoBehaviour
   {
      [Inject] [field: SerializeField] private CameraService CameraService { get; set; }
      private IPositionReceiver positionReceiver;

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
   }
}
