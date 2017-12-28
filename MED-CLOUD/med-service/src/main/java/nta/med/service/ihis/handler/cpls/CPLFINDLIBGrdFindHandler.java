package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.dao.medi.cpl.Cpl0155Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPLFINDLIBGrdFindRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class CPLFINDLIBGrdFindHandler extends ScreenHandler <CplsServiceProto.CPLFINDLIBGrdFindRequest, SystemServiceProto.ComboResponse> {                     
	@Resource                                                                                                       
	private Cpl0109Repository cpl0109Repository;
	
	@Resource
	private Cpl0155Repository cpl0155Repository;
	                                                                                                                
	@Override       
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, CPLFINDLIBGrdFindRequest request) throws Exception  {                                                                   
  	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder(); 
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		if("Y".equalsIgnoreCase(request.getIsExist())){
			List<ComboListItemInfo> comboListItemInfos = cpl0155Repository.getCPL3020U02FwkResult(hospCode, request.getFind(), request.getResultForm());
            if(!CollectionUtils.isEmpty(comboListItemInfos)) {
            	for(ComboListItemInfo info : comboListItemInfos){
            		CommonModelProto.ComboListItemInfo.Builder builder = CommonModelProto.ComboListItemInfo.newBuilder();
            		BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
            		response.addComboItem(builder);
            	}
            }
		}else{
			List<ComboListItemInfo> comboListItemInfos = cpl0109Repository.getFwkJundalGubunListItem(hospCode, request.getCodeType(), request.getFind(), getLanguage(vertx, sessionId));
            if(!CollectionUtils.isEmpty(comboListItemInfos)) {
            	for(ComboListItemInfo info : comboListItemInfos){
            		CommonModelProto.ComboListItemInfo.Builder builder = CommonModelProto.ComboListItemInfo.newBuilder();
            		BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
            		response.addComboItem(builder);
            	}
            }
		}
		return response.build();
	}
}
