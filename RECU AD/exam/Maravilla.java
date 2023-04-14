package exam;

import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class Maravilla{
	
	private int codmaravilla;
	private String nombre;
	private int sigloAcConstruccion;
	private int codCivilizacion;
	private String nombreCiv;
	private String zonaOrigen;
	private String material;
	private Double valoracion;
	
	public Maravilla() {
		
	}
	
	public Maravilla(int codmaravilla, String nombre, int sigloAcConstruccion, int codCivilizacion, String nombreCiv,
			String zonaOrigen, String material, Double valoracion) {
		this.codmaravilla = codmaravilla;
		this.nombre = nombre;
		this.sigloAcConstruccion = sigloAcConstruccion;
		this.codCivilizacion = codCivilizacion;
		this.nombreCiv = nombreCiv;
		this.zonaOrigen = zonaOrigen;
		this.material = material;
		this.valoracion = valoracion;
	}
	public int getCodmaravilla() {
		return codmaravilla;
	}
	public void setCodmaravilla(int codmaravilla) {
		this.codmaravilla = codmaravilla;
	}
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	public int getSigloAcConstruccion() {
		return sigloAcConstruccion;
	}
	public void setSigloAcConstruccion(int sigloAcConstruccion) {
		this.sigloAcConstruccion = sigloAcConstruccion;
	}
	public int getCodCivilizacion() {
		return codCivilizacion;
	}
	public void setCodCivilizacion(int codCivilizacion) {
		this.codCivilizacion = codCivilizacion;
	}
	public String getNombreCiv() {
		return nombreCiv;
	}
	public void setNombreCiv(String nombreCiv) {
		this.nombreCiv = nombreCiv;
	}
	public String getZonaOrigen() {
		return zonaOrigen;
	}
	public void setZonaOrigen(String zonaOrigen) {
		this.zonaOrigen = zonaOrigen;
	}
	public String getMaterial() {
		return material;
	}
	public void setMaterial(String material) {
		this.material = material;
	}
	public Double getValoracion() {
		return valoracion;
	}
	public void setValoracion(Double valoracion) {
		this.valoracion = valoracion;
	}
	
	
	
	
}