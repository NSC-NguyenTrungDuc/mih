package nta.med.service.ihis.handler.adma;

import java.math.BigDecimal;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.config.Configuration;
import nta.med.core.config.MailInfoConfig;
import nta.med.core.config.SshConfig;
import nta.med.core.domain.adm.Adm3200;
import nta.med.core.domain.adm.LoginExt;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.CommonEnum;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.IsChangePassword;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.MonitorKey;
import nta.med.core.glossary.TrialFlg;
import nta.med.core.glossary.UserEnum;
import nta.med.core.glossary.UserGroup;
import nta.med.core.glossary.UserRole;
import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.MonitorLog;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.core.utils.EncryptionUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.adm.LoginExtRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.adma.MailInfo;
import nta.med.service.ihis.handler.system.MailService;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
@Transactional
public class ADM104UGridUserSaveLayoutHandler
		extends ScreenHandler<AdmaServiceProto.ADM104UGridUserSaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	
    private static final Log LOGGER = LogFactory.getLog(ADM104UGridUserSaveLayoutHandler.class);
    
    @Resource
    private Adm3200Repository adm3200Repository;
    
    @Resource
    private LoginExtRepository loginExtRepository;
    
    @Resource
    private Bas0001Repository bas0001Repository;
    @Resource
	private SshConfig sshConfig;
    @Resource
    private Configuration configuration;
    @Resource
    private MailService mailService;
    @Resource
    private MailInfoConfig mailInfoConfig;

    @Override
    @Transactional
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM104UGridUserSaveLayoutRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(request.getHospCode());
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001s.size() > 0 ? bas0001s.get(0).getHospCode() : getHospitalCode(vertx, sessionId),
					bas0001s.size() > 0 ? bas0001s.get(0).getLanguage() : getLanguage(vertx, sessionId), "", 1));
		}
    }
    
    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM104UGridUserSaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospitalCode = request.getHospCode();
        List<AdmaModelProto.ADM104UGridUserInfo> listItem = request.getItemInfoList();
        if (!CollectionUtils.isEmpty(listItem) && !isValidKey(listItem, vertx, clientId, sessionId)) {
        	response.setMsg("ADM_USER_ID_EXISTED");
    		response.setResult(false);
    		return response.build();
        }
        response = saveLayout(request, hospitalCode, getLanguage(vertx, sessionId));
        if (!response.getResult()) {
            throw new ExecutionException(response.build());
        }
        MonitorLog.writeMonitorLog(MonitorKey.REG_USER, "New user have been successfully registered");
        return response.build();
    }

    @Override
	public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			AdmaServiceProto.ADM104UGridUserSaveLayoutRequest request, UpdateResponse response) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup(UserGroup.NTA.getValue(), Language.JAPANESE.toString().toUpperCase(), "", 0));
		}
		
		return response;
	}
    
    public SystemServiceProto.UpdateResponse.Builder saveLayout(AdmaServiceProto.ADM104UGridUserSaveLayoutRequest request, String hospitalCode, String language) {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(hospitalCode);
        boolean isUseVpn = false;
        if(!CollectionUtils.isEmpty(bas0001s) && YesNo.YES.getValue().equalsIgnoreCase(bas0001s.get(0).getVpnYn())){
        	isUseVpn = true;
        }
        List<AdmaModelProto.ADM104UGridUserInfo> listItem = request.getItemInfoList();
        if (!CollectionUtils.isEmpty(listItem)) {
            for (AdmaModelProto.ADM104UGridUserInfo item : listItem) {
                if (item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
                    Adm3200 adm3200 = new Adm3200();
                    BeanUtils.copyProperties(item, adm3200, language);
                    adm3200.setHospCode(hospitalCode);
                    adm3200.setSysId(request.getUserId());
                    adm3200.setUpMemb(request.getUserId());
                    adm3200.setUpTime(new Date());
                    adm3200.setCrMemb(request.getUserId());
                    adm3200.setCrTime(new Date());
                    adm3200.setLoginFlg(BigDecimal.ONE);
                    adm3200.setUserLevel(CommonUtils.parseDouble("9"));
                   
                    if(!StringUtils.isEmpty(item.getClisSmoId())){
                    	adm3200.setClisSmoId(CommonUtils.parseInteger(item.getClisSmoId()));
                    }
                    if(isUseVpn){
                    	Calendar cal = Calendar.getInstance();
    		        	cal.add(Calendar.YEAR, 1); 
                    	adm3200.setCertExpired(cal.getTime());
                    }
                    
                    adm3200Repository.save(adm3200);
                    
//                    String resultCall = adm3200Repository.callPrAdmInsertSubpartDoctor(hospitalCode, item.getUserId(), "I");
//                    if ("0".equalsIgnoreCase(resultCall)) {
//                        response.setResult(false);
//                        return response;
//                    }
                    
                 // if account existing in login_ext => update pass and active account
                    Integer activeFlg = loginExtRepository.activeLoginExt(BigDecimal.ONE, BigDecimal.ONE, item.getUserScrt(), new Date(), request.getUserId(), item.getUserId(), hospitalCode);
                    if(activeFlg == null || activeFlg < 1){
                    	//Insert into table LOGIN_EXT
                        LoginExt loginExt = new LoginExt();
                        loginExt.setUserId(item.getUserId());
                        loginExt.setHospCode(hospitalCode);
                        loginExt.setFirstLoginFlg(BigDecimal.ONE);
                        loginExt.setChangePwdFlg(BigDecimal.ONE);
                        loginExt.setPwdHistory(item.getUserScrt());
                        loginExt.setLastChangePwd(new Date());
                        loginExt.setActiveFlg(BigDecimal.ONE);
                        loginExt.setSysId(request.getUserId());
                        loginExtRepository.save(loginExt);
                    }
//                  send email inform
                    if(isUseVpn){
                    	LOGGER.info("ADM104UGridUserSaveLayoutHandler isUseVpn" + isUseVpn);
                    	String command = new StringBuilder("sh ").append(sshConfig.getScriptPath()).append(" ").append(hospitalCode).append(" ").append(hospitalCode).append("_").append(item.getUserId()).toString();
                    	boolean genVpn = CommonUtils.callScriptGenCert(sshConfig.getHost(), sshConfig.getUser(), sshConfig.getPass(), sshConfig.getPort(), command);
                    	LOGGER.info("ADM104UGridUserSaveLayoutHandler genVpn" + genVpn);
                    	if(genVpn){
                    		String vpnFilePath = new StringBuilder(sshConfig.getCertPath()).append("/").append(hospitalCode).append("/").append(hospitalCode).append("_").append(item.getUserId()).toString();
                    		sendEmailInform(vpnFilePath, hospitalCode, language, bas0001s.get(0), item);
                    	}
                    }else if(!StringUtils.isEmpty(item.getEmail().trim())){
                    	sendEmailInform("", hospitalCode, language, bas0001s.get(0), item);
                    }
                    
                } else if (item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                	BigDecimal logiFlg = new BigDecimal(0);
                	if(TrialFlg.YES.getValue().equals(item.getLoginFlg())){
                		logiFlg = new BigDecimal(1);
                	}else if(TrialFlg.NO.getValue().equals(item.getLoginFlg())){
                		logiFlg = new BigDecimal(0);
                	}
					if (adm3200Repository.updateADM104U(item.getUserNm(), item.getUserScrt(), item.getDeptCode(), item.getUserGroup(), CommonUtils.parseDouble(item.getUserLevel()),
                            DateUtil.toDate(item.getUserEndYmd(), DateUtil.PATTERN_YYMMDD), item.getUserGubun(), request.getUserId(), new Date(),
                            item.getNurseConfirmEnableYn(), item.getCoId(), hospitalCode, item.getUserId(),item.getEmail(), CommonUtils.parseInteger(item.getClisSmoId()), 
                            logiFlg) <= 0) {
                        response.setResult(false);
                        return response;
                    }
                    BigDecimal changePassFlg = new BigDecimal(0);
                	if(YesNo.YES.getValue().equals(item.getChangePwdFlg())){
                		changePassFlg = BigDecimal.ONE;
                	}else if(YesNo.NO.getValue().equals(item.getChangePwdFlg())){
                		changePassFlg = BigDecimal.ZERO;
                	}
                    if(IsChangePassword.TRUE.getValue().equals(item.getIschangePwd()) && loginExtRepository.updateLoginExt(changePassFlg, item.getPwdHistory(), new Date(), item.getUserId(), hospitalCode) <= 0){
                    	response.setResult(false);
                        return response;
                    }
                    if(IsChangePassword.FALSE.getValue().equals(item.getIschangePwd()) &&
                    		loginExtRepository.changeLockStatus(changePassFlg, item.getUserId(), hospitalCode) <= 0){
                    	response.setResult(false);
                        return response;
                    }	
                    
                } else if (item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                	LOGGER.info("ADM104UGridUserSaveLayoutRequest: BEGIN delete user: user_id=" + item.getUserId());
                	// delete PFE user only
                	if(item.getUserId().startsWith(UserEnum.PFE.getValue())){
                		if(adm3200Repository.deleteADM104UByUserId(hospitalCode, item.getUserId()) <= 0 
                				|| loginExtRepository.deleteLoginExtByUserId(hospitalCode, item.getUserId()) <= 0){
                			response.setResult(false);
                            return response;
                		}
                	} else {
                		// delete user and delete PFE user reference: MED-8031
                		String pfeUser = UserEnum.PFE.getValue() + item.getUserId();
                		if(adm3200Repository.deleteADM104U(hospitalCode, item.getUserId(), pfeUser) <= 0
                				|| loginExtRepository.deleteLoginExt(hospitalCode, item.getUserId(), pfeUser) <= 0){
                			response.setResult(false);
                            return response;
                		}
                	}
                	LOGGER.info("ADM104UGridUserSaveLayoutRequest: END delete user: user_id=" + item.getUserId());
                }
            }
        }
        response.setResult(true);
        return response;
    }
    
    
    public boolean isValidKey(List<AdmaModelProto.ADM104UGridUserInfo> listItem, Vertx vertx, String clientId, String sessionId){
    	for (AdmaModelProto.ADM104UGridUserInfo info : listItem) {
            if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
//            	if(info.getUserId().toUpperCase().startsWith(UserEnum.PFE.getValue())){
//            		LOGGER.info("ADM104UGridUserSaveLayoutRequest: ADM_USER_ID_INVALID: user_id=" + info.getUserId());
//                	return false;
//            	}
                boolean existed = adm3200Repository.isExistedAdma(getHospitalCode(vertx, sessionId), info.getUserId());
                if(existed){
            		LOGGER.info("ADM104UGridUserSaveLayoutRequest: ADM_USER_ID_EXISTED: user_id=" + info.getUserId());
                	return false;
                }
            } 
    	}
    	return true;
    }
    
     private void sendEmailInform(String vpnFilePath, String hospCode, String language, Bas0001 bas0001, AdmaModelProto.ADM104UGridUserInfo item) {
     	String hospCodeEncryp = EncryptionUtils.encrypt(hospCode, configuration.getSecretKey(),
	    				EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
     	
     	String misBackEndUrl = configuration.getMisBackEnd() + hospCodeEncryp;
     	String misFrontEndUrl = configuration.getMisFrontEnd().replace(CommonEnum.HOSP_CODE_ENCRYP.getValue(), hospCodeEncryp);
     	String mbsBackEndUrl = configuration.getMbsBackEnd() + hospCodeEncryp;
     	String mbsFrontEndUrl = configuration.getMbsFrontEnd() + hospCodeEncryp;
     	String portalUrl= configuration.getPortal();
    	 
		MailInfo mailInfo = new MailInfo();
		mailInfo.setHospitalCode(hospCode);
		mailInfo.setHospitalName(bas0001.getYoyangName());
		mailInfo.setRegisterName(item.getUserNm());
		mailInfo.setUserId(item.getUserId());
		mailInfo.setPassword(item.getPlainPwd());
		mailInfo.setMisBackEndUrl(misBackEndUrl);
		mailInfo.setMisFrontEndUrl(misFrontEndUrl);
		mailInfo.setMbsBackEndUrl(mbsBackEndUrl);
		mailInfo.setMbsFrontEndUrl(mbsFrontEndUrl);
		mailInfo.setPortalUrl(portalUrl);
		mailInfo.setMbsPassword(mailInfoConfig.getMbsPassword());
		mailInfo.setLinkDownloadVpn(mailInfoConfig.getLinkDownloadVpn());
		if(Language.VIETNAMESE.toString().equalsIgnoreCase(language)){
			mailInfo.setLinkDownloadKcck(mailInfoConfig.getLinkDownloadKcckVn());
		}else{
			mailInfo.setLinkDownloadKcck(mailInfoConfig.getLinkDownloadKcck());
		}
		if(!StringUtils.isEmpty(vpnFilePath)){
			mailService.sendMail(CommonEnum.EMAIL_TEMPLATE_INFORM_CASE_VPN.getValue(), hospCode, language, mailInfo, item.getEmail(), vpnFilePath);
		}else{
			mailService.sendMail(CommonEnum.EMAIL_TEMPLATE_INFORM_CASE_NO_VPN.getValue(), hospCode, language, mailInfo, item.getEmail(), vpnFilePath);
		}
		
	}
}
