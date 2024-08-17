namespace DYT.Components
{
    public class AmbientSoundMixer
    {
        private object reverboverride;
        private string oldreverb;



        public void ClearReverbOverride()
        {
            reverboverride = null;
            TheSim.SetReverbPreset(!string.IsNullOrWhiteSpace(oldreverb) ? oldreverb : "default");
        }
    }
}