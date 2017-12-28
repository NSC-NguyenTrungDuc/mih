using System;
using System.Net;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using IHIS.Framework;

namespace IHIS.NURI
{
    /// <summary>
    /// BedBox(������ ȯ�� Display)�� ���� ��� �����Դϴ�.
    /// </summary>
    public class AnimationButton : System.Windows.Forms.Button
    {
        protected void OnPaint(object sender, PaintEventArgs pevent)
        {
            ImageAnimator.UpdateFrames();
            base.OnPaint(pevent);
        }

        private void OnFrameChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }

}
