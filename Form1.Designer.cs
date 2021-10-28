
namespace KafkaClients
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
            this.addTopicButton = new System.Windows.Forms.Button();
            this.produceMessageButton = new System.Windows.Forms.Button();
            this.consumeMessageButton = new System.Windows.Forms.Button();
            this.field1TextBox = new System.Windows.Forms.TextBox();
            this.field2TextBox = new System.Windows.Forms.TextBox();
            this.field1Label = new System.Windows.Forms.Label();
            this.field2Label = new System.Windows.Forms.Label();
            this.consumerGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.adminGroupBox = new System.Windows.Forms.GroupBox();
            this.consumerGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.adminGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // addTopicButton
            // 
            this.addTopicButton.Location = new System.Drawing.Point(183, 19);
            this.addTopicButton.Name = "addTopicButton";
            this.addTopicButton.Size = new System.Drawing.Size(166, 23);
            this.addTopicButton.TabIndex = 0;
            this.addTopicButton.Text = "1. Add Topic";
            this.addTopicButton.UseVisualStyleBackColor = true;
            this.addTopicButton.Click += new System.EventHandler(this.addTopicButton_Click);
            // 
            // produceMessageButton
            // 
            this.produceMessageButton.Location = new System.Drawing.Point(186, 115);
            this.produceMessageButton.Name = "produceMessageButton";
            this.produceMessageButton.Size = new System.Drawing.Size(166, 23);
            this.produceMessageButton.TabIndex = 2;
            this.produceMessageButton.Text = "2. Produce msg";
            this.produceMessageButton.UseVisualStyleBackColor = true;
            this.produceMessageButton.Click += new System.EventHandler(this.produceMessageButton_Click);
            // 
            // consumeMessageButton
            // 
            this.consumeMessageButton.Location = new System.Drawing.Point(184, 19);
            this.consumeMessageButton.Name = "consumeMessageButton";
            this.consumeMessageButton.Size = new System.Drawing.Size(166, 23);
            this.consumeMessageButton.TabIndex = 0;
            this.consumeMessageButton.Text = "3. Consume msg";
            this.consumeMessageButton.UseVisualStyleBackColor = true;
            this.consumeMessageButton.Click += new System.EventHandler(this.consumeMessageButton_Click);
            // 
            // field1TextBox
            // 
            this.field1TextBox.Location = new System.Drawing.Point(68, 34);
            this.field1TextBox.Multiline = true;
            this.field1TextBox.Name = "field1TextBox";
            this.field1TextBox.Size = new System.Drawing.Size(100, 50);
            this.field1TextBox.TabIndex = 0;
            // 
            // field2TextBox
            // 
            this.field2TextBox.Location = new System.Drawing.Point(68, 90);
            this.field2TextBox.Multiline = true;
            this.field2TextBox.Name = "field2TextBox";
            this.field2TextBox.Size = new System.Drawing.Size(100, 48);
            this.field2TextBox.TabIndex = 1;
            // 
            // field1Label
            // 
            this.field1Label.AutoSize = true;
            this.field1Label.Location = new System.Drawing.Point(27, 41);
            this.field1Label.Name = "field1Label";
            this.field1Label.Size = new System.Drawing.Size(35, 13);
            this.field1Label.TabIndex = 5;
            this.field1Label.Text = "Field1";
            // 
            // field2Label
            // 
            this.field2Label.AutoSize = true;
            this.field2Label.Location = new System.Drawing.Point(27, 95);
            this.field2Label.Name = "field2Label";
            this.field2Label.Size = new System.Drawing.Size(35, 13);
            this.field2Label.TabIndex = 6;
            this.field2Label.Text = "Field2";
            // 
            // consumerGroupBox
            // 
            this.consumerGroupBox.Controls.Add(this.consumeMessageButton);
            this.consumerGroupBox.Location = new System.Drawing.Point(1, 210);
            this.consumerGroupBox.Name = "consumerGroupBox";
            this.consumerGroupBox.Size = new System.Drawing.Size(361, 66);
            this.consumerGroupBox.TabIndex = 3;
            this.consumerGroupBox.TabStop = false;
            this.consumerGroupBox.Text = "Consumer";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.produceMessageButton);
            this.groupBox1.Controls.Add(this.field1Label);
            this.groupBox1.Controls.Add(this.field2Label);
            this.groupBox1.Controls.Add(this.field1TextBox);
            this.groupBox1.Controls.Add(this.field2TextBox);
            this.groupBox1.Location = new System.Drawing.Point(-1, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 144);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producer";
            // 
            // adminGroupBox
            // 
            this.adminGroupBox.Controls.Add(this.addTopicButton);
            this.adminGroupBox.Location = new System.Drawing.Point(2, 6);
            this.adminGroupBox.Name = "adminGroupBox";
            this.adminGroupBox.Size = new System.Drawing.Size(361, 52);
            this.adminGroupBox.TabIndex = 0;
            this.adminGroupBox.TabStop = false;
            this.adminGroupBox.Text = "Admin";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 283);
            this.Controls.Add(this.consumerGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.adminGroupBox);
            this.Name = "MainForm";
            this.Text = "Kafka Client";
            this.consumerGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.adminGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addTopicButton;
        private System.Windows.Forms.Button produceMessageButton;
        private System.Windows.Forms.Button consumeMessageButton;
        private System.Windows.Forms.TextBox field1TextBox;
        private System.Windows.Forms.TextBox field2TextBox;
        private System.Windows.Forms.Label field1Label;
        private System.Windows.Forms.Label field2Label;
        private System.Windows.Forms.GroupBox consumerGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox adminGroupBox;
    }
}

