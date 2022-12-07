using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web;
using DevExpress.Data;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        gridCustomers.GroupSummarySortInfo.Clear();
        ASPxGroupSummarySortInfo sortInfo = new ASPxGroupSummarySortInfo();
        sortInfo.SortOrder = ColumnSortOrder.Ascending;
        sortInfo.SummaryItem = gridCustomers.GroupSummary["Country", SummaryItemType.Custom];
        sortInfo.GroupColumn = "City";
        gridCustomers.GroupSummarySortInfo.AddRange(sortInfo);

    }

    protected void gridCustomers_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e) {
        ASPxSummaryItem item = e.Item as ASPxSummaryItem;
        if (item.FieldName == "Country") {
            if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                e.TotalValue = e.FieldValue.ToString();
        }
    }
}
