using Microsoft.Identity.Client;
using Store.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Store
{
    public partial class MainForm: Form
    {
        public int currentId;

        public MainForm(int Id)
        {
            InitializeComponent();

            currentId = Id;

            acclbl.Text = $"{getUserName(currentId)}";

            productBox.DataSource = getProductList();
            productBox.DisplayMember = "DisplayProduct";

            orderBtn.Click += OrderBtn_Click;
        }

        private void OrderBtn_Click(object? sender, EventArgs e)
        {
            Product? selectedProduct = productBox.SelectedItem as Product;

            if (selectedProduct == null)
            {
                MessageBox.Show("Продукт не найден/Ошибка ввода.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int orderQuantity;
            if (!int.TryParse(quantityBox.Text, out orderQuantity) || orderQuantity <= 0)
            {
                MessageBox.Show("Некоректный ввод.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedProduct.Quantity.GetValueOrDefault() < orderQuantity)
            {
                MessageBox.Show("Недостаточно товара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            insertOrder(selectedProduct, orderQuantity);
        }

        private void insertOrder(Product? product, int quantity)
        {
            using (var context = new MyDbContext())
            {
                var dbProduct = context.Products.FirstOrDefault(p => p.Id == product.Id);

                if (dbProduct == null)
                {
                    MessageBox.Show("Продукт не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dbProduct.Quantity -= quantity;

                Order order = new Order
                {
                    IdUser = currentId,
                    IdProduct = product.Id,
                    Quantity = quantity
                };

                context.Orders.Add(order);
                context.SaveChanges();
                productBox.DataSource = getProductList();
            }
        }

        private List<Product> getProductList()
        {
            using (var context = new MyDbContext())
            {
                List<Product> products = context.Products.ToList();

                return products;
            }
        }

        private string getUserName(int userId)
        {
            using (var db = new MyDbContext())
            {
                string? userName = db.Users
                               .Where(u => u.Id == userId)
                               .Select(u => u.Name)
                               .FirstOrDefault();

                return userName;
            }
        }
    }
}