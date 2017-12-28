package nta.med.service.ihis.handler.invs;

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
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inv.Inv0101Repository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.service.ihis.proto.InvsModelProto.INV0101U01GridDetailInfo;
import nta.med.service.ihis.proto.InvsModelProto.INV0101U01GridMasterInfo;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.SaveLayoutINV0101U01Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Transactional
@Service
@Scope("prototype")
public class SaveLayoutINV0101U01Handler extends ScreenHandler<InvsServiceProto.SaveLayoutINV0101U01Request, SystemServiceProto.UpdateResponse> {
    
	private static final Log LOGGER = LogFactory.getLog(SaveLayoutINV0101U01Handler.class);
    
	@Resource
    private Inv0101Repository inv0101Repository;
    
	@Resource
    private Inv0102Repository inv0102Repository;

    @Override
    @Route(global = true)
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, InvsServiceProto.SaveLayoutINV0101U01Request request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        boolean inv0101Result = false;
        String language = getLanguage(vertx, sessionId);
        if (CollectionUtils.isEmpty(request.getListMasterList())) {
            inv0101Result = true;
        } else {
            for (INV0101U01GridMasterInfo item : request.getListMasterList()) {
                if (item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
                	boolean isDupplicateKey = inv0101Repository.isExistedINV0101(item.getCodeType(), language);
                	if(isDupplicateKey){
                		LOGGER.info("Duplicate entry for key " +item.getCodeType());
						response.setResult(false);
						throw new ExecutionException(response.build());
					}else {				
						inv0101Result = insertInv0101(item, request.getUserId(), language);
					}
                } else if (item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                    inv0101Result = updateInv0101(item, request.getUserId(), language);
                } else if (item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                    inv0101Result = deleteInv0101(item, getLanguage(vertx, sessionId));
                }
                if (!inv0101Result) {
                    response.setResult(false);
                    throw new ExecutionException(response.build());
                }
            }
        }
        
        response.setResult(inv0101Result);
        return response.build();
    }

    @Override
    @Route(global = false)
    public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
    		SaveLayoutINV0101U01Request request, UpdateResponse rs) throws Exception {
    	
    	SystemServiceProto.UpdateResponse.Builder response = rs.toBuilder();
    	String hospitalCode = getHospitalCode(vertx, sessionId);
    	String language = getLanguage(vertx, sessionId);
    	boolean inv0101Result = true;
        boolean inv0102Result = false;
        
        for (INV0101U01GridMasterInfo item : request.getListMasterList()) {
        	if (item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                String result = inv0102Repository.checkDRG0102U00CheckExitToDelete(hospitalCode, item.getCodeType(), language);
                if (!StringUtils.isEmpty(result)) {
                    inv0101Result = deleteInv0102CallerId1(item, hospitalCode, language);
                    if (!inv0101Result) {
                        response.setResult(false);
                        throw new ExecutionException(response.build());
                    }
                }
            }
        }
    	
        if (CollectionUtils.isEmpty(request.getListDetailList())) {
        	inv0102Result = true;
        } else {
            for (INV0101U01GridDetailInfo item : request.getListDetailList()) {
                if (item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
                	inv0102Result = insertInv0102(item, request.getUserId(), hospitalCode, language);
                } else if (item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                	inv0102Result = updateInv0102(item, request.getUserId(), hospitalCode, language);
                } else if (item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                	inv0102Result = deleteInv0102(item, hospitalCode, language);
                }
                if (!inv0102Result) {
                    response.setResult(false);
                    throw new ExecutionException(response.build());
                }
            }
        }
        
        if (inv0101Result && inv0102Result) {
            response.setResult(true);
        } else {
        	response.setResult(false);
        }
        
    	return response.build();
    }
    
    private boolean insertInv0101(INV0101U01GridMasterInfo item, String userId, String language) {
		try {
			Inv0101 inv0101 = new Inv0101();
			inv0101.setSysDate(new Date());
			inv0101.setSysId(userId);
			inv0101.setUpdDate(new Date());
			inv0101.setUpdId(userId);
			inv0101.setCodeType(item.getCodeType());
			inv0101.setCodeTypeName(item.getCodeTypeName());
			inv0101.setAdminGubun(item.getAdminGubun());
			inv0101.setLanguage(language);
			inv0101Repository.save(inv0101);
			return inv0101.getId() > 0;

		} catch (Exception e) {
			LOGGER.error(e.getMessage(), e);
			return false;
		}
    	
    }

    private boolean updateInv0101(INV0101U01GridMasterInfo item, String userId, String language) {
        //return inv0101Repository.updateInv0101(userId, new Date(), item.getCodeType(), item.getCodeTypeName()) > 0;
        return inv0101Repository.updateDRG0102U00UpdateInv0101(userId, new Date(), item.getCodeType(), item.getCodeTypeName(), language) > 0;
    }

    private boolean deleteInv0101(INV0101U01GridMasterInfo item, String language) {
        return inv0101Repository.deleteDRG0102U00UpdateInv0101(item.getCodeType(), language) > 0;
       
    }

    private boolean deleteInv0102CallerId1(INV0101U01GridMasterInfo item, String hospitalCode, String language) {
        return inv0102Repository.deleteDRG0102U00UpdateInv0101(item.getCodeType(), hospitalCode, language) > 0; 
        
    }

    private boolean insertInv0102(INV0101U01GridDetailInfo item, String userId, String hospitalCode, String language) {
        try {
        	Inv0102 inv0102 = new Inv0102();
            inv0102.setSysDate(new Date());
            inv0102.setSysId(userId);
            inv0102.setUpdDate(new Date());
            inv0102.setUpdId(userId);
            inv0102.setCodeType(item.getCodeType());
            inv0102.setCode(item.getCode());
            inv0102.setCodeName(item.getCodeName());
            inv0102.setHospCode(hospitalCode);
            inv0102.setSortKey(CommonUtils.parseDouble(item.getSortKey()));
            inv0102.setLanguage(language);
            inv0102Repository.save(inv0102);
            return inv0102.getId() > 0;
			
		} catch (Exception e) {
			LOGGER.error(e.getMessage(), e);
			return false;
		}
    	
    }

	private boolean updateInv0102(INV0101U01GridDetailInfo item, String userId, String hospitalCode, String language) {
		return inv0102Repository.updateInv0101U00UpdateInv0102( userId, 
																new Date(), 
																item.getCodeName(), 
																CommonUtils.parseDouble(""), 
																item.getCodeType(), 
																item.getCode(), hospitalCode, language) > 0;
	}

    private boolean deleteInv0102(INV0101U01GridDetailInfo item, String hospitalCode, String language) {
        return inv0102Repository.deleteDRG0102U00UpdateInv0102(item.getCodeType(), item.getCode(), hospitalCode, language) > 0; 
       
    }
}