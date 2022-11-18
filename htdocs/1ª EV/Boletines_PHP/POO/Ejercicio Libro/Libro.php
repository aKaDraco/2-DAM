<?php

class Libro
{
    private $autor;
    private $titulo;
    private $paginas;
    private static $refLibro = 1;
    private $prestado;
    private bool $contieneCD;
    const numLibrosMax = 100;

    function __construct()
    {
        if (self::$refLibro <= self::numLibrosMax) {
            self::$refLibro++;
            $this->contieneCD = false;
            $this->autor = $this->autor;
            $this->titulo = $this->titulo;
            $this->paginas = $this->paginas;
            $this->prestado = $this->prestado;
        } else {
            return;
        }
    }

    public function setRefLibro($refLibro)
    {
        if (count($refLibro) > 3) {
            $this->refLibro = $refLibro;
        } else {
            print "<p style = \"color=red;\">" . "Referencia no válida" . "</p>";
        }
    }
    public function setPrestado()
    {
        $this->prestado = $this->prestado + 1;
    }
    public function setContieneCD()
    {
        $this->contieneCD = true;
    }

    public function getContieneCD()
    {
        return $this->contieneCD;
    }
    public function getPrestado()
    {
        return $this->prestado;
    }
    public function getRefLibro()
    {
        return $this->refLibro;
    }
    public function getTitulo()
    {
        return $this->titulo;
    }
    public function getAutor()
    {
        return $this->autor;
    }
    public function getPaginas()
    {
        return $this->paginas;
    }

    public function printAutor()
    {
        print $this->autor;
    }
    public function printTitulo()
    {
        print $this->titulo;
    }
    public function printLibro()
    {
        if ($this->refLibro <= 0) {
            print "Autor: " . $this->getAutor();
            print "Titulo: " . $this->getTitulo();
            print "Páginas: " . $this->getPaginas();
            print "Veces prestado: " . $this->getPrestado();
            print "Contiene CD: " . $this->getContieneCD();
        } else {
            print "Autor: " . $this->getAutor();
            print "Titulo: " . $this->getTitulo();
            print "Páginas: " . $this->getPaginas();
            print "Referencia: " . $this->getRefLibro();
            print "Veces prestado: " . $this->getPrestado();
            print "Contiene CD: " . $this->getContieneCD();
        }
    }

    public function cantLibros()
    {
        print "Hay " . self::$refLibro . " libros en la biblioteca";
    }
}
