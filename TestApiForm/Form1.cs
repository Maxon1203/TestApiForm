using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApi2.Models;

namespace TestApiForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public HttpClient Request_Client()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:62062/");
            return client;
        }

        public IEnumerable<Json> Request_Json()
        {
            var client = Request_Client();
            HttpResponseMessage response = client.GetAsync("api/Jsons").Result;
            var json = response.Content.ReadAsAsync<IEnumerable<Json>>().Result;
            return json;

        }
        public void AddJson()
        {

        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Request_Json();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var client = Request_Client();
            HttpResponseMessage responsse = client.DeleteAsync($"api/Jsons/{dataGridView1.CurrentRow.Cells[0].Value}").Result;
        }
    }
}
