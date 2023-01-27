﻿/********************************************
Course : TGD3351 Game Algorithms
Session: Trimester 1, 2022/23
ID and Name #1 : 1191101213 RavenLimZheXuan
Contacts #1 : 601155873318 1191101213@student.mmu.edu.my
ID and Name #2 : 1181103109 EuwernYongChernJun
Contacts #2 : 60163371078 1181103109@student.mmu.edu.my
********************************************/
using Microsoft.Xna.Framework;
using static ZombieSurvivorZ.Collision;

namespace ZombieSurvivorZ
{
    public class SpriteColliderObject : SpriteObject
    {

        public DynamicCollider CL { get; protected set; }

        public override Vector2 Position
        {
            get => base.Position;
            set
            {
                base.Position = value;
                CL?.UpdatePosition(value);
            }
        }

    }
}