using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing.Printing;
using System.IO;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace CollegeForm.WebForms
{
    public partial class Receipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Export(sender, e);
        }

        protected void Export(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Excel")
                ExportToExcel(sender, e);
            if (DropDownList1.SelectedValue == "Pdf")
                ExportToPdf(sender, e);
        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename = Receipt.xls");
            Response.ContentType = "application/vnd.xls";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            DetailsView1.AllowPaging = false;
            DetailsView1.DataBind();
            DetailsView1.Rows[10].Visible = false;
            DetailsView1.Rows[11].Visible = false;
            DetailsView1.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        protected void ExportToPdf(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename = Receipt.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            DetailsView1.AllowPaging = false;
            DetailsView1.DataBind();
            DetailsView1.Rows[10].Visible = false;
            DetailsView1.Rows[11].Visible = false;
            DetailsView1.RenderControl(htmlWrite);
            DetailsView1.HeaderRow.Style.Add("width", "15%");
            DetailsView1.HeaderRow.Style.Add("font-size", "10px");
            DetailsView1.Style.Add("text-decoration", "none");
            DetailsView1.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            DetailsView1.Style.Add("font-size", "8px");
            StringReader stringReader = new StringReader(stringWrite.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            //htmlparser.Parse(sr);
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, stringReader);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
          server control at run time. */
        }
    }
}