using UnityEngine;
using Cinemachine;
 
/// <summary>
/// An add-on module for Cinemachine Virtual Camera that locks the camera's Y co-ordinate
/// </summary>
[SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
public class CinemachineLimits : CinemachineExtension
{
    [Tooltip("Lock the camera's Y position to this value")]
    private float minY = -14f;
    private float maxY = 14f;
    private float minX = -10f;
    private float maxX = 10f;
 
    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            if(pos.y > maxY){
                pos.y = maxY;
            }
            if(pos.x > maxX){
                pos.x = maxX;
            }
            if(pos.y < minY){
                pos.y = minY;
            }
            if(pos.x < minX){
                pos.x = minX;
            }

            state.RawPosition = pos;
        }
    }
}
 