package models;

public class FirstClassTicket extends Ticket {

	public FirstClassTicket(Flight flight, double ticketPrice) {
		super(flight, ticketPrice);
	}

	@Override
	public double GetRefundAmount() {
		return this.getPrice();
	}

	@Override
	public double GetRefund() {
		this.setStatus(TicketStatusType.CANCELLED);
		return GetRefundAmount();
	}

}
