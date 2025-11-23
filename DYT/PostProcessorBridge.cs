using UnityEngine;

namespace DYT
{
    public class PostProcessorBridge
    {
        // Lua: PostProcessor:SetColourCubeData(0, "path", "path")
        public void SetColourCubeData(int handle, string texturePath1, string texturePath2)
        {
            Debug.LogWarning(
                "PostProcessorBridge -> SetColourCubeData() -> " +
                $"handle=【{handle}】, texturePath1=【{texturePath1}】, texturePath2=【{texturePath2}】"
            );
        }

        // Lua: PostProcessor:SetBlurEnabled(false)
        public void SetBlurEnabled(bool enabled)
        {
            Debug.LogWarning($"PostProcessorBridge -> SetBlurEnabled() -> enabled=【{enabled}】");
        }
    }
}