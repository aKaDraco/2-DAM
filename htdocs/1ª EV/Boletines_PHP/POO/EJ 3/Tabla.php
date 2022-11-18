<?php

class Tabla
{
    private $filas;
    private $columnas;
    private $table = array();

    function __construct($fila, $columna)
    {
        $this->filas = $fila;
        $this->columnas = $columna;
    }

    public function cargarDato($fila, $columna, $dato)
    {
        $this->table[$fila][$columna] = $dato;
    }

    public function mostrarDatos()
    {
        print "<table style = \"border: 1px solid black;\">";
        for ($i = 1; $i <= $this->filas; $i++) {
            print "<tr style = \"border: 1px solid black;\">";
            for ($j = 1; $j <= $this->columnas; $j++) {
                print "<td style = \"border: 1px solid black;\">";
                print $this->table[$i][$j] . "<br>";
                print "</td>";
            }
            print "</tr>";
        }
        print "</table>";
    }
}

$tab = new Tabla(2, 2);
$tab->cargarDato(1, 1, "TETE");
$tab->cargarDato(1, 2, "TaTE");
$tab->cargarDato(2, 1, "ToTE");
$tab->cargarDato(2, 2, "TuTE");
$tab->mostrarDatos();
