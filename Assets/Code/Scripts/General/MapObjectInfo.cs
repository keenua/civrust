using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public enum MapObjectType { Tree, Stone, Barrel }

    public class MapObjectInfo
    {
        public Vector3 Position { get; set; }
        public MapObjectType ObjectType { get; set; }
        public int Seed { get; set; }
    }
}
