using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;

namespace WindowsFormsApplication1
{
    public partial class Polinomios : Form
    {
       
        public Polinomios(DataTable tabla)
        {
            InitializeComponent();

            //Sacar los datos del dataset
            int cantidadFilas = tabla.Rows.Count;
            DataRowCollection filas = tabla.Rows;
           
            //Copiar la Tabla para usarse en el calculo luego
            TablaDatos.Tables.Add(tabla.Copy());

            //Generar Matriz con sus Filas y Columnas a usar 
            int n = cantidadFilas + 1 ;
            int m = cantidadFilas ;
            int z = 0;
            double[,] Tabla = new double[n, m];
            //Cargar Matriz con valores de la Tabla
            foreach(DataRow fila in filas)
            {
                double valorX = fila.Field<double>(0);
                double valorY = fila.Field<double>(1);
                Tabla[0, z] = valorX;
                Tabla[1, z] = valorY;
                z++;
            }
            //Ordenar Matriz                
            double VX = 0;
            double VY = 0;
            for (int d = 0; d < m; d++ )
            {
                for (int s = 0; s < m - 1 - d; s++)
                {
                    if (Tabla[0, s] > Tabla[0, s + 1])
                    {
                        VX = Tabla[0, s];
                        VY = Tabla[1, s];
                        Tabla[0, s] = Tabla[0, s + 1];
                        Tabla[1, s] = Tabla[1, s + 1];
                        Tabla[0, s + 1] = VX;
                        Tabla[1, s + 1] = VY;
                    }
                       
                }
            }
                         
            //Carga de la Matriz con los Ordenes
            int posY = 1;            
            for (int x = 0; x < n - 2 ; x++)
            {            
            for (int y = 0; y <= m - 1 - posY; y ++ )
            {
                Tabla[x + 2, y] = (Tabla[x + 1, y + 1] - Tabla[x + 1, y]) / (Tabla[0, y + posY] - Tabla[0, y]);
            }
            posY++;
            }                       
            
            //Grado del polinomio
            int cont = 0;          
            
            for (int h = m; h > 1 ; h--)
            {                
                if (Tabla[h,0] == 0)                    
                    cont++;                    
                else
                    break;                                 

            }  
            //Mostrar Grado
            GradoTextBox.Text = (m - cont - 1).ToString();

            //Polinomio Progresivo
            int cant = m;
            ProgTextBox.Text = "P(x) = ";
            for (int a = 1; a <= m ; a++)
            {
                    //Muestra los X
                    if (a == 1)
                        {
                            if (Tabla[a,0] >= 0)
                                //Muestra los positivos
                                ProgTextBox.Text = ProgTextBox.Text + Tabla[a, 0].ToString();
                            else
                                //Muestra los negativos entre ()
                                ProgTextBox.Text = ProgTextBox.Text + "("+ Tabla[a, 0].ToString() + ")";
                        } 
                    else
                        {
                            if (Tabla[a, 0] >= 0)
                                //Muestra los positivos
                                ProgTextBox.Text = ProgTextBox.Text + Tabla[a, 0].ToString() + ".";
                            else
                                //Muestra los negativos entre ()
                                ProgTextBox.Text = ProgTextBox.Text + "(" + Tabla[a, 0].ToString() + ")" + ".";

                        } 
                for (int q = 0; q < m - cant; q++)
                {
                    //Carga los valores del polinomio
                    if (Tabla[0,q] >= 0)
                        //Muestra los positivos
                        ProgTextBox.Text = ProgTextBox.Text + "(X - " + Tabla[0, q].ToString() + ") ";
                    else
                        //Muestra los negativos con el signo +
                        ProgTextBox.Text = ProgTextBox.Text + "(X + " + (Tabla[0, q] * (-1)).ToString() + ") ";

                }                
                //Para evitar que ponga un + al final
                if (a == m)
                    break;

                ProgTextBox.Text = ProgTextBox.Text + " + ";
                cant--;
            }
            
            //Polinomio Regresivo
            int cantb = 0;
            int c = m - 1;
            RegTextBox.Text = "P(x) = ";
            for (int b = 1; b <=m ; b++)
            {
                //Muestra los X
                    if (b == 1)
                    {
                        if (Tabla[b , c] >= 0)
                            //Muestra los positivos
                            RegTextBox.Text = RegTextBox.Text + Tabla[b, c].ToString();
                        else
                            //Muestra los negativos entre ()
                            RegTextBox.Text = RegTextBox.Text + "(" + Tabla[b, c].ToString() + ")"; 
                    }
                    else
                    {
                        if (Tabla[b, c] >= 0)
                            //Muestra los positivos
                            RegTextBox.Text = RegTextBox.Text + Tabla[b, c].ToString() + ".";
                        else
                            //Muestra los negativos entre ()
                            RegTextBox.Text = RegTextBox.Text + "(" + Tabla[b, c].ToString() + ")" + "."; 
              
                    } 
        
                for (int v = m-1; v > m - 1 - cantb ; v--)
                {
                    //Carga los valores del polinomio
                    
                    if (Tabla[0, v] >= 0)
                        //Muestra los positivos
                        RegTextBox.Text = RegTextBox.Text + "(X - " + Tabla[0,v].ToString() + ") ";
                    else
                        //Muestra los negativos con el signo +
                        RegTextBox.Text = RegTextBox.Text + "(X - " + (Tabla[0,v] * (-1)).ToString() + ") ";
                }
                 
                //Para evitar que ponga un + al final
                if (b == m)
                    break;
                RegTextBox.Text = RegTextBox.Text + " + ";
                cantb++;
                c--;
           }
           
        }
       
        private void button1_Click(object sender, EventArgs e)
        {

            //Arma la tabla
            DataTable tabladatos = TablaDatos.Tables["TablaDatos"];
            int cantidadFilas = tabladatos.Rows.Count;
            DataRowCollection filas = tabladatos.Rows;
            
            //Generar Matriz con sus Filas y Columnas a usar 
            int n = cantidadFilas + 1 ;
            int m = cantidadFilas ;
            int z = 0;
            double[,] Tabla = new double[n, m];

            //Cargar Matriz con valores de la Tabla
            foreach(DataRow fila in filas)
            {
                double valorX = fila.Field<double>(0);
                double valorY = fila.Field<double>(1);
                Tabla[0, z] = valorX;
                Tabla[1, z] = valorY;
                z++;
            }
            //Ordenar Matriz                
            double VX = 0;
            double VY = 0;
            for (int d = 0; d < m; d++)
            {
                for (int s = 0; s < m - 1 - d; s++)
                {
                    if (Tabla[0, s] > Tabla[0, s + 1])
                    {
                        VX = Tabla[0, s];
                        VY = Tabla[1, s];
                        Tabla[0, s] = Tabla[0, s + 1];
                        Tabla[1, s] = Tabla[1, s + 1];
                        Tabla[0, s + 1] = VX;
                        Tabla[1, s + 1] = VY;
                    }

                }
            }


            //Carga de la Matriz con los Ordenes
            int posY = 1;            
            for (int x = 0; x < n - 2 ; x++)
            {            
            for (int y = 0; y <= m - 1 - posY; y ++ )
            {
                Tabla[x + 2, y] = (Tabla[x + 1, y + 1] - Tabla[x + 1, y]) / (Tabla[0, y + posY] - Tabla[0, y]);
            }
            posY++;
            }
                //Agarrar los datos del textbox
                if (ValorXBox.TextLength == 0)
                {
                    MessageBox.Show("Ingrese un Valor");
                }
                else
                {        
                    double valor;
                    bool convertir = double.TryParse(ValorXBox.Text, out valor);    
                    if (convertir == false)
                    {
                        MessageBox.Show("No ingrese letras");                   
                    }
                    else
                    {
                    int l = ValorXBox.TextLength;

                    double x = double.Parse(ValorXBox.Text);
                    //Agarrar el polinomio
                    double fx;
                    fx = Tabla[1, 0];
                    double aux;
                    aux = 0;
                    //Calculo Valor            
                    int cant = m;
                    for (int a = 1; a <= m; a++)
                    {
                        for (int q = 0; q < m - cant; q++)
                        {
                            // Multiplicacion de los (X - xT)                    
                            aux = aux * (x - (Tabla[0, q]));
                        }
                        //Suma de los f(x)
                        fx = fx + (Tabla[a, 0]) * aux;
                        cant--;
                        aux = 1;
                    }
                    //Mostrar el Valor                            
                    MessageBox.Show("f (" + x.ToString() + ") = " + fx.ToString());
                    }
                } 
        }                         
                                     
    }
}