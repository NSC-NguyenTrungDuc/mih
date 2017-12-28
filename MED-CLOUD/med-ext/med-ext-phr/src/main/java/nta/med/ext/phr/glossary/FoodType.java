package nta.med.ext.phr.glossary;

public enum FoodType {
	
	FOOD_ALL("00"),
	FOOD_CALORIES("01"),
	FOOD_CARBOHYDRATE("02"),
	FOOD_TOTAL_FAT("03");

    private String value;

    private FoodType(String value) {
        this.value = value;
    }
    public String getValue(){
        return value;
    }
}
