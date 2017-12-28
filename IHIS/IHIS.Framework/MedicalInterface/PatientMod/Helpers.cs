using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace IHIS.Framework.PatientMod
{
    public static class Helpers
    {
        public static XmlAttribute CreateAttr(XmlDocument doc, string attrName, string attrValue)
        {
            XmlAttribute attr = doc.CreateAttribute(attrName);
            attr.Value = attrValue;

            return attr;
        }
    }
}
