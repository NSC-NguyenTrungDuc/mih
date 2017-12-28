package nta.sfd.core.converter;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.mozilla.universalchardet.UniversalDetector;

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
	 * Gets the file encoding.
	 *
	 * @param file the file
	 * @return the file encoding
	 * @throws FileNotFoundException the file not found exception
	 * @author Dev-DuyenNT
	 */
	@SuppressWarnings("unused")
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
