<?php

class Libro {

    private $autor;
    private $titulo;
    private $paginas;
    private $refLibro;
    private $prestado;
    private $contieneCD;
    private static $referencia=1;
    public static $numLibros=0;
    
    const LIBRO=1;

    public function __construct($autor, $titulo, $paginas, $refLibro, $prestado) {
        $this->autor = $autor;
        $this->titulo = $titulo;
        $this->paginas = $paginas;
        $this->refLibro = self::$referencia++;
        /*$this->refLibro = $refLibro;*/
        $this->prestado=$prestado;
        $this->contieneCD=FALSE;
        self::$numLibros++;
        
    }

    public function getAutor() {
        return $this->autor;
    }

    public function getTitulo() {
        return $this->titulo;
    }

    public function getPaginas() {
        return $this->paginas;
    }

    function setRefLibro($refLibro) {
        if (strlen($refLibro) > 3) {
            $this->refLibro = $refLibro;
        } else {
            echo '<p> Longitud no válida <p>';
        }
    }
    
    public function setPrestado(){
        $this->prestado++;
    }
    
    public function setContieneCD(){
        $this->contieneCD=TRUE;
    }

    public function printTitulo() {
        echo 'El título del libro', $this->titulo, '<br>';
    }

    public function printAutor() {
        echo 'El autor del libro es ', $this->autor, '<br>';
    }

    public function printLibro() {
        echo 'El autor del libro es ', $this->autor, '<br>';
        echo 'El título del libro ', $this->titulo, '<br>';
        echo 'El número de páginas es ', $this->paginas, '<br>';
        if (strlen($this->refLibro) > 0) {
            echo 'La referencia del libro es ', $this->refLibro , '<br>';
        }
        echo 'El libro fue prestado ', $this->prestado ,' veces <br>';
        
        if ($this->contieneCD){
            echo 'El libro contiene CD';
        }

        print "<hr>";
    }

}



$libro1 = new Libro('David', 'Vais a aprobar', 100, '',0);

print $libro1->getAutor();
print $libro1->getTitulo();
print $libro1->getPaginas();
echo '<br>';
//$libro1->setRefLibro(5522);
$libro1->setPrestado();
$libro1->printLibro();


$libro2 = new Libro('Javi', 'Viendo la luz', 150, '',0);
$libro2->printLibro();

$libro3 = new Libro('Frank Herbert', 'Dune', 500, '',0);
$libro3->setPrestado();
$libro3->printLibro();

print 'El número de libros que hay es '. Libro::$numLibros;