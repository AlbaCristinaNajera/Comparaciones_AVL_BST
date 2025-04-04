using System;
using System.Collections.Generic;

class Nodo
{
    public int valor;
    public Nodo izquierdo;
    public Nodo derecho;
    public Nodo(int valor)
    {
        this.valor = valor;
        this.izquierdo = null;
        this.derecho = null;
    }
}

class ArbolBinario
{
    public Nodo raiz;
    public ArbolBinario()
    {
        raiz = null;
    }

    private Nodo InsertarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.valor)
            nodo.izquierdo = InsertarRecursivo(nodo.izquierdo, valor);
        else if (valor > nodo.valor)
            nodo.derecho = InsertarRecursivo(nodo.derecho, valor);

        return nodo;
    }

    public void Insertar(int valor)
    {
        raiz = InsertarRecursivo(raiz, valor);
    }

    public Nodo Buscar(int valor)
    {
            return Buscar(raiz, valor);
    }

    private Nodo Buscar(Nodo nodo, int valor)
    {
        if (nodo == null || nodo.valor == valor)
            return nodo;

        if (valor < nodo.valor)
            return Buscar(nodo.izquierdo, valor);
        else
            return Buscar(nodo.derecho, valor);
    }

    public void Eliminar(int valor)
    {
        raiz = EliminarRecursivo(raiz, valor);
    }

    private Nodo EliminarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null) return nodo;

        if (valor < nodo.valor)
            nodo.izquierdo = EliminarRecursivo(nodo.izquierdo, valor);
        else if (valor > nodo.valor)
            nodo.derecho = EliminarRecursivo(nodo.derecho, valor);
        else
        {
            if (nodo.izquierdo == null)
                return nodo.derecho;
            else if (nodo.derecho == null)
                return nodo.izquierdo;

            nodo.valor = Minimo(nodo.derecho);

            nodo.derecho = EliminarRecursivo(nodo.derecho, nodo.valor);
        }
        return nodo;
    }
    private int Minimo(Nodo nodo)
    {
        int min = nodo.valor;
        while (nodo.izquierdo != null)
        {
            min = nodo.izquierdo.valor;
            nodo = nodo.izquierdo;
        }
        return min;
    }

}