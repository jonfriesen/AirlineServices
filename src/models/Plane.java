package models;

public class Plane {
	private int tailNumber;

	public Plane(int tailNumber) {
		super();
		this.tailNumber = tailNumber;
	}

	@Override
	public String toString() {
		return "Plane [tailNumber=" + tailNumber + "]";
	}
	
}
