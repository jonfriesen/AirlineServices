package models;

public class CoachTicket extends Ticket{

	public CoachTicket(Flight flight, double ticketPrice) {
		super(flight, ticketPrice);
	}

	@Override
	public double GetRefundAmount() {
		return (this.getPrice() * 0.85);
	}

	@Override
	public double GetRefund() {
		this.setStatus(TicketStatusType.CANCELLED);
		return GetRefundAmount();
	}

}
