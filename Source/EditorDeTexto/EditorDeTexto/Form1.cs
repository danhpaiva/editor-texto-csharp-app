using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EditorDeTexto
{
    public partial class Form1 : Form
    {
        //Criação da variável leitura
        StreamReader leitura = null;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Novo() //Função para criar novo documento
        {
            //Limpar Texto dentro da Caixa de Diálogo
            richTextBox1.Clear();
            //Posicionar o cursor
            richTextBox1.Focus();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novo();
        }
    }
}
