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

public class DatabaseConnect {
	private static final Logger LOG = LogManager.getLogger(DatabaseConnect.class);
	
	@SuppressWarnings("resource")
	public static boolean insertHospital(Integer numOfPatient, String hospitalCode, String hospitalName, String userId, String language, String userPassword, Integer timeout, String hospGroup, String vpnYn, Integer timeZone, String locale) throws SQLException, IOException{
		LOG.info("EXECUTE DatabaseConnect:"+ hospitalName);
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
			
			String createNewClinicByHospcodeSqlGlobal = "{call PR_HP_CREATE_NEW_CLINIC_GLOBAL(?, ?, ?, ?, ?, ?, ?)}";
			String getHospSysIdSqlGlobal = "SELECT HOSP_SYS_ID FROM BAS0001 where HOSP_CODE = ? LIMIT 1";
			String createNewClinicByHospcodeSqlShard = "{call PR_HP_CREATE_NEW_CLINIC_SHARDING(?, ?, ?, ?, ?)}";
			try {
				// call global procedure
				conIhisGlobal = DriverManager.getConnection(ihisGlobal, username, password);
				fabricConIhisGlobal = (FabricMySQLConnection) conIhisGlobal;
				fabricConIhisGlobal.setAutoCommit(false);
				proc = fabricConIhisGlobal.prepareCall(createNewClinicByHospcodeSqlGlobal);
				
				proc.setQueryTimeout(timeout);
				proc.setString(1, hospitalCode);
				proc.setString(2, language);
				proc.setString(3, hospitalName);
				proc.setString(4, hospGroup);
				proc.setString(5, vpnYn);
				proc.setInt(6, timeZone);
				proc.registerOutParameter(7, java.sql.Types.VARCHAR);
				LOG.info("EXECUTE STORED GLOBAL PROCEDURE - [START]: " + hospitalCode);
				proc.executeUpdate();
				LOG.info("EXECUTE STORED GLOBAL PROCEDURE - [END]: " + hospitalCode);
				String errorMsgGlobal = proc.getString(7);
				LOG.info("EXECUTE STORED GLOBAL PROCEDURE - HospCode: " + hospitalCode);
				LOG.info("EXECUTE STORED GLOBAL PROCEDURE - Return Message: " + errorMsgGlobal);
				if (errorMsgGlobal != null && !errorMsgGlobal.equals("0")) {
					throw new RuntimeException();
				}
				
				// get HOSP_SYS_ID after insert from global 
				preparedStatement = fabricConIhisGlobal.prepareStatement(getHospSysIdSqlGlobal);
				preparedStatement.setQueryTimeout(timeout);
				preparedStatement.setString(1, hospitalCode);
				ResultSet rs = preparedStatement.executeQuery();
				while (rs.next()) {
					hospSysId = String.valueOf(rs.getInt("HOSP_SYS_ID"));
					LOG.info("GET HOSP_SYS_ID FROM BAS0001: " + hospSysId);
				}
				
				// call sharding procedure
				conIhisShard = DriverManager.getConnection(ihisShard, username, password);
				fabricConIhisShard = (FabricMySQLConnection) conIhisShard;
				fabricConIhisShard.setAutoCommit(false);
				fabricConIhisShard.setShardKey(hospSysId);
				proc = fabricConIhisShard.prepareCall(createNewClinicByHospcodeSqlShard);
				proc.setQueryTimeout(timeout);
				proc.setString(1, hospitalCode);
				proc.setString(2, language);
				proc.setString(3, locale);
				proc.setString(4, vpnYn);
				proc.registerOutParameter(5, java.sql.Types.VARCHAR);
				LOG.info("EXECUTE STORED SHARD PROCEDURE - [START]: " + hospitalCode);
				proc.executeUpdate();
				LOG.info("EXECUTE STORED SHARD PROCEDURE - [END]: " + hospitalCode);
				String errorMsgShard = proc.getString(5);
				LOG.info("EXECUTE STORED SHARD PROCEDURE - HospCode: " + hospitalCode);
				LOG.info("EXECUTE STORED SHARD PROCEDURE - Return Message: " + errorMsgShard);
				if (errorMsgShard != null && errorMsgShard.equals("0")) {
					result = true;
				}else{
					throw new RuntimeException();
				}
			} catch (Exception err) {
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
	
	@SuppressWarnings("finally")
	public static boolean updateExpiredCert(String hospCode, Integer timeout) throws SQLException{
		PreparedStatement preparedStatementGlobal = null;
		FabricMySQLConnection fabricConIhisGlobal = null;
		String updateCertExpired = "UPDATE BAS0001 SET CERT_EXPIRED = DATE_ADD(SYSDATE(), INTERVAL 1 YEAR) WHERE HOSP_CODE = ? AND VPN_YN = 'Y' ";
		try {
			fabricConIhisGlobal = getFabricConnection(true);
			preparedStatementGlobal = fabricConIhisGlobal.prepareStatement(updateCertExpired);
			preparedStatementGlobal.setQueryTimeout(timeout);
			preparedStatementGlobal.setString(1, hospCode);
			preparedStatementGlobal.executeUpdate();
			
		} catch (Exception e) {
			LOG.error("updateExpiredCert : " + e.getMessage(), e);
			return false;
		}finally {
			if (fabricConIhisGlobal != null) fabricConIhisGlobal.commit();
			if (preparedStatementGlobal != null) preparedStatementGlobal.close();
			return true;
		}
	}
	
	private static FabricMySQLConnection getFabricConnection(boolean isGlobal){
		Properties prop = new Properties();
		InputStream input = null;
		FabricMySQLConnection fabricConIhis = null;
		Connection conIhis = null;
		try {
			String configPath = System.getProperty("configPath");
	        File file = new File( (configPath == null ? "" : configPath + "/") + "configs.properties" );
	        input = new FileInputStream( file );
			prop.load(input);
			String username = prop.getProperty("jdbc.ihis.username");
			String password = prop.getProperty("jdbc.ihis.password");
			if(isGlobal){
				String ihisGlobal = prop.getProperty("jdbc.ihis.ihisGlobal");
				conIhis = DriverManager.getConnection(ihisGlobal, username, password);
				fabricConIhis = (FabricMySQLConnection) conIhis;
				fabricConIhis.setAutoCommit(false);
			}else{
				String ihisShard = prop.getProperty("jdbc.ihis.ihisShard");
				conIhis = DriverManager.getConnection(ihisShard, username, password);
				fabricConIhis = (FabricMySQLConnection) conIhis;
				fabricConIhis.setAutoCommit(false);
			}
						
		} catch (Exception e) {
			LOG.error("getFabricConnection : " + e.getMessage(), e);
		} finally {
			if (input != null) {
				try {
					input.close();
				} catch (IOException e) {
					LOG.error(e.getMessage(), e);
				}
			}
        }
		return fabricConIhis;
	}
	
	public static boolean insertHospitalMIS(String hospitalCode, String hospitalName, String address, String locale, Integer timeZone){
		LOG.info("[START] CALL PR_MIS_CREATE_NEW_HOSPITAL: hospitalCode = " + hospitalCode + ", hospitalName = "
				+ hospitalName + ", " + " address = " + address + ", locale = " + locale + ", timeZone = " + timeZone);
		
		boolean result = false;
		Properties prop = new Properties();
		InputStream input = null;
		Connection connectMis = null;
		CallableStatement proc = null;
		
		try {
			String configPath = System.getProperty("configPath");
	        File file = new File( (configPath == null ? "" : configPath + "/") + "configs.properties" );
	        input = new FileInputStream( file );
			prop.load(input);
			
			String urlMis = prop.getProperty("jdbc.mis.url");
			String usernameMis = prop.getProperty("jdbc.mis.username");
			String passwordMis = prop.getProperty("jdbc.mis.password");
			
			try {
				connectMis = DriverManager.getConnection(urlMis, usernameMis, passwordMis);
				proc = connectMis.prepareCall("CALL PR_MIS_CREATE_NEW_HOSPITAL(?, ?, ?, ?, ?, ?)");
				
				proc.setString(1, hospitalCode);
				proc.setString(2, hospitalName);
				proc.setString(3, address);
				proc.setString(4, locale);
				proc.setInt(5, timeZone);
				proc.registerOutParameter(6, java.sql.Types.VARCHAR);
				proc.executeUpdate();
				
				String msg = proc.getString(6);
				if (msg != null && msg.equals("0")) {
					result = true;
				}
				
			} catch (Exception e) {
				LOG.error(e.getMessage(), e);
			} finally {
				if(connectMis != null) connectMis.close();
				if(proc != null) proc.close();
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
		
		LOG.info("[END] CALL PR_MIS_CREATE_NEW_HOSPITAL - RESULT = " + result);
		return result;
	}
	
	public static boolean insertHospitalMBS(String hospitalCode, String hospitalName, String hospNameFurigana, String address, String email, String locale, Integer timeZone, String password){
		LOG.info("[START] CALL PR_MBS_CREATE_NEW_HOSPITAL: hospitalCode = " + hospitalCode + ", hospitalName = "
				+ hospitalName + ", hospNameFurigana = " + hospNameFurigana + ", address = " + address + ", email = "
				+ email + ", locale = " + locale + ", timeZone = " + timeZone + ", password = " + password);
		boolean result = false;
		Properties prop = new Properties();
		InputStream input = null;
		Connection connectMis = null;
		CallableStatement proc = null;
		
		try {
			String configPath = System.getProperty("configPath");
	        File file = new File( (configPath == null ? "" : configPath + "/") + "configs.properties" );
	        input = new FileInputStream( file );
			prop.load(input);
			
			String urlMbs = prop.getProperty("jdbc.mbs.url");
			String usernameMbs = prop.getProperty("jdbc.mbs.username");
			String passwordMbs = prop.getProperty("jdbc.mbs.password");
			
			try {
				connectMis = DriverManager.getConnection(urlMbs, usernameMbs, passwordMbs);
				proc = connectMis.prepareCall("CALL PR_MBS_CREATE_NEW_HOSPITAL(?, ?, ?, ?, ?, ?, ?, ?, ?)");
				
				proc.setString(1, hospitalCode);
				proc.setString(2, hospitalName);
				proc.setString(3, hospNameFurigana);
				proc.setString(4, address);
				proc.setString(5, email);
				proc.setString(6, locale);
				proc.setInt(7, timeZone);
				proc.setString(8, password);
				
				proc.registerOutParameter(9, java.sql.Types.VARCHAR);
				proc.executeUpdate();
				
				String msg = proc.getString(9);
				if (msg != null && msg.equals("0")) {
					result = true;
				}
				
			} catch (Exception e) {
				LOG.error(e.getMessage(), e);
			} finally {
				if(connectMis != null) connectMis.close();
				if(proc != null) proc.close();
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
		
		LOG.info("[END] CALL PR_MBS_CREATE_NEW_HOSPITAL - RESULT = " + result);
		return result;
	}
	
}
