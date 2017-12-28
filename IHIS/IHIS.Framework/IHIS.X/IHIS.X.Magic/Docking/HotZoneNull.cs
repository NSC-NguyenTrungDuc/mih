// *****************************************************************************
// 
//  (c) Crownwood Consulting Limited 2002 
//  All rights reserved. The software and associated documentation 
//  supplied hereunder are the proprietary information of Crownwood Consulting 
//	Limited, Haxey, North Lincolnshire, England and are supplied subject to 
//	licence terms.
// 
//  Magic Version 1.6.1 	www.dotnetmagic.com
// *****************************************************************************

using System;
using System.Drawing;
using System.Windows.Forms;
using IHIS.X.Magic.Common;

namespace IHIS.X.Magic.Docking
{
    public class HotZoneNull : HotZone
    {
        public HotZoneNull(Rectangle hotArea)
            : base(hotArea, hotArea)
        {
        }

        public override void DrawIndicator(Point mousePos) {}
        public override void RemoveIndicator(Point mousePos) {}
    }
}