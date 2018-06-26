using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TPA.Framework.Core
{
    public partial class DevConsole : Form
    {
        public delegate void CommandFunc(string raw, string args);

        private static DevConsole dev = null;
        public static DevConsole Get
        {
            get
            {
                if (dev == null) dev = new DevConsole();
                return dev;
            }
        }

        public static readonly Color commandLineColor = Color.CornflowerBlue;

        private Dictionary<string, CommandFunc> dicCmd = new Dictionary<string, CommandFunc>()
        {
            ["test"] = (raw, args) => { Debug.Log(args); },
        };

        public DevConsole()
        {
            dev = this;
            InitializeComponent();
            Text = "framework by gze1206";
            dicCmd["hide"] = (raw, args) =>
            {
                Close();
            };
            dicCmd["editor"] = (raw, args) =>
            {
                new Custom.MapEditor().Show();
                dicCmd["hide"]("/hide force", "force");
            };
        }

        private void DevConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string raw = commandBox.Text;
            commandBox.Clear();
            commandBox.ClearUndo();

            var color = console.SelectionColor;
            console.SelectionStart = console.TextLength;
            console.SelectionColor = commandLineColor;
            console.AppendText(raw);
            console.AppendText(Environment.NewLine);
            console.SelectionStart = console.TextLength;
            console.SelectionColor = color;
            console.ScrollToCaret();

            string lower = raw.ToLower();

            foreach (string word in dicCmd.Keys)
            {
                if (lower.StartsWith($"/{word}"))
                {
                    string args = raw.Substring(word.Length + 1);
                    if (args.StartsWith(" ")) args = args.Substring(1);
                    dicCmd[word](raw, args);
                    return;
                }
            }

            Debug.WarningFormat("'{0}' is not a command!", raw);
        }

        private void commandBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) button1_Click(sender, e);
            if (e.KeyCode == Keys.Escape) dicCmd["hide"]("/hide force", "force");
        }
    }
}
