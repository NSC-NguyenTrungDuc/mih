package nta.med.service.ihis.handler.invs;

import java.util.Date;

import javax.annotation.Resource;

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
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inv.Inv0101Repository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.SaveLayoutINV0101Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class SaveLayoutINV0101Handler extends ScreenHandler<InvsServiceProto.SaveLayoutINV0101Request, SystemServiceProto.UpdateResponse>{

	@Resource
    private Inv0101Repository inv0101Repository;
    
	@Resource
    private Inv0102Repository inv0102Repository;
	
    @Override
    @Route(global = true)
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			SaveLayoutINV0101Request request) throws Exception {
    	
    	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        boolean saveInv0101Result = false;
        String language = getLanguage(vertx, sessionId);
        if (CollectionUtils.isEmpty(request.getListMasterList())) {
        	saveInv0101Result = true;
        } else {
            for (InvsModelProto.LoadGrdMasterINV0101Info item : request.getListMasterList()) {
                if (item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
                	saveInv0101Result = insertInv0101(item, request.getUserId(), language);
                } else if (item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                	saveInv0101Result = updateInv0101(item, request.getUserId(), language);
                } else if (item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                	saveInv0101Result = deleteInv0101(item, language);
                }
                
                if (!saveInv0101Result) {
                    response.setResult(false);
                    throw new ExecutionException(response.build());
                }
            }
        }

        response.setResult(saveInv0101Result);
        return response.build();
	}

    @Override
    @Route(global = false)
    public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
    		SaveLayoutINV0101Request request, UpdateResponse rs) throws Exception {
    	SystemServiceProto.UpdateResponse.Builder response = rs.toBuilder();
    	String hospCode = getHospitalCode(vertx, sessionId);
    	String language = getLanguage(vertx, sessionId);
    	boolean saveInv0101Result = true;
        boolean saveInv0102Result = false;
        
        for (InvsModelProto.LoadGrdMasterINV0101Info item : request.getListMasterList()) {
        	if (item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                String result = inv0102Repository.checkDRG0102U00CheckExitToDelete(hospCode, item.getCodeType(), language);
                if (!StringUtils.isEmpty(result)) {
                	saveInv0101Result = deleteInv0102ByCodeType(item.getCodeType(), hospCode, language);
                    if (!saveInv0101Result) {
                        response.setResult(false);
                        throw new ExecutionException(response.build());
                    }
                }
            }
        }
    	
        if (CollectionUtils.isEmpty(request.getListDetailList())) {
        	saveInv0102Result = true;
        } else {
            for (InvsModelProto.LoadGrdDetailINV0101Info item : request.getListDetailList()) {
                if (item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
                	saveInv0102Result = insertInv0102(item, request.getUserId(), hospCode, language);
                } else if (item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                	saveInv0102Result = updateInv0102(item, request.getUserId(), hospCode, language);
                } else if (item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                	saveInv0102Result = deleteInv0102(item, hospCode, language);
                }
                
                if (!saveInv0102Result) {
                    response.setResult(false);
                    throw new ExecutionException(response.build());
                }
            }
        }
        
        if (saveInv0101Result && saveInv0102Result) {
            response.setResult(true);
        } else {
        	response.setResult(false);
        }
        
    	return response.build();
    }
    
	private boolean insertInv0101(InvsModelProto.LoadGrdMasterINV0101Info item, String userId, String language) {
        Inv0101 inv0101 = new Inv0101();
        inv0101.setSysDate(new Date());
        inv0101.setSysId(userId);
        inv0101.setUpdDate(new Date());
        inv0101.setUpdId(userId);
        inv0101.setCodeType(item.getCodeType());
        inv0101.setCodeTypeName(item.getCodeName());
        inv0101.setLanguage(language);
        inv0101Repository.save(inv0101);
        return inv0101.getId() > 0;
    }

    private boolean updateInv0101(InvsModelProto.LoadGrdMasterINV0101Info item, String userId, String language) {
    	return inv0101Repository.updateDRG0102U00UpdateInv0101(userId, new Date(), item.getCodeType(), item.getCodeName(), language) > 0;
    }

    private boolean deleteInv0101(InvsModelProto.LoadGrdMasterINV0101Info item, String language) {
        return inv0101Repository.deleteDRG0102U00UpdateInv0101(item.getCodeType(), language) > 0;
    }

    private boolean deleteInv0102ByCodeType(String codeType, String hospCode, String language) {
        return inv0102Repository.deleteDRG0102U00UpdateInv0101(codeType, hospCode, language) > 0;
    }

    private boolean insertInv0102(InvsModelProto.LoadGrdDetailINV0101Info item, String userId, String hospCode, String language) {
        Inv0102 inv0102 = new Inv0102();
        inv0102.setSysDate(new Date());
        inv0102.setSysId(userId);
        inv0102.setUpdDate(new Date());
        inv0102.setUpdId(userId);
        inv0102.setHospCode(hospCode);
        inv0102.setCodeType(item.getCodeType());
        inv0102.setCode(item.getCode());
        inv0102.setCodeName(item.getCodeName());
        inv0102.setSortKey(CommonUtils.parseDouble(item.getSortKey()));
        inv0102.setLanguage(language);
        inv0102Repository.save(inv0102);
        return inv0102.getId() > 0;
    }

    private boolean updateInv0102(InvsModelProto.LoadGrdDetailINV0101Info item, String userId, String hospCode, String language) {
		return inv0102Repository.updateInv0101U00UpdateInv0102(userId, new Date(), item.getCodeName(), 
				CommonUtils.parseDouble(""), item.getCodeType(), item.getCode(), hospCode, language) > 0;
    }

    private boolean deleteInv0102(InvsModelProto.LoadGrdDetailINV0101Info item, String hospCode, String language) {
        return inv0102Repository.deleteDRG0102U00UpdateInv0102(item.getCodeType(), item.getCode(), hospCode, language) > 0;
    }
	
}
