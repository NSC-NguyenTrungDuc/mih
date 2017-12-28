package nta.sfd.batch.tool;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Properties;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import com.mysql.fabric.jdbc.FabricMySQLConnection;


public class FabricTest {
	private static final Logger LOG = LogManager.getLogger(FabricTest.class);
	public static void main(String[] args) {
		try {
			boolean result = insertHospital("225");
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	@SuppressWarnings("resource")
	public static boolean insertHospital(String hospitalCode) throws SQLException, IOException{
		boolean result = false;
		Properties prop = new Properties();
		InputStream input = null;
		CallableStatement proc = null;
		PreparedStatement preparedStatement = null;
		String hospSysId = null;
		
		try {
			String configPath = System.getProperty("configPath");
            File file = new File( (configPath == null ? "" : configPath + "/") + "configs.properties" );
            input = new FileInputStream( file );
			prop.load(input);
			
			String ihisGlobal = prop.getProperty("jdbc.ihis.ihisGlobal");
			String ihisShard = prop.getProperty("jdbc.ihis.ihisShard");
			String username = prop.getProperty("jdbc.ihis.username");
			String password = prop.getProperty("jdbc.ihis.password");
						
			Connection conIhisGlobal = null;
			Connection conIhisShard = null;
			
			FabricMySQLConnection fabricConIhisGlobal = null;
			FabricMySQLConnection fabricConIhisShard = null;
			
			String createNewClinicByHospcodeSqlGlobal = "{call PR_HP_CREATE_NEW_CLINIC_GLOBAL(?, ?,?)}";
			String getHospSysIdSqlGlobal = "SELECT HOSP_SYS_ID FROM BAS0001 where HOSP_CODE = ? LIMIT 1";
			String createNewClinicByHospcodeSqlShard = "{call PR_HP_CREATE_NEW_CLINIC_SHARDING(?, ?)}";
			try {
				// call global procedure
				conIhisGlobal = DriverManager.getConnection(ihisGlobal, username, password);
				fabricConIhisGlobal = (FabricMySQLConnection) conIhisGlobal;
				fabricConIhisGlobal.setAutoCommit(false);
				proc = fabricConIhisGlobal.prepareCall(createNewClinicByHospcodeSqlGlobal);
				proc.setString(1, hospitalCode);
				proc.setString(2, "test11");
				proc.registerOutParameter(3, java.sql.Types.VARCHAR);
				
				LOG.info("EXECUTE STORED GLOBAL PROCEDURE - [START]: " + hospitalCode);
				proc.executeUpdate();
				LOG.info("EXECUTE STORED GLOBAL PROCEDURE - [END]: " + hospitalCode);
				String errorMsgGlobal = proc.getString(3);
				LOG.info("EXECUTE STORED GLOBAL PROCEDURE - HospCode: " + hospitalCode);
				LOG.info("EXECUTE STORED GLOBAL PROCEDURE - Return Message: " + errorMsgGlobal);
				if (errorMsgGlobal != null && !errorMsgGlobal.equals("0")) {
					throw new RuntimeException();
				}
				
				//get HOSP_SYS_ID after insert from global 
				preparedStatement = fabricConIhisGlobal.prepareStatement(getHospSysIdSqlGlobal);
				preparedStatement.setString(1, hospitalCode);
				ResultSet rs = preparedStatement.executeQuery();
				while (rs.next()) {
					hospSysId = String.valueOf(rs.getInt("HOSP_SYS_ID"));
					LOG.info("GET HOSP_SYS_ID FROM BAS0001: " + hospSysId);
				}

				
				
				//call procedure shard				
				conIhisShard = DriverManager.getConnection(ihisShard, username, password);
				fabricConIhisShard = (FabricMySQLConnection) conIhisShard;
				fabricConIhisShard.setAutoCommit(false);
				fabricConIhisShard.setShardKey(hospSysId);
				proc = fabricConIhisShard.prepareCall(createNewClinicByHospcodeSqlShard);
				
				proc.setString(1, hospitalCode);
				proc.registerOutParameter(2, java.sql.Types.VARCHAR);
				LOG.info("EXECUTE STORED SHARD PROCEDURE - [START]: " + hospitalCode);
				proc.executeUpdate();
				LOG.info("EXECUTE STORED SHARD PROCEDURE - [END]: " + hospitalCode);
				String errorMsgShard = proc.getString(2);
				LOG.info("EXECUTE STORED SHARD PROCEDURE - HospCode: " + hospitalCode);
				LOG.info("EXECUTE STORED SHARD PROCEDURE - Return Message: " + errorMsgGlobal);
				if (errorMsgShard != null && errorMsgShard.equals("0")) {
					result = true;
				}else{
					throw new RuntimeException();
				}
				
			} catch (Exception err) {
				err.printStackTrace();
				fabricConIhisGlobal.rollback();
				fabricConIhisShard.rollback();
				throw new RuntimeException(err.getMessage());
			} finally {
				if (fabricConIhisGlobal != null) fabricConIhisGlobal.commit();
				if (fabricConIhisShard != null) fabricConIhisShard.commit();
				if (fabricConIhisGlobal != null) fabricConIhisGlobal.close();
				if (fabricConIhisShard != null) fabricConIhisShard.close();
				
				if (proc != null) proc.close();
				if (preparedStatement != null) preparedStatement.close();
			}
        } catch (Exception e) {
        	LOG.error(e.getMessage(), e);
        } finally {
			if (input != null) {
				try {
					input.close();
				} catch (IOException e) {
					LOG.error(e.getMessage(), e);
				}
			}
        }
		return result;
	}
}
