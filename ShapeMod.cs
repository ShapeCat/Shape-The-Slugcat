using BepInEx;
using SlugBase;

namespace ShapeTheSlugcat
{
    [BepInPlugin("author.ShapeTheMoonlight", "ShapeTheSlugcat", "0.4")]
    public class ShapeMod : BaseUnityPlugin
    {
        public void OnEnable()
        {
            PlayerManager.RegisterCharacter(new Shape());
        }
    }
}

