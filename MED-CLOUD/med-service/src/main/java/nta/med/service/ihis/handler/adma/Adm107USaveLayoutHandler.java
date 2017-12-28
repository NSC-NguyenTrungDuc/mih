package nta.med.service.ihis.handler.adma;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.adm.Adm4200;
import nta.med.core.domain.adm.Adm4310;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.adm.Adm4200Repository;
import nta.med.data.dao.medi.adm.Adm4300Repository;
import nta.med.data.dao.medi.adm.Adm4310Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto.Adm107USaveLayoutInfo;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
@Transactional
public class Adm107USaveLayoutHandler extends ScreenHandler<AdmaServiceProto.Adm107USaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    
	private static final Log LOGGER = LogFactory.getLog(Adm107USaveLayoutHandler.class);
    
	@Resource
    private Adm3200Repository adm3200Repository;
    
	@Resource
    private Adm4310Repository adm4310Repository;
    
	@Resource
    private Adm4200Repository adm4200Repository;
    
	@Resource
    private Adm4300Repository adm4300Repository;

    private void insertAdm4200(Adm107USaveLayoutInfo info, String hospitalCode) {
        Adm4200 adm4200 = new Adm4200();
        Double trSeq = CommonUtils.parseDouble(info.getTrSeq());
        adm4200.setHospCode(hospitalCode);
        adm4200.setUserId(info.getUserId());
        adm4200.setSysId(info.getSysId());
        adm4200.setTrId(info.getTrId());
        adm4200.setTrSeq(trSeq);
        adm4200.setUpprMenu(info.getUpprMenu());
        adm4200.setCrMemb(info.getCrMemb());
        adm4200.setCrTime(new Date());
        adm4200Repository.save(adm4200);
        
    }

    private void insertAdm4310(String userId, String sysId, String hospitalCode) {
        Adm4310 adm4310 = new Adm4310();
        adm4310.setHospCode(hospitalCode);
        adm4310.setUserId(userId);
        adm4310.setSysId(sysId);
        adm4310.setMenuGenYn("N");
        adm4310Repository.save(adm4310);
    }

    @Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.Adm107USaveLayoutRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
    
    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.Adm107USaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        Integer result = null;
        String hospitalCode = request.getHospCode();
        //ex1
        for (Adm107USaveLayoutInfo info : request.getSaveLayoutItemList()) {
            if ("Y".equalsIgnoreCase(info.getUseYn())) {
                insertAdm4200(info, hospitalCode);
                result = 1;
            } else if ("N".equalsIgnoreCase(info.getUseYn())) {
                Integer getCount = adm4200Repository.countAdm107uExecute(hospitalCode, info.getUserId(), info.getSysId(), info.getTrId());
                if (getCount == 0) {
                    break;
                }
                result = adm4200Repository.deleteAdm107uExecute(hospitalCode, info.getUserId(), info.getSysId(), info.getTrId());
            }
        }
        //ex2
        List<String> listUserId = adm3200Repository.getListUserId(hospitalCode, request.getMainUserId());
        if (!CollectionUtils.isEmpty(listUserId)) {
            for (String userId : listUserId) {
                result = adm4310Repository.updateAdm4310(hospitalCode, userId, request.getFbxSysId(), "N");
                if (result == 0) {
                    insertAdm4310(userId, request.getFbxSysId(), hospitalCode);
                    result = 1;
                }
            }
        }
        result = adm4310Repository.updateAdm4310(hospitalCode, request.getMainUserId(), request.getFbxSysId(), "N");
        if (result == 0) {
            insertAdm4310(request.getMainUserId(), request.getFbxSysId(), hospitalCode);
            result = 1;
        }
        result = adm4200Repository.getMenuByHospCodeAndUserIdAndSysID(hospitalCode, request.getMainUserId(), request.getFbxSysId());
        if (result == 0) {
            adm4300Repository.deleteByHospCodeAndLanguageAndUserIdAndSysId(hospitalCode, getLanguage(vertx, sessionId),
                    request.getMainUserId(), request.getFbxSysId());
            result = adm4310Repository.updateAdm4310(hospitalCode, request.getMainUserId(), request.getFbxSysId(), "Y");
        }
        response.setResult(result != null);
        return response.build();
    }
}