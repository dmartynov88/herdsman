using System;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace Common.Utils
{
    //ToDo rewrite to scheduler
    public static class CustomGameLoop
    {
        private enum AddMode { Beginning, End }

        // callbacks in case someone needs to use early/lateupdate too.
        public static Action OnEarlyUpdate;
        public static Action OnLateUpdate;

        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            PlayerLoopSystem playerLoop =
#if UNITY_2019_3_OR_NEWER
                PlayerLoop.GetCurrentPlayerLoop();
#else
                PlayerLoop.GetDefaultPlayerLoop();
#endif
            AddToPlayerLoop(NetworkEarlyUpdate, typeof(CustomGameLoop), ref playerLoop, typeof(EarlyUpdate), AddMode.End);

            // add NetworkLateUpdate to the end of PreLateUpdate so it runs after
            // LateUpdate(). adding to the beginning of PostLateUpdate doesn't
            // actually work.
            AddToPlayerLoop(NetworkLateUpdate, typeof(CustomGameLoop), ref playerLoop, typeof(PreLateUpdate), AddMode.End);

            // set the new loop
            PlayerLoop.SetPlayerLoop(playerLoop);
        }
        
        private static void NetworkEarlyUpdate()
        {
            OnEarlyUpdate?.Invoke();
        }

        private static void NetworkLateUpdate()
        {
            OnLateUpdate?.Invoke();
        }

        private static bool AddToPlayerLoop(PlayerLoopSystem.UpdateFunction function, Type ownerType, ref PlayerLoopSystem playerLoop, Type playerLoopSystemType, AddMode addMode)
        {
            // did we find the type? e.g. EarlyUpdate/PreLateUpdate/etc.
            if (playerLoop.type == playerLoopSystemType)
            {
                // resize & expand subSystemList to fit one more entry
                int oldListLength = (playerLoop.subSystemList != null) ? playerLoop.subSystemList.Length : 0;
                Array.Resize(ref playerLoop.subSystemList, oldListLength + 1);
                
                PlayerLoopSystem system = new PlayerLoopSystem {
                    type = ownerType,
                    updateDelegate = function
                };

                // prepend our custom loop to the beginning
                if (addMode == AddMode.Beginning)
                {
                    // shift to the right, write into first array element
                    Array.Copy(playerLoop.subSystemList, 0, playerLoop.subSystemList, 1, playerLoop.subSystemList.Length - 1);
                    playerLoop.subSystemList[0] = system;

                }
                
                // append our custom loop to the end
                else if (addMode == AddMode.End)
                {
                    // simply write into last array element
                    playerLoop.subSystemList[oldListLength] = system;
                }

                return true;
            }

            // recursively keep looking
            if (playerLoop.subSystemList != null)
            {
                for(int i = 0; i < playerLoop.subSystemList.Length; ++i)
                {
                    if (AddToPlayerLoop(function, ownerType, ref playerLoop.subSystemList[i], playerLoopSystemType, addMode))
                        return true;
                }
            }
            return false;
        }
    }
}