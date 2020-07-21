using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace Kino.PostProcessing
{
    [System.Serializable, VolumeComponentMenu("Post-processing/Kino/Linear To S-Log3")]
    public sealed class LinearToSLog3 : CustomPostProcessVolumeComponent, IPostProcessComponent
    {
        #region Effect parameters

        public BoolParameter enable = new BoolParameter(false);

        #endregion

        #region Private members

        static class ShaderIDs
        {
            internal static readonly int InputTexture = Shader.PropertyToID("_InputTexture");
        }

        Material _material;

        #endregion

        #region IPostProcessComponent implementation

        public bool IsActive() => _material != null && enable.value;

        #endregion

        #region CustomPostProcessVolumeComponent implementation

        public override CustomPostProcessInjectionPoint injectionPoint =>
            CustomPostProcessInjectionPoint.AfterPostProcess;

        public override void Setup()
        {
            _material = CoreUtils.CreateEngineMaterial("Hidden/Kino/PostProcess/SLog3");
        }

        public override void Render(CommandBuffer cmd, HDCamera camera, RTHandle srcRT, RTHandle destRT)
        {
            _material.SetTexture(ShaderIDs.InputTexture, srcRT);
            HDUtils.DrawFullScreen(cmd, _material, destRT, null, 0);
        }

        public override void Cleanup()
        {
            CoreUtils.Destroy(_material);
        }

        #endregion
    }
}
