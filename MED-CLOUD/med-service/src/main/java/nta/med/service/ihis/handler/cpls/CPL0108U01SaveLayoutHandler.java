package nta.med.service.ihis.handler.cpls;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.cpl.Cpl0108;
import nta.med.core.domain.cpl.Cpl0109;
import nta.med.core.domain.ocs.Ocs0116;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.ModifyFlg;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.data.dao.medi.cpl.Cpl0108Repository;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.dao.medi.ocs.Ocs0116Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto.CPL0108U01GrdDetailInfo;
import nta.med.service.ihis.proto.CplsModelProto.CPL0108U01GrdMasterItemInfo;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U01SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
@Transactional
public class CPL0108U01SaveLayoutHandler extends ScreenHandler<CplsServiceProto.CPL0108U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    
	@Resource
    private Cpl0108Repository cpl0108Repository;
    
	@Resource
    private Cpl0109Repository cpl0109Repository;
    
	@Resource
    private Ocs0116Repository ocs0116Repository;

    @Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, CPL0108U01SaveLayoutRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
    
    @Override
    @Route(global = false)
    public UpdateResponse handle(Vertx vertx, String clientId,
                                 String sessionId, long contextId,
                                 CPL0108U01SaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        Integer result = null;
        String hospCode = StringUtils.isEmpty(request.getHospCode()) ? getHospitalCode(vertx, sessionId) : request.getHospCode();
        String language = getLanguage(vertx, sessionId);

        for (CPL0108U01GrdMasterItemInfo info : request.getGrdMstItemList()) {
            if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
                List<String> getX = cpl0109Repository.getXByCodeType(hospCode, language, info.getCodeType());
                if (!CollectionUtils.isEmpty(getX) && "Y".equals(StringUtils.isEmpty(getX.get(0)))) {
                    result = cpl0109Repository.deleteCpl0109ByCodeType(info.getCodeType(), hospCode, language);
                }
            }
        }
        //callerId = 2
        for (CPL0108U01GrdDetailInfo info : request.getGrdDetailItemList()) {
            if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
                insertCpl0109(info, request.getUserId(), hospCode, language);
                result = 1;
            } else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
                result = cpl0109Repository.updateCPL010108U00Cpl0109(request.getUserId(), info.getCodeName(), info.getCodeNameRe(), info.getCodeValue(), ModifyFlg.UPDATE.getValue(), 
                        info.getCodeType(), info.getCode(), hospCode, language);
            } else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
                result = cpl0109Repository.deleteCPL010108U00Cpl0109(info.getCodeType(), hospCode, info.getCode(), language);
            }
            //inside callerId = 2
            if (DataRowState.ADDED.getValue().equals(info.getRowState()) || DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
                if ("04".equalsIgnoreCase(info.getCodeType())) {
                    String getY = ocs0116Repository.getCpl0108U00DupYn(hospCode, info.getCode(), "CPL");
                    if ("Y".equalsIgnoreCase(getY)) {
                        result = ocs0116Repository.UpdateCpl0108U00Ocs0116(request.getUserId(), info.getCodeName(), hospCode, info.getCode(), "CPL");
                    } else {
                        insertOcs0116(info, request.getUserId(), hospCode);
                        result = 1;
                    }
                }
            }
        }

        if (StringUtils.isEmpty(result)) {
            response.setResult(false);
        } else {
            response.setResult(true);
        }
        return response.build();
    }

    @Override
    @Route(global = true)
    public UpdateResponse postHandle(Vertx vertx, String clientId,
                                     String sessionId, long contextId,
                                     CPL0108U01SaveLayoutRequest request, SystemServiceProto.UpdateResponse response) {
        SystemServiceProto.UpdateResponse.Builder updateReponse = response.toBuilder();
        Integer result = null;
        String hospCode = StringUtils.isEmpty(request.getHospCode()) ? getHospitalCode(vertx, sessionId) : request.getHospCode();
        String language = getLanguage(vertx, sessionId);
        //callerId = 1
        for (CPL0108U01GrdMasterItemInfo info : request.getGrdMstItemList()) {
            if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
                insertCpl0108(info, request.getUserId(), hospCode, language);
                result = 1;
            } else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
                result = cpl0108Repository.updateCPL0108U01(request.getUserId(), info.getCodeTypeName(), info.getAdminGubun(), info.getCodeType(), language);
            } else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
//                List<String> getX = cpl0109Repository.getXByCodeType(hospCode, language, info.getCodeType());
//                if (!CollectionUtils.isEmpty(getX) && "Y".equals(StringUtils.isEmpty(getX.get(0)))) {
//                    result = cpl0109Repository.deleteCpl0109ByCodeType(info.getCodeType(), hospCode, language);
//                }
                result = cpl0108Repository.deleteCPL0108U00(info.getCodeType(), language);
            }
        }
        if (StringUtils.isEmpty(result)) {
            updateReponse.setResult(false);
        } else {
            updateReponse.setResult(true);
        }
        return updateReponse.build();
    }

    private void insertCpl0108(CPL0108U01GrdMasterItemInfo info, String userId, String hospCode, String language) {
        Cpl0108 cpl0108 = new Cpl0108();
        cpl0108.setSysDate(new Date());
        cpl0108.setSysId(userId);
        cpl0108.setUpdDate(new Date());
        cpl0108.setUpdId(userId);
        cpl0108.setCodeType(StringUtils.isEmpty(info.getCodeType()) ? null : info.getCodeType());
        cpl0108.setCodeTypeName(StringUtils.isEmpty(info.getCodeTypeName()) ? null : info.getCodeTypeName());
        cpl0108.setAdminGubun(info.getAdminGubun());
        cpl0108.setLanguage(language);
        cpl0108Repository.save(cpl0108);
    }

    private void insertCpl0109(CPL0108U01GrdDetailInfo info, String userId, String hospCode, String language) {
        Cpl0109 cpl0109 = new Cpl0109();
        cpl0109.setSysDate(new Date());
        cpl0109.setSysId(userId);
        cpl0109.setUpdDate(new Date());
        cpl0109.setUpdId(userId);
        cpl0109.setCodeType(StringUtils.isEmpty(info.getCodeType()) ? null : info.getCodeType());
        cpl0109.setCode(StringUtils.isEmpty(info.getCode()) ? null : info.getCode());
        cpl0109.setCodeName(info.getCodeName());
        cpl0109.setCodeNameRe(info.getCodeNameRe());
        cpl0109.setSystemGubun(info.getSystemGubun());
        cpl0109.setHospCode(hospCode);
        cpl0109.setLanguage(language);
        cpl0109.setCodeValue(info.getCodeValue());
        cpl0109.setModifyFlg(ModifyFlg.INSERT.getValue());
        cpl0109Repository.save(cpl0109);
    }

    private void insertOcs0116(CPL0108U01GrdDetailInfo info, String userId, String hospCode) {
        Ocs0116 ocs0116 = new Ocs0116();
        ocs0116.setSysDate(new Date());
        ocs0116.setSysId(userId);
        ocs0116.setUpdDate(new Date());
        ocs0116.setUpdId(userId);
        ocs0116.setHospCode(hospCode);
        ocs0116.setSpecimenGubun("CPL");
        ocs0116.setSpecimenCode(StringUtils.isEmpty(info.getCode()) ? null : info.getCode());
        ocs0116.setSpecimenName(StringUtils.isEmpty(info.getCodeName()) ? null : info.getCodeName());
        ocs0116Repository.save(ocs0116);
    }

}