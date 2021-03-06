using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace IHIS.Framework
{
    public class XmlHelper
    {
        #region XML 관련 메소드 3세트

        /// <summary>
        /// nodeList 와 key 를 가지고 해당 어트리뷰트를 반환
        /// </summary>
        public static string getAttribute(XmlNodeList nodeList, string key)
        {
            try
            {
                foreach (XmlElement xx in nodeList)
                {
                    // 모든 attribute 찍기
                    for (int i = 0; i < xx.Attributes.Count; i++)
                    {
                        //richTextBox.Text += "      attribute name : " + xx.Attributes[i].Name + "value[" + xx.Attributes[i].Value + "]";
                        if (xx.Attributes[i].Name == key)
                        {
                            return xx.GetAttribute(key);
                        }
                    }

                }
            }
            catch//(Exception ex) 
            {
                //XMessageBox.Show(ex.Message);
                //XMessageBox.Show(ex.Source);
                return "getAttribute err";
            }


            return null;
        }

        /// <summary>
        /// node 와 key 로 해당 노드의 값을 가져옴. 
        /// </summary>
        public static ArrayList getValue(XmlNode node, string key)
        {
            if (node == null) return null;

            ArrayList val = new ArrayList();

            int count = 0;
            try
            {
                foreach (XmlNode xx in node.ChildNodes)
                {
                    if (xx.Name == key)
                    {
                        //richTextBox.Text += node.FirstChild.Value;
                        //val[count] = xx.FirstChild.Value;
                        val.Add(xx.FirstChild.Value);
                        count++;
                    }
                }
                if (count > 0)
                    return val;

            }
            catch //(Exception ex)
            {
                //XMessageBox.Show(ex.Message);
                //XMessageBox.Show(ex.Source);
                return null;
            }


            return null;
        }

        /// <summary>
        /// nodeList 에서 key 값에 해당하는 node 를 반환
        /// </summary>
        public static XmlNode getNode(XmlNodeList nodeList, string key)
        {
            try
            {
                foreach (XmlNode xx in nodeList)
                {
                    if (xx.Name == key)
                        return xx;
                }
            }
            catch//(Exception ex) 
            {
                //XMessageBox.Show(ex.Message);
                //XMessageBox.Show(ex.Source);
                return null; 
            }


            return null;
        }

        #endregion
    }
}
