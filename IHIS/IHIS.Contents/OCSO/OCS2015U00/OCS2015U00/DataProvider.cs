namespace IHIS.OCSO
{
    using System;
    using System.Collections.Generic;

    public class DataProvider
    {
        private Dictionary<String, List<String>> tags = new Dictionary<string, List<string>>();

        private static readonly DataProvider _instance = new DataProvider();

        private static readonly IImageEditor _imageEditor = new ImageEditor();

        private DataProvider()
        {
            tags.Add("tag1", new List<string>(new String[] { "sub1", "sub2", "sub3" }));
            tags.Add("tag2", new List<string>(new String[] { "sub1", "sub2", "sub3" }));
            tags.Add("tag3", new List<string>(new String[] { "sub1", "sub2", "sub3" }));
        }

        public static DataProvider Instance
        {
            get
            {
                return _instance;
            }
        }

        public Dictionary<string, List<string>> Tags
        {
            get
            {
                return this.tags;
            }
        }

        public List<string> AllTags
        {
            get
            {
                List<string> ret = new List<string>();
                foreach (KeyValuePair<string, List<string>> pair in tags)
                {
                    ret.Add(pair.Key);
                    foreach (string subTag in pair.Value)
                    {
                        ret.Add(String.Format("{0}-{1}", pair.Key, subTag));
                    }
                    
                }
                return ret;
            }
        }

        public static IImageEditor ImageEditorInstance
        {
            get
            {
                return _imageEditor;
            }
        }
    }
}