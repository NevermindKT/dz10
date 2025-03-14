using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();

            applyBtn.Click += ApplyBtn_Click;
            createBtn.Click += CreateBtn_Click;
        }

        private void CreateBtn_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameBox.Text))
            {
                MessageBox.Show("Ошибка ввода.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new MyDbContext())
            {
                var user = new User
                {
                    Name = nameBox.Text
                };

                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Такой пользователь уже есть.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void ApplyBtn_Click(object? sender, EventArgs e)
        {
            int currentUserId = getUser(nameBox.Text);

            if (string.IsNullOrEmpty(nameBox.Text) || currentUserId <= 0)
            {
                MessageBox.Show("Пользователь не найден/Ошибка ввода.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form mainForm = new MainForm(currentUserId);
                this.Hide();
                mainForm.ShowDialog();
                this.Show();
            }
        }

        private int getUser(string username)
        {
            using (var db = new MyDbContext())
            {
                int userId = db.Users
                               .Where(u => u.Name == username)
                               .Select(u => u.Id)
                               .FirstOrDefault();

                return userId;
            }
        }
    }
}