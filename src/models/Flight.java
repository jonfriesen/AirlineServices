package models;

import java.util.Date;

public class Flight {
	private Plane plane;
	private Locations source;
	private Locations destination;
	private Date departureDate;
	
	public Flight(Plane plane, Locations source, Locations destination,
			Date departureDate) {
		super();
		this.plane = plane;
		this.source = source;
		this.destination = destination;
		this.departureDate = departureDate;
	}

	public Plane getPlane() {
		return plane;
	}

	public void setPlane(Plane plane) {
		this.plane = plane;
	}

	public Locations getSource() {
		return source;
	}

	public void setSource(Locations source) {
		this.source = source;
	}

	public Locations getDestination() {
		return destination;
	}

	public void setDestination(Locations destination) {
		this.destination = destination;
	}

	public Date getDepartureDate() {
		return departureDate;
	}

	public void setDepartureDate(Date departureDate) {
		this.departureDate = departureDate;
	}

	@Override
	public String toString() {
		return "Flight [plane=" + plane + ", source=" + source
				+ ", destination=" + destination + ", departureDate="
				+ departureDate + "]";
	}
	
	
}
