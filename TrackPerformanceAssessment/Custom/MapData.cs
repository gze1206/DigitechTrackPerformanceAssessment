using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TPA.Custom
{
    [Serializable]
    public class TileList : IEnumerable<int>
    {
        private int[,] tileDatas = null;
        public int width => (tileDatas == null) ? 0 : tileDatas.GetLength(1);
        public int height => (tileDatas == null) ? 0 : tileDatas.GetLength(0);

        public void Resize(Size size)
        {
            var old = (tileDatas?.Clone() ?? null) as int[,];
            tileDatas = new int[size.Height, size.Width];

            for (int i = 0, maxI = size.Height; i < maxI; i++)
            {
                for (int j = 0, maxJ = size.Width; j < maxJ; j++)
                {
                    if ((old?.GetLength(0) ?? 0) > i && (old?.GetLength(1) ?? 0) > j)
                        tileDatas[i, j] = old[i, j];
                    else tileDatas[i, j] = -1;
                }
            }
        }

        public int this[int x, int y]
        {
            get => (x >= width || y >= height || x < 0 || y < 0) ? -1 : tileDatas[y, x];
            set {
                if (x >= width || y >= height || x < 0 || y < 0) return;
                tileDatas[y, x] = value;
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return tileDatas.GetEnumerator() as IEnumerator<int>;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return tileDatas.GetEnumerator();
        }
    }

    [Serializable]
    public class MapData
    {
        public string name = "new Map";
        public TileList tiles = new TileList();
        public Dictionary<int, Tuple<string, bool>> tileData = new Dictionary<int, Tuple<string, bool>>()
        {
            [-1] = new Tuple<string, bool>() { first = "../Resources/empty.png", second = false },
        };

        public int width => tiles.width;
        public int height => tiles.height;

        public int GetID(int x, int y) => tiles[x, y];

        public bool IsWalkable(int x, int y) => tileData[tiles[x, y]].second;
    }
}
