using SlugBase;
using UnityEngine;

namespace ShapeTheSlugcat
{
    public partial class Shape
    {
        private bool CanBeInvisible(PlayerCarryableItem self)
        {
            if (self.grabbedBy == null) return false;

            for (int i = 0; i < self.grabbedBy.Count; i++)
            {
                if (self.grabbedBy[i].grabber is Player player && player.playerState.slugcatCharacter == PlayerManager.GetCustomPlayer("Shape").SlugcatIndex)
                {
                    return true;
                }
            }
            return false;
        }

        // Weapons
        private void Spear_DrawSprites(On.Spear.orig_DrawSprites orig, Spear self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);

            if (InSteathMode)
            {
                if (self.mode == Weapon.Mode.Carried && CanBeInvisible(self))
                {
                    ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
                }
                else if (self.mode == Weapon.Mode.OnBack && self.color == Color.blue)
                {
                    ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
                }
                else
                {
                    self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
                }
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void ExplosiveSpear_DrawSprites(On.ExplosiveSpear.orig_DrawSprites orig, ExplosiveSpear self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);

            if (InSteathMode)
            {
                if (self.mode == Weapon.Mode.Carried && CanBeInvisible(self))
                {
                    ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
                }
                else if (self.mode == Weapon.Mode.OnBack && self.color == Color.blue)
                {
                    ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
                }
                else
                {
                    self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
                }
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void ScavengerBomb_DrawSprites(On.ScavengerBomb.orig_DrawSprites orig, ScavengerBomb self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);

            if (InSteathMode && self.mode == Weapon.Mode.Carried && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void Rock_DrawSprites(On.Rock.orig_DrawSprites orig, Rock self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);

            if (InSteathMode && self.mode == Weapon.Mode.Carried && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void FlareBomb_DrawSprites(On.FlareBomb.orig_DrawSprites orig, FlareBomb self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);

            if (InSteathMode && self.mode == Weapon.Mode.Carried && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
                self.light.color = self.color;
            }
        }
        private void FirecrackerPlant_DrawSprites(On.FirecrackerPlant.orig_DrawSprites orig, FirecrackerPlant self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);

            if (InSteathMode && self.mode == Weapon.Mode.Carried && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void PuffBall_DrawSprites(On.PuffBall.orig_DrawSprites orig, PuffBall self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);

            if (InSteathMode && self.mode == Weapon.Mode.Carried && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void SporePlant_DrawSprites(On.SporePlant.orig_DrawSprites orig, SporePlant self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);

            if (InSteathMode && self.mode == Weapon.Mode.Carried && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }


        // Items
        private void VultureMask_DrawSprites(On.VultureMask.orig_DrawSprites orig, VultureMask self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);
            if (InSteathMode && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void WaterNut_DrawSprites(On.WaterNut.orig_DrawSprites orig, WaterNut self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);
            if (InSteathMode && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void SlimeMold_DrawSprites(On.SlimeMold.orig_DrawSprites orig, SlimeMold self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);
            if (InSteathMode && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void NeedleEgg_DrawSprites(On.NeedleEgg.orig_DrawSprites orig, NeedleEgg self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);
            if (InSteathMode && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }

        }
        private void Mushroom_DrawSprites(On.Mushroom.orig_DrawSprites orig, Mushroom self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);
            if (InSteathMode && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void DataPearl_DrawSprites(On.DataPearl.orig_DrawSprites orig, DataPearl self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);
            if (InSteathMode && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void Lantern_DrawSprites(On.Lantern.orig_DrawSprites orig, Lantern self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);
            if (InSteathMode && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
                self.lightSource.color = self.color;
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void FlyLure_DrawSprites(On.FlyLure.orig_DrawSprites orig, FlyLure self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);
            if (InSteathMode && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void EggBugEgg_DrawSprites(On.EggBugEgg.orig_DrawSprites orig, EggBugEgg self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);
            if (InSteathMode && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void DangleFruit_DrawSprites(On.DangleFruit.orig_DrawSprites orig, DangleFruit self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);
            if (InSteathMode && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void BubbleGrass_DrawSprites(On.BubbleGrass.orig_DrawSprites orig, BubbleGrass self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);
            if (InSteathMode && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
        private void OverseerCarcass_DrawSprites(On.OverseerCarcass.orig_DrawSprites orig, OverseerCarcass self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);
            if (InSteathMode && CanBeInvisible(self))
            {
                ChangeSpriteVisibility(sLeaser, rCam.currentPalette.blackColor, Visibility);
            }
            else
            {
                self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }
        }
    }
}
