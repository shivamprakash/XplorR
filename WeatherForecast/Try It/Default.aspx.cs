using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     

   }
    protected void SearchButton_Click(object sender, EventArgs e)
    {

        Array Data = null;
        ForecastServiceReference.ForecastWCFClient weatherClient = new ForecastServiceReference.ForecastWCFClient();
        Data=weatherClient.GetWeatherForecast(CityTextBox.Text);

        DataTable table = new DataTable();
        table.Columns.Add("Date", typeof(string));
        table.Columns.Add("Image", typeof(string));
        table.Columns.Add("MaxTemp", typeof(string));
        table.Columns.Add("MinTemp", typeof(string));
        table.Columns.Add("Wind", typeof(string));
        table.Columns.Add("Humidity", typeof(string));

        for (int i = 0; i <5;i++ )
        {
            DataRow entry = table.NewRow();
            String dt = ((ForecastServiceReference.Forecast[])(Data))[i].ForecastDate.Month + "/" +
                ((ForecastServiceReference.Forecast[])(Data))[i].ForecastDate.Day + "/" +
            ((ForecastServiceReference.Forecast[])(Data))[i].ForecastDate.Year;
            entry["Date"] = dt;
            entry["MaxTemp"] = ((ForecastServiceReference.Forecast[])(Data))[i].Maxtemp;
            entry["MinTemp"] = ((ForecastServiceReference.Forecast[])(Data))[i].Mintemp;
            entry["Wind"] = ((ForecastServiceReference.Forecast[])(Data))[i].WindObj.Direction;
            entry["Humidity"] = ((ForecastServiceReference.Forecast[])(Data))[i].Humidity;
            entry["Image"] = ((ForecastServiceReference.Forecast[])(Data))[i].Url;
           table.Rows.Add(entry);
        }
        GridView1.DataSource = table;
        GridView1.DataBind();




        
    }

    //public DataTable GetForecastTable()
    //{
    //    ForecastServiceReference.ForecastWCFClient weatherClient = new ForecastServiceReference.ForecastWCFClient();
    //    DataTable table = new DataTable();
    //    table.TableName = "ForecastTable";
        
    //    weatherClient.GetWeatherForecast(CityTextBox.Text).Count();
    //    table.Columns.Add("Image", typeof(string));
    //    table.Columns.Add("Max Temp", typeof(string));
    //    table.Columns.Add("Min Temp", typeof(string));
    //    table.Columns.Add("Wind", typeof(string));
    //    table.Columns.Add("Humidity", typeof(string));
        
    //    //for (int i = 0; i < weatherClient.GetWeatherForecast(CityTextBox.Text).Length;i++ )
    //    //{
    //    //    DataRow entry = table.NewRow();
    //    //    table.Rows.Add = weatherClient.GetWeatherForecast(CityTextBox.Text)[i]

    //    //}




    //        return table;
    //}
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
       
    }
}