using System;
using System.Diagnostics;

namespace Arbolbalanceado
{
    class NodoAVL
    {
        public int Valor;
        public NodoAVL Izquierdo;
        public NodoAVL Derecho;
        public int Altura;

        public NodoAVL(int valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
            Altura = 1;
        }
    }

    class ArbolAVL
    {
        public NodoAVL raiz;

        public ArbolAVL()
        {
            raiz = null;
        }

        public int ObtenerAltura(NodoAVL nodo)
        {
            return nodo == null ? 0 : nodo.Altura;
        }

        public int ObtenerFactorDeEquilibrio(NodoAVL nodo)
        {
            return nodo == null ? 0 : ObtenerAltura(nodo.Izquierdo) - ObtenerAltura(nodo.Derecho);
        }

        public NodoAVL RotacionDerecha(NodoAVL y)
        {
            NodoAVL x = y.Izquierdo;
            NodoAVL T2 = x.Derecho;

            x.Derecho = y;
            y.Izquierdo = T2;

            y.Altura = Math.Max(ObtenerAltura(y.Izquierdo), ObtenerAltura(y.Derecho)) + 1;
            x.Altura = Math.Max(ObtenerAltura(x.Izquierdo), ObtenerAltura(x.Derecho)) + 1;

            return x;
        }

        public NodoAVL RotacionIzquierda(NodoAVL x)
        {
            NodoAVL y = x.Derecho;
            NodoAVL T2 = y.Izquierdo;

            y.Izquierdo = x;
            x.Derecho = T2;

            x.Altura = Math.Max(ObtenerAltura(x.Izquierdo), ObtenerAltura(x.Derecho)) + 1;
            y.Altura = Math.Max(ObtenerAltura(y.Izquierdo), ObtenerAltura(y.Derecho)) + 1;

            return y;
        }

       public NodoAVL Insertar(NodoAVL nodo, int valor)
        {
            if (nodo == null)
                return new NodoAVL(valor);

            if (valor < nodo.Valor)
                nodo.Izquierdo = Insertar(nodo.Izquierdo, valor);
            else if (valor > nodo.Valor)
                nodo.Derecho = Insertar(nodo.Derecho, valor);
            else
                return nodo;

            nodo.Altura = 1 + Math.Max(ObtenerAltura(nodo.Izquierdo), ObtenerAltura(nodo.Derecho));

            int balance = ObtenerFactorDeEquilibrio(nodo);

            if (balance > 1 && valor < nodo.Izquierdo.Valor)
                return RotacionDerecha(nodo);

            if (balance < -1 && valor > nodo.Derecho.Valor)
                return RotacionIzquierda(nodo);

            if (balance > 1 && valor > nodo.Izquierdo.Valor)
            {
                nodo.Izquierdo = RotacionIzquierda(nodo.Izquierdo);
                return RotacionDerecha(nodo);
            }

            if (balance < -1 && valor < nodo.Derecho.Valor)
            {
                nodo.Derecho = RotacionDerecha(nodo.Derecho);
                return RotacionIzquierda(nodo);
            }

            return nodo;
        }

        public void Insertar(int valor)
        {
            raiz = Insertar(raiz, valor);
        }

        public NodoAVL Buscar(int valor)
        {
            return Buscar(raiz, valor);
        }

        private NodoAVL Buscar(NodoAVL nodo, int valor)
        {
            if (nodo == null || nodo.Valor == valor)
                return nodo;

            if (valor < nodo.Valor)
                return Buscar(nodo.Izquierdo, valor);
            else
                return Buscar(nodo.Derecho, valor);
        }

        public void Inorden(NodoAVL nodo)
        {
            if (nodo != null)
            {
                Inorden(nodo.Izquierdo);
                Console.Write(nodo.Valor + " ");
                Inorden(nodo.Derecho);
            }
        }

        public void Preorden(NodoAVL nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.Valor + " ");
                Preorden(nodo.Izquierdo);
                Preorden(nodo.Derecho);
            }
        }

        public void Postorden(NodoAVL nodo)
        {
            if (nodo != null)
            {
                Postorden(nodo.Izquierdo);
                Postorden(nodo.Derecho);
                Console.Write(nodo.Valor + " ");
            }
        }

        public int BuscarConRecorrido(NodoAVL nodo, int valor, string tipo)
        {
            int pasos = 0;
            if (tipo == "preOrden") pasos = BuscarPreOrden(nodo, valor, ref pasos);
            else if (tipo == "inOrden") pasos = BuscarInOrden(nodo, valor, ref pasos);
            else if (tipo == "postOrden") pasos = BuscarPostOrden(nodo, valor, ref pasos);
            return pasos;
        }

        private int BuscarPreOrden(NodoAVL nodo, int valor, ref int pasos)
        {
            if (nodo == null) return pasos;
            pasos++;
            if (nodo.Valor == valor) return pasos;
            BuscarPreOrden(nodo.Izquierdo, valor, ref pasos);
            BuscarPreOrden(nodo.Derecho, valor, ref pasos);
            return pasos;
        }

        private int BuscarInOrden(NodoAVL nodo, int valor, ref int pasos)
        {
            if (nodo == null) return pasos;
            BuscarInOrden(nodo.Izquierdo, valor, ref pasos);
            pasos++;
            if (nodo.Valor== valor) return pasos;
            BuscarInOrden(nodo.Derecho, valor, ref pasos);
            return pasos;
        }

        private int BuscarPostOrden(NodoAVL nodo, int valor, ref int pasos)
        {
            if (nodo == null) return pasos;
            BuscarPostOrden(nodo.Izquierdo, valor, ref pasos);
            BuscarPostOrden(nodo.Derecho, valor, ref pasos);
            pasos++;
            if (nodo.Valor == valor) return pasos;
            return pasos;
        }
        public NodoAVL Eliminar(NodoAVL nodo, int valor)
        {
            if (nodo == null)
                return nodo;

            if (valor < nodo.Valor)
                nodo.Izquierdo = Eliminar(nodo.Izquierdo, valor);
            else if (valor > nodo.Valor)
                nodo.Derecho = Eliminar(nodo.Derecho, valor);
            else
            {
                if (nodo.Izquierdo == null || nodo.Derecho == null)
                {
                    NodoAVL temp = nodo.Izquierdo ?? nodo.Derecho;
                    if (temp == null)
                    {
                        temp = nodo;
                        nodo = null;
                    }
                    else
                        nodo = temp;
                }
                else
                {
                    NodoAVL temp = ObtenerNodoMinimo(nodo.Derecho);
                    nodo.Valor = temp.Valor;
                    nodo.Derecho = Eliminar(nodo.Derecho, temp.Valor);
                }
            }

            if (nodo == null)
                return nodo;

            nodo.Altura = 1 + Math.Max(ObtenerAltura(nodo.Izquierdo), ObtenerAltura(nodo.Derecho));

            int balance = ObtenerFactorDeEquilibrio(nodo);

            if (balance > 1 && ObtenerFactorDeEquilibrio(nodo.Izquierdo) >= 0)
                return RotacionDerecha(nodo);

            if (balance > 1 && ObtenerFactorDeEquilibrio(nodo.Izquierdo) < 0)
            {
                nodo.Izquierdo = RotacionIzquierda(nodo.Izquierdo);
                return RotacionDerecha(nodo);
            }

            if (balance < -1 && ObtenerFactorDeEquilibrio(nodo.Derecho) <= 0)
                return RotacionIzquierda(nodo);

            if (balance < -1 && ObtenerFactorDeEquilibrio(nodo.Derecho) > 0)
            {
                nodo.Derecho = RotacionDerecha(nodo.Derecho);
                return RotacionIzquierda(nodo);
            }

            return nodo;
        }


        private NodoAVL ObtenerNodoMinimo(NodoAVL nodo)
        {
            NodoAVL actual = nodo;
            while (actual.Izquierdo != null)
                actual = actual.Izquierdo;
            return actual;
        }

        public void Eliminar(int valor)
        {
            raiz = Eliminar(raiz, valor);
        }

    }
}
