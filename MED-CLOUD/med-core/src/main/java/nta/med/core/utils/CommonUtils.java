package nta.med.core.utils;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.StringWriter;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Random;

import javax.mail.internet.MimeMessage;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.core.io.FileSystemResource;
import org.springframework.mail.SimpleMailMessage;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.mail.javamail.MimeMessageHelper;
import org.springframework.mail.javamail.MimeMessagePreparator;
import org.springframework.util.StringUtils;

import com.jcraft.jsch.Channel;
import com.jcraft.jsch.ChannelExec;
import com.jcraft.jsch.JSch;
import com.jcraft.jsch.Session;

import nta.med.common.util.Strings;
import nta.med.common.util.converter.HalfFullConverter;
import nta.med.common.util.converter.HiraganaKatakanaConverter;
import nta.med.core.glossary.CommonEnum;

public class CommonUtils {
	private static final Log LOGGER = LogFactory.getLog(CommonUtils.class);
	
	public static Double parseDouble(String string) {
    	if (StringUtils.isEmpty(string)) return null;
    	string = string.replace(CommonEnum.COMMA.getValue(), CommonEnum.DOT.getValue());
    	return Double.valueOf(string);
    }
	
	public static Integer parseInteger(String str) {
    	if (StringUtils.isEmpty(str)) return null;
    	return Integer.valueOf(str);
    }
	
	public static Long parseLong(String str) {
    	if (StringUtils.isEmpty(str)) return null;
    	return Long.valueOf(str);
    }
	
	public static BigDecimal parseBigDecimal(String str) {
		Double result = parseDouble(str);
    	if (result == null) return null;
    	return BigDecimal.valueOf(result);
    }

	public static final <T> boolean isEquals(T lhs, T rhs) {
		if(lhs == null && rhs == null) {
			return true;
		} else if(lhs == null || rhs == null) {
			return false;
		} else {
			return lhs.equals(rhs);
		}
	}
	
	public static Integer getStartNumberPaging(String pageNumberStr, String offsetStr) {
		if(StringUtils.isEmpty(offsetStr)) return null;
		Integer pageNumber = parseInteger(pageNumberStr);
		Integer offset = parseInteger(offsetStr);
		return ((pageNumber == null ? 1 : pageNumber) - 1) * offset;
	}
	
	public static String formatMmlString(String str){
		if(StringUtils.isEmpty(str)){
			return "";
		}
		
		String result = str.replaceAll("\n", "").replaceAll("\t", "");
		return result.trim();
	}
	
	public static int getAge(Date dateOfBirth) {

		Calendar today = Calendar.getInstance();
		Calendar birthDate = Calendar.getInstance();
		int age = 0;

		birthDate.setTime(dateOfBirth);
		if (birthDate.after(today)) {
			throw new IllegalArgumentException("Can't be born in the future: " + dateOfBirth);
		}

		age = today.get(Calendar.YEAR) - birthDate.get(Calendar.YEAR);

		if ((birthDate.get(Calendar.DAY_OF_YEAR) - today.get(Calendar.DAY_OF_YEAR) > 3)
				|| (birthDate.get(Calendar.MONTH) > today.get(Calendar.MONTH))) {
			age--;
		} else if ((birthDate.get(Calendar.MONTH) == today.get(Calendar.MONTH))
				&& (birthDate.get(Calendar.DAY_OF_MONTH) > today.get(Calendar.DAY_OF_MONTH))) {
			age--;
		}
		
		return age;
	}
	
	public static String parseString(Double value) {
    	if (value == null) return null;
    	return String.format("%.0f", value);
    }
	public static String parseString(Integer value)
	{
		if (value == null) return "";
    	return value.toString();
	}
	
	public static String getNewGlobalRevision(String oldRevision, String screenTableName){
		StringBuilder revision = new StringBuilder();
		String[] oldRevisionTable = oldRevision.split("\\" + CommonEnum.VERTICALBAR.getValue());
		for(int i = 0 ; i < oldRevisionTable.length ; i++){
			String[] revisionNum = oldRevisionTable[i].split(CommonEnum.UNDERSCORE.getValue());
			if(revisionNum.length > 1){
				if(screenTableName.contains(revisionNum[0])){
					if(i == oldRevisionTable.length - 1){
						revision.append(revisionNum[0]).append(CommonEnum.UNDERSCORE.getValue()).append(CommonUtils.parseInteger(revisionNum[1]) + 1);
						break;
					}
					revision.append(revisionNum[0]).append(CommonEnum.UNDERSCORE.getValue()).append(CommonUtils.parseInteger(revisionNum[1]) + 1).append(CommonEnum.VERTICALBAR.getValue());
					continue;
				}else{
					if(i == oldRevisionTable.length - 1){
						revision.append(oldRevisionTable[i]);
						break;
					}
					revision.append(oldRevisionTable[i]).append(CommonEnum.VERTICALBAR.getValue());
				}
			}
		}
		return revision.toString();
	}
	
	public static String getNewShardingRevision(String globalRevision, String shardingRevision, String screenTableName){
		StringBuilder revision = new StringBuilder();
		String[] globalRevisionTable = globalRevision.split("\\" + CommonEnum.VERTICALBAR.getValue());
		String[] shardingRevionTable = shardingRevision.split("\\" + CommonEnum.VERTICALBAR.getValue());
		if(globalRevisionTable.length != shardingRevionTable.length) 	return shardingRevision;
		for(int i = 0 ; i < globalRevisionTable.length ; i++){
			String[] revisionNum = globalRevisionTable[i].split(CommonEnum.UNDERSCORE.getValue());
			if(revisionNum.length > 1){
				if(screenTableName.contains(revisionNum[0])){
					if(i == globalRevisionTable.length - 1){
						revision.append(revisionNum[0]).append(CommonEnum.UNDERSCORE.getValue()).append(revisionNum[1]);
						break;
					}
					revision.append(revisionNum[0]).append(CommonEnum.UNDERSCORE.getValue()).append(revisionNum[1]).append(CommonEnum.VERTICALBAR.getValue());
					continue;
				}else{
					if(i == shardingRevionTable.length - 1){
						revision.append(shardingRevionTable[i]);
						break;
					}
					revision.append(shardingRevionTable[i]).append(CommonEnum.VERTICALBAR.getValue());
				}
			}
		}
		return revision.toString();
	}
	
	public static int randomInt(int min, int max) {
		int result = 0;
		Random rand = new Random();

	    // nextInt is normally exclusive of the top value,
	    // so add 1 to make it inclusive
		result = rand.nextInt((max - min) + 1) + min;
		return result;
	}
	
	public static String formatNumericSeqN(Long seqN){
		if(seqN == null){
			return null;
		}
		return String.format("%09d%n", seqN).trim();
	}
	
	public static String formatNumericSeqN(Long seqN, int lenght){
		if(seqN == null){
			return null;
		}
		return String.format("%0" + lenght + "d%n", seqN).trim();
	}
	
	public static String rPad(String str, int length, String car) {
		if (str == null || str.length() >= length)
			return str;
		
		return String.format("%" + (length - str.length()) + "s", "").replace(" ", car) + str;
	}
	
	public static String lPad(String str, int length, String car) {
		if (str == null || str.length() >= length)
			return str;
		
		return str + String.format("%" + (length - str.length()) + "s", "").replace(" ", car);
	}
	
	public static Date getLocalDateTime(int defaultTimeZone, int localTimeZone){
		int offset = defaultTimeZone - localTimeZone;
		Calendar calendar = Calendar.getInstance();
		calendar.add(Calendar.HOUR, -offset);
		return calendar.getTime();
	}
	
	public static boolean callScriptGenCert(String remoteHost, String remoteUser, String remotePassword, Integer remotePort, String sellScript){
		boolean result = false; 
		Channel channel = null ;
		Session session = null;
		InputStream in  = null;
		try{
	            java.util.Properties config = new java.util.Properties(); 
	            config.put("StrictHostKeyChecking", "no");
	            JSch jsch = new JSch();
	            session = jsch.getSession(remoteUser, remoteHost, remotePort);
	            session.setPassword(remotePassword);
	            session.setConfig(config);
	            session.connect();
	            LOGGER.info("callScriptGenCert Connected");
	            LOGGER.info("callScriptGenCert sellScript : " + sellScript);
	            channel = session.openChannel("exec");
	            ((ChannelExec)channel).setCommand(sellScript);
//	            channel.setInputStream(null);
	            ((ChannelExec)channel).setErrStream(System.err);
	            
	            in = channel.getInputStream();
	            channel.connect();
	            byte[] tmp = new byte[1024];
	            while(true){
	              while(in.available() > 0){
	                int i = in.read(tmp, 0, 1024);
	                if(i < 0) break;
	                System.out.print(new String(tmp, 0, i));
	              }
	              if(channel.isClosed()){
	            	 Integer status = channel.getExitStatus();
	            	 result = status == 0 ? true : false; 
	            	 LOGGER.info("callScriptGenCert status : " + status);
	            	System.out.println("status: " + status);
	                break;
	              }
	              try{Thread.sleep(1000);}catch(Exception ee){}
	            }
	            
	            LOGGER.info("callScriptGenCert DONE" + channel.getOutputStream());
	        }catch(Exception e){
	        	LOGGER.error("callScriptGenCert Exception : " + e.getMessage(), e);
	        }finally {
	        	if(channel != null) channel.disconnect();
	            if(session != null) session.disconnect();
	            if(in != null)
					try {
						in.close();
					} catch (IOException e) {
						LOGGER.error( "callScriptGenCert InputStream "+ e.getMessage(), e);
					}
			}
		return result;
	}
	
	
	public static void sendEmail(String subject, String email, String body, boolean html,
    		String vpnFilePath,  JavaMailSender mailSender, SimpleMailMessage templateMessage){
    	 MimeMessagePreparator preparator = new MimeMessagePreparator() {
             public void prepare(MimeMessage mimeMessage) throws Exception {
                 MimeMessageHelper message = new MimeMessageHelper(mimeMessage, true, "UTF-8");
                 LOGGER.debug("Send email to: " + email);
                 message.setTo(email);
                 message.setFrom(templateMessage.getFrom());
                 message.setSubject(subject);
                 if(templateMessage.getBcc() != null){
                     message.setBcc(templateMessage.getBcc());
                 }
//               attach file
                 try {
 					if(!StringUtils.isEmpty(vpnFilePath)){
 						 File folder = new File(vpnFilePath);
 						 if(folder != null){
 							File[] listOfCert = folder.listFiles();
 	 					     for(int i = 0; i < listOfCert.length; i++){
 	 					     	if(listOfCert[i].isFile()){
 	 					     		FileSystemResource file =  new FileSystemResource(folder + File.separator + listOfCert[i].getName());
 	 					     		message.addAttachment(file.getFilename(), file);
 	 					     	}
 	 					     }
 						 }
 					}
 				} catch (Exception e) {
 					LOGGER.error("attach file to email Exception " + e.getMessage(), e);
 				}
                 message.setText(body, html);
             }
         };
         mailSender.send(preparator);
         LOGGER.info("Send email is success");
    }
	
	public static Integer getStartNumberPaging(Integer pageNumber, Integer offset) {
		return ((pageNumber == null ? 1 : pageNumber) - 1) * offset;
	}
	
	//Trim white spaces with Java Regular Expression
	public static String trimspace(String str) {
		str = str.replaceAll("\\s+", " ");
		str = str.replaceAll("(^\\s+|\\s+$)", "");
		return str;
	}
	
	public static String convertToHalfWidthKana(String text){
		String kana = HiraganaKatakanaConverter.toKatakana(text);
		// not find solution convert space from full to half width then using replace. first sapce is full kana, second space is half kana
		String halfWidthKana = HalfFullConverter.toHalfWidthKana(kana).replace("　", " ");
		return halfWidthKana;
	}
}
