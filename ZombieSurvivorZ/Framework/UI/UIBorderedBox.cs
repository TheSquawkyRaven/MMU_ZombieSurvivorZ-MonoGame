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
    public class UIBorderedBox : UIBorder
    {

        public UIBox Box;

        public UIBorderedBox(UIBase parent, Vector2 pos, Vector2 size) : base(parent, pos, size)
        {
            Color = Color.Black;
            Box = new(this, new(0, 0), size);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void SetActive(bool active)
        {
            base.SetActive(active);
            Box.SetActive(active);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle(new(GetOffset(), Scale), Color, Thickness);
        }

    }
}