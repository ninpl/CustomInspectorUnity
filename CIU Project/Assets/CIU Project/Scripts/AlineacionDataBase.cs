/// AlineacionDataBase.cs Agosto 22/2016 MoonPincho
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
