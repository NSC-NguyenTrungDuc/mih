package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs0803;
import nta.med.core.domain.ocs.Ocs0804;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0803Repository;
import nta.med.data.dao.medi.ocs.Ocs0804Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0803U00grdOCS0803ItemInfo;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0803U00grdOCS0804ItemInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0803U00ExecuteRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class OCS0803U00ExecuteHandler
	extends ScreenHandler<OcsaServiceProto.OCS0803U00ExecuteRequest, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Ocs0803Repository ocs0803Repository; 
	@Resource                                                                                                       
	private Ocs0804Repository ocs0804Repository; 
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0803U00ExecuteRequest request)
			throws Exception {                                                               
      	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();       
      	   	String hospCode = getHospitalCode(vertx, sessionId);
      	   	String language = getLanguage(vertx, sessionId);
			boolean ocs0804 = false;
			boolean ocs0803 = false;
			if(CollectionUtils.isEmpty(request.getInputOCS0803List())){
				ocs0803 = true;
			}else{
				for(OCS0803U00grdOCS0803ItemInfo  item: request.getInputOCS0803List()){
				    	if(DataRowState.ADDED.getValue().equals(item.getRowState())) {
				    		insertOcs0803(item, request.getUserId(), hospCode, language);
				    		ocs0803 = true;
				    	} else if(DataRowState.MODIFIED.getValue().equals(item.getRowState())) {
				    		System.out.println(request.getUserId()+" " +item.getPatStatusGrName()+" " + new Date()+" " + 
				    				item.getMent()+" " +CommonUtils.parseDouble(item.getSeq())+" " +item.getPatStatusGr());
				    		if(ocs0803Repository.updateOCS0803U00ExecuteCase1(hospCode,request.getUserId(), item.getPatStatusGrName(), new Date(), 
				    				item.getMent(),CommonUtils.parseDouble(item.getSeq()),item.getPatStatusGr(), language)>0){
				    			ocs0803 = true;
				    		}else{
				    			response.setResult(false);
				    			throw new ExecutionException(response.build());
				    		}
				    	} else if(DataRowState.DELETED.getValue().equals(item.getRowState())) {
				    		if(ocs0803Repository.deleteOCS0803U00ExecuteCase1(hospCode,item.getPatStatusGr(), language)>0){
				    			ocs0803 = true;
				    		}else{
				    			response.setResult(false);
								throw new ExecutionException(response.build());
				    		}
				    	}
				}
			
			}
			if(CollectionUtils.isEmpty(request.getInputOCS0804List())){
				ocs0804 = true;
			}else{
				for(OCS0803U00grdOCS0804ItemInfo item : request.getInputOCS0804List()){
					if(DataRowState.ADDED.getValue().equals(item.getRowState())) {
			    		insertOcs0804(item, request.getUserId(), hospCode);
			    		ocs0804 = true;
			    	} else if(DataRowState.MODIFIED.getValue().equals(item.getRowState())) {
			    		System.out.println(request.getUserId()+" "+
				    			item.getIndispensableYn()+" "+item.getBreakPatStatusCode()+" "+item.getMent()+" "+
				    			CommonUtils.parseDouble(item.getSeq())+" "+item.getPatStatusGr()+" "+item.getPatStatusGr());
			    		if(ocs0804Repository.updateOCS0803U00ExecuteCase2(hospCode,request.getUserId(), new Date(),
			    			item.getIndispensableYn(),item.getBreakPatStatusCode(),item.getMent(),
			    			CommonUtils.parseDouble(item.getSeq()),item.getPatStatusGr(),item.getPatStatus())>0){
			    			ocs0804 = true;
			    		}else{
			    			response.setResult(false);
			    			throw new ExecutionException(response.build());
			    		}
			    	} else if(DataRowState.DELETED.getValue().equals(item.getRowState())) {
			    		if(ocs0804Repository.deleteOCS0803U00ExecuteCase2(hospCode,item.getPatStatusGr(),item.getPatStatus())>0){
			    			ocs0804 = true;
			    		}else{
			    			response.setResult(false);
			    			throw new ExecutionException(response.build());
			    		}	
			    	}
				}
			}	
			if(ocs0803 && ocs0804){
				response.setResult(true);
			}
			return response.build();
	}

	public void insertOcs0803(OCS0803U00grdOCS0803ItemInfo info, String userId, String hospCode, String language){
		Ocs0803 ocs0803 = new Ocs0803();
		ocs0803.setSysDate(new Date());
		ocs0803.setSysId(userId);
		ocs0803.setPatStatusGr(info.getPatStatusGr());
		ocs0803.setPatStatusGrName(info.getPatStatusGrName());
		ocs0803.setMent(info.getMent());
		ocs0803.setSeq(CommonUtils.parseDouble(info.getSeq()));
		ocs0803.setHospCode(hospCode);
		ocs0803.setLanguage(language);
		ocs0803Repository.save(ocs0803);
	}
	public void insertOcs0804(OCS0803U00grdOCS0804ItemInfo info, String userId, String hospCode){
		Ocs0804 ocs0804= new Ocs0804();
		ocs0804.setSysDate(new Date());
		ocs0804.setSysId(userId);
		ocs0804.setPatStatusGr(info.getPatStatusGr());
		ocs0804.setPatStatus(info.getPatStatus());
		ocs0804.setIndispensableYn(info.getIndispensableYn());
		ocs0804.setBreakPatStatusCode(info.getBreakPatStatusCode());
		ocs0804.setMent(info.getMent());
		ocs0804.setSeq(CommonUtils.parseDouble(info.getSeq()));
		ocs0804.setHospCode(hospCode);
		ocs0804Repository.save(ocs0804);
	}

}