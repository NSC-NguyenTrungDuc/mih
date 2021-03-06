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

namespace IHIS.X.Magic.Common
{
    public enum VisualStyle
    {
        IDE,
        Plain
    }

    public enum Direction
    {
        Vertical,
        Horizontal
    }
    
    public enum Edge
    {
        Top,
        Left,
        Bottom,
        Right,
        None
    }

	// Enumeration of appearance styles
	public enum VisualAppearance
	{
		MultiDocument = 0,
		MultiForm = 1,
		MultiBox = 2
	}
}

