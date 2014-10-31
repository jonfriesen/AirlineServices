package models;

public class EconomyTicket extends Ticket {

	public EconomyTicket(Flight flight, double ticketPrice) {
		super(flight, ticketPrice);
	}

	@Override
	public double GetRefundAmount() {
		return (this.getPrice() * 0.7);
	}

	@Override
	public double GetRefund() {
		this.setStatus(TicketStatusType.CANCELLED);
		return GetRefundAmount();
	}

}
