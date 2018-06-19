using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TrackPerformanceAssessment.Framework.Core;
using TrackPerformanceAssessment.Framework.Core.Exception;

namespace TrackPerformanceAssessment
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                using (MainForm form = new MainForm())
                using (MainGame game = new MainGame())
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
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}\n{e.StackTrace}");
            }
        }
    }
}
