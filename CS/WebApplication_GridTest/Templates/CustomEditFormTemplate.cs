using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace WebApplication_GridTest {
    public class CustomEditFormTemplate : ITemplate {
        public void InstantiateIn(Control _container) {
            GridViewEditFormTemplateContainer container = _container as GridViewEditFormTemplateContainer;
            object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "Id", "Type", "DataValue" });
            string id = Convert.ToString(values[0]);
            string dataType = Convert.ToString(values[1]);
            string dataValue = Convert.ToString(values[2]);

            ASPxTextBox tb = new ASPxTextBox();
            tb.ID = "id";
            container.Controls.Add(tb);
            tb.Text = values[0].ToString();
            tb.ReadOnly = true;

            tb = new ASPxTextBox();
            tb.ID = "datatype";
            container.Controls.Add(tb);
            tb.Text = values[1].ToString();
            tb.ReadOnly = true;

            switch (dataType) {
                case "Text":
                    ASPxTextBox txt = new ASPxTextBox();
                    txt.ID = "txt";
                    container.Controls.Add(txt);
                    txt.Text = dataValue;
                    break;
                case "DateTime":
                    ASPxDateEdit date = new ASPxDateEdit();
                    date.ID = "date";
                    container.Controls.Add(date);
                    date.Date = Convert.ToDateTime(dataValue);
                    break;
                case "Dictionary1":
                    ASPxComboBox cmb = new ASPxComboBox();
                    cmb.ID = "dict";
                    container.Controls.Add(cmb);
                    cmb.DataSource = DataProvider.GetDictionaryData(DataType.Dictionary1);
                    cmb.TextField = "Data";
                    cmb.ValueField = "Id";
                    cmb.DataBind();
                    cmb.Value = dataValue;
                    break;
                case "Dictionary2":
                    ASPxComboBox cmb2 = new ASPxComboBox();
                    cmb2.ID = "dict";
                    container.Controls.Add(cmb2);
                    cmb2.DataSource = DataProvider.GetDictionaryData(DataType.Dictionary2);
                    cmb2.TextField = "Data";
                    cmb2.ValueField = "Id";
                    cmb2.DataBind();
                    cmb2.Value = dataValue;
                    break;
            }

            ASPxGridViewTemplateReplacement updateBtn = new ASPxGridViewTemplateReplacement();
            updateBtn.ReplacementType = GridViewTemplateReplacementType.EditFormUpdateButton;
            container.Controls.Add(updateBtn);

            ASPxGridViewTemplateReplacement cancelBtn = new ASPxGridViewTemplateReplacement();
            cancelBtn.ReplacementType = GridViewTemplateReplacementType.EditFormCancelButton;
            container.Controls.Add(cancelBtn);
        }
    }
}