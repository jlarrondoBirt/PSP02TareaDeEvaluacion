using System;
using System.Threading;
using System.Windows.Forms;

namespace CarreraCaballos
{
    public partial class Form1 : Form
    {
        // la carrera tiene 100 metros
        const int META = 100;

        //Declaramos 4 Threads para los caballos
        Thread[] caballos = new Thread[4];

        // Y otro array de 4 para las posiciones
        int[] posiciones = new int[4];

        //Para saber cuando termina la carrera
        volatile bool carreraActiva = false;

        // -1→todavía no hay ganador, 0→ganó Caballo 1, 1→ganó Caballo 2, 2→ganó Caballo 3, 3→ganó Caballo 4
        int ganador = -1;

        //Para evitar que dos hilos lleguen a la meta
        object bloqueo = new object();

        public Form1()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            progressCaballo1.Minimum = 0;
            progressCaballo1.Maximum = META;
            progressCaballo1.Value = 0;

            progressCaballo2.Minimum = 0;
            progressCaballo2.Maximum = META;
            progressCaballo2.Value = 0;

            progressCaballo3.Minimum = 0;
            progressCaballo3.Maximum = META;
            progressCaballo3.Value = 0;

            progressCaballo4.Minimum = 0;
            progressCaballo4.Maximum = META;
            progressCaballo4.Value = 0;

            lblResultado.Text = "";
        }

        private void btnEmpezar_Click_1(object sender, EventArgs e)
        {
            // Para evitar crear carreras simultáneas
            if (carreraActiva)
            {
                return;
            }

            carreraActiva = true;
            ganador = -1;

            //Reiniciamos las posiciones de los 4 caballos
            for (int i = 0; i < 4; i++)
            {
                posiciones[i] = 0;
            }

            progressCaballo1.Value = 0;
            progressCaballo2.Value = 0;
            progressCaballo3.Value = 0;
            progressCaballo4.Value = 0;

            // Creamos los 4 hilos de los caballos
            caballos[0] = new Thread(() => CorrerCaballo(0));
            caballos[1] = new Thread(() => CorrerCaballo(1));
            caballos[2] = new Thread(() => CorrerCaballo(2));
            caballos[3] = new Thread(() => CorrerCaballo(3));

            lblResultado.Text = "¡Preparados, listos, ya!";

            //Y les asignamos prioridades
            caballos[0].Priority = ThreadPriority.AboveNormal;
            caballos[1].Priority = ThreadPriority.Normal;
            caballos[2].Priority = ThreadPriority.Highest;
            caballos[3].Priority = ThreadPriority.BelowNormal;

            //Iniciamos los 4 hilos
            for (int i = 0; i < 4; i++)
            {
                caballos[i].Start();
            }
        }

        private void CorrerCaballo(int numeroCaballo)
        {
            // Cada caballo tendra su propio Random
            Random random = new Random();

            // Mientras la carrera este activa
            while (carreraActiva)
            {
                //Inicializamos la variable para que los caballos avancen 10%
                int avance = random.Next(1, 11);

                // Actualizar la posición de los caballos
                // Para que dos caballos no lleguen a la vez, cuando uno llega se para
                lock (bloqueo)
                {
                    if (!carreraActiva)
                    {
                        return;
                    }

                    posiciones[numeroCaballo] += avance;

                    if (posiciones[numeroCaballo] >= META)
                    {
                        posiciones[numeroCaballo] = META;

                        ganador = numeroCaballo;

                        carreraActiva = false;
                    }
                }

                ActualizarInterfaz(numeroCaballo);

                if (!carreraActiva)
                {
                    MostrarResultado();
                    return;
                }
                //Hacemos que el caballo descanse un poco
                Thread.Sleep(100);
            }
        }

        //Creamos un metodo para actualizar las barras correctamente.
        private void ActualizarInterfaz(int caballo)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ActualizarInterfaz(caballo)));
                return;
            }

            int posicion = posiciones[caballo];

            switch (caballo)
            {
                case 0:
                    progressCaballo1.Value = posicion;
                    break;

                case 1:
                    progressCaballo2.Value = posicion;
                    break;

                case 2:
                    progressCaballo3.Value = posicion;
                    break;

                case 3:
                    progressCaballo4.Value = posicion;
                    break;
            }
        }

        private void MostrarResultado()
        {
            // Como este método puede ser llamado desde un hilo secundario
            if (InvokeRequired)
            {
                Invoke(new Action(MostrarResultado));
                return;
            }

            // Despues podemos mostrar el caballo ganador y las posiciones
            string texto = "Ganador: Caballo " + (ganador + 1) + "\r\n";

            texto += "Caballo 1: " + posiciones[0] + "\r\n";
            texto += "Caballo 2: " + posiciones[1] + "\r\n";
            texto += "Caballo 3: " + posiciones[2] + "\r\n";
            texto += "Caballo 4: " + posiciones[3];

            lblResultado.Text = texto;
        }

        private void btnReiniciar_Click_1(object sender, EventArgs e)
        {
            // Primero detenemos la carrera
            carreraActiva = false;

            // Esperamos a que terminen los hilos con Join
            for (int i = 0; i < 4; i++)
            {
                if (caballos[i] != null && caballos[i].IsAlive)
                {
                    caballos[i].Join();
                }
            }

            // Reiniciamos las posiciones
            for (int i = 0; i < 4; i++)
            {
                posiciones[i] = 0;
            }

            ganador = -1;

            // Reiniciamos las barras progresivas
            progressCaballo1.Value = 0;
            progressCaballo2.Value = 0;
            progressCaballo3.Value = 0;
            progressCaballo4.Value = 0;

            // Y mostramos que el juego se ha reiniciado
            lblResultado.Text = "Juego reiniciado";
        }

        // Para que cuando se cierre el formulario se cierre también el programa
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            carreraActiva = false;

            for (int i = 0; i < 4; i++)
            {
                if (caballos[i] != null && caballos[i].IsAlive)
                {
                    caballos[i].Join();
                }
            }
        }
    }
}
