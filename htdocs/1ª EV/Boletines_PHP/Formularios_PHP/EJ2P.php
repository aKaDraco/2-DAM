<?php
$fecha = date('d-m-Y');
if (isset($_POST['nombre']) && !empty($_POST['nombre'])) {
    $nombre = $_POST['nombre'];
}

if (isset($_POST['mail']) && !empty($_POST['mail'])) {
    $mail = $_POST['mail'];
}

if (isset($_POST['telefono']) && !empty($_POST['telefono']) && is_numeric($_POST['telefono'])) {
    $telefono = $_POST['telefono'];
}

if (isset($_POST['mensaje']) && !empty($_POST['mensaje'])) {
    $mensaje = $_POST['mensaje'];
}

print "El mensaje " . $mensaje . " fue enviado por " . $nombre . ", telefono " . $telefono . ". Su e-mail es: " . $mail . ". Enviado el " . $fecha;
