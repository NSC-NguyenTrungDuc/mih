package nta.mss.misc.common;

import java.util.LinkedHashMap;
import java.util.Locale;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.MessageSource;
import org.springframework.stereotype.Component;

@Component
public class CrmUtils {
	
	/** The message source. */
	private static MessageSource messageSource;
	
	@Autowired
	public CrmUtils(MessageSource messageSource){
		CrmUtils.messageSource = messageSource;
	}
	
	public static Map<String, String> getStatusOfDisease (Locale locale) {
		Map<String, String> listStatusOfDisease = new LinkedHashMap<>();
		StringBuilder sb = new StringBuilder();
		sb.append(messageSource.getMessage("general.status.of.disease", null, locale));
		String[] listStatus = sb.toString().split(",");
		if(listStatus.length > 0){
			for (int i = 0; i < listStatus.length; i++) {
				listStatusOfDisease.put(String.valueOf(i+1), listStatus[i]);
			}
			listStatusOfDisease.remove("3");
		}
		return listStatusOfDisease;
	}
}
