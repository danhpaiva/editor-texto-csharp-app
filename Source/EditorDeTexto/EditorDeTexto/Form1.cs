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

        private void Negrito()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool negrito = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            negrito = richTextBox1.Font.Bold;

            //Verificação se o campo selecionado está em negrito
            if (negrito == false)
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold); //Colocar o negrito no texto
            }
            else
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular); //Colocar o texto de forma comum (sem negrito)
            }    
        }

        private void Italico()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool italico = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            italico = richTextBox1.Font.Bold;

            //Verificação se o campo selecionado está em italico
            if (italico == false)
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic); //Colocar o itálico no texto
            }
            else
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular); //Colocar o texto de forma comum (sem itálico)
            }
        }
    }
}
