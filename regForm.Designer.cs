namespace Store
{
    partial class RegForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            applyBtn = new Button();
            nameBox = new TextBox();
            createBtn = new Button();
            SuspendLayout();
            // 
            // applyBtn
            // 
            applyBtn.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            applyBtn.Location = new Point(258, 104);
            applyBtn.Name = "applyBtn";
            applyBtn.Size = new Size(451, 44);
            applyBtn.TabIndex = 0;
            applyBtn.Text = "Apply";
            applyBtn.UseVisualStyleBackColor = true;
            // 
            // nameBox
            // 
            nameBox.Font = new Font("Segoe UI", 16F);
            nameBox.Location = new Point(12, 31);
            nameBox.Name = "nameBox";
            nameBox.PlaceholderText = "Enter name";
            nameBox.Size = new Size(697, 36);
            nameBox.TabIndex = 1;
            nameBox.TextAlign = HorizontalAlignment.Center;
            // 
            // createBtn
            // 
            createBtn.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            createBtn.Location = new Point(12, 104);
            createBtn.Name = "createBtn";
            createBtn.Size = new Size(240, 44);
            createBtn.TabIndex = 2;
            createBtn.Text = "Create";
            createBtn.UseVisualStyleBackColor = true;
            // 
            // RegForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(721, 169);
            Controls.Add(createBtn);
            Controls.Add(nameBox);
            Controls.Add(applyBtn);
            Name = "RegForm";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button applyBtn;
        private TextBox nameBox;
        private Button createBtn;
    }
}
