package nta.sfd.batch.tool;

import java.io.IOException;
import java.sql.SQLException;

public class TestCallPro {
	public static void main(String[] args) throws SQLException, IOException {
		Integer timeout = 7200;
		boolean result = DatabaseConnect.insertHospital(1, "135", "1111TEST", "151", "JA", "1527" , timeout, "DEMO");
		System.out.println("Check call pro : " + result);
	}
}
