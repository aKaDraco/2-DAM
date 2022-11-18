<?php
if (!empty($_POST['nombre']) && isset($_POST['nombre'])) {
    $nombre =  $_POST['nombre'];
}

if (!empty($_POST['email']) && isset($_POST['email'])) {
    $email =  $_POST['email'];
}

if (!empty($_POST['tfno']) && isset($_POST['tfno'])) {
    $telefono =  $_POST['tfno'];
}

if (!empty($_POST['textA']) && isset($_POST['textA'])) {
    $textA =  $_POST['textA'];
}

echo "El mensaje \"" . $textA . "\" fue enviado por " . $nombre . ", teléfono " . $telefono . ". Su email es: " . $email;
