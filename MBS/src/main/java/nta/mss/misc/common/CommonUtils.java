package nta.mss.misc.common;

import org.springframework.util.StringUtils;

/**
 * 
 * @author TungLT
 *
 */
public class CommonUtils {
	
	public static Integer getStartNumberPaging(String pageNumberStr, String offsetStr) {
		if(StringUtils.isEmpty(offsetStr)) return null;
		Integer pageNumber = parseInteger(pageNumberStr);
		Integer offset = parseInteger(offsetStr);
		return ((pageNumber == null ? 1 : pageNumber) - 1) * offset;
	}
	
	public static Integer parseInteger(String str) {
    	if (StringUtils.isEmpty(str)) return null;
    	return Integer.valueOf(str);
    }
	
	public static Long parseLong(String str) {
    	if (StringUtils.isEmpty(str)) return null;
    	return Long.valueOf(str);
    }
	

}
