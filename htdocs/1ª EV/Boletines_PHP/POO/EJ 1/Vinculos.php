<?php
    class Vinculos {
        private $enlaces=array();
        private $titulos=array();

        public function cargarOpcion($en,$tit) {
            $this->enlaces[]=$en;
            $this->titulos[]=$tit;
        }
        
        public function mostrar() {
            for ($i=0; $i < count($this->enlaces); $i++) { 
                print "Titulo: "."<a href=\"{$this->titulos[$i]}\">{$this->enlaces[$i]}</a><br>";
                print"<br>";
            }
        }
    }

    $menu = new Vinculos();
    $menu -> cargarOpcion("Marca", "https://www.marca.com");
    $menu -> cargarOpcion("Google", "https://www.google.es");
    $menu -> cargarOpcion("YouTube", "https://www.youtube.com");
    $menu -> cargarOpcion("El Tiempo", "https://www.eltiempo.es");
    $menu ->mostrar();
?>