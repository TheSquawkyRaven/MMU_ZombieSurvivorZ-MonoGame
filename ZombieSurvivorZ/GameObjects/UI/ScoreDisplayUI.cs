﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Timers;
using MonoGame.Extended;
using System;
using System.Runtime.CompilerServices;
using MonoGame.Extended.ViewportAdapters;

namespace ZombieSurvivorZ
{
    public class ScoreDisplayUI : UIBox
    {

        public readonly UIText DeathText;
        public readonly UIText ZombiesScore;
        public readonly UIText TimeSurvived;

        public ScoreDisplayUI() : base(null, new(0, 0), new(Game1.ScreenSize.X, Game1.ScreenSize.Y))
        {
            Color = Color.Black;
            Alpha = 0.7f;

            DeathText = new(this, new(Game1.ScreenSize.X / 2 - 300, Game1.ScreenSize.Y / 2 - 100), new(600, 100));
            DeathText.Text = "You Are Dead";
            DeathText.Color = Color.White;

            ZombiesScore = new(this, new(Game1.ScreenSize.X / 2 - 200, Game1.ScreenSize.Y / 2), new(400, 50));
            ZombiesScore.Text = "Zombies Killed: ";
            ZombiesScore.Color = Color.AntiqueWhite;

            TimeSurvived = new(this, new(Game1.ScreenSize.X / 2 - 200, Game1.ScreenSize.Y / 2 + 50), new(400, 50));
            TimeSurvived.Text = "Time Survived: ";
            TimeSurvived.Color = Color.AntiqueWhite;

            SetActive(false);
        }

        public void PlayerDied(int zombiesKilled, TimeSpan timeSurvived)
        {
            ZombiesScore.Text = $"Zombies Killed: {zombiesKilled}";
            TimeSurvived.Text = $"Time Survived: {PadInt(timeSurvived.Minutes)} : {PadInt(timeSurvived.Seconds)}";
            SetActive(true);
        }

        public static string PadInt(int value)
        {
            if (value >= 10)
            {
                return value.ToString();
            }
            return "0" + value.ToString();
        }

        public override void SetActive(bool active)
        {
            base.SetActive(active);
            DeathText.SetActive(active);
            ZombiesScore.SetActive(active);
            TimeSurvived.SetActive(active);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}