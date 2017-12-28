package nta.sfd.validation;

import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.validation.Errors;
import org.springframework.validation.Validator;
import org.springframework.web.multipart.MultipartFile;

/**
* The Class MultipartFileValidator.
* 
* @author Dev-DuyenNT
* @CrtDate Jul 29, 2014
*/
public class MultipartFileValidator implements Validator {
	private static final Logger LOG = LogManager.getLogger(MultipartFileValidator.class);
	private final List<String> extensionWhitelist;
	
	private final long maxFileSize;
	
	public MultipartFileValidator(List<String> extensionWhitelist, long maxFileSize) {
		this.maxFileSize = maxFileSize;

		// clean up the received whitelist before setting it up:
		// - strip leading dots
		// - convert to lowercase
		if (extensionWhitelist != null) {
			this.extensionWhitelist = new ArrayList<String>(extensionWhitelist.size());
			for (String extension : extensionWhitelist) {
				final String cleanedExtension =	(extension.charAt(0) == '.') ? extension.substring(1) : extension;
				this.extensionWhitelist.add(cleanedExtension.toLowerCase());
			}
		} else {
			this.extensionWhitelist = null;
		}
		
		
	}
	
	@Override
	public boolean supports(Class<?> clazz) {
		return false;
	}

	@Override
	public void validate(Object target, Errors errors) {
		MultipartFile multipartFile = (MultipartFile) target;
		
		// empty uploads		
		if (multipartFile.isEmpty()) {
			LOG.debug("Rejecting empty file content: " + multipartFile.getOriginalFilename());
			errors.reject("EmptyContent.file", new String[] {multipartFile.getOriginalFilename()}, "");
			return;
		}
		
		// empty file names		
		if (StringUtils.isBlank(multipartFile.getOriginalFilename())) {
			LOG.debug("Rejecting empty file name.");
			errors.reject("EmptyName.file");
			return;
		}
		
		// whitelist-based rejection of filenames, if required
		if (extensionWhitelist != null) {			
			final String lowerCaseFileName = multipartFile.getOriginalFilename().toLowerCase();
			boolean isAllowedExtension = false;
			
			for (String allowedExtension : extensionWhitelist) {
				if (lowerCaseFileName.endsWith(allowedExtension)) {
					LOG.debug("Authorised extension detected: " + allowedExtension);
					isAllowedExtension = true;
					break;
				}
			}			
			if (!isAllowedExtension) {
				if (LOG.isDebugEnabled()) {
					LOG.debug("Rejecting file, no match in whitelist of supported extensions for file: " + multipartFile.getOriginalFilename());
					LOG.debug("Allowed extensions are: " + extensionWhitelist);
				}
				errors.reject("BadExtension.file", new String[] {multipartFile.getOriginalFilename()}, "");
			}
		}
		
		if(maxFileSize>0){
			if(multipartFile.getSize()>maxFileSize){
				if (LOG.isDebugEnabled()) {
					LOG.debug("Rejecting file, file size to big: " + multipartFile.getSize());
					LOG.debug("Maximum file size is: " + maxFileSize);	
				}
				errors.reject("Maxsize.file");
			}
		}
	}

	public List<String> getExtensionWhitelist() {
		return extensionWhitelist;
	}

	public long getMaxFileSize() {
		return maxFileSize;
	}

}
