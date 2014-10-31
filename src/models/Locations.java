package models;

public enum Locations {
	YYX ("Abbotsford"),
	YAL ("Albert Bay"),
	YBD ("Bella Coola"),
	YCW ("Chilliwack"),
	YKA ("Kamloops"),
	YVR ("Vancouver");
	
	Locations(String place)
	{
		this.place = place;
	}
	
    private final String place;

    public String getLocation(){return place;}

}
