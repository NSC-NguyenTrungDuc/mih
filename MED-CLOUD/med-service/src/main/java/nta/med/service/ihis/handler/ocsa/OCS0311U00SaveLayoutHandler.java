package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs0311;
import nta.med.core.domain.ocs.Ocs0312;
import nta.med.core.domain.ocs.Ocs0313;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0311Repository;
import nta.med.data.dao.medi.ocs.Ocs0312Repository;
import nta.med.data.dao.medi.ocs.Ocs0313Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0311U00grdHangmogCodeListInfo;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0311U00grdSetCodeListInfo;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0311U00grdSetHangmogListInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0311U00SaveLayoutHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Ocs0311Repository ocs0311Repository;                                                                    
	@Resource
	private Ocs0312Repository ocs0312Repository;
	@Resource
	private Ocs0313Repository ocs0313Repository;
	
	
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0311U00SaveLayoutRequest request) throws Exception {
      	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
			boolean grdHangmog = false;
			boolean grdSetCode = false;
			boolean grdSetHangMog = false;
			String hospCode = getHospitalCode(vertx, sessionId);
			// OCS0311
			if(CollectionUtils.isEmpty(request.getGrdHangMogListList())){
				grdHangmog = true;
			}else{
				for(OCS0311U00grdHangmogCodeListInfo item : request.getGrdHangMogListList()){
					if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
						grdHangmog = insertOcs0311(item, request.getUserId(), hospCode);
					}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
						if(ocs0311Repository.deleteOCS0311U00Execute(hospCode,item.getSetPart(),item.getHangmogCode()) >0){
							grdHangmog = true ;
						}else{
							grdHangmog = false ;
						}
					}
				}
			}
			
			//OCS0312
			if(CollectionUtils.isEmpty(request.getGrdSetCodeListList())){
				grdSetCode = true;
			}else{
				for(OCS0311U00grdSetCodeListInfo item : request.getGrdSetCodeListList()){
					if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
						grdSetCode = insertOcs0312(item, request.getUserId(), hospCode);
					}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
						if(ocs0312Repository.updateOcs0312OCS0311U00Execute(hospCode,request.getUserId(),item.getSetCodeName(),
				    			item.getComments(),item.getSetPart(),item.getHangmogCode(),item.getSetCode()) >0){
							grdSetCode = true ;
						}else{
							grdSetCode = false ;
						}
					}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
						if(ocs0312Repository.deleteOcs0312OCS0311U00Execute(hospCode,item.getSetPart() ,item.getHangmogCode(),item.getSetCode()) >0){
							grdSetCode = true ;
						}else{
							grdSetCode = false ;
						}
					}
				}
			}
			
			//OCS0313
			if(CollectionUtils.isEmpty(request.getGrdSetHangMogListList())){
				grdSetHangMog = true;
			}else{
				for(OCS0311U00grdSetHangmogListInfo item : request.getGrdSetHangMogListList()){
					if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
						grdSetHangMog = insertOcs0313(item, request.getUserId(), hospCode);
					}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
						if(ocs0313Repository.updateOcs0313OCS0311U00Execute(hospCode,request.getUserId(), CommonUtils.parseDouble(item.getSuryang()),item.getDanui(),
			    				item.getSetPart(),item.getHangCode(),item.getSetCode(),item.getSetHangmogCode()) >0){
							grdSetHangMog = true ;
						}else{
							grdSetHangMog = false ;
						}
					}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
						if(ocs0313Repository.deleteOcs0313OCS0311U00Execute(hospCode,item.getSetPart(),item.getHangCode(),item.getSetCode(),item.getSetHangmogCode()) >0){
							grdSetHangMog = true ;
						}else{
							grdSetHangMog = false ;
						}
					}
				}
			}
			
			if(grdHangmog && grdSetCode && grdSetHangMog){
				response.setResult(true);
			}else{
				response.setResult(false);
				throw new ExecutionException(response.build());
			}
		return response.build();		
	}     
	
	public boolean insertOcs0311(OCS0311U00grdHangmogCodeListInfo item, String userId, String hospCode){
		Ocs0311 ocs0311 = new Ocs0311();
		ocs0311.setSysDate(new Date());
		ocs0311.setSysId(userId);
		ocs0311.setUpdDate(new Date());
		ocs0311.setUpdId(userId);
		ocs0311.setHospCode(hospCode);
		ocs0311.setSetPart(item.getSetPart());
		ocs0311.setHangmogCode(item.getHangmogCode());
		ocs0311Repository.save(ocs0311);
		return true;
	}
	
	public boolean insertOcs0312(OCS0311U00grdSetCodeListInfo item, String userId, String hospCode){
		Ocs0312 ocs0312 = new Ocs0312();
		ocs0312.setSysDate(new Date());
		ocs0312.setSysId(userId);
		ocs0312.setUpdDate(new Date());
		ocs0312.setUpdId(userId);
		ocs0312.setHospCode(hospCode);
		ocs0312.setSetPart(item.getSetPart());
		ocs0312.setHangmogCode(item.getHangmogCode());
		ocs0312.setSetCode(item.getSetCode());
		ocs0312.setSetCodeName(item.getSetCodeName());
		ocs0312.setComments(item.getComments());
		ocs0312Repository.save(ocs0312);
		return true;
	}
	
	public boolean insertOcs0313(OCS0311U00grdSetHangmogListInfo item, String userId, String hospCode){
		Ocs0313 ocs0313 = new Ocs0313();
		ocs0313.setSysDate(new Date());
		ocs0313.setSysId(userId);
		ocs0313.setUpdDate(new Date());
		ocs0313.setUpdId(userId);
		ocs0313.setHospCode(hospCode);
		ocs0313.setSetPart(item.getSetPart());
		ocs0313.setHangmogCode(item.getHangCode());
		ocs0313.setSetCode(item.getSetCode());
		ocs0313.setSetHangmogCode(item.getSetHangmogCode());
		ocs0313.setSuryang(CommonUtils.parseDouble(item.getSuryang()));
		ocs0313.setDanui(item.getDanui());
		ocs0313Repository.save(ocs0313);
		return true;
	}

}