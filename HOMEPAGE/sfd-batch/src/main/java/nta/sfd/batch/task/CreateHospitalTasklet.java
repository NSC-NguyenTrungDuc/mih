package nta.sfd.batch.task;

import java.io.File;
import java.io.IOException;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.batch.core.StepContribution;
import org.springframework.batch.core.scope.context.ChunkContext;
import org.springframework.batch.core.step.tasklet.Tasklet;
import org.springframework.batch.repeat.RepeatStatus;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;

import nta.sfd.batch.tool.DatabaseConnect;
import nta.sfd.core.info.MailInfo;
import nta.sfd.core.misc.common.EncryptionUtils;
import nta.sfd.core.misc.common.IMedConstants;
import nta.sfd.core.misc.common.IMedConstants.REGISTRATION_TYPE;
import nta.sfd.core.model.HospitalRegisterModel;
import nta.sfd.core.service.IHospitalRegisterService;
import nta.sfd.core.service.IMailService;

@Service
public class CreateHospitalTasklet implements Tasklet {
	private static final Logger LOG = LogManager.getLogger(CreateHospitalTasklet.class);
	private static final String PREFIX = "";
	private static final String LOCALE = "ja";
	private static final String PASSWORD = "11111111";
    private static final Lock lock = new ReentrantLock();
	private Integer timeout;
	private String vpnCertFolder;
	private String shellScriptGenVpn;
	private String mbsFrontEnd;
	private String mbsBackEnd;
	private String misFrontEnd;
	private String misBackEnd;
	private String portal;
	private String secretKey;
	private String mbsPassword;
	private String linkDownloadVpn;
	private String linkDownloadKcck;
	private String linkDownloadKcckVn;
	
    /** The mail service. */
	private IMailService mailService;
	
	private IHospitalRegisterService hospitalRegisterService;
    
    @Autowired
	public CreateHospitalTasklet(IMailService mailService, IHospitalRegisterService hospitalRegisterService){
		this.mailService = mailService;
		this.hospitalRegisterService = hospitalRegisterService;
	}

    @Override
    public RepeatStatus execute(StepContribution contribution, ChunkContext chunkContext) throws Exception {
    	LOG.info("[START] Create hospital");
        // [1] Get list hospital  request demo
        boolean accessible = false;
    	try{
    		 accessible = lock.tryLock(100, TimeUnit.MILLISECONDS);
    		if(accessible){
    			List<HospitalRegisterModel> lstHospitalRegisters = this.hospitalRegisterService.findByStatus(IMedConstants.HOSPITAL_REGISTER_STATUS.CONFIRMED);
    	        // GET MAX_SEQ
    	        Integer maxSequence = this.hospitalRegisterService.maxHospitalRegisterId();
    	        if (maxSequence == null) {
    				LOG.error("Cannot get Maximum of HospitalRegisterId");
    				return RepeatStatus.FINISHED;
    			}
    	        for (HospitalRegisterModel hospitalRegister : lstHospitalRegisters) {
    	        	hospitalRegister.setStatus(IMedConstants.HOSPITAL_REGISTER_STATUS.INPROGRESS);
    	        	this.hospitalRegisterService.updateHospitalRegister(hospitalRegister);
    	        	
    	        	Integer nextSequence = hospitalRegister.getHospitalRegisterId();
    	        	// [2] Generate account demo
    	        	String hospCode = hospitalRegister.getHospitalCode();
    	        	String userId = "";
    	        	String password = "";
    	        	if (StringUtils.isEmpty(hospCode)) {
    	        		hospCode = PREFIX + nextSequence.toString();
    	        		userId = PREFIX + nextSequence.toString();
    	        		password = PASSWORD;
    	        		
    	        		// [2.1] Request IHIS create demo account
                        LOG.info("CreateHospitalTasklet.execute(): Request IHIS create demo account");
                        String hospGroup = "";
                        boolean additionalAcc = false;
                        if(IMedConstants.LOCALE.JP.equals(hospitalRegister.getLocale()) 
                        		&& BigDecimal.ZERO.compareTo(hospitalRegister.getDemoFlg()) == 0){
                        	hospGroup = IMedConstants.HOSP_GROUP.JP;
                        } else if(IMedConstants.LOCALE.VN.equals(hospitalRegister.getLocale()) 
                        		&& BigDecimal.ZERO.compareTo(hospitalRegister.getDemoFlg()) == 0){
                        	hospGroup = IMedConstants.HOSP_GROUP.VN;
                        }else{
                        	hospGroup = IMedConstants.HOSP_GROUP.DEMO;
                        	additionalAcc = true;
                        }
                        
                        boolean result = false;
                        if(StringUtils.isEmpty(hospGroup)){
                        	LOG.error("Cannot get hospGroup");
                        }else{
                        	result = DatabaseConnect.insertHospital(1, hospCode, hospitalRegister.getHospitalName(), userId, 
                        			hospitalRegister.getLanguage(), password, timeout, hospGroup, hospitalRegister.getVpnYn(), hospitalRegister.getTimeZone(), hospitalRegister.getLocale());
                        	
                        	if(result){
                        		createVpnAndSendEmailInform(hospitalRegister, hospCode, userId, password, additionalAcc);
                        		
                        		String address = "";     
                        		String locale = "";
                        		if("JP".equals(hospitalRegister.getLocale())){
                        			locale = "JA";
                        		} else if("VN".equals(hospitalRegister.getLocale())){
                        			locale = "VI";
                        		} else {
                        			locale = hospitalRegister.getLocale();
                        		}
                        		String defaultPassword = "1bbd886460827015e5d605ed44252251"; // 11111111
                        		
                        		LOG.info("[START] CLONE DATA MIS...");
                        		DatabaseConnect.insertHospitalMIS(hospCode, hospitalRegister.getHospitalName(), address, locale, hospitalRegister.getTimeZone());
                        		LOG.info("[END] CLONE DATA MIS");
                        		
                        		LOG.info("[START] CLONE DATA MBS...");
                        		DatabaseConnect.insertHospitalMBS(hospCode, hospitalRegister.getHospitalName(),
										hospitalRegister.getHospitalNameFurigana(), address,
										hospitalRegister.getRegisterEmail(), locale, hospitalRegister.getTimeZone(),
										defaultPassword);
								LOG.info("[END] CLONE DATA MBS");
                        	}
                        }
                        
    	        		if (!result) {
    						LOG.error("Cannot insert Hospital with hospCode = " + hospCode + " and userId = " + userId);
    						continue;
    					}

    	        		// Insert account demo into database
    	        		LOG.info("CreateHospitalTasklet.execute(): Update HospitalCode of " + hospitalRegister.getHospitalRegisterId());
    	        		hospitalRegister.setHospitalCode(hospCode);
    	        	}else{
    	        		LOG.info("CreateHospitalTasklet hospCode already exists");
    	        	}
    	        	
    	        	// [5] Update hospital register status
    	        	LOG.info("CreateHospitalTasklet.execute(): Update Status of " + hospitalRegister.getHospitalRegisterId());
    	        	hospitalRegister.setStatus(IMedConstants.HOSPITAL_REGISTER_STATUS.COMPLETED);
    	        	this.hospitalRegisterService.updateHospitalRegister(hospitalRegister);
    	        	
    	        	// [4] Update log email sending (success) //TODO
    			}
    		} else {
    			LOG.warn("Process creating new hospital is not finished yet !!!");
    		}
    	} finally {
            if(accessible)
    		    lock.unlock();
    	}        
        LOG.info("[END] Finish create hospital batch for inprogress status");
        return RepeatStatus.FINISHED;
    }
    
	private void sendEmailConfirm(String registerName, String userId, String password, String hospitalName, String emailTo, String language,
			String vpnPath, String misBackEndUrl, String misFrontEndUrl, String mbsBackEndUrl, String mbsFrontEndUrl, String portalUrl, String locale, boolean additionalAcc, String demoFlag) {
		MailInfo mailInfo = new MailInfo();
		mailInfo.setRegisterName(registerName);
		mailInfo.setHospitalName(hospitalName);
		mailInfo.setUserId(userId);
		mailInfo.setPassword(password);
		mailInfo.setMisBackEndUrl(misBackEndUrl);
		mailInfo.setMisFrontEndUrl(misFrontEndUrl);
		mailInfo.setMbsBackEndUrl(mbsBackEndUrl);
		mailInfo.setMbsFrontEndUrl(mbsFrontEndUrl);
		mailInfo.setPortalUrl(portalUrl);
		mailInfo.setMbsPassword(mbsPassword);
		mailInfo.setLinkDownloadVpn(linkDownloadVpn);
		mailInfo.setLinkDownloadKcck(linkDownloadKcck);
		mailInfo.setAdditionalAcc(additionalAcc);
		if(IMedConstants.LOCALE.VN.equals(locale)){
			mailInfo.setLinkDownloadKcck(linkDownloadKcckVn);
		}

		//NVN
		String templateCode = "";
		if ("1".equalsIgnoreCase(demoFlag)) {
			templateCode = IMedConstants.MAIL_CODE.ACCOUNT_REGISTER;
			if(StringUtils.isEmpty(vpnPath)){
				templateCode = IMedConstants.MAIL_CODE.EMAIL_TEMPLATE_INFORM_CASE_NO_VPN;
			}
		} else {
			templateCode = IMedConstants.MAIL_CODE.REAL_ACCOUNT_REGISTER;
			if(StringUtils.isEmpty(vpnPath)){
				templateCode = IMedConstants.MAIL_CODE.REAL_EMAIL_TEMPLATE_INFORM_CASE_NO_VPN;
			}
		}
		
		List<String> toList = new ArrayList<String>();
		toList.add(emailTo);
		mailService.sendMail(templateCode, language, mailInfo, toList, vpnPath);
	}
	
	private boolean callScriptGenVpnCert(String scriptPath, String hospCode, String userId){
		try {
			ProcessBuilder processBuilder = new ProcessBuilder(scriptPath, hospCode, userId);
			Process process = processBuilder.start();
			process.waitFor();
			LOG.info("callScriptGenVpnCert success ");
			return true;
		} catch (IOException e) {
			LOG.error("callScriptGenVpnCert " + e.getMessage(), e);
			return false;
		} catch (InterruptedException e) {
			LOG.error("callScriptGenVpnCert " + e.getMessage(), e);
			return false;
		}
	}
	
	private void createVpnAndSendEmailInform(HospitalRegisterModel hospitalRegister, String hospCode, String userId, String password, boolean additionalAcc){
		try {
			LOG.info("CreateHospitalTasklet.createVpnAndSendEmailInform(): start ");
    	String registerName = hospitalRegister.getRegisterName();
    	String hospitalName = hospitalRegister.getHospitalName();
    	String emailTo = hospitalRegister.getRegisterEmail();
    	String language = hospitalRegister.getLanguage();
    	String vpnPath = "";
    	//boolean demoFlag = false;
    	
    	//run shell script gen vpn
    	if("Y".equals(hospitalRegister.getVpnYn())){
        	String hospCodeAndUserId = hospCode.concat("_").concat(hospCode).concat("ADM"); // userId = hospCode  + ADM
        	LOG.info("shellScriptGenVpn : " + shellScriptGenVpn + " hospCode :" + hospCode + " hospCodeAndUserId : " + hospCodeAndUserId);
        	callScriptGenVpnCert(shellScriptGenVpn, hospCode, hospCodeAndUserId);
        	vpnPath = vpnCertFolder + File.separator + hospCode + File.separator + hospCodeAndUserId;
    	}
    	LOG.info("vpnCertFolder vpnPath : " + vpnPath);
    	String hospCodeEncryp = EncryptionUtils.encrypt(hospCode, secretKey,
    				EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
    	
    	String misBackEndUrl = misBackEnd + hospCodeEncryp;
    	String misFrontEndUrl = misFrontEnd.replace("hosp_code_encryp", hospCodeEncryp);
    	String mbsBackEndUrl = mbsBackEnd + hospCodeEncryp;
    	String mbsFrontEndUrl = mbsFrontEnd + hospCodeEncryp;
    	String portalUrl= portal;
    	// [3] Send email account info
    	LOG.info("CreateHospitalTasklet.execute(): Send email for " + hospitalRegister.getHospitalRegisterId());
    	sendEmailConfirm(registerName, userId, password, hospitalName, emailTo, language, vpnPath, misBackEndUrl, misFrontEndUrl, 
    			mbsBackEndUrl, mbsFrontEndUrl, portalUrl, hospitalRegister.getLocale(), additionalAcc, hospitalRegister.getDemoFlg().toString());
    	LOG.info("CreateHospitalTasklet.createVpnAndSendEmailInform(): done ");
		} catch (Exception e) {
			LOG.error("CreateHospitalTasklet.createVpnAndSendEmailInform() " + e.getMessage(), e);
		}
	}
	
	public Integer getTimeout() {
		return timeout;
	}

	public void setTimeout(Integer timeout) {
		this.timeout = timeout;
	}

	public String getVpnCertFolder() {
		return vpnCertFolder;
	}

	public void setVpnCertFolder(String vpnCertFolder) {
		this.vpnCertFolder = vpnCertFolder;
	}

	public String getShellScriptGenVpn() {
		return shellScriptGenVpn;
	}

	public void setShellScriptGenVpn(String shellScriptGenVpn) {
		this.shellScriptGenVpn = shellScriptGenVpn;
	}

	public String getMbsFrontEnd() {
		return mbsFrontEnd;
	}

	public void setMbsFrontEnd(String mbsFrontEnd) {
		this.mbsFrontEnd = mbsFrontEnd;
	}

	public String getMbsBackEnd() {
		return mbsBackEnd;
	}

	public void setMbsBackEnd(String mbsBackEnd) {
		this.mbsBackEnd = mbsBackEnd;
	}

	public String getMisFrontEnd() {
		return misFrontEnd;
	}

	public void setMisFrontEnd(String misFrontEnd) {
		this.misFrontEnd = misFrontEnd;
	}

	public String getMisBackEnd() {
		return misBackEnd;
	}

	public void setMisBackEnd(String misBackEnd) {
		this.misBackEnd = misBackEnd;
	}

	public String getPortal() {
		return portal;
	}

	public void setPortal(String portal) {
		this.portal = portal;
	}

	public String getSecretKey() {
		return secretKey;
	}

	public void setSecretKey(String secretKey) {
		this.secretKey = secretKey;
	}

	public String getMbsPassword() {
		return mbsPassword;
	}

	public void setMbsPassword(String mbsPassword) {
		this.mbsPassword = mbsPassword;
	}

	public String getLinkDownloadVpn() {
		return linkDownloadVpn;
	}

	public void setLinkDownloadVpn(String linkDownloadVpn) {
		this.linkDownloadVpn = linkDownloadVpn;
	}

	public String getLinkDownloadKcck() {
		return linkDownloadKcck;
	}

	public void setLinkDownloadKcck(String linkDownloadKcck) {
		this.linkDownloadKcck = linkDownloadKcck;
	}

	public String getLinkDownloadKcckVn() {
		return linkDownloadKcckVn;
	}

	public void setLinkDownloadKcckVn(String linkDownloadKcckVn) {
		this.linkDownloadKcckVn = linkDownloadKcckVn;
	}
}