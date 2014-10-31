package models;

public class Passenger {
	private String firstName;
	private String lastName;
	private Ticket ticket = null;
	
	public Passenger(String firstName, String lastName) {
		super();
		this.firstName = firstName;
		this.lastName = lastName;
	}

	@Override
	public String toString() {
		return "Passenger [firstName=" + firstName + ", lastName=" + lastName
				+ ", ticket=" + ticket + "]";
	}
	
	
}
