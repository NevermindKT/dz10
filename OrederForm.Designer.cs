namespace Store
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            productBox = new ListBox();
            orderBtn = new Button();
            acclbl = new Label();
            quantityBox = new TextBox();
            SuspendLayout();
            // 
            // productBox
            // 
            productBox.FormattingEnabled = true;
            productBox.Location = new Point(439, 12);
            productBox.Name = "productBox";
            productBox.Size = new Size(349, 274);
            productBox.TabIndex = 0;
            // 
            // orderBtn
            // 
            orderBtn.Location = new Point(628, 303);
            orderBtn.Name = "orderBtn";
            orderBtn.Size = new Size(160, 35);
            orderBtn.TabIndex = 1;
            orderBtn.Text = "Order";
            orderBtn.UseVisualStyleBackColor = true;
            // 
            // acclbl
            // 
            acclbl.AutoSize = true;
            acclbl.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            acclbl.Location = new Point(12, 12);
            acclbl.Name = "acclbl";
            acclbl.Size = new Size(77, 30);
            acclbl.TabIndex = 2;
            acclbl.Text = "<Acc>";
            // 
            // quantityBox
            // 
            quantityBox.Font = new Font("Segoe UI", 15F);
            quantityBox.Location = new Point(439, 303);
            quantityBox.Name = "quantityBox";
            quantityBox.PlaceholderText = "Quantity";
            quantityBox.Size = new Size(183, 34);
            quantityBox.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 350);
            Controls.Add(quantityBox);
            Controls.Add(acclbl);
            Controls.Add(orderBtn);
            Controls.Add(productBox);
            Name = "MainForm";
            Text = "Products";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox productBox;
        private Button orderBtn;
        private Label acclbl;
        private TextBox quantityBox;
    }
}