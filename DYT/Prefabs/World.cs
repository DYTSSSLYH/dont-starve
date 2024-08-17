namespace DYT.Prefabs
{
    public class World : Prefab
    {
        #region common stuff

        public bool IsCave()
        {
            return inst.HasTag("Cave");
        }

        #endregion
    }
}