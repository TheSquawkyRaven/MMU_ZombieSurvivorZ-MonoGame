﻿/********************************************
Course : TGD3351 Game Algorithms
Session: Trimester 1, 2022/23
ID and Name #1 : 1191101213 RavenLimZheXuan
Contacts #1 : 601155873318 1191101213@student.mmu.edu.my
ID and Name #2 : 1181103109 EuwernYongChernJun
Contacts #2 : 60163371078 1181103109@student.mmu.edu.my
********************************************/
using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;

namespace ZombieSurvivorZ
{
    public class WallsMap : BaseMap
    {

        public WallsMap(TiledMapTileLayer layer) : base(layer)
        {

        }

        protected override void InitializeTile(int x, int y, TiledMapTile tile)
        {
            base.InitializeTile(x, y, tile);
            Vector2 topLeftTile = LocalToTileTopLeftPosition(x, y);
            new Collision.BoxStaticCollider(this, TileSize.X, TileSize.Y, topLeftTile.X, topLeftTile.Y);
        }

        public override bool IsTileWalkable(ushort x, ushort y, out float cost)
        {
            if (x >= 52 || y >= 52)
            {
                //TODO
                cost = 0;
                return false;
            }
            TiledMapTile tile = Layer.GetTile(x, y);
            cost = 0;
            return tile.GlobalIdentifier == 0;
        }

    }

}