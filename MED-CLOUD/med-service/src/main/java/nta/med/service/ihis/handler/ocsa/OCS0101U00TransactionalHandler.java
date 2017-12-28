package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs0101;
import nta.med.core.domain.ocs.Ocs0102;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.ocs.Ocs0101Repository;
import nta.med.data.dao.medi.ocs.Ocs0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0101U00GrdOcs0101ListItemInfo;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0101U00GrdOcs0102ListItemInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101U00TransactionalRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101U00TransactionalResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0101U00TransactionalHandler extends ScreenHandler<OcsaServiceProto.OCS0101U00TransactionalRequest, OcsaServiceProto.OCS0101U00TransactionalResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0101U00TransactionalHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0101Repository ocs0101Repository;                                                                    
	@Resource                                                                                                       
	private Ocs0102Repository ocs0102Repository;  
	
	@Override        
	@Route(global = true)
	public OCS0101U00TransactionalResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0101U00TransactionalRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0101U00TransactionalResponse.Builder response = OcsaServiceProto.OCS0101U00TransactionalResponse.newBuilder();
  	    String language = getLanguage(vertx, sessionId);
		if(CollectionUtils.isEmpty(request.getListGrdOcs0101List())){
			response.setResultOcs0101(true);
		}else{
			for(OCS0101U00GrdOcs0101ListItemInfo item : request.getListGrdOcs0101List()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					response.setResultOcs0101(insertOcs0101(item, request.getUserId(), language));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(ocs0101Repository.updateOcs0101U00Ocs0101Modified(request.getUserId(),
							item.getSlipGubunName(), item.getSlipGubun(), language) > 0){
						response.setResultOcs0101(true);
					}else{
						response.setResultOcs0101(false);
						throw new ExecutionException(response.build());
					}
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(ocs0101Repository.deleteOcs0101U00Ocs0101Deleted(item.getSlipGubun(), language) > 0){
						response.setResultOcs0101(true);
					}else{
						response.setResultOcs0101(false);
						throw new ExecutionException(response.build());
					}
				}
			}
		}
		
		return response.build();
	}             
	
	@Override
	@Route(global = false)
	public OCS0101U00TransactionalResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS0101U00TransactionalRequest request, OCS0101U00TransactionalResponse rs) throws Exception {
		
		OcsaServiceProto.OCS0101U00TransactionalResponse.Builder response = rs.toBuilder();
		String hospCode = request.getHospCode();
		
		if(CollectionUtils.isEmpty(request.getListGrdOcs0102List())){
			response.setResultOcs0102(true);
		}else{
			for(OCS0101U00GrdOcs0102ListItemInfo item : request.getListGrdOcs0102List()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					response.setResultOcs0102(insertOcs0102(item, request.getUserId(), hospCode, getLanguage(vertx, sessionId)));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(ocs0102Repository.updateOcs0101U00Ocs0102Modified(request.getUserId(), 
							item.getSlipName(), item.getSlipGubun(), item.getSlipCode(), hospCode, getLanguage(vertx, sessionId))>0){
						response.setResultOcs0102(true);
					}else{
						response.setResultOcs0102(false);
						throw new ExecutionException(response.build());
					}
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(ocs0102Repository.deleteOcs0101U00Ocs0102Deleted(item.getSlipGubun(), 
							item.getSlipCode(), hospCode, getLanguage(vertx, sessionId))>0){
						response.setResultOcs0102(true);
					}else{
						response.setResultOcs0102(false);
						throw new ExecutionException(response.build());
					}
				}
			}
		}
		
		return response.build();
	}
	
	public boolean insertOcs0101(OCS0101U00GrdOcs0101ListItemInfo item, String userId, String language){
		Ocs0101 ocs0101 = new Ocs0101();
		ocs0101.setSysDate(new Date());
		ocs0101.setSysId(userId);
		ocs0101.setSlipGubun(item.getSlipGubun());
		ocs0101.setSlipGubunName(item.getSlipGubunName());
		ocs0101.setUpdDate(new Date());
		ocs0101.setUpdId(userId);
		ocs0101.setLanguage(language);
		ocs0101Repository.save(ocs0101);
		return true;
	}
	
	
	public boolean insertOcs0102(OCS0101U00GrdOcs0102ListItemInfo item, String userId, String hospCode, String language){
		Ocs0102 ocs0102 = new Ocs0102();
		ocs0102.setSysDate(new Date());
		ocs0102.setSysId(userId);
		ocs0102.setSlipGubun(item.getSlipGubun());
		ocs0102.setSlipCode(item.getSlipCode());
		ocs0102.setSlipName(item.getSlipName());
		ocs0102.setHospCode(hospCode);
		ocs0102.setUpdDate(new Date());
		ocs0102.setUpdId(userId);
		ocs0102.setLanguage(language);

		ocs0102Repository.save(ocs0102);
		return true;
	}
	
}