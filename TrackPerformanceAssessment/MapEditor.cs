using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using TPA.Framework.Core;
using TPA.Framework.Core.Manager;

namespace TPA.Custom
{
    public partial class MapEditor : Form
    {
        // 에디터 왼쪽에 타일별 그래픽과 통행가능 여부를 표시하고, 브러쉬를 변경가능하게 한다.
        class TilePaletteItem
        {
            public Point pos = new Point();
            public PictureBox preview;
            public Button button;

            public static readonly int PreviewSize = 64;

            public void Setup(MapEditor form, int id)
            {
                var container = form.splitContainer1;
                var mapData = form.mapData;
                var tileData = mapData.tileData;
                pos.Y = PreviewSize * (id + 1);

                preview = new PictureBox();
                preview.Location = new Point(pos.X, pos.Y);
                preview.Size = new Size(PreviewSize, PreviewSize);
                preview.Load(tileData[id].first);

                button = new Button();
                button.Location = new Point(pos.X + PreviewSize, pos.Y);
                button.Text = $"{tileData[id].first}\nCan Move : {tileData[id].second}";
                button.Size = new Size(Math.Max(150, container.SplitterDistance - PreviewSize - 4), PreviewSize);
                container.SplitterMoved += (object sender, SplitterEventArgs args) =>
                {
                    button.Size = new Size(Math.Max(150, args.X - PreviewSize - 4), PreviewSize);
                };
                button.MouseDown += (object sender, MouseEventArgs args) =>
                {
                    if (args.Button == MouseButtons.Left)
                        form.brush = id;
                    else if (args.Button == MouseButtons.Right)
                    {
                        var tuple = mapData.tileData[id];
                        tuple.second = !tuple.second;
                        mapData.tileData[id] = tuple;
                        button.Text = $"{tileData[id].first}\nCan Move : {mapData.tileData[id].second}";
                    }
                };

                container.Panel1.Controls.Add(preview);
                container.Panel1.Controls.Add(button);
            }
        }

        // 에디터 오른쪽에 맵을 배치하기 위해 클릭/드래그하는 이미지 객체
        class Tile
        {
            public PictureBox picture;
            public Point pos;
            public Point index;

            public void Setup(MapEditor form)
            {
                picture = new PictureBox();
                picture.Load(form.mapData.tileData[form.mapData.tiles[index.X, index.Y]].first);
                picture.Size = new Size(TilePaletteItem.PreviewSize, TilePaletteItem.PreviewSize);
                picture.Location = pos;

                MouseEventHandler func = (object a, MouseEventArgs b) =>
                {
                    Control control = a as Control;
                    if (b.Button == MouseButtons.Left)
                    {
                        if (control.Capture) control.Capture = false;
                        picture.Load(form.mapData.tileData[form.brush].first);
                        form.mapData.tiles[index.X, index.Y] = form.brush;
                    }
                };
                picture.MouseMove += func;
                picture.MouseDown += func;

                form.splitContainer1.Panel2.Controls.Add(picture);
                form.tileList.Add(this);
            }
        }

        public MapData mapData = null;
        public int brush = -1;

        private Uri appStartPath;
        private List<Tile> tileList = new List<Tile>();

        public MapEditor()
        {
            InitializeComponent();

            tbMapWidth.LostFocus += OnLostFocus;
            tbMapHeight.LostFocus += OnLostFocus;

            appStartPath = new Uri(Path.Combine(Application.StartupPath, "./"));

            mapData = new MapData();
            mapData.tiles.Resize(new Size(10, 10));

            tbMapWidth.Text = mapData.width.ToString();
            tbMapHeight.Text = mapData.height.ToString();

            TilePaletteItem item;

            foreach (var i in mapData.tileData.Keys)
            {
                item = new TilePaletteItem();
                item.Setup(this, i);
            }

            Tile tile;

            for (int i = 0; i < mapData.height; i++)
            {
                for (int j = 0; j < mapData.width; j++)
                {
                    tile = new Tile();
                    tile.pos = new Point(64 * j, 64 * i);
                    tile.index = new Point(j, i);
                    tile.Setup(this);
                }
            }
        }

        // 타일 이미지를 불러와 맵 정보에 추가한다
        public void LoadTile(string path, bool isWalkable = true)
        {
            int id = mapData.tileData.Count - 1;
            mapData.tileData[id] = new Tuple<string, bool>() { first = path, second = isWalkable };

            TilePaletteItem item = new TilePaletteItem();
            item.Setup(this, id);
        }

        // 절대 경로 --> 상대 경로
        private string GetRelativePath(string path)
        {
            Uri rawPath = new Uri(path);
            Uri relativePath = appStartPath.MakeRelativeUri(rawPath);
            return relativePath.ToString();
        }

        // 맵 사이즈 입력
        private void tbMapWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) e.Handled = true;
        }

        // 맵 사이즈 변경
        private void OnLostFocus(object sender, EventArgs e)
        {
            Size oldSize = new Size(mapData.width, mapData.height);
            mapData.tiles.Resize(new Size(int.Parse(tbMapWidth.Text), int.Parse(tbMapHeight.Text)));

            Tile tile;

            // 맵의 크기가 커졌을 때
            if (oldSize.Width < mapData.width || oldSize.Height < mapData.height)
            {
                // 타일 이미지를 추가로 표시한다
                for (int i = 0, maxI = mapData.height; i < maxI; i++)
                {
                    for (int j = 0, maxJ = mapData.width; j < maxJ; j++)
                    {
                        if (i < oldSize.Height && j < oldSize.Width) continue;

                        tile = new Tile();
                        tile.pos = new Point(64 * j, 64 * i);
                        tile.index = new Point(j, i);
                        tile.Setup(this);
                    }
                }
            }
            // 맵의 크기가 작아졌을 때
            else if (oldSize.Width > mapData.width || oldSize.Height > mapData.height)
            {
                // 필요없어진 타일을 제거한다
                var list = tileList.FindAll(iter =>
                    (iter.index.X >= mapData.width) ||
                    (iter.index.Y >= mapData.height)
                );

                foreach (var iter in list)
                {
                    splitContainer1.Panel2.Controls.Remove(iter.picture);
                    tileList.Remove(iter);
                }
            }
        }

        // 이름대로
        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "맵 파일|*.gze1206.map";
            ofd.InitialDirectory = "../Resources";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                mapData = FileManager.Get.ReadFile<MapData>(ofd.FileName);

                tbMapWidth.Text = mapData.width.ToString();
                tbMapHeight.Text = mapData.height.ToString();

                TilePaletteItem item;

                foreach (var i in mapData.tileData.Keys)
                {
                    item = new TilePaletteItem();
                    item.Setup(this, i);
                }

                foreach (var iter in tileList)
                {
                    splitContainer1.Panel2.Controls.Remove(iter.picture);
                }
                tileList.Clear();

                Tile tile;

                for (int i = 0; i < mapData.height; i++)
                {
                    for (int j = 0; j < mapData.width; j++)
                    {
                        tile = new Tile();
                        tile.pos = new Point(64 * j, 64 * i);
                        tile.index = new Point(j, i);
                        tile.Setup(this);
                    }
                }
            }
        }

        // 이름대로
        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "맵 파일|*.gze1206.map";
            sfd.InitialDirectory = "../Resources";

            if (sfd.ShowDialog() == DialogResult.OK)
                FileManager.Get.WriteFile(mapData, sfd.FileName);
        }

        // 이름대로
        private void 새타일생성ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "이미지 파일 (*.png, *.jpg)|*.png;*.jpg";
            ofd.InitialDirectory = "../Resources";

            if (ofd.ShowDialog() == DialogResult.OK)
                LoadTile(GetRelativePath(ofd.FileName));
        }
    }
}
