using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebApplication_GridTest {
    public class CustomEditItemTemplate : ITemplate {
        public void InstantiateIn(Control _container) {
            GridViewEditItemTemplateContainer container = _container as GridViewEditItemTemplateContainer;
            object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "Type", "DataValue" });
            string dataType = Convert.ToString(values[0]);
            string dataValue = Convert.ToString(values[1]);

            switch (dataType) {
                case "Text":
                    ASPxTextBox txt = new ASPxTextBox();
                    txt.ID = "txt";
                    txt.Text = dataValue;
                    container.Controls.Add(txt);
                    break;

                case "DateTime":
                    ASPxDateEdit date = new ASPxDateEdit();
                    date.ID = "date";
                    date.Date = Convert.ToDateTime(dataValue);
                    container.Controls.Add(date);
                    break;

                case "Dictionary1":
                    ASPxComboBox cmb = new ASPxComboBox();
                    cmb.ID = "dict";
                    cmb.DataSource = DataProvider.GetDictionaryData(DataType.Dictionary1);
                    cmb.TextField = "Data";
                    cmb.ValueField = "Id";
                    cmb.DataBind();
                    cmb.Value = dataValue;
                    container.Controls.Add(cmb);
                    break;
                case "Dictionary2":
                    ASPxComboBox cmb2 = new ASPxComboBox();
                    cmb2.ID = "dict";
                    cmb2.DataSource = DataProvider.GetDictionaryData(DataType.Dictionary2);
                    cmb2.TextField = "Data";
                    cmb2.ValueField = "Id";
                    cmb2.DataBind();
                    cmb2.Value = dataValue;
                    container.Controls.Add(cmb2);
                    break;
            }
        }
    }
}