using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Glazki.Class;
namespace Glazki.Model
{
    public partial class Agent
    {
        public string ImagePath
        {
            get
            {
                if (Logo is null)
                {
                    return "/Resources/picture.png";
                }
                else
                {
                    return Directory.GetCurrentDirectory() + Logo.ToString();
                }
            }
        }
        public string CountForYear
        {
            get
            {
                List<ProductSale> productSales = ProductSale.Where(s => s.AgentID == ID && s.SaleDate > DateTime.Today.AddDays(-365)).ToList();
                int countSales = 0;
                foreach (var i in productSales)
                {
                    countSales += i.ProductCount;
                }
                return countSales.ToString();
            }
        }
        public string Percent
        {
            get
            {
                List<ProductSale> productSales = ProductSale.Where(s => s.AgentID == ID).ToList();
                List<Product> products = AgentExtension.GetProducts();

                decimal SUM = 0;
                foreach (var item in productSales)
                {
                    SUM += item.ProductCount * products.Where(w => w.ID == item.ProductID).Select(s => s.MinCostForAgent).FirstOrDefault();
                }
                if (SUM >= 10000 && SUM <= 5000)
                {
                    return "5 %";
                }
                else if (SUM >= 50000 && SUM<=15000)
                {
                    return "10 %";
                }
                else if (SUM >= 150000 && SUM <= 500000)
                {
                    return "20 %";
                }
                else if (SUM > 500000)
                {
                    return "25 %";
                }
                else
                {
                    return "0 %";
                }
            }
        }
        public string BackgroundColor
        {
            get
            {
                string i = Percent;
                if (i == "25 %")
                {
                    return "LightGreen";
                }
                else
                {
                    return "#FFF";
                }
            }
        }
    }
}
