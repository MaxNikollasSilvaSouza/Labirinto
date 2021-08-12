using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Jogo_do_Labirinto
{
    public partial class Form1 : Form
    {
       
        int tempo_total; 
        Boolean SAIR = false;
        Labirinto labirinto = new Labirinto();
        Boolean retorno;
        Int16 pontostotais;
        int passos;
        
        public Form1()
        {
            InitializeComponent();
            label1.Hide();
            
            textBox1.Hide();
            
            checkBox1.Hide();
            dataGridView1.Hide();
            button9.Hide();
            textBox2.Hide();
            textBox3.Hide();
            label5.Hide();
            label4.Hide();
            button4.Hide();
            passos = 0;
            pontostotais = 0;
            B1.Hide();
            button2.Hide();
            button1.Hide();
           
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            comeco_Form1();

        }
        private void comeco_Form1()
        {
            
            
        }

        public void desenha_labirinto()
        {
            if (checkBox2.Checked == true)
            {
                for (int i = 0; i < labirinto.obtem_linhas(); i++)
                {
                    //Ajusta a altura da Linha
                    dataGridView1.Rows[i].Height = 18;

                    for (int j = 0; j < labirinto.obtem_colunas(); j++)
                    {
                        //Ajusta a largura da coluna
                        dataGridView1.Columns[j].Width = 18;

                        //Escolhe a cor baseado no valor escrito na matriz do labirinto
                        switch (labirinto.obtem_valor(i, j))
                        {
                            case "P":
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Black;
                                break;

                            case "R":
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Silver;
                                break;

                            case "Q":
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                                break;

                            case "X":
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                                break;
                            case "E":
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.OrangeRed;
                                break;
                            case "r":
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Turquoise;
                                break;

                            default:
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.DarkBlue;
                                break;
                        }
                    }

                }

            }
            else
            {
                for (int i = 0; i < labirinto.obtem_linhas(); i++)
                {
                    //Ajusta a altura da Linha
                    dataGridView1.Rows[i].Height = 18;

                    for (int j = 0; j < labirinto.obtem_colunas(); j++)
                    {
                        //Ajusta a largura da coluna
                        dataGridView1.Columns[j].Width = 18;

                        //Escolhe a cor baseado no valor escrito na matriz do labirinto
                        switch (labirinto.obtem_valor(i, j))
                        {
                            case "P":
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Chocolate;
                                break;

                            case "R":
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Black;
                                break;

                            case "Q":
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                                break;

                            case "X":
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                                break;

                            case "E":
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Pink;
                                break;

                            case "r":
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Brown;
                                break;

                            default:
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                                break;

                        }
                    }

                }
            }
        }

        private void B1_Click(object sender, EventArgs e)
        {
          
            if (checkBox3.Checked == true)
            {
                if (textBox1.Text != null)
                {
                    try
                    {
                        
                        checkBox1.Hide();
                        checkBox2.Hide();
                        labirinto.reinicia_pontuacao(0);
                        label3.Text = "0";
                        label7.Text = "0";
                        label8.Text = "0";
                        button1.Show();
                        button2.Show();
                        dataGridView1.Show();
                        button1.Show();
                        button2.Show();
                        button9.Show();
                        tempo_total = Convert.ToInt32(textBox1.Text);                                                
                        comeco_Form1();                                                                    
                        labirinto.mudaqueijo(Convert.ToInt16(textBox2.Text) - pontostotais);
                        desenha_labirinto();
                        this.Refresh();
                        
                        
                    }
                    catch
                    {
                        MessageBox.Show("Coloque corretamente o que é solicitado nos textbox.");
                    }
                }
            }
            else
            {
                if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null)
                {
                    try
                    {
                        checkBox1.Enabled = true;
                        labirinto.reinicia_pontuacao(0);
                        label3.Text = "0";
                        label7.Text = "0";
                        label8.Text = "0";
                        button1.Show();
                        button2.Show();
                        dataGridView1.Show();
                        button4.Show();
                        tempo_total = Convert.ToInt32(textBox1.Text);

                        comeco_Form1();
                        labirinto.mudaqueijo(Convert.ToInt16(textBox2.Text) - pontostotais);
                        desenha_labirinto();
                        this.Refresh();
                       
                       
                    }
                    catch
                    {
                        MessageBox.Show("Coloque o tempo que voce deseja ver o rato andando no textbox.");
                        
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int linhas = dataGridView1.CurrentCell.RowIndex;
            int coluna = dataGridView1.CurrentCell.ColumnIndex;
            labirinto.define_celula_valor(linhas, coluna, "P");
            desenha_labirinto();
            dataGridView1.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int linhas = dataGridView1.CurrentCell.RowIndex;
            int coluna = dataGridView1.CurrentCell.ColumnIndex;
            labirinto.define_celula_valor(linhas, coluna, "");
            desenha_labirinto();
            dataGridView1.ClearSelection();



        }





        private void button5_Click(object sender, EventArgs e)
        {
            labirinto.movimenta_rato('C');
            desenha_labirinto();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            labirinto.movimenta_rato('E');
            desenha_labirinto();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            labirinto.movimenta_rato('B');
            desenha_labirinto();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            labirinto.movimenta_rato('D');
            desenha_labirinto();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            do
            {
                labirinto.automatico();
                desenha_labirinto();

                Form1.ActiveForm.Refresh();

            } while (labirinto.queijo.obtem_colunas() != labirinto.rato.obtem_colunas() || labirinto.queijo.obtem_linhas() != labirinto.rato.obtem_linhas());
            MessageBox.Show("Achei o Queijo!");

        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                retorno = true;
                comeco_Form1();
            }
            else
            {
                retorno = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Hide();
            B1.Hide();
            textBox1.Hide();
            label1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            label5.Hide();
            label4.Hide();
            timer1.Enabled = true;
            timer2.Enabled = true;
            button4.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = labirinto.Punto.ToString();
            
                labirinto.Automatico_Teseu();
                desenha_labirinto();

                this.Refresh();
            
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int tempo = Convert.ToInt32(label3.Text);
            tempo += 1;
            label3.Text = tempo.ToString();
            
            
            if (tempo == Convert.ToInt16(textBox1.Text) || labirinto.Punto == Convert.ToInt16(textBox2.Text))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox3.Hide();
                label1.Hide();
                textBox1.Hide();
                label10.Show();
                label11.Show();
                button10.Show();
                textBox4.Show();
                textBox5.Show();

                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
               
                
                button1.Hide();
                B1.Hide();
                button2.Hide();
                dataGridView1.Hide();
                button9.Hide();
                button4.Hide();
               
                

            }
            else
            {
                checkBox1.Enabled = true;
                checkBox3.Hide();
                label1.Hide();
                textBox1.Hide();
                label10.Show();
                label11.Show();
                button10.Show();
                textBox4.Show();
                textBox5.Show();
                
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
           
                
                button1.Hide();
                B1.Hide();
                button2.Hide();
                dataGridView1.Hide();
                textBox2.Text = "1";
                textBox3.Text = "0";
                button4.Hide();
                button9.Hide();
                textBox2.Hide();
                textBox3.Hide();
                label5.Hide();
                label4.Hide();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            checkBox1.Hide();
            checkBox2.Hide();
            button1.Hide();
            button2.Hide();
            B1.Hide();
            textBox1.Hide();
            label1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            label5.Hide();
            label4.Hide();
            timer3.Enabled = true;
            timer4.Enabled = true;
            button9.Hide();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            labirinto.Automatico_Teseu();
            desenha_labirinto();

            this.passos += 1;
            label8.Text = labirinto.Punto.ToString();
            label7.Text = passos.ToString();
           
            if (this.passos == Convert.ToInt16(textBox3.Text))
            {
               labirinto.mudaqueijo(Convert.ToInt16(textBox2.Text)-Convert.ToInt16(label8.Text));
               this.passos = 0;                              
            }
            
            this.Refresh();
        }

       
        private void timer4_Tick(object sender, EventArgs e)
        {
            int tempo = Convert.ToInt32(label3.Text);
            tempo += 1;
            label3.Text = tempo.ToString();

            if (pontostotais == Convert.ToInt16(textBox2.Text))
            {
                timer4.Enabled = false;
                timer3.Enabled = false;
            }

            if (tempo == Convert.ToInt16(textBox1.Text) || labirinto.Punto == Convert.ToInt16(textBox2.Text))
            {
                timer3.Enabled = false;
                timer4.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox3.Checked == false)
                {
                    if (textBox1.Text != null && Convert.ToInt16(textBox1.Text) > 4 && Convert.ToInt16(textBox1.Text) <= 999)
                    {
                        B1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Digite um valor ente 5 e 999");
                    }
                }
                else if (checkBox3.Checked == true && Convert.ToInt16(textBox1.Text) > 4 && Convert.ToInt16(textBox1.Text) <= 999)
                {
                    if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null)
                    {
                        label4.Show();
                        textBox2.Show();
                    }

                }
                else
                {
                    label4.Hide();
                    textBox2.Hide();
                    MessageBox.Show("Digite um valor ente 5 e 999.");
                }
            }
            catch
            {
                label4.Hide();
                textBox2.Hide();
                MessageBox.Show("Digite valores numéricos simples e inteiros!!!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox3.Checked == true && Convert.ToInt16(textBox2.Text) > 0 && Convert.ToInt16(textBox2.Text) <= 13)
                {
                    if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null)
                    {
                        label5.Show();
                        textBox3.Show();
                    }
                }
                else
                {
                    label5.Hide();
                    textBox3.Hide();
                    MessageBox.Show("Digite um valor ente 1 e 10.");
                }
            }
            catch
            {
                label5.Hide();
                textBox3.Hide();
                MessageBox.Show("Digite valores numéricos simples e inteiros!!!");
            }
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox3.Checked == true && Convert.ToInt16(textBox3.Text) > 0 && Convert.ToInt16(textBox3.Text) <= 30)
                {
                    if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null)
                    {
                        B1.Show();
                    }
                }
                else
                {
                    B1.Hide();
                    MessageBox.Show("Digite um valor ente 0 e 30.");
                }
            }

            catch
            {
                B1.Hide();
                MessageBox.Show("Digite valores numéricos simples e inteiros!!!");
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
               int linha = Convert.ToInt16(textBox4.Text);
               int coluna = Convert.ToInt16(textBox5.Text);
               
                if (linha > 9 && coluna > 9 && linha<=50 && coluna <= 50)
               {
                   labirinto.define_linhas(linha);
                   labirinto.define_colunas(coluna);

                   label10.Hide();
                   label11.Hide();
                   button10.Hide();
                   textBox4.Hide();
                   textBox5.Hide();
                   checkBox3.Show();
                   label1.Show();
                   textBox1.Show();

                   if (checkBox3.Checked == true )//&& checkBox2.Checked == true)
                   {
                       labirinto.inicializa_matriz(false, Convert.ToInt16(textBox2.Text));
                   }
                   else if (checkBox3.Checked == false)// && checkBox2.Checked == false)
                   {
                       labirinto.inicializa_matriz(true, Convert.ToInt16(textBox2.Text));
                   }
                   //Desenha o labirinto
                   dataGridView1.ColumnCount = labirinto.obtem_colunas();
                   dataGridView1.RowCount = labirinto.obtem_linhas();
               }
               else
               {
                   MessageBox.Show("Medida inválida, Digite uma medida entre 10 e 50 linhas ou colunas para o labirinto.");
               }
            }
            catch
            {
                MessageBox.Show("Medida inválida, Digite uma medida entre 10 e 50 linhas ou colunas para o labirinto.");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        

        

       













    }



    public class Labirinto
    {
        public void reinicia_pontuacao(int zero)
        {
            this.pontuacao = zero;
        }
        private int pontuacao = 0;
        private int linhas = 0;
        private int colunas = 0;
        private char ultimo = 'N';
        String[,] matriz;

        public int Punto { get { return pontuacao; } }
        Random aleatorio = new Random();
        public Rato rato = new Rato();
        public Queijo queijo = new Queijo();
       
        public void define_linhas(int linhas_1)
        {
            this.linhas = linhas_1;          
            
        }

        public void define_colunas(int colunas)
        {
            this.colunas = colunas;
        }

        public void start()
        {
            this.matriz = new String[linhas, colunas];
        }

        public void inicializa_matriz(Boolean RADIOBUTTON2, int quantidade)
        {
            this.matriz = new String[linhas, colunas];
            if (RADIOBUTTON2 == true)
            {//11  


                for (int i = 0; i < this.linhas; i++)
                {//2
                    for (int j = 0; j < this.colunas; j++)
                    {//1

                        if (i == 0 || i == this.linhas - 1 || j == 0 || j == this.colunas - 1)
                        {
                            this.matriz[i, j] = "P";
                        }
                        else
                        {
                            this.matriz[i, j] = "";
                        }

                    }//1
                }//2

                //mexer no meio                                              

                int quantidade_de_paredes = 14;

                for (int i = 0; i < quantidade_de_paredes; i++)
                {//10
                    int linha;
                    int coluna;
                    

                    do
                    {
                        linha = aleatorio.Next(1, this.linhas - 1);
                        coluna = aleatorio.Next(1, this.colunas - 1);
                    } while (this.matriz[linha + 1, coluna] == "P" ||
                        this.matriz[linha, coluna - 1] == "P" ||
                        this.matriz[linha, coluna + 1] == "P" ||
                        this.matriz[linha - 1, coluna] == "P" ||
                        this.matriz[linha - 1, coluna - 1] == "P" ||
                         this.matriz[linha - 1, coluna + 1] == "P" ||
                        this.matriz[linha + 1, coluna - 1] == "P" ||
                         this.matriz[linha + 1, coluna + 1] == "P");


                    this.matriz[linha, coluna] = "E";
                    Boolean sair = false;
                    int linha_referencia = linha;
                    int coluna_referencia = coluna;

                    if (i<7)
                    {//6
                        while (sair == false)
                        {//4
                            if (this.matriz[linha, coluna + 1] == "")
                            {
                                coluna = coluna + 1;
                                this.matriz[linha, coluna] = "P";
                            }

                            else
                            {
                                sair = true;
                            }
                        }//4
                        sair = false;
                        linha = linha_referencia;
                        coluna = coluna_referencia;

                        while (sair == false)
                        {//5
                            if (this.matriz[linha, coluna - 1] == "")
                            {
                                coluna = coluna - 1;
                                this.matriz[linha, coluna] = "P";
                            }

                            else
                            {
                                sair = true;
                            }
                        }//5 
                        sair = false;
                    }//6

                    else
                    {//9
                        while (sair == false)
                        {//7
                            if (this.matriz[linha + 1, coluna] == "")
                            {
                                linha = linha + 1;
                                this.matriz[linha, coluna] = "P";
                            }

                            else
                            {
                                sair = true;
                            }
                        }//7 
                        sair = false;
                        linha = linha_referencia;
                        coluna = coluna_referencia;
                        while (sair == false)
                        {//8
                            if (this.matriz[linha - 1, coluna] == "")
                            {
                                linha = linha - 1;
                                this.matriz[linha, coluna] = "P";
                            }
                            else
                            {
                                sair = true;
                            }
                        }//8

                        sair = false;
                    }//9


                }//10

            }//11

                //radio button desativado

            else
            {
           
                for (int i = 0; i < this.linhas; i++)
                {
                    for (int j = 0; j < this.colunas; j++)
                    {

                        if (i == 0 || i == this.linhas - 1 || j == 0 || j == this.colunas - 1)
                        {
                            this.matriz[i, j] = "P";
                            
                        }
                        else
                        {if (aleatorio.Next(0, 10) % 4 == 0)
                            {
                               
                                    this.matriz[i, j] = "P";
                                  
                            }
                            else
                            {
                                this.matriz[i, j] = "";
                            }
                            }
                        
                    }
                }
            }


            this.rato.define_linhas(aleatorio.Next(1, this.linhas - 2));
            this.rato.define_colunas(aleatorio.Next(1, this.colunas - 2));
            this.matriz[rato.obtem_linhas(), rato.obtem_colunas()] = "R";
            //do
            //{
            //    this.queijo.define_linhas(aleatorio.Next(1, this.linhas - 2));
            //    this.queijo.define_colunas(aleatorio.Next(1, this.colunas - 2));

            //} while (this.queijo.obtem_linhas() == this.rato.obtem_linhas() && this.queijo.obtem_colunas() == this.rato.obtem_colunas());
            //this.matriz[queijo.obtem_linhas(), queijo.obtem_colunas()] = "Q";
            mudaqueijo(quantidade);
        }

        public void define_valor_celula(int linha, int coluna, String valor)
        {
            this.matriz[linha, coluna] = valor;
        }

        public String obtem_valor(int linha, int coluna)
        {
            return this.matriz[linha, coluna];
        }

        public int obtem_linhas()
        {
            return this.linhas;
        }

        public int obtem_colunas()
        {
            return this.colunas;
        }

        public void define_celula_valor(int linha, int coluna, String valor) //última etapa antes de desenhar 
        {
            if (linha == -1)
            {
                // 1 e -1 pois é a última parede...
                linha = aleatorio.Next(1, this.linhas - 1);
            }
            if (coluna == -1)
            {
                // 1 e -1 pois é a última parede...
                coluna = aleatorio.Next(1, this.colunas - 1);
            }
            this.matriz[linha, coluna] = valor;
        }

        public void movimenta_rato(Char direcao)
        {
            int linha_atual = rato.obtem_linhas();
            int coluna_atual = rato.obtem_colunas();

            switch (direcao)
            {

                case 'C':
                    if (obtem_valor(linha_atual - 1, coluna_atual) == "" ||
                        obtem_valor(linha_atual - 1, coluna_atual) == "E" ||
                        obtem_valor(linha_atual - 1, coluna_atual) == "Q")
                    {                        
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "";
                        this.rato.define_linhas(linha_atual - 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";                        

                    } break;

                case 'B':
                    if (obtem_valor(linha_atual + 1, coluna_atual) == "" ||
                        obtem_valor(linha_atual + 1, coluna_atual) == "E" ||
                        obtem_valor(linha_atual + 1, coluna_atual) == "Q")
                    {
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "";
                        this.rato.define_linhas(linha_atual + 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    } break;

                case 'E':
                    if (obtem_valor(linha_atual, coluna_atual - 1) == "" ||
                        obtem_valor(linha_atual, coluna_atual - 1) == "E" ||
                        obtem_valor(linha_atual, coluna_atual - 1) == "Q")
                    {

                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "";
                        this.rato.define_colunas(coluna_atual - 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    } break;
                case 'D':
                    if (obtem_valor(linha_atual, coluna_atual + 1) == "" ||
                        obtem_valor(linha_atual, coluna_atual + 1) == "E" ||
                        obtem_valor(linha_atual, coluna_atual + 1) == "Q")
                    {

                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "";
                        this.rato.define_colunas(coluna_atual + 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    } break;



            }
        }
        private void rato_movimenta_beco(char direcao)
        {
            int linha_atual = rato.obtem_linhas();
            int coluna_atual = rato.obtem_colunas();

            switch (direcao)
            {

                case 'C':
                    if (obtem_valor(linha_atual - 1, coluna_atual) == "" ||
                        obtem_valor(linha_atual - 1, coluna_atual) == "E" ||
                        obtem_valor(linha_atual - 1, coluna_atual) == "Q" ||
                        obtem_valor(linha_atual - 1, coluna_atual) == "r")
                    {
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "X";
                        this.rato.define_linhas(linha_atual - 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";


                    } break;

                case 'B':
                    if (obtem_valor(linha_atual + 1, coluna_atual) == "" ||
                        obtem_valor(linha_atual + 1, coluna_atual) == "E" ||
                        obtem_valor(linha_atual + 1, coluna_atual) == "Q" ||
                        obtem_valor(linha_atual + 1, coluna_atual) == "r")
                    {
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "X";
                        this.rato.define_linhas(linha_atual + 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";


                    } break;
                case 'E':
                    if (obtem_valor(linha_atual, coluna_atual - 1) == "" ||
                        obtem_valor(linha_atual, coluna_atual - 1) == "E" ||
                        obtem_valor(linha_atual, coluna_atual - 1) == "Q" ||
                        obtem_valor(linha_atual, coluna_atual - 1) == "r")
                    {
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "X";
                        this.rato.define_colunas(coluna_atual - 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    } break;
                case 'D':
                    if (obtem_valor(linha_atual, coluna_atual + 1) == "" ||
                        obtem_valor(linha_atual, coluna_atual + 1) == "E" ||
                        obtem_valor(linha_atual, coluna_atual + 1) == "Q" ||
                        obtem_valor(linha_atual, coluna_atual + 1) == "r")
                    {
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "X";
                        this.rato.define_colunas(coluna_atual + 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";
                    } break;
            }
        }
        public void automatico()
        {
           
            int linha_atual = rato.obtem_linhas();
            int coluna_atual = rato.obtem_colunas();
            int numero = aleatorio.Next(0, 4);
            //queijo
            if (obtem_valor(linha_atual - 1, coluna_atual) == "Q")
            {
                movimenta_rato('C');
                this.ultimo = 'C';
            }
            else if (obtem_valor(linha_atual + 1, coluna_atual) == "Q")
            {
                movimenta_rato('B');
                this.ultimo = 'B';
            }
            else if (obtem_valor(linha_atual, coluna_atual + 1) == "Q")
            {
                movimenta_rato('D');
                this.ultimo = 'D';
            }
            else if (obtem_valor(linha_atual, coluna_atual - 1) == "Q")
            {
                movimenta_rato('E');
                this.ultimo = 'E';
            }
            //movimento



            else if (obtem_valor(linha_atual - 1, coluna_atual) == "" && ultimo != 'B' && numero != 2 || obtem_valor(linha_atual - 1, coluna_atual) == "E" && ultimo != 'B' && numero != 2)
            {
                movimenta_rato('C');
                this.ultimo = 'C';
            }

            else if (obtem_valor(linha_atual - 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual - 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual - 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual - 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual - 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual - 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual - 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual - 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "P")
            {
                rato_movimenta_beco('B');
                this.ultimo = 'N';
            }
            else if (obtem_valor(linha_atual + 1, coluna_atual) == "" && ultimo != 'C' && numero != 1 || obtem_valor(linha_atual + 1, coluna_atual) == "E" && ultimo != 'C' && numero != 1)
            {
                movimenta_rato('B');
                this.ultimo = 'B';
            }

            else if (obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "X")
            {
                rato_movimenta_beco('C');
                this.ultimo = 'N';
            }

            else if (obtem_valor(linha_atual, coluna_atual + 1) == "" && ultimo != 'E' && numero != 3 || obtem_valor(linha_atual, coluna_atual + 1) == "E" && ultimo != 'E' && numero != 3)
            {
                movimenta_rato('D');
                this.ultimo = 'D';
            }

            else if (obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "P")
            {
                rato_movimenta_beco('E');
                this.ultimo = 'N';
            }


            else if (obtem_valor(linha_atual, coluna_atual - 1) == "" && ultimo != 'D' && numero != 0 || obtem_valor(linha_atual, coluna_atual - 1) == "E" && ultimo != 'D' && numero != 0)
            {

                movimenta_rato('E');
                this.ultimo = 'E';
            }

            else if (obtem_valor(linha_atual, coluna_atual - 1) == "P" && obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual, coluna_atual - 1) == "X" && obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual, coluna_atual - 1) == "P" && obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual, coluna_atual - 1) == "P" && obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual, coluna_atual - 1) == "P" && obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual, coluna_atual - 1) == "X" && obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual, coluna_atual - 1) == "X" && obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual, coluna_atual - 1) == "X" && obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "X")
            {
                this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "B";
                rato_movimenta_beco('D');
                this.ultimo = 'N';
            }


        }

        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        //Teseu
        public void Automatico_Teseu()
        {
            int linha_atual = rato.obtem_linhas();
            int coluna_atual = rato.obtem_colunas();
            int numero = aleatorio.Next(0, 4);
            //queijo
            if (obtem_valor(linha_atual - 1, coluna_atual) == "Q")
            {
                movimenta_rato('C');
                this.ultimo = 'C';
                this.pontuacao += 1;
                
            }
            else if (obtem_valor(linha_atual + 1, coluna_atual) == "Q")
            {
                movimenta_rato('B');
                this.ultimo = 'B';
                this.pontuacao += 1;
                
            }
            else if (obtem_valor(linha_atual, coluna_atual + 1) == "Q")
            {
                movimenta_rato('D');
                this.ultimo = 'D';
                this.pontuacao += 1;
                
            }
            else if (obtem_valor(linha_atual, coluna_atual - 1) == "Q")
            {
                movimenta_rato('E');
                this.ultimo = 'E';
                this.pontuacao += 1;
                
            }

            //movimento

            if (obtem_valor(linha_atual - 1, coluna_atual) == "" || obtem_valor(linha_atual, coluna_atual - 1) == "" || obtem_valor(linha_atual + 1, coluna_atual) == "" || obtem_valor(linha_atual, coluna_atual + 1) == "")
            {

                if (obtem_valor(linha_atual - 1, coluna_atual) == "" && ultimo != 'B')//|| obtem_valor(linha_atual - 1, coluna_atual) == "E" && ultimo != 'B' )
                {
                    movimenta_rato_Teseu1('C');
                    this.ultimo = 'C';
                }


                else if (obtem_valor(linha_atual, coluna_atual + 1) == "" && ultimo != 'E')//|| obtem_valor(linha_atual, coluna_atual + 1) == "E" && ultimo != 'E')
                {
                    movimenta_rato_Teseu1('D');
                    this.ultimo = 'D';
                }



                else if (obtem_valor(linha_atual + 1, coluna_atual) == "" && ultimo != 'C')// || obtem_valor(linha_atual + 1, coluna_atual) == "E" && ultimo != 'C' )
                {
                    movimenta_rato_Teseu1('B');
                    this.ultimo = 'B';
                }



                else if (obtem_valor(linha_atual, coluna_atual - 1) == "" && ultimo != 'D')//|| obtem_valor(linha_atual, coluna_atual - 1) == "E" && ultimo != 'D' )
                {

                    movimenta_rato_Teseu1('E');
                    this.ultimo = 'E';
                }


            }
            //////////////////////////////
            //  2º parte
            //////////////////////////////
            else if (obtem_valor(linha_atual - 1, coluna_atual) == "r" || obtem_valor(linha_atual, coluna_atual - 1) == "r" || obtem_valor(linha_atual + 1, coluna_atual) == "r" || obtem_valor(linha_atual, coluna_atual + 1) == "r")
            {
                if (obtem_valor(linha_atual - 1, coluna_atual) == "E")
                {
                    movimenta_rato_Teseu3('C');
                    this.ultimo = 'C';
                }

                else if (obtem_valor(linha_atual, coluna_atual + 1) == "E")
                {
                    movimenta_rato_Teseu3('D');
                    this.ultimo = 'D';
                }
                else if (obtem_valor(linha_atual + 1, coluna_atual) == "E")
                {
                    movimenta_rato_Teseu3('B');
                    this.ultimo = 'B';
                }
                else if (obtem_valor(linha_atual, coluna_atual - 1) == "E")
                {
                    movimenta_rato_Teseu3('E');
                    this.ultimo = 'E';
                }





                             /////////////////////////////////////////////////

                else if (obtem_valor(linha_atual + 1, coluna_atual) == "r" && ultimo != 'C')
                {
                    movimenta_rato_Teseu2('B');
                    this.ultimo = 'B';
                }
                else if (obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "X")
                {
                    rato_movimenta_beco('C');
                    this.ultimo = 'N';
                }
               
                else if (obtem_valor(linha_atual, coluna_atual - 1) == "r" && ultimo != 'D')
                {

                    movimenta_rato_Teseu2('E');
                    this.ultimo = 'E';
                }

                else if (obtem_valor(linha_atual, coluna_atual - 1) == "P" && obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual, coluna_atual - 1) == "X" && obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual, coluna_atual - 1) == "P" && obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual, coluna_atual - 1) == "P" && obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual, coluna_atual - 1) == "P" && obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual, coluna_atual - 1) == "X" && obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual, coluna_atual - 1) == "X" && obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual, coluna_atual - 1) == "X" && obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "X")
                {
                    this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "B";
                    rato_movimenta_beco('D');
                    this.ultimo = 'N';
                }

                else if (obtem_valor(linha_atual - 1, coluna_atual) == "r" && ultimo != 'B')
                {
                    movimenta_rato_Teseu2('C');
                    this.ultimo = 'C';
                }
                else if (obtem_valor(linha_atual - 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual - 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual - 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual - 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual - 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual - 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual - 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual - 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "P" )
                {
                    rato_movimenta_beco('B');
                    this.ultimo = 'N';
                }
                else if (obtem_valor(linha_atual, coluna_atual + 1) == "r" && ultimo != 'E')
                {
                    movimenta_rato_Teseu2('D');
                    this.ultimo = 'D';
                }
                else if (obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "P")
                {
                    rato_movimenta_beco('E');
                    this.ultimo = 'N';
                }
                

                
               
            }
             else 
            {
                socorro();
                Automatico_Teseu();
                ultimo = 'N';
            }


        }

        public void socorro()
        {
            for (int i = 0; i < this.linhas - 1; i++)
            {
                for (int j = 0; j < this.colunas - 1; j++)
                {
                    if (this.matriz[i, j] == "X" || this.matriz[i, j] == "r")
                    {
                        int sorte = aleatorio.Next(0, 15);
                        if (sorte % 5 == 0)
                        {
                            this.matriz[i, j] = "r";
                        }
                        else
                        {
                            this.matriz[i, j] = "";
                        }
                    }
                }
            }

        }
        public void mudaqueijo(int quantidade)
        {
            int maisum = 0;
            for (int i = 0; i < this.linhas - 1; i++)
            {
                for (int j = 0; j < this.colunas - 1; j++)
                {
                    if (this.matriz[i, j] == "Q")
                    {
                        this.matriz[i, j] = "";
                    }
                }
            }
           
            while(maisum<quantidade)
            {
                        int linhass = aleatorio.Next(1, this.linhas - 2);
                        int colunass = aleatorio.Next(1, this.colunas - 2);

                        if (this.matriz[linhass, colunass] == "" || this.matriz[linhass, colunass] == "r")
                        {
                            this.queijo.define_linhas(linhass);
                            this.queijo.define_colunas(colunass);
                            this.matriz[queijo.obtem_linhas(), queijo.obtem_colunas()] = "Q";
                            maisum +=1;
                            //Form1 tela1 = new Form1();
                            //ela1.refresh();
                        }
            }
        }
        public void movimenta_rato_Teseu1(Char direcao)
        {
            int linha_atual = rato.obtem_linhas();
            int coluna_atual = rato.obtem_colunas();

            switch (direcao)
            {

                case 'C':
                    if (obtem_valor(linha_atual - 1, coluna_atual) == "" ||
                        obtem_valor(linha_atual - 1, coluna_atual) == "E" ||
                        obtem_valor(linha_atual - 1, coluna_atual) == "Q")
                    {

                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "r";
                        this.rato.define_linhas(linha_atual - 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";


                    } break;

                case 'B':
                    if (obtem_valor(linha_atual + 1, coluna_atual) == "" ||
                        obtem_valor(linha_atual + 1, coluna_atual) == "E" ||
                        obtem_valor(linha_atual + 1, coluna_atual) == "Q")
                    {
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "r";
                        this.rato.define_linhas(linha_atual + 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    } break;

                case 'E':
                    if (obtem_valor(linha_atual, coluna_atual - 1) == "" ||
                        obtem_valor(linha_atual, coluna_atual - 1) == "E" ||
                        obtem_valor(linha_atual, coluna_atual - 1) == "Q")
                    {

                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "r";
                        this.rato.define_colunas(coluna_atual - 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    } break;
                case 'D':
                    if (obtem_valor(linha_atual, coluna_atual + 1) == "" ||
                        obtem_valor(linha_atual, coluna_atual + 1) == "E" ||
                        obtem_valor(linha_atual, coluna_atual + 1) == "Q")
                    {

                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "r";
                        this.rato.define_colunas(coluna_atual + 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    } break;



            }



        }
        public void movimenta_rato_Teseu2(Char direcao)
        {
            int linha_atual = rato.obtem_linhas();
            int coluna_atual = rato.obtem_colunas();

            switch (direcao)
            {

                case 'C':
                    if (obtem_valor(linha_atual - 1, coluna_atual) == "r" ||
                        obtem_valor(linha_atual - 1, coluna_atual) == "E" ||
                        obtem_valor(linha_atual - 1, coluna_atual) == "Q")
                    {

                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "X";
                        this.rato.define_linhas(linha_atual - 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";


                    } break;

                case 'B':
                    if (obtem_valor(linha_atual + 1, coluna_atual) == "r" ||
                        obtem_valor(linha_atual + 1, coluna_atual) == "E" ||
                        obtem_valor(linha_atual + 1, coluna_atual) == "Q")
                    {
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "X";
                        this.rato.define_linhas(linha_atual + 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    } break;

                case 'E':
                    if (obtem_valor(linha_atual, coluna_atual - 1) == "r" ||
                        obtem_valor(linha_atual, coluna_atual - 1) == "E" ||
                        obtem_valor(linha_atual, coluna_atual - 1) == "Q")
                    {

                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "X";
                        this.rato.define_colunas(coluna_atual - 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    } break;
                case 'D':
                    if (obtem_valor(linha_atual, coluna_atual + 1) == "r" ||
                        obtem_valor(linha_atual, coluna_atual + 1) == "E" ||
                        obtem_valor(linha_atual, coluna_atual + 1) == "Q")
                    {

                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "X";
                        this.rato.define_colunas(coluna_atual + 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    } break;



            }
        }
             public void movimenta_rato_Teseu3(Char direcao)
        {
            int linha_atual = rato.obtem_linhas();
            int coluna_atual = rato.obtem_colunas();

            switch (direcao)
            {

                case 'C':
                    if (obtem_valor(linha_atual - 1, coluna_atual) == "E")
                    {

                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "X";
                        this.rato.define_linhas(linha_atual - 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";


                    } break;

                case 'B':
                    if (obtem_valor(linha_atual + 1, coluna_atual) == "E")
                    {
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "X";
                        this.rato.define_linhas(linha_atual + 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    } break;

                case 'E':
                    if (obtem_valor(linha_atual, coluna_atual - 1) == "E")
                    {

                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "X";
                        this.rato.define_colunas(coluna_atual - 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    } break;
                case 'D':
                    if (obtem_valor(linha_atual, coluna_atual + 1) == "E")
                    {

                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "X";
                        this.rato.define_colunas(coluna_atual + 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    } break;



            }



        }
    }

    public class Rato
    {
        private int linhas = 0;
        private int colunas = 0;

        public void define_linhas(int linha)
        {
            this.linhas = linha;
        }

        public void define_colunas(int coluna)
        {
            this.colunas = coluna;
        }
        public int obtem_linhas()
        {
            return this.linhas;
        }
        public int obtem_colunas()
        {
            return this.colunas;
        }
        public void para_cima()
        {
            this.linhas--;
        }
        public void para_baixo()
        {
            this.linhas++;
        }
        public void para_direita()
        {
            this.colunas++;
        }
        public void para_esquerda()
        {
            this.colunas--;
        }


    }

    public class Queijo
    {
        private int linhas = 0;
        private int colunas = 0;

        public void define_linhas(int linha)
        {
            this.linhas = linha;
        }

        public void define_colunas(int coluna)
        {
            this.colunas = coluna;
        }
        public int obtem_linhas()
        {
            return this.linhas;
        }
        public int obtem_colunas()
        {
            return this.colunas;
        }
    }
}
    
