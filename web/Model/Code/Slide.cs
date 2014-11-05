using System;
namespace Tc.Model
{
    /// <summary>
    /// 幻灯片实体类
    /// </summary>
    [Serializable]
    public partial class Slide
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Types
        /// </summary>		
        private string _types;
        public string Types
        {
            get { return _types; }
            set { _types = value; }
        }
        /// <summary>
        /// Title
        /// </summary>		
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// Image
        /// </summary>		
        private string _image;
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
        /// <summary>
        /// Url
        /// </summary>		
        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        /// <summary>
        /// Sort
        /// </summary>		
        private int _sort;
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

    }
}
