namespace BrainfkInterpreter
{
	public partial class Form1 : Form
	{

		private Label brainfkLabel = new Label();
		private TextBox brainfkTextBox = new TextBox();
		private Button brainfkButton = new Button();
		private Label outputLabel = new Label();
		private Label output = new Label();
		private Label errorMessage = new Label();

		public Form1()
		{
			InitializeComponent();
			brainfkButton.Click += new EventHandler(brainfkButton_Click);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.BackColor = Color.FromArgb(45, 45, 48);
			this.ForeColor = Color.White;

			brainfkLabel.Text = "Insert Brainfk code here: ";
			brainfkLabel.Location = new Point(30, 30);
			brainfkLabel.Width = 500;
			brainfkLabel.ForeColor = Color.DeepSkyBlue;
			brainfkLabel.Font = new Font("Calibri", 12, FontStyle.Bold);
			this.Controls.Add(brainfkLabel);

			brainfkTextBox.Location = new Point(30, 60);
			brainfkTextBox.Multiline = true;
			brainfkTextBox.Width = 740;
			brainfkTextBox.Height = 100;
			brainfkTextBox.BackColor = Color.FromArgb(30, 30, 35);
			brainfkTextBox.ForeColor = Color.White;
			brainfkTextBox.BorderStyle = BorderStyle.FixedSingle;
			this.Controls.Add(brainfkTextBox);

			brainfkButton.Location = new Point(650, 30);
			brainfkButton.Text = "Run Interpreter";
			brainfkButton.Width = 120;
			brainfkButton.Height = 30;
			brainfkButton.BackColor = Color.DeepSkyBlue;
			brainfkButton.ForeColor = Color.White;
			brainfkButton.FlatStyle = FlatStyle.Flat;
			brainfkButton.FlatAppearance.BorderSize = 0;
			this.Controls.Add(brainfkButton);

			outputLabel.Text = "Output :";
			outputLabel.Location = new Point(30, 170);
			outputLabel.ForeColor = Color.DeepSkyBlue;
			outputLabel.Width = 70;
			outputLabel.Font = new Font("Calibri", 12, FontStyle.Bold);
			this.Controls.Add(outputLabel);

			errorMessage.Text = "";
			errorMessage.Location = new Point(100, 170);
			errorMessage.ForeColor = Color.Red;
			errorMessage.Font = new Font("Calibri", 12, FontStyle.Bold);
			errorMessage.Width = 500;
			this.Controls.Add(errorMessage);

			output.Text = "";
			output.Location = new Point(30, 200);
			output.Width = 740;
			output.Height = 70;
			output.BackColor = Color.FromArgb(30, 30, 35);
			output.ForeColor = Color.White;
			output.BorderStyle = BorderStyle.FixedSingle;
			this.Controls.Add(output);
		}

		private void brainfkButton_Click(object sender, EventArgs e)
		{
			Interpreter interpreter = new Interpreter();
			(string result, bool isValid) = interpreter.Run(brainfkTextBox.Text);

			if (isValid)
			{
				output.Text = result;
				errorMessage.Text = "";
			}
			else
			{
				output.Text = "";
				errorMessage.Text = "Invalid Brainfk Code!";
			}
		}
	}
}
