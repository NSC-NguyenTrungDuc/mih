package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0300Repository;
import nta.med.data.model.ihis.system.OFMakeTreeViewInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OFMakeTreeViewRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OFMakeTreeViewResponse;

@Service                                                                                                          
@Scope("prototype")
public class OFMakeTreeViewHandler extends ScreenHandler <SystemServiceProto.OFMakeTreeViewRequest, SystemServiceProto.OFMakeTreeViewResponse> {
	@Resource
	private Ocs0300Repository ocs0300Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OFMakeTreeViewResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OFMakeTreeViewRequest request) throws Exception {
		SystemServiceProto.OFMakeTreeViewResponse.Builder response = SystemServiceProto.OFMakeTreeViewResponse.newBuilder();
		 List<OFMakeTreeViewInfo> listTreeView = ocs0300Repository.getOFMakeTreeView(getHospitalCode(vertx, sessionId), request.getMemb(), request.getInputTab());
		 if(!CollectionUtils.isEmpty(listTreeView)){
			 for(OFMakeTreeViewInfo item : listTreeView){
				CommonModelProto.OFMakeTreeViewInfo.Builder info = CommonModelProto.OFMakeTreeViewInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addTreeViewItem(info);
			 }
		 }
		 return response.build();
	}

}
