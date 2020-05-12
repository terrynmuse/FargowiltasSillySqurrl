using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FargowiltasSillySqurrl.NPCs
{
    [AutoloadHead]
    public class SillySqurrl : ModNPC
    {
        public override string Texture => "FargowiltasSillySqurrl/NPCs/SillySqurrl";

        public override bool Autoload(ref string name) 
        {
            name = "Silly Squrrl";
            return mod.Properties.Autoload;
        }
	
        public override void SetStaticDefaults() 
        {
            DisplayName.SetDefault("Silly Squrrl");
	    Main.npcFrameCount[npc.type] = 6;
	    NPCID.Sets.ExtraFramesCount[npc.type] = 9;
	    NPCID.Sets.AttackFrameCount[npc.type] = 4;
	    NPCID.Sets.DangerDetectRange[npc.type] = 700;
	    NPCID.Sets.AttackType[npc.type] = 0;
	    NPCID.Sets.AttackTime[npc.type] = 90;
	    NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults() 
        {
            npc.townNPC = true;
            npc.friendly = true;
	    npc.width = 50;
            npc.height = 32;
            npc.aiStyle = 7;
            npc.damage = 50;
            npc.defense = 35;
            npc.lifeMax = 750;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Squirrel;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) 
        {        
            for (int k = 0; k < 255; k++) 
            {
                Player player = Main.player[k];
                if (!player.active) 
                {
                    continue;
                }

                return true;
            }
            return false;
        }

        public override string TownNPCName() 
        {
            switch (WorldGen.genRand.Next(4)) 
            {
                case 0:
                    return "god";
                case 1:
                    return "fargowilta";
                case 2:
                    return "terry n. muse";
                default:
                    return "universe destroyer, deity slayer, ruler of galaxies, tyrant of the multiverse";
            }
        }

        public override void FindFrame(int frameHeight) 
        {
            /*npc.frame.Width = 40;
            if (((int)Main.time / 10) % 2 == 0)
            {
                npc.frame.X = 40;
            }
            else
            {
                npc.frame.X = 0;
            }*/
        }

        public override string GetChat() 
        {
            if (Main.bloodMoon) 
            {
                return "FUCK";
            } 
            else
	    {
		switch (Main.rand.Next(4)) 
            {
                case 0:
                    return "squeak";
                case 1:
                    return "squeak";
                case 2:
                    return "squeak";
                default:
                    return "squeak";
            }

	    }
        }
        
        public override void SetChatButtons(ref string button, ref string button2) 
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }
        
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        { 
            if(firstButton)
            {
                shop = true;
            }
        }
        public override void SetupShop(Chest shop, ref int nextSlot) 
        {
            shop.item[nextSlot].SetDefaults(27);
            nextSlot++;
        }

        public override bool CanGoToStatue(bool toKingStatue) 
        {
            return true;
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback) 
        {
            damage = 999999;
            knockback = 0f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) 
        {
            cooldown = 2;
            randExtraCooldown = 2;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay) 
        {            
            projType = 528;
            attackDelay = 2;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) 
        {
            multiplier = 1212f;
            randomOffset = 2f;
        }	
        public override void AI()
	{
	    if (npc.active && Main.bloodMoon && Main.dayTime == false)
	    {
		Main.dayTime = false;
		Main.time = 0;
		Main.bloodMoon = true;
	    }
	}
    }
}
