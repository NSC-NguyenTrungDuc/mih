package nta.med.service.ihis.handler.schs;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Arrays;
import java.util.List;

import nta.med.common.util.converter.HalfFullConverter;
import nta.med.common.util.converter.HiraganaKatakanaConverter;


public class ToolConvertHalfWidth {
	public static void main(String[] argv) throws SQLException {

		System.out.println("-------- MySQL JDBC Connection Testing ------------");

		try {
//			Class.forName("com.mysql.fabric.jdbc.FabricMySQLDriver");
			Class.forName("com.mysql.jdbc.Driver");
		} catch (ClassNotFoundException e) {
			System.out.println("Where is your MySQL JDBC Driver?");
			e.printStackTrace();
			return;
		}
		System.out.println("MySQL JDBC Driver Registered!");
		Connection connection = null;
		Statement statement;
		PreparedStatement preparedStatement = null;
		try {
//			connection = DriverManager
//			.getConnection("jdbc:mysql:fabric://10.1.20.196:32274/ihis_20160706?useUnicode=true&characterEncoding=UTF-8&noAccessToProcedureBodies=true&zeroDateTimeBehavior=convertToNull&useLegacyDatetimeCode=false&serverTimezone=Asia/Tokyo&fabricUsername=admin&fabricPassword=admin&fabricShardTable=OUT1001",
//					"root", "meddba");
			connection = DriverManager
					.getConnection("jdbc:mysql://10.1.20.3:3306/ihis_20160817?useUnicode=true&characterEncoding=UTF-8&noAccessToProcedureBodies=true",
							"root", "meddba");
			statement = connection.createStatement();
		} catch (SQLException e) {
			System.out.println("Connection Failed! Check output console");
			e.printStackTrace();
			return;
		}
		String[] hospCodeJP = {"244",
		"248","250","256","264",
		"316","319","320",
		"321","322","323",
		"324","325","326",
		"327","329","332",
		"333","334","335",
		"K01","NTA","386","391",
		"399","400","401","402",
		"403","405","407","408",
		"410","411","412","414",
		"438","439","445",
		"446","451","457",
		"458","459","460","461",
		"463","465","466","467",};
		String[] hospCodeDemo = {"337","338","339",
				"340","341","343",
				"344","346","349",
				"350","354","357",
				"359","360","361",
				"362","364","368",
				"369","372","373",
				"374","375","376",
				"379","380","381",
				"383","426"};
		List<String> listHospCode = Arrays.asList(hospCodeDemo);
		System.out.println("size : " + listHospCode.size());
		String selectTableSQL = "SELECT * from OUT0101 WHERE HOSP_CODE = ? ";
		String updateOut0101 = "UPDATE OUT0101 SET SUNAME2 = ? WHERE HOSP_CODE = ? AND BUNHO = ? ";
		for(int x = 0; x < listHospCode.size() ; x++){
			preparedStatement = connection.prepareStatement(selectTableSQL);
			preparedStatement.setString(1, listHospCode.get(x));
			ResultSet rs = preparedStatement.executeQuery();
			while (rs.next()) {
				String suname2 = rs.getString("SUNAME2");
				String bunho = rs.getString("BUNHO");
				String suname2HalfWidth = convertToHalfWidthKana(suname2);
				System.out.println("suname2 : " + suname2 + " " + suname2HalfWidth);
				connection.setAutoCommit(false);
				preparedStatement = connection.prepareStatement(updateOut0101);
				preparedStatement.setString(1, suname2HalfWidth);
				preparedStatement.setString(2, listHospCode.get(x));
				preparedStatement.setString(3, bunho);
				preparedStatement.executeUpdate();
			}
		}
		connection.commit();
		System.out.println("Done!");
	  }
	
	public static String convertToHalfWidthKana(String text){
		String kana = HiraganaKatakanaConverter.toKatakana(text);
		String halfWidthKana = HalfFullConverter.toHalfWidthKana(kana).replace("　", " ");
		return halfWidthKana;
	}
}
