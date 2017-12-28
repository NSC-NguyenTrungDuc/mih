package nta.med.service.ihis.handler.ocsa;


import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CommonModelProto.DataStringListItemInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GetCommonYnRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GetCommonYnResponse;

@Service                                                                                                          
@Scope("prototype")
public class OCS0103U00GetCommonYnHandler extends ScreenHandler<OcsaServiceProto.OCS0103U00GetCommonYnRequest, OcsaServiceProto.OCS0103U00GetCommonYnResponse>{
	private static final Log LOG = LogFactory.getLog(OCS0103U00GetCommonYnHandler.class);
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository; 
	
	@Override
	@Transactional(readOnly = true)
	public OCS0103U00GetCommonYnResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS0103U00GetCommonYnRequest request) throws Exception {
		OcsaServiceProto.OCS0103U00GetCommonYnResponse.Builder response = OcsaServiceProto.OCS0103U00GetCommonYnResponse.newBuilder();
		List<String> hangmogList = new ArrayList<>();
		if(!CollectionUtils.isEmpty(request.getHangmogListList())){
			for(DataStringListItemInfo item : request.getHangmogListList()){
				hangmogList.add(item.getDataValue());
			}
		}
		List<String> commonYnList = ocs0103Repository.getCommonYnList(getHospitalCode(vertx, sessionId), hangmogList);
		if(!CollectionUtils.isEmpty(commonYnList)){
			for(String item : commonYnList){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				info.setDataValue(StringUtils.isEmpty(item) == true ? "" : item);
				response.addCommonYnList(info);
			}
		}
		return response.build();
	}

}
