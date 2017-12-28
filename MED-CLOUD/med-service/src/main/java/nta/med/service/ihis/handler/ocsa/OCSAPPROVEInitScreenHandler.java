package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.helper.OrderBizHelper;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CommonModelProto.ComboDataSourceInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCSAPPROVEInitScreenRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCSAPPROVEInitScreenResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSAPPROVEInitScreenHandler
	extends ScreenHandler<OcsaServiceProto.OCSAPPROVEInitScreenRequest, OcsaServiceProto.OCSAPPROVEInitScreenResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override     
	@Transactional(readOnly = true)
	public OCSAPPROVEInitScreenResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCSAPPROVEInitScreenRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCSAPPROVEInitScreenResponse.Builder response = OcsaServiceProto.OCSAPPROVEInitScreenResponse.newBuilder();  
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		for(ComboDataSourceInfo inputInfo : request.getCboListInfoList()){
			List<ComboListItemInfo> list = OrderBizHelper.getLoadComboDataSource(hospCode, language, inputInfo);
			if(!CollectionUtils.isEmpty(list)){
				for(ComboListItemInfo item : list){
					CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					if(inputInfo.getColName().equals("suryang")){
						response.addCboSuryang(info);
					}else if(inputInfo.getColName().equals("nalsu")){
						response.addCboNalsu(info);
					}else if(inputInfo.getColName().equals("dv")){
						response.addCboDv(info);
					}
				}
			}
		}
		List<ComboListItemInfo> listPostApprove = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospCode, "POSTAPPROVE_VISIBLE", "APPROVE_FLAG", language);
		if(!CollectionUtils.isEmpty(listPostApprove)){
			if(listPostApprove.get(0).getCodeName().equalsIgnoreCase("Y")){
				response.setPostApproveVisible(true);
			}else{
				response.setPostApproveVisible(false);
			}
		}else{
			response.setPostApproveVisible(false);
		}
		
		List<ComboListItemInfo> listApprove = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospCode, "APPROVE_FORCE", "APPROVE_FLAG", language);
		if(!CollectionUtils.isEmpty(listApprove)){
			if(listApprove.get(0).getCodeName().equalsIgnoreCase("Y")){
				response.setApproveForce(true);
			}else{
				response.setApproveForce(false);
			}
		}else{
			response.setApproveForce(false);
		}
		return response.build();	
	}
}