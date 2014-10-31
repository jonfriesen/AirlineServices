package models;

public abstract class Ticket implements TicketClass {
	private Flight flight;
	private TicketStatusType status;
	private double price = 0;
	private double amountPaid = 0;
	
	public Ticket(Flight flight, double price) {
		super();
		this.flight = flight;
		this.status = TicketStatusType.BOOKED;
		this.price = price;
	}
	
	public Flight getFlight() {
		return flight;
	}

	public void setFlight(Flight flight) {
		this.flight = flight;
	}

	public TicketStatusType getStatus() {
		return status;
	}

	public void setStatus(TicketStatusType status) {
		this.status = status;
	}

	public double getPrice() {
		return price;
	}

	public void setPrice(double price) {
		this.price = price;
	}
	
	public void pay(double amount) {
		amountPaid += amount;
		if(amountPaid >= price) {
			this.status = TicketStatusType.CANCELLED;
		}
	}

	@Override
	public String toString() {
		return "Ticket [flight=" + flight + ", status=" + status
				+ ", ticketPrice=" + price + "]";
	}
	
}
