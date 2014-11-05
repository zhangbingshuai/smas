using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tc.BLL;

namespace Tc.Web.Admin.huandeng
{
    public partial class info : AdminBase
    {
        public int id = 0;
        public string dp = "display:none";
        public string tupianurl = "";
        public string content = "";

        public string types = "";
        public string height = "";
        public string width = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"].GetInt();
            height = Request.QueryString["height"];
            width = Request.QueryString["width"];
            types = Request.QueryString["types"].GetString();
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            if (id > 0)
            {
                var f = BLL.Slide.Instance.GetModel(id);
                if (f != null)
                {
                    txt_title.Text = f.Title;
                    txt_url.Text = f.Url;
                    txt_paixu.Text = f.Sort.GetString();
                    if (f.Image.GetString().Length > 0)
                    {
                        dp = "";
                        tupianurl = LibFile.get_img(f.Image.GetString(), width, height);
                        hd_tupian.Value = f.Image.GetString();
                    }
                }
            }
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            var bll = Tc.BLL.Slide.Instance;
            var m = id > 0 ? bll.GetModel(id) : new Model.Slide();
            if (m == null)
                m = new Model.Slide();
            m.Title = txt_title.Text.GetString();
            m.Url = txt_url.Text.GetString();
            m.Sort = txt_paixu.Text.GetInt();
            m.Image = this.hd_tupian.Value.GetString();
            m.Types = types;
            if (id > 0)
            {
                bll.Update(m);//更新
            }
            else
            {
                bll.Add(m);//添加
            }

            Alert("保存成功！", "list.aspx?width=" + width + "&height=" + height + "&types=" + types);
        }
    }
}