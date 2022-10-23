using SlugBase;
using UnityEngine;

namespace ShapeTheSlugcat
{
    public partial class Shape : SlugBaseCharacter
    {
        //Register Character
        public Shape() : base("Shape", FormatVersion.V1, 1, true) { }
        public override string DisplayName => "Shape";
        public override string Description => @"Shape is a fast and weak slugcat. Can be Invisible";


        //Hooks
        protected override void Disable()
        {
            On.Player.ctor -= Player_ctor;

            // Movement
            On.Player.Jump -= Player_Jump;

            // Combat Skills
            On.Player.ThrowObject -= Player_ThrowObject;
            On.Player.ThrownSpear -= Player_ThrownSpear;
            On.Player.CanIPickThisUp -= Player_CanIPickThisUp;

            // Player Invisibility
            On.PlayerGraphics.DrawSprites -= PlayerGraphics_DrawSprites;
            On.PlayerGraphics.ApplyPalette -= Player_ApplyPalette;
            On.Player.Update -= Player_Update;
            On.Player.Collide -= Player_Collide;
            On.RainCycle.Update -= RainCycle_Update;

            // Food preferences
            On.KarmaFlower.BitByPlayer -= KarmaFlower_BitByPlayer;

            // Items Invisibility.
            // TODO: find better way. too lond...
            On.Spear.DrawSprites -= Spear_DrawSprites;
            On.BubbleGrass.DrawSprites -= BubbleGrass_DrawSprites;
            On.DangleFruit.DrawSprites -= DangleFruit_DrawSprites;
            On.DataPearl.DrawSprites -= DataPearl_DrawSprites;
            On.EggBugEgg.DrawSprites -= EggBugEgg_DrawSprites;
            On.FlyLure.DrawSprites -= FlyLure_DrawSprites;
            On.Lantern.DrawSprites -= Lantern_DrawSprites;
            On.Mushroom.DrawSprites -= Mushroom_DrawSprites;
            On.NeedleEgg.DrawSprites -= NeedleEgg_DrawSprites;
            On.SlimeMold.DrawSprites -= SlimeMold_DrawSprites;
            On.WaterNut.DrawSprites -= WaterNut_DrawSprites;
            On.VultureMask.DrawSprites -= VultureMask_DrawSprites;
            On.FirecrackerPlant.DrawSprites -= FirecrackerPlant_DrawSprites;
            On.FlareBomb.DrawSprites -= FlareBomb_DrawSprites;
            On.PuffBall.DrawSprites -= PuffBall_DrawSprites;
            On.Rock.DrawSprites -= Rock_DrawSprites;
            On.ScavengerBomb.DrawSprites -= ScavengerBomb_DrawSprites;
            On.ExplosiveSpear.DrawSprites -= ExplosiveSpear_DrawSprites;
            On.SporePlant.DrawSprites -= SporePlant_DrawSprites;
            On.OverseerCarcass.DrawSprites -= OverseerCarcass_DrawSprites;
        }
        protected override void Enable()
        {
            On.Player.ctor += Player_ctor;

            // Movement
            On.Player.Jump += Player_Jump;

            // Combat Skills
            On.Player.ThrowObject += Player_ThrowObject;
            On.Player.ThrownSpear += Player_ThrownSpear;
            On.Player.CanIPickThisUp += Player_CanIPickThisUp;

            // Player Invisibility
            On.PlayerGraphics.DrawSprites += PlayerGraphics_DrawSprites;
            On.PlayerGraphics.ApplyPalette += Player_ApplyPalette;
            On.Player.Update += Player_Update;
            On.Player.Collide += Player_Collide;
            On.RainCycle.Update += RainCycle_Update;

            // Food preferences
            On.KarmaFlower.BitByPlayer += KarmaFlower_BitByPlayer;

            // Items Invisibility.
            // TODO: find better way. too lond...
            On.Spear.DrawSprites += Spear_DrawSprites;
            On.BubbleGrass.DrawSprites += BubbleGrass_DrawSprites;
            On.DangleFruit.DrawSprites += DangleFruit_DrawSprites;
            On.DataPearl.DrawSprites += DataPearl_DrawSprites;
            On.EggBugEgg.DrawSprites += EggBugEgg_DrawSprites;
            On.FlyLure.DrawSprites += FlyLure_DrawSprites;
            On.Lantern.DrawSprites += Lantern_DrawSprites;
            On.Mushroom.DrawSprites += Mushroom_DrawSprites;
            On.NeedleEgg.DrawSprites += NeedleEgg_DrawSprites;
            On.SlimeMold.DrawSprites += SlimeMold_DrawSprites;
            On.WaterNut.DrawSprites += WaterNut_DrawSprites;
            On.VultureMask.DrawSprites += VultureMask_DrawSprites;
            On.FirecrackerPlant.DrawSprites += FirecrackerPlant_DrawSprites;
            On.FlareBomb.DrawSprites += FlareBomb_DrawSprites;
            On.PuffBall.DrawSprites += PuffBall_DrawSprites;
            On.Rock.DrawSprites += Rock_DrawSprites;
            On.ScavengerBomb.DrawSprites += ScavengerBomb_DrawSprites;
            On.ExplosiveSpear.DrawSprites += ExplosiveSpear_DrawSprites;
            On.SporePlant.DrawSprites += SporePlant_DrawSprites;
            On.OverseerCarcass.DrawSprites += OverseerCarcass_DrawSprites;
        }


        // Basic Stats
        public override void GetFoodMeter(out int maxFood, out int foodToSleep)
        {
            foodToSleep = 4;
            maxFood = 6;
        }
        protected override void GetStats(SlugcatStats stats)
        {
            stats.runspeedFac *= 1.25f;
            stats.corridorClimbSpeedFac *= 1.25f;

            stats.loudnessFac *= 0.9f;
            stats.generalVisibilityBonus -= 0.1f;
            stats.visualStealthInSneakMode -= 0.1f;

            stats.bodyWeightFac = 1f;
            stats.lungsFac = 0.9f;
        }
        public override bool CanEatMeat(Player player, Creature creature) => false;
        public override bool HasGuideOverseer => true;
        public override bool QuarterFood => false;


        //Start
        public override string StartRoom => "SU_A24";
        public override void StartNewGame(Room room)
        {
            base.StartNewGame(room);

            // Make sure this is the right room
            if (room.abstractRoom.name != StartRoom) return;

            room.AddObject(new ShapeStart(room));
        }
        private void Player_ctor(On.Player.orig_ctor orig, Player self, AbstractCreature abstractCreature, World world)
        {
            orig(self, abstractCreature, world);
            if (!IsMe(self)) return;

            self.spearOnBack = new Player.SpearOnBack(self);
            Visibility = 1f;
            _basicCatStats = new SlugcatStats(1, self.Malnourished);
            GetStats(_basicCatStats);
        }


        // Movement Hooks
        private void Player_Jump(On.Player.orig_Jump orig, Player self)
        {
            orig(self);
            if (!IsMe(self)) return;

            self.jumpBoost *= 1.1f;            
        }


        // Fight hooks
        private void Player_ThrownSpear(On.Player.orig_ThrownSpear orig, Player self, Spear spear)
        {
            orig(self, spear);
            if (!IsMe(self)) return;

            spear.spearDamageBonus = 0.95f;
            spear.firstChunk.vel.x *= 0.8f;
            spear.gravity = 1.4f;
        }
        private void Player_ThrowObject(On.Player.orig_ThrowObject orig, Player self, int grasp, bool eu)
        {
            orig(self, grasp, eu);
            if (!IsMe(self)) return;

            if (InSteathMode)
            {
                _visibilityChange = 0.1f;
            }
        }
        private bool Player_CanIPickThisUp(On.Player.orig_CanIPickThisUp orig, Player self, PhysicalObject obj)
        {
            if (IsMe(self) && obj is Spear)
            {
                bool alreadyHasSpear = self.spearOnBack.HasASpear;
                for (int i = 0; i < self.grasps.Length; i++)
                {
                    alreadyHasSpear = alreadyHasSpear || (self.grasps[i] == null ? false : self.grasps[i].grabbed is Spear);
                }

                if (alreadyHasSpear)
                {
                    return false;
                }
            }
            return orig(self, obj);
        } // Only one Spear at time


        // Player Graphics Hooks
        public static Color BasicBodyColor { get; } = new Color(0.21f, 0.19f, 0.29f);
        public static Color BasicEyeColor { get; } = Color.gray;
        private void Player_ApplyPalette(On.PlayerGraphics.orig_ApplyPalette orig, PlayerGraphics self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, RoomPalette palette)
        {
            Color bodyColor = BasicBodyColor;
            Player player = self.player;

            if (IsMe(player))
            {
                if (player.Malnourished || player.dead)
                {
                    float num = (!player.Malnourished) ? Mathf.Max(0f, self.malnourished - 0.005f) : self.malnourished;
                    bodyColor = Color.Lerp(bodyColor, Color.gray, 0.4f * num);
                }
                ChangeSpriteVisibility(sLeaser, bodyColor, Visibility);

                if (player.spearOnBack.spear != null) // Marks spear nedeed to hide
                {
                    if (InSteathMode)
                    {
                        player.spearOnBack.spear.color = Color.blue;
                    }
                }
            }
            else
            {
                orig.Invoke(self, sLeaser, rCam, palette);
            }
        }
        private void PlayerGraphics_DrawSprites(On.PlayerGraphics.orig_DrawSprites orig, PlayerGraphics self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            orig(self, sLeaser, rCam, timeStacker, camPos);
            if (!IsMe(self.player)) return;

            self.ApplyPalette(sLeaser, rCam, rCam.currentPalette);

        }
        private void ChangeSpriteVisibility(RoomCamera.SpriteLeaser sLeaser, Color bodyColor, float persent)
        {
            for (int i = 0; i < sLeaser.sprites.Length; i++)
            {
                if (sLeaser.sprites[i] == null) continue;

                if (i != 9)
                {
                    sLeaser.sprites[i].color = Color.Lerp(Color.black, bodyColor, persent);

                }
                else
                {
                    sLeaser.sprites[i].color = BasicEyeColor;
                }
            }
        }


        // Invisibility
        private SlugcatStats _basicCatStats;
        private float _visibility;

        private float _visibilityChange = 0.1f; // Swift Changing
        private int _stateChangeCooldown = 10; // 10 tick = 0.15 seconds
        public float Visibility
        {
            get => _visibility;
            set
            {
                if (value < 0f)
                {
                    _visibility = 0f;
                }
                else if (value > 1f)
                {
                    _visibility = 1f;
                }
                else
                {
                    _visibility = value;
                }
            }
        }
        public bool InSteathMode => Visibility <= 0.4f;

        private void ChangeVisibilityStats(Player self)
        {
            if (IsMe(self))
            {
                SlugcatStats stats = self.slugcatStats;

                stats.generalVisibilityBonus = InSteathMode ? -1f : _basicCatStats.generalVisibilityBonus;
                stats.visualStealthInSneakMode = InSteathMode ? 1f : _basicCatStats.visualStealthInSneakMode;
                stats.loudnessFac = InSteathMode ? 0.5f : _basicCatStats.loudnessFac;

                stats.corridorClimbSpeedFac = InSteathMode ? 0.4f : _basicCatStats.corridorClimbSpeedFac;
                stats.poleClimbSpeedFac = InSteathMode ? 0.6f : _basicCatStats.poleClimbSpeedFac;
                stats.runspeedFac = InSteathMode ? 0.2f : _basicCatStats.runspeedFac;
            }
        }
        private bool CanBeInvisible(Player self)
        {
            if (self.dead || self.inShortcut || self.Stunned)
            {
                return false;
            }

            if (self.bodyMode is Player.BodyModeIndex.Swimming)
            {
                return false;
            }

            for (int i = 0; i < self.grasps.Length; i++)
            {
                bool isCreature = self.grasps[i] != null ? self.grasps[i].grabbed is Creature : false;
                if (isCreature)
                    return false;
            }
            return true;
        }
        private void Player_Update(On.Player.orig_Update orig, Player self, bool eu)
        {
            orig(self, eu);
            if (!IsMe(self)) return;

            if (Visibility <= 1 && Visibility >= 0)
            {
                Visibility += (CanBeInvisible(self) ? _visibilityChange : 0.1f);
                ChangeVisibilityStats(self);
            }

            if (Input.GetKey(KeyCode.Tab) && _stateChangeCooldown <= 0)
            {
                _visibilityChange = -_visibilityChange;
                _stateChangeCooldown = 10;
            }
            else
            {
                _stateChangeCooldown--;
            }
        }
        private void Player_Collide(On.Player.orig_Collide orig, Player self, PhysicalObject otherObject, int myChunk, int otherChunk)
        {
            orig.Invoke(self, otherObject, myChunk, otherChunk);

            if (IsMe(self) && otherObject is Creature && InSteathMode)
            {
                _visibilityChange = 0.1f;
            }
        }
        private void RainCycle_Update(On.RainCycle.orig_Update orig, RainCycle self)
        {
            orig(self);
            if (self.TimeUntilRain < 400)
            {
                _visibilityChange = 0.1f;
            }
        } // Rain is water
        private void KarmaFlower_BitByPlayer(On.KarmaFlower.orig_BitByPlayer orig, KarmaFlower self, Creature.Grasp grasp, bool eu)
        {
            orig(self, grasp, eu);
            if ((grasp.grabber as Player).playerState.slugcatCharacter == PlayerManager.GetCustomPlayer("Shape").SlugcatIndex)
            {
                _visibilityChange = 1f;
                if (self.BitesLeft == 0)
                {
                    (grasp.grabber as Player).Stun(320);

                }
            }
        } // No "Magic"
    }
}


