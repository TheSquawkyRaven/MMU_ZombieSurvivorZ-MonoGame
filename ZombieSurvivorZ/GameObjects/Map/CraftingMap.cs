﻿using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;
using System.Collections.Generic;

namespace ZombieSurvivorZ
{
    public class CraftingMap : BaseMap
    {

        public readonly HashSet<Vector2Int> Crafting = new();

        public CraftingMap(TiledMapTileLayer layer) : base(layer)
        {

        }

        protected override void InitializeTile(int x, int y, TiledMapTile tile)
        {
            base.InitializeTile(x, y, tile);
            Vector2 topLeftTile = LocalToTileTopLeftPosition(x, y);
            new Collision.BoxStaticCollider(this, TileSize.X, TileSize.Y, topLeftTile.X, topLeftTile.Y);
            Crafting.Add(new(x, y));
        }

        public override bool IsTileWalkable(ushort x, ushort y, out float cost)
        {
            TiledMapTile tile = Layer.GetTile(x, y);
            cost = 0;
            return tile.GlobalIdentifier == 0;
        }

        public bool SurroundingAreCrafting(Vector2Int pos, out Vector2Int cell)
        {
            cell = pos;
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    Vector2Int c = new(cell.X + x, cell.Y + y);
                    if (Crafting.Contains(c))
                    {
                        cell = c;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}