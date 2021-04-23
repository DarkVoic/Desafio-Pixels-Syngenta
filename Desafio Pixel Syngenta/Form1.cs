using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio_Pixel_Syngenta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Classe para abrir o diretorio para o arquivo
            OpenFileDialog file = new OpenFileDialog();

            // Tipos de arquivos aceitos
            file.Filter = "bmp|*.bmp|jpg|*.jpg|png|*.png";

            if (file.ShowDialog() == DialogResult.OK)
            {
                // Variável recebendo o arquivo de imagem selecionada
                pictureBox1.ImageLocation = file.FileName;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Contador de pixels 
            var count = 0;

            Bitmap img = new Bitmap(pictureBox1.Image);
            
            // Metodo de repetição para passar em cada pixel, por matriz.
            for (var x = 0; x < img.Width; x++)
            {
                for (var y = 0; y < img.Height; y++)
                {
                    Color pixelColor = img.GetPixel(x, y);

                    // Se o pixel da variável pixelColor for da cor verde de valores entre 0 a 199.
                    if (pixelColor.G > 0 && pixelColor.G < 200)
                    { 
                        count++;
                        // "setando" o pixel verde contado, alterando para a cor vermelha 
                        img.SetPixel(x, y, Color.Red);
                    }
                }
            }

            // retornar a imagem alterada com os pixels em cor vermelho.
            pictureBox1.Image = img;

            var percent = ((float)count / (img.Width * img.Height)) * 100;
            label1.Text = String.Format("A imagem contém {0:d} pixels (ou seja, uma área equivalente a {1:f}%)", count, percent);
        }
    }
}

