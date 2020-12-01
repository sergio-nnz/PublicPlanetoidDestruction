using UnityEngine;
using _Project.GunSystem.Core.Data;

namespace _Project.GunSystem.Core.Builders
{
    public class ProjectilePropertiesBuilder
    {
        private ProjectileProperties properties = new ProjectileProperties();


        public void AddPosition(Vector3 position)
        {
            properties.position = position;
        }
        
        public void AddRotation(Quaternion rotation)
        {
            properties.rotation = rotation;
        }

        public ProjectileProperties Build()
        {
            ProjectileProperties result = this.properties;
            properties = new ProjectileProperties();
            return result;
        }
    }
}