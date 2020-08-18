/// AlineacionDataBase.cs Enero 6/2018 Antonio Moon
/// 

using UnityEngine;
using System.Collections.Generic;


namespace MoonPincho.Alineacion
{
    [System.Serializable]
    public class AlineacionDataBase : ScriptableObject
    {
        public List<Alineacion> alineaciones = new List<Alineacion>();
    }
}
