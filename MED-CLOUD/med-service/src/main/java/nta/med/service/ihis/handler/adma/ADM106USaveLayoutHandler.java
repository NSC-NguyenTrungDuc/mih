package nta.med.service.ihis.handler.adma;

import java.util.Date;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import com.google.common.base.Strings;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.adm.Adm4100;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.UserRole;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm4100Repository;
import nta.med.data.dao.medi.adm.Adm4310Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto.ADM106UMakeQueryListItemInfo;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.AdmaServiceProto.ADM106USaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Transactional
@Service
@Scope("prototype")
public class ADM106USaveLayoutHandler extends ScreenHandler<AdmaServiceProto.ADM106USaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    @Resource
    private Adm4100Repository adm4100Repository;
    
    @Resource
    private Adm4310Repository adm4310Repository;
    
    @Override
    public boolean isAuthorized(Vertx vertx, String sessionId){

        return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
    }
    
    @Override
    @Route(global = true)
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM106USaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        boolean save = false;
        String msg = "";
        if (CollectionUtils.isEmpty(request.getInputListList())) {
            response.setResult(false);
        } else {
            String hospitalCode = getHospitalCode(vertx, sessionId);
            String language  = getLanguage(vertx, sessionId);
            String role = getUserRole(vertx, sessionId);
            for (ADM106UMakeQueryListItemInfo item : request.getInputListList()) {
                if (item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
                    String max = adm4100Repository.getAdm106UMaxValueCaseAdded(hospitalCode, language, item.getSysId(), role);
                    if (StringUtils.isEmpty(max)) {
                    	max = "0";
                    }
                    
                    save = insertAdm4100(item, max, request.getUserId(), request.getUserTrm(), hospitalCode, language);
                } else if (item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                    save = updateAdm4100(item, request.getUserId(), request.getUserTrm(), hospitalCode, role, language);
                } else if (item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                    save = deleteAdm4100(item, language);
                    if (save) {
                        String chk = adm4100Repository.getAdm106Uchkdelete(hospitalCode, language, item.getSysId(), item.getTrId(), role);
                        if (StringUtils.isEmpty(chk)) {
                            // save = false; if chk null not return
                        } else {
                            if (chk.equalsIgnoreCase("X")) {
                                save = deleteAdm4100CaseChkEqualsX(item, language);
                            }
                        }
                    } else {
                        response.setResult(false);
                        response.setMsg("Delete Failed.");
                        throw new ExecutionException(response.build());
                    }
                }
                                
            }
        }
        response.setResult(save);
        response.setMsg(msg);
        return response.build();
    }
    
    @Override
    @Route(global = false)
    public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
    		ADM106USaveLayoutRequest request, UpdateResponse rs) throws Exception {
    	SystemServiceProto.UpdateResponse.Builder response = rs.toBuilder();
    	boolean save = false;
    	
    	if (CollectionUtils.isEmpty(request.getInputListList())) {
            response.setResult(false);
        } else {
        	for (ADM106UMakeQueryListItemInfo item : request.getInputListList()) {
              save = updateAdm4310(item);
              if (!save) {
                  response.setResult(false);
                  response.setMsg("Failed");
                  throw new ExecutionException(response.build());
              }
        	}
        }
    	
    	return response.build();
    }
    
    public boolean insertAdm4100(ADM106UMakeQueryListItemInfo item, String max, String userId, String userTrm, String hospitalCode, String language) {
        Adm4100 adm4100 = new Adm4100();
        adm4100.setSysId(item.getSysId());
        adm4100.setTrId(Strings.padStart(max, 5, '0'));
        adm4100.setPgmId(item.getPgmId());
        adm4100.setTrSeq(CommonUtils.parseDouble(item.getTrSeq()));
        if (!StringUtils.isEmpty(item.getUpprMenu())) {
            adm4100.setUpprMenu(item.getUpprMenu());
        }
        adm4100.setPgmOpenTp(item.getPgmOpenTp());
        adm4100.setMenuParam("");
        adm4100.setMenuTitle(item.getPgmNm());
        adm4100.setCrMemb(userId);
        adm4100.setCrTrm(userTrm);
        adm4100.setCrTime(new Date());
        adm4100.setLanguage(language);
        adm4100Repository.save(adm4100);
        return true;
    }

    public boolean updateAdm4100(ADM106UMakeQueryListItemInfo item, String userId, String userTrm, String hospitalCode, String role, String language) {
        String UpprMenu = item.getUpprMenu();
        if (StringUtils.isEmpty(UpprMenu)) {
            UpprMenu = null;
        }
    	if (adm4100Repository.updateAdm106UAdm4100(
                item.getPgmId(),
                item.getPgmNm(),
                CommonUtils.parseDouble(item.getTrSeq()),
                UpprMenu,
                item.getPgmOpenTp(),
                item.getMenuParam(),
                userId,
                userTrm,
                new Date(),
                item.getSysId(),
                item.getTrId(), language) > 0) {
            return true;
        } else {
            return false;
        }
    }

    public boolean deleteAdm4100(ADM106UMakeQueryListItemInfo item, String language) {
        if (adm4100Repository.deleteAdm106UAdm4100(item.getSysId(), item.getTrId(), language) > 0) {
            return true;
        } else {
            return false;
        }
    }

    public boolean deleteAdm4100CaseChkEqualsX(ADM106UMakeQueryListItemInfo item, String language) {
        if (adm4100Repository.deleteAdm106UAdm4100CaseChkEqualsX(item.getSysId(), item.getTrId(), language) > 0) {
            return true;
        } else {
            return false;
        }
    }

    public boolean updateAdm4310(ADM106UMakeQueryListItemInfo item) {
        if (adm4310Repository.updateAdm106UAdm4310("N", item.getSysId()) >= 0) {
            return true;
        } else {
            return false;
        }
    }
}

