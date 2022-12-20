package examen;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

public class NombreS extends DefaultHandler {
    private String apellido;
    private String numero;
    private String escuderia;
    private boolean is_constructor = false;
    private String qname = "";

    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
        this.qname = qName;
        if (qname.equals("Constructor")) {
            is_constructor = true;
        }
        super.startElement(uri, localName, qName, attributes);
    }

    @Override
    public void characters(char[] ch, int start, int length) throws SAXException {
        String cad = new String(ch, start, length);

        if (qname.equals("Surname")) {
            apellido = cad;
            // qname = "";
        }

        if (qname.equals("Number")) {
            numero = cad;
            // qname = "";
        }

        if (is_constructor && qname.equals("Name")) {
            escuderia = cad;
            is_constructor = false;
            // qname = "";
        }
        super.characters(ch, start, length);
    }

    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {
        // if (qname.equals("Constructor")) {
        //     is_constructor = false;
        // }
        qname = "";
        super.endElement(uri, localName, qName);
    }

    @Override
    public void endDocument() throws SAXException {
        System.out.println("Apellido: " + apellido + "\nNumero: " + numero + "\nEscuderia: " + escuderia + "\n");
        super.endDocument();
    }
}
