package nta.mss.converter;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.lang.reflect.Field;
import java.util.List;
import java.util.Map;

import nta.mss.info.DoctorInfo;
import nta.mss.info.MailListDetailInfo;
import nta.mss.misc.enums.CsvErrorCode;

import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.mozilla.universalchardet.UniversalDetector;

import au.com.bytecode.opencsv.CSVReader;
import au.com.bytecode.opencsv.bean.ColumnPositionMappingStrategy;

/**
 * The Class CsvConverter.
 * 
 * @author DinhNX
 * @CrtDate Jul 31, 2014
 */
public class CsvConverter {
	private static final Logger LOG = LogManager.getLogger(CsvConverter.class);

    public static final Integer DEFAULT_CSV_NO_IGNORE_LINES = 0;
	
	/**
	 * Parses the doctors info from csv.
	 * 
	 * @param fileName
	 *            the file name
	 * @return the list
	 * @throws FileNotFoundException
	 *             the file not found exception
	 * @throws UnsupportedEncodingException
	 *             the unsupported encoding exception
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<Map.Entry<DoctorInfo, CsvErrorCode>> parseFromCsv(String fileName) throws FileNotFoundException, UnsupportedEncodingException {
		LOG.info("[Start] Parse doctor from csv file: " + fileName);
        ApiCsvToBean.ensureRegisteredEditor();
//        CSVReader reader = new CSVReader(new FileReader(fileName));
        String encoding = getFileEncoding(fileName);
        
        InputStreamReader streamReader = null;
        if (StringUtils.isNotBlank(encoding)) {
        	streamReader = new InputStreamReader(new FileInputStream(fileName), encoding);
        } else {
        	streamReader = new InputStreamReader(new FileInputStream(fileName));
        }
        CSVReader reader = new CSVReader(streamReader);
        ColumnPositionMappingStrategy strategy = new ColumnPositionMappingStrategy();
        strategy.setType(DoctorInfo.class);
        
        Field[] arrayField = DoctorInfo.class.getDeclaredFields();
        String[] columns = new String[arrayField.length];
        if(arrayField != null && arrayField.length > 0) {
        	for(int i = 0; i < arrayField.length; i++) {
        		columns[i] = arrayField[i].getName();
        	}
        }
//        String[] columns = new String[] {"hospitalCode", "hospitalName", "departmentCode", "departmentName", "departmentType", "departmentOrder", "doctorName", "juniorFlg", "kpi"};
        strategy.setColumnMapping(columns);

        ApiCsvToBean csvToBean = new ApiCsvToBean();
        LOG.info("[End] Parse doctor from csv");
        return csvToBean.parse(strategy, reader, columns.length, DEFAULT_CSV_NO_IGNORE_LINES, true);
	}
	
	/**
	 * Parses the doctors info from csv.
	 * 
	 * @param fileName
	 *            the file name
	 * @return the list
	 * @throws FileNotFoundException
	 *             the file not found exception
	 * @throws UnsupportedEncodingException
	 *             the unsupported encoding exception
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<Map.Entry<MailListDetailInfo, CsvErrorCode>> parseCsvMailListDetail(String fileName) throws FileNotFoundException, UnsupportedEncodingException {
		LOG.info("[Start] Parse doctor from csv file: " + fileName);
        ApiCsvToBean.ensureRegisteredEditor();
//        CSVReader reader = new CSVReader(new FileReader(fileName));
        String encoding = getFileEncoding(fileName);
        
        InputStreamReader streamReader = null;
        if (StringUtils.isNotBlank(encoding)) {
        	streamReader = new InputStreamReader(new FileInputStream(fileName), encoding);
        } else {
        	streamReader = new InputStreamReader(new FileInputStream(fileName));
        }
        CSVReader reader = new CSVReader(streamReader);
        ColumnPositionMappingStrategy strategy = new ColumnPositionMappingStrategy();
        strategy.setType(MailListDetailInfo.class);
        
        Field[] arrayField = MailListDetailInfo.class.getDeclaredFields();
        String[] columns = new String[arrayField.length];
        if(arrayField != null && arrayField.length > 0) {
        	for(int i = 0; i < arrayField.length; i++) {
        		columns[i] = arrayField[i].getName();
        	}
        }
//        String[] columns = new String[] {"hospitalCode", "hospitalName", "departmentCode", "departmentName", "departmentType", "departmentOrder", "doctorName", "juniorFlg", "kpi"};
        strategy.setColumnMapping(columns);

        ApiCsvToBean csvToBean = new ApiCsvToBean();
        LOG.info("[End] Parse doctor from csv");
        return csvToBean.parse(strategy, reader, columns.length, DEFAULT_CSV_NO_IGNORE_LINES, false);
	}
	
	/**
	 * Gets the file encoding.
	 *
	 * @param file the file
	 * @return the file encoding
	 * @throws FileNotFoundException the file not found exception
	 * @author Dev-DuyenNT
	 */
	private String getFileEncoding(String file) throws FileNotFoundException {
		String encoding = "UTF-8";
		FileInputStream fis = null;
		
		byte[] buf = new byte[1024];
		UniversalDetector detector = new UniversalDetector(null);
		int nread;
		try {
			fis = new FileInputStream(file);
			while ((nread = fis.read(buf)) > 0 && !detector.isDone()) {
			  detector.handleData(buf, 0, nread);
			}
			detector.dataEnd();
		    
		    encoding = detector.getDetectedCharset();
		} catch (IOException e) {
			LOG.warn("Cannot get file encoding");
		} finally {
			if (fis != null) {
				try {
					fis.close();
				} catch (IOException e) {
					LOG.error("Cannot close the file input stream", e.getMessage());
				}
			}
		}
	    return encoding;
	}
}
