package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto.PHY0001U00GrdOCS0132Info;
import nta.med.service.ihis.proto.PhysModelProto.PHY0001U00GrdRehaSinryouryouCodeInfo;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY0001U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class PHY0001U00SaveLayoutHandler
	extends ScreenHandler<PhysServiceProto.PHY0001U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;   
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY0001U00SaveLayoutRequest request) throws Exception {                                                                   
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();      
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		response = saveLayout(request, hospCode, language);
		if(!response.getResult()){
			throw new ExecutionException(response.build());
		}
		return response.build();
	}
	
	public SystemServiceProto.UpdateResponse.Builder saveLayout(PhysServiceProto.PHY0001U00SaveLayoutRequest request, String hospCode, String language){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<PHY0001U00GrdOCS0132Info> listGroupItem = request.getGrdOcsInfoList();
		if(!CollectionUtils.isEmpty(listGroupItem)){
			for(PHY0001U00GrdOCS0132Info item : listGroupItem){
				if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(ocs0132Repository.updatePHY0001U00SaveLayout(item.getCodeName(), hospCode, language,
							item.getCodeType(), item.getCode()) <= 0){
						response.setResult(false);
						return response;
					}
				} 
			}
		}
		
		List<PHY0001U00GrdRehaSinryouryouCodeInfo> listSystemItem = request.getGrdRehaInfoList();
		if(!CollectionUtils.isEmpty(listSystemItem)){
			for(PHY0001U00GrdRehaSinryouryouCodeInfo item : listSystemItem){
		 if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(ocs0132Repository.updatePHY0001U00SaveLayout(item.getHangmogCode(), hospCode, language,
							"REHA_SINRYOURYOU", item.getCode()) <= 0 ){
						response.setResult(false);
						return response;
					}
				} 
			}
		}
		
		response.setResult(true);
		return response;
	}

}
