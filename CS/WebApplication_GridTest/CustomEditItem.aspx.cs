using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.Data;
using System;

namespace WebApplication_GridTest {
    public partial class CustomEditItem : System.Web.UI.Page {
        protected void ASPxGridView1_Init(object sender, EventArgs e) {
            ASPxGridView grid = (ASPxGridView)sender;
            ((GridViewDataColumn)grid.Columns["DataValue"]).EditItemTemplate = new CustomEditItemTemplate();
        }

        protected void ASPxGridView1_RowUpdating(object sender, ASPxDataUpdatingEventArgs e) {
            ASPxGridView grid = (ASPxGridView)sender;
            DataType dataType = (DataType)grid.GetRowValuesByKeyValue(e.Keys[0], "Type");

            string editorID = string.Empty;
            switch (dataType) {
                case DataType.Text:
                    editorID = "txt";
                    break;
                case DataType.DateTime:
                    editorID = "date";
                    break;
                case DataType.Dictionary1:
                    editorID = "dict";
                    break;
                case DataType.Dictionary2:
                    editorID = "dict";
                    break;
            }

            ASPxEdit editor = (ASPxEdit)grid.FindEditRowCellTemplateControl((GridViewDataColumn)grid.Columns["DataValue"], editorID);
            e.NewValues["DataValue"] = editor.Value.ToString();
        }

        protected void ASPxGridView1_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e) {
            DataType dataType = (DataType)e.GetFieldValue(e.VisibleRowIndex, "Type");

            if (e.Column.FieldName == "DataValue") {
                switch (dataType) {
                    case DataType.Dictionary1:
                        e.DisplayText = DataProvider.GetDictionaryItem(dataType, Convert.ToInt32(e.Value)).Data;
                        break;
                    case DataType.Dictionary2:
                        e.DisplayText = DataProvider.GetDictionaryItem(dataType, Convert.ToInt32(e.Value)).Data;
                        break;
                }
            }
        }
    }
}