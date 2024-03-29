﻿namespace ZombieSurvivorZ
{
    public class Rifle : Weapon
    {
        public Rifle()
        {
            WeaponName = "Rifle";
            WeaponUITexture = Game1.GetTexture("rifle_texture");
            MaterialsToPurchase = 500;
            MaterialsToPurchaseAmmo = 50;

            FireTime = 0.1f;
            MuzzleFlashTime = 0.1f;
            FiringLineFlashTime = 0.05f;
            ReloadTime = 1.5f;
            SwitchTime = 0.5f;

            Damage = 8;
            ClipSize = 25;
            Pellets = 1;
            BaseSpread = 0;
            CanAutoFire = true;
            FiringLineStartOffset = 40;

            AmmoInClip = 25;
            AmmoReserve = 75;

            RecoilSpreadIncrease = 10.0f;
            RecoilSpreadDecrease = 60.0f;
            RecoilMaxSpread = 35.0f;
            RecoilTime = 0.3f;
            RecoilAimFactor = 0.2f;

            Levels = new Level[]
            {
                new Level
                {
                    UpgradeCost = 400,
                    ClipSize = 30,
                },
                new Level
                {
                    UpgradeCost = 500,
                    ClipSize = 35,
                },
                new Level
                {
                    UpgradeCost = 750,
                    ClipSize = 40,
                },
                new Level
                {
                    UpgradeCost = 750,
                    ClipSize = 45,
                },
                new Level
                {
                    UpgradeCost = 1000,
                    ClipSize = 50,
                    Damage = 10,
                },
                new Level
                {
                    UpgradeCost = 10000,
                    ClipSize = 75,
                    ReloadTime = 1.1f,
                    FireTime = 0.075f,
                    RecoilMaxSpread = 25f,
                }
            };
        }

        public override void Initialize()
        {
            PlayerBodyTextureHolding = Game1.GetTexture("Player/player_body_holdingrifle");
            PlayerBodyTextureMuzzleFlashing = Game1.GetTexture("Player/player_body_recoilingrifle");
            PlayerBodyTextureReloading = Game1.GetTexture("Player/player_body_reloadingpistol");

            WeaponTexture = Game1.GetTexture("Player/player_rifle");
            WeaponMuzzleFlashingTexture = Game1.GetTexture("Player/player_recoilingrifle");
            WeaponReloadTexture = Game1.GetTexture("Player/player_reloadingrifle");

            WeaponFlashTexture = Game1.GetTexture("Player/player_rifleflash");

            Texture = WeaponTexture;

            WeaponFireSE = Game1.GetSoundEffect("Audio/rifle");
            WeaponReloadSE = Game1.GetSoundEffect("Audio/reload_mag");
            WeaponNoAmmoSE = Game1.GetSoundEffect("Audio/noammo");

            weaponReloadInstance = WeaponReloadSE.CreateInstance();

            base.Initialize();
        }

        public override void AmmoPurchased()
        {
            AmmoReserve += ClipSize;
        }
    }
}
