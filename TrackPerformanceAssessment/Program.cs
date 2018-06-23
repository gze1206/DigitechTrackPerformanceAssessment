using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using TPA.Framework.Core;
using TPA.Framework.Core.Exception;

namespace TPA
{
    public delegate void Action();
    public delegate void Action<T1, T2>(T1 t1, T2 t2);

    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Load DLL
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(ResolveAssembly);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                using (MainForm form = new MainForm())
                using (MainGame game = MainGame.Get)
                {
                    if (game.Init(form))
                    {
                        form.Show();

                        while (form.Created)
                        {
                            game.Update();
                            game.Render();
                            System.Threading.Thread.Sleep(10);
                            Application.DoEvents();
                        }
                    }
                    else throw new GameInitializeException();
                }
            }
            catch (GameException e)
            {
                Debug.Exception(e);
                Console.ReadKey();
            }
        }

        // Load DLL from Resources
        static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            string resourceName = null;
            string fileName = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";
            foreach (string name in thisAssembly.GetManifestResourceNames())
            {
                if (name.EndsWith(fileName))
                {
                    resourceName = name;
                }
            }

            if (resourceName != null)
            {
                using (Stream stream = thisAssembly.GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        byte[] assembly = new byte[stream.Length];
                        stream.Read(assembly, 0, assembly.Length);
                        Console.WriteLine("Dll file load : " + resourceName);
                        return Assembly.Load(assembly);
                    }
                }
            }
            return null;
        }
    }
}
