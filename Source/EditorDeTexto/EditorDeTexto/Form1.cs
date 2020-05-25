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

        private void Salvar() //Função para salvar o documento
        {
            try
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //Criação do Arquivo
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter paiva_streamWriter = new StreamWriter(arquivo); //Criação do escritor
                    paiva_streamWriter.Flush(); //Responsável por fazer a transição com o buffer
                    paiva_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin); //A partir de onde começará a escrever
                    paiva_streamWriter.Write(this.richTextBox1.Text); //Conteúdo que será gravado
                    paiva_streamWriter.Flush();
                    paiva_streamWriter.Close(); //Fechar o escritor
                }
            }
            catch (Exception ex) //Caso aconteça algum erro
            {
                MessageBox.Show("Erro na gravação: " + ex.Message, "Erro ao gravar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Abrir() //Função para abrir documento
        {
            this.openFileDialog1.Title = "Abrir arquivo"; //Título da janela
            openFileDialog1.InitialDirectory = ""; //Diretório inicial - Desktop
            openFileDialog1.FileName = ""; //Limpa o nome da busca pelo arquivo
            openFileDialog1.Filter = "Arquivo de texto (*.txt)|*.txt|Todos os arquivos(*.*)|*.*"; //Opção de filtro que irá abrir

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader paiva_streamReader = new StreamReader(arquivo); //Criação do leitor
                    paiva_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";

                    string linha = paiva_streamReader.ReadLine(); //Ler uma linha e armazenar na variável

                    //Enquanto houver linha ele vai ler e armazenar na variavel linha
                    while (linha != null)
                    {
                        this.richTextBox1.Text += linha + "\n";
                        linha = paiva_streamReader.ReadLine(); //Leitura da nova linha
                    }
                    paiva_streamReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de leitura: " + ex.Message, "Erro ao ler arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void Copiar()
        {
            //Verificar se existe uma seleção de texto para copiar
            if (richTextBox1.SelectionLength > 0) //Tem conteúdo selecionado
            {
                richTextBox1.Copy(); //Copiar conteúdo
            }
        }

        private void Colar()
        {
            richTextBox1.Paste(); //Colar conteúdo
        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void btn_colar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void Negritar()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool negrito, italico, sublinhado = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular); //Colocar o texto de forma comum (sem negrito)

            //Verificação se o campo selecionado está em negrito
            if (negrito == false)
            {
                if (italico == true & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline); //Colocar o texto em negrito, itálico e sublinhado
                }
                else if (italico == false & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline); //Colocar o texto em negrito e sublinhado
                }
                else if (italico == true & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic); //Colocar o texto em negrito e itálico
                }
                else if (italico == false & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold); //Colocar o texto em negrito
                }
            }
            else
            {
                if (italico == true & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline); //Colocar o texto itálico e sublinhado
                }
                else if (italico == false & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline); //Colocar o texto em sublinhado
                }
                else if (italico == true & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic); //Colocar o texto em itálico
                }
            }
        }

        private void Italicar()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool negrito, italico, sublinhado = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular); //Colocar o texto de forma comum

            //Verificação se o campo selecionado está em itálico
            if (italico == false)
            {
                if (negrito == true & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline); //Colocar o texto em negrito, itálico e sublinhado
                }
                else if (negrito == false & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline); //Colocar o texto em itálico e sublinhado
                }
                else if (negrito == true & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic); //Colocar o texto em negrito e itálico
                }
                else if (negrito == false & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic); //Colocar o texto em Itálico
                }
            }
            else
            {
                if (negrito == true & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline); //Colocar o texto negrito e sublinhado
                }
                else if (negrito == false & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline); //Colocar o texto em sublinhado
                }
                else if (negrito == true & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold); //Colocar o texto em negrito
                }
            }
        }

        private void Sublinhar()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool negrito, italico, sublinhado = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular); //Colocar o texto de forma comum

            //Verificação se o campo selecionado está sublinhado
            if (sublinhado == false)
            {
                if (negrito == true & italico == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline); //Colocar o texto em negrito, itálico e sublinhado
                }
                else if (negrito == false & italico == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline); //Colocar o texto em itálico e sublinhado
                }
                else if (negrito == true & italico == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline); //Colocar o texto em negrito e sublinhado
                }
                else if (negrito == false & italico == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline); //Colocar o texto sublinhado
                }
            }
            else
            {
                if (negrito == true & italico == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic); //Colocar o texto negrito e italico
                }
                else if (negrito == false & italico == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic); //Colocar o texto em itálico
                }
                else if (negrito == true & italico == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold); //Colocar o texto em negrito
                }
            }
        }

        private void alinharEsquerda() //ALinhar texto a esquerda
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void alinharCentro()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void alinharDireita()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }


        private void btn_negrito_Click(object sender, EventArgs e)
        {
            Negritar();
        }

        private void btn_italico_Click(object sender, EventArgs e)
        {
            Italicar();
        }

        private void btn_sublinhado_Click(object sender, EventArgs e)
        {
            Sublinhar();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negritar();
        }

        private void itálicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italicar();
        }

        private void btn_esquerda_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void btn_centro_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void btn_direita_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void diretaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }
    }
}
