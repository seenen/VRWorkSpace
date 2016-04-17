using System;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VRClient
{
    public partial class Form1
    {
        #region 菜单
        MenuStrip MainMenu1;
        DataTable menuTable;

        public void CreateMenu()
        {
            //加载MenuStrip菜单
            ToolStripMenuItem topMenu = new ToolStripMenuItem();
            LoadSubMenu(ref topMenu, "0");
        }

        /// <summary>
        /// 递归创建MenuStrip菜单(模块列表)
        /// </summary>
        /// <param name="topMenu">父菜单项</param>
        /// <param name="FATHER_ID">父菜单的ID</param>
        private void LoadSubMenu(ref ToolStripMenuItem topMenu, String inFatherId)
        {
            DataView dvList = new DataView(menuTable);
            //过滤出当前父菜单下在所有子菜单数据(仅为下一层的)
            dvList.RowFilter = "FATHER_ID='" + inFatherId + "'";
            ToolStripMenuItem subMenu;
            foreach (DataRowView dv in dvList)
            {
                //创建子菜单项
                subMenu = new ToolStripMenuItem();
                subMenu.Name = dv["MENU_NAME"].ToString();
                subMenu.Text = dv["MENU_TEXT"].ToString();
                //判断是否为顶级菜单
                if (inFatherId == "0")
                {
                    MainMenu1.Items.Add(subMenu);
                }
                else
                {
                    subMenu.Tag = dv["MODULE_ACTION"].ToString();
                    String str = " void " + dv["MODULE_ACTION"].ToString();
                    //给菜单项加事件。
                    subMenu.Click += new EventHandler(subMenu_Click);
                    topMenu.DropDownItems.Add(subMenu);
                }
                //递归调用
                LoadSubMenu(ref subMenu, dv["ID"].ToString());
            }
        }

        /// <summary>
        /// 菜单单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void subMenu_Click(object sender, EventArgs e)
        {
            try
            {
                //tag属性在这里有用到。
                string acName = ((ToolStripMenuItem)sender).Tag.ToString();
                if (acName != "")
                {
                    string[] strArray = acName.Split(new char[] { ',' });
                    if (strArray.Length > 2)
                    {
                    }
                    else
                    {
                        String str = "void " + acName;
                        foreach (MethodInfo info in base.GetType().GetMethods())
                        {
                            if (str.Trim().ToLower().CompareTo(info.ToString().Trim().ToLower()) == 0)
                            {
                                info.Invoke(this, null);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
            }
        }
        #endregion
    }
}
