namespace JuegoMemorama
{
    public partial class Form1 : Form
    {
        Random randy = new Random();

        List<string> iconosjuego = new List<string>()
        {
            "l","l", "e","e", "m","m", "o","o",
            ",",",", "G","G","C","C","O","O"
        };

        Label firstClicked, secondClicked;

        public Form1()
        {
            InitializeComponent();
            AsignarIconos();
        }

        private void AsignarIconos()
        {
            Label labelAllenar;
            int randomNumber;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    labelAllenar = (Label)tableLayoutPanel1.Controls[i];
                else

                    continue;

                randomNumber = randy.Next(0, iconosjuego.Count);
                labelAllenar.Text = iconosjuego[randomNumber];

                iconosjuego.RemoveAt(randomNumber);
            }

        }

        private void AverSiGanaste()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }

            MessageBox.Show("Ganaste EL MEMORAMA de Pablo. Felicidades!");
            Close();
        }





        private void label_click(object sender, EventArgs e)
        {
            if (firstClicked != null && secondClicked != null)
                return;
            Label clickedlabel = sender as Label;

            if (clickedlabel == null)
                return;

            if (clickedlabel.ForeColor == Color.Black)
                return;

            if (firstClicked == null)
            {
                firstClicked = clickedlabel;
                firstClicked.ForeColor = Color.Black;
                return;
            }

            secondClicked = clickedlabel;
            secondClicked.ForeColor = Color.Black;

            AverSiGanaste();

            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
            }
            else
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }
    }
}