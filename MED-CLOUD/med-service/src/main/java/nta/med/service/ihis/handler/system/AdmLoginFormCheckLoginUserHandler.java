package nta.med.service.ihis.handler.system;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.config.Configuration;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.kinki.Revision;
import nta.med.core.domain.ocs.Ocs0132;
import nta.med.core.domain.ocs.Ocs0150;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.glossary.CheckKinki;
import nta.med.core.glossary.CommonEnum;
import nta.med.core.glossary.KinkiTable;
import nta.med.core.glossary.MonitorKey;
import nta.med.core.glossary.ScreenMater;
import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.MonitorLog;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.core.utils.EncryptionUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.adm.LoginExtRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.kinki.RevisionRepository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.ocs.Ocs0150Repository;
import nta.med.data.model.ihis.adma.MailInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.system.AdmLoginFormCheckLoginUserInfo;
import nta.med.data.model.ihis.system.CacheRevisionInfo;
import nta.med.data.model.ihis.system.FormGwaItemInfo;
import nta.med.data.model.ihis.system.LoginExtInfo;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.AdmLoginFormCheckLoginUserRequest;
import nta.med.service.ihis.proto.SystemServiceProto.AdmLoginFormCheckLoginUserResponse;

@Service
@Scope("prototype")
public class AdmLoginFormCheckLoginUserHandler extends ScreenHandler<SystemServiceProto.AdmLoginFormCheckLoginUserRequest, SystemServiceProto.AdmLoginFormCheckLoginUserResponse> {
    private static final Log LOGGER = LogFactory.getLog(AdmLoginFormCheckLoginUserHandler.class);
    @Resource
    private Adm3200Repository adm3200Repository;
    @Resource
    private RevisionRepository revisionRepository;
    @Resource
    private Ocs0132Repository ocs0132Repository;
    @Resource
    private Ocs0150Repository ocs0150Repository;
    @Resource
    private Bas0260Repository bas0260Repository;
    @Resource
    private Bas0102Repository bas0102Repository;
    @Resource
    private LoginExtRepository loginExtRepository;
    @Resource
	private CommonRepository commonRepository;
    @Resource
    private Bas0001Repository bas0001Repository;
    @Resource
    private Configuration configuration;
    @Resource
    private MailService mailService;
    @Override
    public boolean isAuthorized(Vertx vertx, String sessionId){
        return true;
    }
    
    @Override
    @Transactional
    @Route(global = true)
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, AdmLoginFormCheckLoginUserRequest request) throws Exception {
        List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
        if(!CollectionUtils.isEmpty(bas0001List))
        {
            Bas0001 bas0001 = bas0001List.get(0);
            setSessionInfo(vertx, sessionId,
                    SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(), bas0001.getLanguage(), "", 1, ""));
        }
        else
        {
            LOGGER.info("AdmLoginFormCheckLoginUserHandler preHandle not found hosp code");
        }
    }
    @Override
    @Transactional(readOnly = true)
    @Route(global = false)
    public AdmLoginFormCheckLoginUserResponse handle(Vertx vertx,
                                                     String clientId, String sessionId, long contextId,
                                                     AdmLoginFormCheckLoginUserRequest request) throws Exception {
        SystemServiceProto.AdmLoginFormCheckLoginUserResponse.Builder response = SystemServiceProto.AdmLoginFormCheckLoginUserResponse.newBuilder();
        SystemModelProto.MisaInfo.Builder   misaInfo = SystemModelProto.MisaInfo.newBuilder();
        SystemModelProto.OrcaInfo.Builder   orcaInfo = SystemModelProto.OrcaInfo.newBuilder();
        AdmLoginFormCheckLoginUserInfo item = adm3200Repository.getAdmLoginFormCheckLoginUserInfo(request.getUser(), request.getPassword(), request.getHospCode());
        response.setSessionId(sessionId);
      //Bas0001 basClinic = bas0001Repository.findLatestByHospCode(request.getHospCode()).get(0);
        Bas0001 basClinic = CollectionUtils.isEmpty(bas0001Repository.findLatestByHospCode(request.getHospCode())) 
        		? new Bas0001() : bas0001Repository.findLatestByHospCode(request.getHospCode()).get(0);

        if (item != null) {
        	/*if(item.getLoginFlg().equals(BigDecimal.ZERO)){
        		response.setOrcaInfo(orcaInfo);
            	response.setMisaInfo(misaInfo);
        		return response.build();
        	}*/
        	if (!StringUtils.isEmpty(item.getUserGroup())) {
        		if(item.getUserGroup().equals("SMO") && StringUtils.isEmpty(item.getClisSmoId())){
        			response.setOrcaInfo(orcaInfo);
                	response.setMisaInfo(misaInfo);
                	response.setMsg("SMO");
            		return response.build();
            	}
            }
        	
        	SystemModelProto.AdmLoginFormCheckLoginUserInfo.Builder info = SystemModelProto.AdmLoginFormCheckLoginUserInfo.newBuilder();
        	
        	//Check First Login
        	LoginExtInfo loginExt = loginExtRepository.getLoginExt(request.getUser(), request.getHospCode());
        	if(loginExt != null){
        		if(BigDecimal.ONE.equals(loginExt.getChangePwdFlg())){
        			info.setChangePwdFlg(YesNo.YES.getValue());
            	}else if(BigDecimal.ZERO.equals(loginExt.getChangePwdFlg())){
            		info.setChangePwdFlg(YesNo.NO.getValue());
            	}
        		if(BigDecimal.ONE.equals(loginExt.getFirstLoginFlg())){
        			info.setFirstLoginFlg(YesNo.YES.getValue());
            	}else if(BigDecimal.ZERO.equals(loginExt.getFirstLoginFlg())){
            		info.setFirstLoginFlg(YesNo.NO.getValue());
            	}
        		info.setLastPwdChange(DateUtil.toString(loginExt.getLastChangePwd(), DateUtil.PATTERN_YYMMDD));
        		info.setPwdHistory(loginExt.getPwdHistory());
        	}
        	String currentTime = DateUtil.toString(new Date(), DateUtil.PATTERN_YYMMDD);  //commonRepository.getFormEnvironInfoSysDate();
        	info.setCurrentTime(currentTime);
            if(item.getClisSmoId() != null) info.setClisSmoId(item.getClisSmoId());
        	if(!StringUtils.isEmpty(item.getUserEndYmd())){
            	info.setEndTime(item.getUserEndYmd());
        	}
        	
            if (!StringUtils.isEmpty(item.getUserId())) {
                info.setUserId(item.getUserId());
            }
            if (!StringUtils.isEmpty(item.getUserNm())) {
                info.setUserNm(item.getUserNm());
            }
            if (!StringUtils.isEmpty(item.getUserGroup())) {
                info.setUserGroup(item.getUserGroup());
            }
            if (!StringUtils.isEmpty(item.getHospCode())) {
                info.setHospCode(item.getHospCode());
            }
            if (!StringUtils.isEmpty(item.getLanguage())) {
                info.setLanguage(item.getLanguage());
            }
            if(!StringUtils.isEmpty(item.getCertExpired())){
            	info.setCertExpired(item.getCertExpired());
            }
            if(!StringUtils.isEmpty(item.getTimeZone())){
            	info.setTimeZone(item.getTimeZone().toString());
            }
            
            List<Bas0102> bas0102List = bas0102Repository.getByHospCodeAndCodeType(item.getHospCode(), "ACCT_TYPE","ACCT_ORCA", "ACCT_MISA");
            if(!CollectionUtils.isEmpty(bas0102List))
            {
            	String accType = null;
                for(Bas0102 bas0102 : bas0102List)
                {
                	if(AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(bas0102.getCode())){
                		accType = bas0102.getCode();
                		break;
                	}else if(AccountingConfig.ACCT_TYPE_MISA.getValue().equalsIgnoreCase(bas0102.getCode())){
                		accType = bas0102.getCode();
                		break;
                	}
                }
            	if(AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(accType)){
            		LOGGER.info("AdmLoginFormCheckLoginUserHandler case ORCA");
            		orcaInfo = getOrcaInfo(bas0102List, orcaInfo);
            	}else if(AccountingConfig.ACCT_TYPE_MISA.getValue().equalsIgnoreCase(accType)){
            		LOGGER.info("AdmLoginFormCheckLoginUserHandler case MISA");
            		misaInfo = getMisaInfo(bas0102List, misaInfo);
            	}
            }
            response.setOrcaInfo(orcaInfo);
        	response.setMisaInfo(misaInfo);
            MonitorLog.writeMonitorLog(MonitorKey.LOGIN_SUCCESS, "New user have been successfully logged in");


            setKinkiData(item.getHospCode(), info);
            //get gwa from FormGwaListRequest
            String gwa = null;
            List<FormGwaItemInfo> listFormGwa = bas0260Repository.getFormGwaItemInfo(item.getHospCode(), item.getLanguage(), item.getUserId(), false);
        	if(!CollectionUtils.isEmpty(listFormGwa)){
        		gwa = listFormGwa.get(0).getDoctorGwa();
        	}
            List<Ocs0150> ocs0150List = ocs0150Repository.findByHospCodeAndDoctorAndGwa(info.getHospCode(), info.getUserId(), gwa);
            if(!CollectionUtils.isEmpty(ocs0150List))
            {
                 info.setDoctorDrugCheck(ocs0150List.get(0).getCheckingDrgYn());
            }
            //get cache revision
            List<CacheRevisionInfo> cacheRevision = revisionRepository.getCacheRevisionInfo(info.getHospCode());
            if(!CollectionUtils.isEmpty(cacheRevision)){
            	for(CacheRevisionInfo cache : cacheRevision){
            		SystemModelProto.CacheRevisionInfo.Builder cacheInfo = SystemModelProto.CacheRevisionInfo.newBuilder();
            		if(!StringUtils.isEmpty(cache.getTableName())){
            			cacheInfo.setTableName(cache.getTableName());
            		}
            		if(!StringUtils.isEmpty(cache.getRevision())){
            			cacheInfo.setRevision(cache.getRevision());
            		}
    				response.addCacheRevItem(cacheInfo);
            	}
            }
            
            SessionUserInfo sessionUserInfo = SessionUserInfo.setSessionUserInfoByUserGroup(item.getHospCode(), item.getLanguage(), item.getUserId(), item.getClisSmoId(), item.getUserGroup());
            sessionUserInfo.setTimeZone(basClinic.getTimeZone());
            setSessionInfo(vertx, sessionId, sessionUserInfo);
         // check using inventory or not
            List<ComboListItemInfo> inventoryYn = bas0102Repository.getComboListItemInfoByCodeType(item.getHospCode(), item.getLanguage(), "INV_USAGE");
            if(!CollectionUtils.isEmpty(inventoryYn)){
            	info.setInvUsage(inventoryYn.get(0).getCode());
            }
            if(!StringUtils.isEmpty(basClinic.getVpnYn())){
                response.setVpnYn(basClinic.getVpnYn());
            }
            List<Bas0102> bas0102s = bas0102Repository.getByCodeType(request.getHospCode(), "PHR_USE", item.getLanguage());
            info.setUsePhr("N");
            if(!CollectionUtils.isEmpty(bas0102s))
            {
                if(bas0102s.get(0).getCode().equals("1"))
                    info.setUsePhr("Y");
            }
            
//            info.setLanguage("VI");
            response.addUserInfoItem(info);
            setScreensNeedToUpdateMasterData(response, item, basClinic);



        } else {
            if(!StringUtils.isEmpty(basClinic.getVpnYn())){
                response.setVpnYn(basClinic.getVpnYn());
            }
        }
        return response.build();
    }

    private void setScreensNeedToUpdateMasterData(AdmLoginFormCheckLoginUserResponse.Builder response, AdmLoginFormCheckLoginUserInfo item, Bas0001 basClinic ) {
        //Bas0001 bas0001 = bas0001Repository.getHospital()

        Bas0001 basNTA = bas0001Repository.findLatestByHospCode("NTA").get(0);


        String nta = basNTA.getRevision();
        String clinic = basClinic.getRevision();
        String[] ntas = nta.split("\\|");
        String[] clinics = clinic.split("\\|");

        Map<String, Long> mapNtas = new HashMap<>();
        for (String item1 : ntas) {
              String[] items = item1.split("_");
              mapNtas.put(items[0], Long.parseLong(items[1]));
        }
        Map<String, Long> mapClinic = new HashMap<>();
        if(!StringUtils.isEmpty(clinic)){
        	for (String item2 : clinics) {
                String[] items = item2.split("_");
                mapClinic.put(items[0], Long.parseLong(items[1]));
            }
        }
        List<String> tableList = new ArrayList<>();
        for (Map.Entry<String, Long> entry : mapNtas.entrySet())
        {
            if(mapClinic.containsKey(entry.getKey()))
            {
                Long keyClinic  = mapClinic.get(entry.getKey());
                if(keyClinic < entry.getValue())
                {
                    tableList.add(entry.getKey());
                }
            }
        }

        List<SystemModelProto.NewMstDataListInfo> masterDataList = new ArrayList<>();

        for(ScreenMater screenMater : ScreenMater.values())
        {
            boolean hasContainTable = false;
            SystemModelProto.NewMstDataListInfo.Builder masterInfo =  SystemModelProto.NewMstDataListInfo.newBuilder();

            for(String screen : tableList)
            {
                if(screenMater.getTables().contains(screen))
                {
                    hasContainTable = true;
                    break;
                }
            }

            if(hasContainTable)
            {
                masterInfo.setScreenName(screenMater.name());
                masterDataList.add(masterInfo.build());
            }
        }


//        masterInfo.setScreenName("OCS0103U00");
//        masterDataList.add(masterInfo.build());
//
//        masterInfo =  SystemModelProto.NewMstDataListInfo.newBuilder();
//        masterInfo.setScreenName("BAS0310U00");
//        masterDataList.add(masterInfo.build());
//
//        masterInfo =  SystemModelProto.NewMstDataListInfo.newBuilder();
//        masterInfo.setScreenName("OCS0108U00");
//        masterDataList.add(masterInfo.build());
//
//        masterInfo =  SystemModelProto.NewMstDataListInfo.newBuilder();
//        masterInfo.setScreenName("CPL0101U00");
      //  masterDataList.add(masterInfo.build());


        response.addAllNewMstDataListItem(masterDataList);
    }

    private void setKinkiData(String hospCode, SystemModelProto.AdmLoginFormCheckLoginUserInfo.Builder info) {
        List<Revision> revisions = revisionRepository.findAll();

        for (Revision revision : revisions) {
            if (KinkiTable.get(revision.getTableName()) != null) {
                KinkiTable kinkiTable = KinkiTable.get(revision.getTableName());
                String value = String.valueOf(revision.getRevision());
                switch (kinkiTable) {
                    case DRUG_KINKI_MESSAGE:
                        info.setRevKinkiMessage(value);
                        break;
                    case DRUG_KINKI_DISEASE:
                        info.setRevKinkiDisease(value);
                        break;
                    case DRUG_DOSAGE:
                        info.setRevDosage(value);
                        break;
                    case DRUG_CHECKING:
                        info.setRevDrugChecking(value);
                        break;
                    case DRUG_INTERACTION:
                        info.setRevInteraction(value);
                        break;
                    case DRUG_GENERIC_NAME:
                        info.setRevGenericName(value);
                        break;
                }
            }

        }
        List<Ocs0132> ocs0132List = ocs0132Repository.findByHospCodeAndCodeTypeAndCodeIn(hospCode, "KINKI",
                Arrays.asList(CheckKinki.CHECK_DOSAGE.getValue(), CheckKinki.CHECK_INTERACTION.getValue(), CheckKinki.CHECK_KINKI.getValue()));
        info.setCheckDosage("N");
        info.setCheckInteraction("N");
        info.setCheckKinki("N");
        info.setDoctorDrugCheck("N");
        for(Ocs0132 ocs0132 : ocs0132List)
        {
            if(ocs0132.getCode().equals(CheckKinki.CHECK_DOSAGE.getValue()))
            {
                info.setCheckDosage(ocs0132.getCodeName());
            }
            else if(ocs0132.getCode().equals(CheckKinki.CHECK_INTERACTION.getValue()))
            {
                info.setCheckInteraction(ocs0132.getCodeName());
            }
            else if(ocs0132.getCode().equals(CheckKinki.CHECK_KINKI.getValue()))
            {
                info.setCheckKinki(ocs0132.getCodeName());
            }
        }
    }

    private SystemModelProto.OrcaInfo.Builder getOrcaInfo(List<Bas0102> bas0102List, SystemModelProto.OrcaInfo.Builder orcaInfo){
    	for(Bas0102 bas0102Orca : bas0102List)
        {
    		if(bas0102Orca.getCode().equals(AccountingConfig.ORCA_IP.getValue()))
            {
    			orcaInfo.setOrcaIp(bas0102Orca.getCodeName());
            }
            else if(bas0102Orca.getCode().equals(AccountingConfig.ORCA_USER.getValue()))
            {
            	orcaInfo.setOrcaUser(bas0102Orca.getCodeName());
            }
            else if(bas0102Orca.getCode().equals(AccountingConfig.ORCA_PWD.getValue()))
            {
            	orcaInfo.setOrcaPassword(bas0102Orca.getCodeName());
            }
            else if(bas0102Orca.getCode().equals(AccountingConfig.ORCA_PORT.getValue()))
            {
            	orcaInfo.setOrcaPort(bas0102Orca.getCodeName());
            }
            else if(bas0102Orca.getCode().equals(AccountingConfig.HOSP_CODE.getValue()))
            {
            	orcaInfo.setOrcaHospCode(bas0102Orca.getCodeName());
            }
            else if(bas0102Orca.getCode().equals(AccountingConfig.PORT_CLAIM.getValue()))
            {
            	orcaInfo.setOrcaPortRcvClaim(bas0102Orca.getCodeName());
            }else if(bas0102Orca.getCode().equals(AccountingConfig.CLOUD_YN.getValue()))
            {
            	orcaInfo.setOrcaCloudYn(bas0102Orca.getCodeName());
            }
        }
    	return orcaInfo;
    }
    
    private SystemModelProto.MisaInfo.Builder getMisaInfo(List<Bas0102> bas0102List, SystemModelProto.MisaInfo.Builder misaInfo){
    	for(Bas0102 bas0102Misa : bas0102List)
        {
    		if(bas0102Misa.getCode().equals(AccountingConfig.MISA_IP.getValue()))
            {
    			misaInfo.setMisaIp(bas0102Misa.getCodeName());
            }
            else if(bas0102Misa.getCode().equals(AccountingConfig.MISA_USER.getValue()))
            {
            	misaInfo.setMisaUser(bas0102Misa.getCodeName());
            }
            else if(bas0102Misa.getCode().equals(AccountingConfig.MISA_PWD.getValue()))
            {
            	misaInfo.setMisaPwd(bas0102Misa.getCodeName());
            }
            else if(bas0102Misa.getCode().equals(AccountingConfig.INST_NAME.getValue()))
            {
            	misaInfo.setMisaInstanceName(bas0102Misa.getCodeName());
            }
            else if(bas0102Misa.getCode().equals(AccountingConfig.DB_NAME.getValue()))
            {
            	misaInfo.setMisaDbInsurName(bas0102Misa.getCodeName());
            }
        }
    	return misaInfo;
    }

}