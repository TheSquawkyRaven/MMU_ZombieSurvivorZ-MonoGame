﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Timers;
using MonoGame.Extended;
using System;
using System.Runtime.CompilerServices;
using MonoGame.Extended.ViewportAdapters;
using System.Collections.Generic;

namespace ZombieSurvivorZ
{
    public abstract class UIBase : SpriteObject
    {

        public override World World => World.UI;

        public UIBase Parent { get; private set; }

        public UIBase(UIBase parent, Vector2 pos, Vector2 size)
        {
            Parent = parent;
            Texture = Game1.GetTexture("pixel");
            Position = pos;
            Scale = size;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public bool MouseWithinBounds()
        {
            Vector2 screenPos = Input.MousePos;
            Vector2 topLeft = GetOffset();
            Vector2 bottomRight = topLeft + Scale;
            if (screenPos.X >= topLeft.X && screenPos.X <= bottomRight.X &&
                screenPos.Y >= topLeft.Y && screenPos.Y <= bottomRight.Y)
            {
                return true;
            }
            return false;
        }

        protected Vector2 GetOffset()
        {
            if (Parent == null)
            {
                return Position;
            }
            return Parent.GetOffset() + Position;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //base.Draw(spriteBatch);
            //Draw from the top right
            spriteBatch.Draw(Texture, GetOffset() + (Scale / 2), null, Color, Rotation, OriginPixels, Scale, SpriteEffects.None, RenderOrder);
        }

    }
}