package nta.med.service.ihis.handler.drgs;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.inv.Inv0101;
import nta.med.core.domain.inv.Inv0102;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.inv.Inv0101Repository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto.DRG0102U01GrdDetailItemInfo;
import nta.med.service.ihis.proto.DrgsModelProto.DRG0102U01GrdMasterItemInfo;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG0102U01SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Transactional
@Service
@Scope("prototype")
public class DRG0102U01SaveLayoutHandler extends ScreenHandler<DrgsServiceProto.DRG0102U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    
	private static final Log LOGGER = LogFactory.getLog(DRG0102U01SaveLayoutHandler.class);
    
	@Resource
    private Inv0101Repository inv0101Repository;
    
	@Resource
    private Inv0102Repository inv0102Repository;

    @Override
    @Route(global = true)
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0102U01SaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        boolean inv0101 = false;
        String language = getLanguage(vertx, sessionId);
        if (CollectionUtils.isEmpty(request.getGrdMasterItemInfoList())) {
            inv0101 = true;
        } else {
            for (DRG0102U01GrdMasterItemInfo item : request.getGrdMasterItemInfoList()) {
                if (item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
                    inv0101 = insertInv0101(item, request.getUserId(), language);
                } else if (item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                    inv0101 = updateInv0101(item, request.getUserId(), language);
                } else if (item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                    inv0101 = deleteInv0101(item, language);
                }
                if (!inv0101) {
                    response.setResult(false);
                    throw new ExecutionException(response.build());
                }
            }
        }

        if (inv0101) {
            response.setResult(true);
        } else {
        	response.setResult(false);
        }
        
        return response.build();
    }

    @Override
    @Route(global = false)
    public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
    		DRG0102U01SaveLayoutRequest request, UpdateResponse rs) throws Exception {
    	
    	SystemServiceProto.UpdateResponse.Builder response = rs.toBuilder();
    	String hospitalCode = getHospitalCode(vertx, sessionId);
    	String language = getLanguage(vertx, sessionId);
    	boolean inv0101 = true;
        boolean inv0102 = false;
        
        for (DRG0102U01GrdMasterItemInfo item : request.getGrdMasterItemInfoList()) {
        	if (item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                String result = inv0102Repository.checkDRG0102U00CheckExitToDelete(hospitalCode, item.getCodeType(), language);
                if (!StringUtils.isEmpty(result)) {
                    inv0101 = deleteInv0102CallerId1(item, hospitalCode, language);
                    if (!inv0101) {
                        response.setResult(false);
                        throw new ExecutionException(response.build());
                    }
                }
            }
        }
    	
        if (CollectionUtils.isEmpty(request.getGrdDetailItemInfoList())) {
            inv0102 = true;
        } else {
            for (DRG0102U01GrdDetailItemInfo item : request.getGrdDetailItemInfoList()) {
                if (item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
                    inv0102 = insertInv0102(item, request.getUserId(), hospitalCode, language);
                } else if (item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                    inv0102 = updateInv0102(item, request.getUserId(), hospitalCode, language);
                } else if (item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                    inv0102 = deleteInv0102(item, hospitalCode, language);
                }
                if (!inv0102) {
                    response.setResult(false);
                    throw new ExecutionException(response.build());
                }
            }
        }
        
        if (inv0101 && inv0102) {
            response.setResult(true);
        } else {
        	response.setResult(false);
        }
        
    	return response.build();
    }
    
    private boolean insertInv0101(DRG0102U01GrdMasterItemInfo item, String userId, String language) {
        Inv0101 inv0101 = new Inv0101();
        inv0101.setSysDate(new Date());
        inv0101.setSysId(userId);
        inv0101.setUpdDate(new Date());
        inv0101.setUpdId(userId);
        inv0101.setCodeType(item.getCodeType());
        inv0101.setCodeTypeName(item.getCodeTypeName());
        inv0101.setAdminGubun(item.getAdminGubun());
        inv0101.setRemark(item.getRemark());
        inv0101.setLanguage(language);
        inv0101Repository.save(inv0101);
        return true;
    }

    private boolean updateInv0101(DRG0102U01GrdMasterItemInfo item, String userId, String language) {
        if (inv0101Repository.updateDRG0102U01UpdateInv0101(
                userId,
                new Date(),
                item.getCodeType(),
                item.getCodeTypeName(),
                item.getAdminGubun(),
                item.getRemark(), language) > 0) {
            return true;
        } else {
            return false;
        }
    }

    private boolean deleteInv0101(DRG0102U01GrdMasterItemInfo item, String language) {
        if (inv0101Repository.deleteDRG0102U00UpdateInv0101(item.getCodeType(), language) > 0) {
            return true;
        } else {
            return false;
        }
    }

    private boolean deleteInv0102CallerId1(DRG0102U01GrdMasterItemInfo item, String hospitalCode, String language) {
        if (inv0102Repository.deleteDRG0102U00UpdateInv0101(item.getCodeType(), hospitalCode, language) > 0) {
            return true;
        } else {
            return false;
        }
    }

    private boolean insertInv0102(DRG0102U01GrdDetailItemInfo item, String userId, String hospitalCode, String language) {
        Inv0102 inv0102 = new Inv0102();
        inv0102.setSysDate(new Date());
        inv0102.setSysId(userId);
        inv0102.setUpdDate(new Date());
        inv0102.setUpdId(userId);
        inv0102.setCodeType(item.getCodeType());
        inv0102.setCode(item.getCode());
        inv0102.setCode2(item.getCode2());
        inv0102.setCodeName(item.getCodeName());
        inv0102.setHospCode(hospitalCode);
        inv0102.setRemark(item.getRemark());
        inv0102.setCodeValue(item.getCodeValue());
        inv0102.setLanguage(language);
        inv0102Repository.save(inv0102);
        return true;
    }

    private boolean updateInv0102(DRG0102U01GrdDetailItemInfo item, String userId, String hospitalCode, String language) {
        if (inv0102Repository.updateDRG0102U01UpdateInv0102(
                userId,
                new Date(),
                item.getCode2(),
                item.getCodeName(),
                item.getCodeValue(),
                item.getRemark(),
                item.getCodeType(),
                item.getCode(),
                hospitalCode, language) > 0) {
            return true;
        } else {
            return false;
        }
    }

    private boolean deleteInv0102(DRG0102U01GrdDetailItemInfo item, String hospitalCode, String language) {
        if (inv0102Repository.deleteDRG0102U00UpdateInv0102(item.getCodeType(), item.getCode(), hospitalCode, language) > 0) {
            return true;
        } else {
            return false;
        }
    }
}