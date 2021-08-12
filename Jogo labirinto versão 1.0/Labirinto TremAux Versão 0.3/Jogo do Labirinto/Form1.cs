using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jogo_do_Labirinto
{
    public partial class Form1 : Form
    {
        Boolean SAIR = false;
        Labirinto labirinto = new Labirinto();
        Boolean retorno;
       
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            comeco_Form1();

        }
        private void comeco_Form1()
        {
            labirinto.define_linhas(20);
            labirinto.define_colunas(20);
            if (checkBox1.Checked == true)
            {
                labirinto.inicializa_matriz(true);
            }
            else
            {
                labirinto.inicializa_matriz(false);
            }
            //Desenha o labirinto
            dataGridView1.ColumnCount = labirinto.obtem_colunas();
            dataGridView1.RowCount = labirinto.obtem_linhas();
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

                            case "Z":
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Gold;
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
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Orange;
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

                            case "Z":
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Gold;
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
            comeco_Form1();
            desenha_labirinto();
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
            do
            {
                labirinto.Automatico_Teseu();
                desenha_labirinto();

                this.Refresh();
               

            } while (labirinto.queijo.obtem_colunas() != labirinto.rato.obtem_colunas() || labirinto.queijo.obtem_linhas() != labirinto.rato.obtem_linhas());
            MessageBox.Show("Achei o Queijo!");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            do
            {
                labirinto.Automatico_TreumAx();
                desenha_labirinto();

                this.Refresh();


            } while (labirinto.queijo.obtem_colunas() != labirinto.rato.obtem_colunas() || labirinto.queijo.obtem_linhas() != labirinto.rato.obtem_linhas());
            MessageBox.Show("Achei o Queijo!");
        }













    }



    public class Labirinto
    {

        private int linhas = 0;
        private int colunas = 0;
        private char ultimo = 'N';

        String[,] matriz;
         Boolean encruzilhada = false;
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

        public void inicializa_matriz(Boolean RADIOBUTTON2)
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

                int quantidade_de_paredes = 20;

                for (int i = 0; i < quantidade_de_paredes; i++)
                {//10
                    int linha;
                    int coluna;
                    int direcao = aleatorio.Next(0, 2);

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


                    this.matriz[linha, coluna] = "";
                    Boolean sair = false;
                    int linha_referencia = linha;
                    int coluna_referencia = coluna;

                    if (direcao == 0)
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
                    {//2
                        for (int j = 0; j < this.colunas; j++)
                        {//1

                            if (i == 0 || i == this.linhas - 1 || j == 0 || j == this.colunas - 1)
                            {
                                this.matriz[i, j] = "Z";
                            }
                            else if (i == 1 || i == this.linhas - 2 || j == 1 || j == this.colunas - 2)
                            {
                                this.matriz[i, j] = "";
                            }
                            else
                            {
                                this.matriz[i, j] = "P";
                            }

                        }//1
                    }//2

                    //mexer no meio                                              

                    int quantidade_de_paredes = 10;

                    for (int i = 0; i < quantidade_de_paredes; i++)
                    {//10
                        int linha;
                        int coluna;
                        int direcao = aleatorio.Next(0, 2);

                        do
                        {
                            linha = aleatorio.Next(1, this.linhas - 1);
                            coluna = aleatorio.Next(1, this.colunas - 1);
                        } while (this.matriz[linha + 1, coluna] == "" ||
                            this.matriz[linha, coluna - 1] == "" ||
                            this.matriz[linha, coluna + 1] == "" ||
                            this.matriz[linha - 1, coluna] == "" ||
                            this.matriz[linha - 1, coluna - 1] == "" ||
                             this.matriz[linha - 1, coluna + 1] == "" ||
                            this.matriz[linha + 1, coluna - 1] == "" ||
                             this.matriz[linha + 1, coluna + 1] == "");


                        this.matriz[linha, coluna] = "";
                        Boolean sair = false;
                        int linha_referencia = linha;
                        int coluna_referencia = coluna;

                        if (direcao == 0)
                        {//6
                            while (sair == false)
                            {//4
                                if (this.matriz[linha, coluna + 1] == "P")
                                {
                                    coluna = coluna + 1;
                                    this.matriz[linha, coluna] = "";
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
                                if (this.matriz[linha, coluna - 1] == "P")
                                {
                                    coluna = coluna - 1;
                                    this.matriz[linha, coluna] = "";
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
                                if (this.matriz[linha + 1, coluna] == "P")
                                {
                                    linha = linha + 1;
                                    this.matriz[linha, coluna] = "";
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
                                if (this.matriz[linha - 1, coluna] == "P")
                                {
                                    linha = linha - 1;
                                    this.matriz[linha, coluna] = "";
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
            


            this.rato.define_linhas(aleatorio.Next(1, this.linhas - 2));
            this.rato.define_colunas(aleatorio.Next(1, this.colunas - 2));
            this.matriz[rato.obtem_linhas(), rato.obtem_colunas()] = "R";
            do
            {
                this.queijo.define_linhas(aleatorio.Next(1, this.linhas - 2));
                this.queijo.define_colunas(aleatorio.Next(1, this.colunas - 2));

            } while (this.queijo.obtem_linhas() == this.rato.obtem_linhas() && this.queijo.obtem_colunas() == this.rato.obtem_colunas());
            this.matriz[queijo.obtem_linhas(), queijo.obtem_colunas()] = "Q";
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
                        this.ultimo = 'C';
                    } break;

                case 'B':
                    if (obtem_valor(linha_atual + 1, coluna_atual) == "" ||
                        obtem_valor(linha_atual + 1, coluna_atual) == "E" ||
                        obtem_valor(linha_atual + 1, coluna_atual) == "Q")
                    {
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "";
                        this.rato.define_linhas(linha_atual + 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";
                        this.ultimo = 'B';
                    } break;

                case 'E':
                    if (obtem_valor(linha_atual, coluna_atual - 1) == "" ||
                        obtem_valor(linha_atual, coluna_atual - 1) == "E" ||
                        obtem_valor(linha_atual, coluna_atual - 1) == "Q")
                    {

                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "";
                        this.rato.define_colunas(coluna_atual - 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";
                        this.ultimo = 'E';
                    } break;
                case 'D':
                    if (obtem_valor(linha_atual, coluna_atual + 1) == "" ||
                        obtem_valor(linha_atual, coluna_atual + 1) == "E" ||
                        obtem_valor(linha_atual, coluna_atual + 1) == "Q")
                    {

                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "";
                        this.rato.define_colunas(coluna_atual + 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";
                        this.ultimo = 'D';
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



            else if (obtem_valor(linha_atual - 1, coluna_atual) == "" && ultimo != 'B'|| obtem_valor(linha_atual - 1, coluna_atual) == "E" && ultimo != 'B')
            {
                movimenta_rato('C');
                this.ultimo = 'C';
            }

            else if (obtem_valor(linha_atual - 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual - 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual - 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual - 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual - 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual - 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual - 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual - 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "P")
            {
                rato_movimenta_beco('B');
                this.ultimo = 'N';
            }
            else if (obtem_valor(linha_atual + 1, coluna_atual) == "" && ultimo != 'C' || obtem_valor(linha_atual + 1, coluna_atual) == "E" && ultimo != 'C' )
            {
                movimenta_rato('B');
                this.ultimo = 'B';
            }

            else if (obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual, coluna_atual - 1) == "X")
            {
                rato_movimenta_beco('C');
                this.ultimo = 'N';
            }

            else if (obtem_valor(linha_atual, coluna_atual + 1) == "" && ultimo != 'E'|| obtem_valor(linha_atual, coluna_atual + 1) == "E" && ultimo != 'E' )
            {
                movimenta_rato('D');
                this.ultimo = 'D';
            }

            else if (obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "P" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "X" || obtem_valor(linha_atual + 1, coluna_atual) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual - 1, coluna_atual) == "P")
            {
                rato_movimenta_beco('E');
                this.ultimo = 'N';
            }


            else if (obtem_valor(linha_atual, coluna_atual - 1) == "" && ultimo != 'D' || obtem_valor(linha_atual, coluna_atual - 1) == "E" && ultimo != 'D')
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
        public void Automatico_TreumAx()
        {
            int linha_atual = rato.obtem_linhas();
            int coluna_atual = rato.obtem_colunas();
            int numero = aleatorio.Next(0, 3);
          
            
            
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
            else if (obtem_valor(linha_atual, coluna_atual - 1) == "X" && obtem_valor(linha_atual, coluna_atual + 1) == "X" && obtem_valor(linha_atual - 1, coluna_atual ) == "X" && obtem_valor(linha_atual + 1, coluna_atual ) == "X")
            {
                socorro();
            }
            //Movimento 
            else if (obtem_valor(linha_atual, coluna_atual - 1) == "" && obtem_valor(linha_atual, coluna_atual + 1) == "" && obtem_valor(linha_atual - 1, coluna_atual) == "P" && obtem_valor(linha_atual + 1, coluna_atual) == "P")
            {
                automatico();
            }
            else if (obtem_valor(linha_atual, coluna_atual - 1) == "P" && obtem_valor(linha_atual, coluna_atual + 1) == "P" && obtem_valor(linha_atual - 1, coluna_atual) == "" && obtem_valor(linha_atual + 1, coluna_atual) == "")
            {
                automatico();
            }
            else if (this.ultimo == 'B' && obtem_valor(linha_atual, coluna_atual + 1) == ""

            //else if (this.ultimo == 'B' && obtem_valor(linha_atual, coluna_atual + 1) == ""  && numero == 0 || this.ultimo == 'C' && obtem_valor(linha_atual, coluna_atual + 1) == "" && numero == 0)
            //{
            //    if (this.ultimo == 'B')
            //    {
            //        this.matriz[linha_atual - 1, coluna_atual] = "r";
            //        Encruzilhada('D', numero);
            //    }
            //    else
            //    {
            //        this.matriz[linha_atual + 1, coluna_atual] = "r";
            //        Encruzilhada('D', numero);
            //    }
            //}

            //else if (this.ultimo == 'B' && obtem_valor(linha_atual, coluna_atual - 1) == "" && numero == 1 || this.ultimo == 'C' && obtem_valor(linha_atual, coluna_atual - 1) == "" && numero == 1)
            //{
            //    if (this.ultimo == 'B')
            //    {
            //        this.matriz[linha_atual - 1, coluna_atual] = "r";
            //        Encruzilhada('E', numero);
            //    }
            //    else
            //    {
            //        this.matriz[linha_atual + 1, coluna_atual] = "r";
            //        Encruzilhada('E', numero);
            //    }

            //}

            //else if (this.ultimo == 'D' && obtem_valor(linha_atual - 1, coluna_atual) == "" && numero == 0 || this.ultimo == 'E' && obtem_valor(linha_atual - 1, coluna_atual) == "" && numero == 0)
            //{
            //    if (this.ultimo == 'D')
            //    {
            //        this.matriz[linha_atual, coluna_atual - 1] = "r";
            //        Encruzilhada('C', numero);
            //    }
            //    else
            //    {
            //        this.matriz[linha_atual, coluna_atual + 1] = "r";
            //        Encruzilhada('C', numero);
            //    }
            //}
            //else if (this.ultimo == 'D' && obtem_valor(linha_atual + 1, coluna_atual) == "" && numero == 1 || this.ultimo == 'E' && obtem_valor(linha_atual + 1, coluna_atual) == "" && numero == 1)
            //{
            //    if (this.ultimo == 'D')
            //    {
            //        this.matriz[linha_atual, coluna_atual - 1] = "r";
            //        Encruzilhada('B', numero);
            //    }
            //    else
            //    {
            //        this.matriz[linha_atual, coluna_atual + 1] = "r";
            //        Encruzilhada('B', numero);
            //    }
            //}
            else
            {
                
                automatico();
            }

            
            
            
       
        }
        public void Encruzilhada(char indo, int sorteio)
        {
            int linha_atual = rato.obtem_linhas();
            int coluna_atual = rato.obtem_colunas();
            
           
            if (indo == 'D' )                         
            {                                            
                if (this.matriz[linha_atual, coluna_atual + 1] == "")
                {
                    this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "";
                    this.rato.define_colunas(rato.obtem_colunas() + 1);
                    this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    movimenta_rato_Teseu1('D');                    
                    this.ultimo = 'D';
                    automatico();
                }                                               
            }
            else if (indo == 'E')
            {
                if (this.matriz[linha_atual, coluna_atual - 1] == "")
                {
                    this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "";
                    this.rato.define_colunas(rato.obtem_colunas() - 1);
                    this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    movimenta_rato_Teseu1('E');
                    this.ultimo = 'E';
                    automatico();
                }
            }
            else if (indo == 'C')
            {
                if (this.matriz[linha_atual - 1, coluna_atual] == "")
                {
                    this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "";
                    this.rato.define_linhas(rato.obtem_linhas() - 1);
                    this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    movimenta_rato_Teseu1('C');
                    this.ultimo = 'C';
                    automatico();
                }
            }
            else if (indo == 'B')
            {
                if (this.matriz[linha_atual + 1, coluna_atual] == "")
                {
                    this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "";
                    this.rato.define_linhas(rato.obtem_linhas() + 1);
                    this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";

                    movimenta_rato_Teseu1('B');
                    this.ultimo = 'B';
                    automatico();
                }
            }
        }
        public void Movimento_Encruzilhada(char direcao)
        {
            int linha_atual = rato.obtem_linhas();
            int coluna_atual = rato.obtem_colunas();
           
            if (direcao == 'D')
            {
                this.matriz[linha_atual, coluna_atual] = "";
                this.rato.define_colunas(rato.obtem_colunas() + 1);
                this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";
                linha_atual += 1;

                if (this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas() + 1] == "")
                {
                    this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "r";
                    this.rato.define_colunas(rato.obtem_colunas() + 1);
                    this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "R";
                }
            }
        }

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
    
