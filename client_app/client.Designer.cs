namespace client_app
{
    partial class Form1
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
            this.btn_connect = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.btn_restart = new System.Windows.Forms.Button();
            this.btn_shutdown = new System.Windows.Forms.Button();
            this.btn_sleep = new System.Windows.Forms.Button();
            this.btn_edge = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_connect.Location = new System.Drawing.Point(332, 232);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(111, 36);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "connect";
            this.btn_connect.UseVisualStyleBackColor = false;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(250, 299);
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(274, 27);
            this.textBoxLog.TabIndex = 1;
            // 
            // btn_restart
            // 
            this.btn_restart.Location = new System.Drawing.Point(81, 375);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(108, 29);
            this.btn_restart.TabIndex = 2;
            this.btn_restart.Text = "restart";
            this.btn_restart.UseVisualStyleBackColor = true;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // btn_shutdown
            // 
            this.btn_shutdown.Location = new System.Drawing.Point(323, 375);
            this.btn_shutdown.Name = "btn_shutdown";
            this.btn_shutdown.Size = new System.Drawing.Size(120, 29);
            this.btn_shutdown.TabIndex = 3;
            this.btn_shutdown.Text = "shut down";
            this.btn_shutdown.UseVisualStyleBackColor = true;
            this.btn_shutdown.Click += new System.EventHandler(this.btn_shutdown_Click);
            // 
            // btn_sleep
            // 
            this.btn_sleep.Location = new System.Drawing.Point(579, 375);
            this.btn_sleep.Name = "btn_sleep";
            this.btn_sleep.Size = new System.Drawing.Size(112, 29);
            this.btn_sleep.TabIndex = 4;
            this.btn_sleep.Text = "sleep";
            this.btn_sleep.UseVisualStyleBackColor = true;
            this.btn_sleep.Click += new System.EventHandler(this.btn_sleep_Click);
            // 
            // btn_edge
            // 
            this.btn_edge.Location = new System.Drawing.Point(30, 44);
            this.btn_edge.Name = "btn_edge";
            this.btn_edge.Size = new System.Drawing.Size(172, 40);
            this.btn_edge.TabIndex = 5;
            this.btn_edge.Text = "Open Microsoft Edge";
            this.btn_edge.UseVisualStyleBackColor = true;
            this.btn_edge.Click += new System.EventHandler(this.btn_edge_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_edge);
            this.Controls.Add(this.btn_sleep);
            this.Controls.Add(this.btn_shutdown);
            this.Controls.Add(this.btn_restart);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.btn_connect);
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_connect;
        private TextBox textBoxLog;
        private Button btn_restart;
        private Button btn_shutdown;
        private Button btn_sleep;
        private Button btn_edge;
    }
}