package nta.med.service.ihis.handler.cpls;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02CbxJangbiRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL3020U02CbxJangbiHandler extends ScreenHandler <CplsServiceProto.CPL3020U02CbxJangbiRequest, SystemServiceProto.ComboResponse> {                     
	@Resource                                                                                                       
	private Cpl0109Repository cpl0109Repository;                                                                    
	                                                                                                                
	@Override                
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, CPL3020U02CbxJangbiRequest request)
			throws Exception  {                                                                   
  	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
		List<ComboListItemInfo> list = new ArrayList<ComboListItemInfo>();
		list.add(new ComboListItemInfo("",""));
		list.addAll(cpl0109Repository.getListCboBarCodeItem(getHospitalCode(vertx, sessionId), "07", getLanguage(vertx, sessionId),"IS NULL"));
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item : list){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		return response.build();
	}
}