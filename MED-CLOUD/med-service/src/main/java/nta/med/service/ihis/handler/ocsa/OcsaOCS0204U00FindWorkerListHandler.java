package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.cht.Cht0110Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0204U00MembListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0204U00FindWorkerListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0204U00FindWorkerListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsaOCS0204U00FindWorkerListHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0204U00FindWorkerListRequest, OcsaServiceProto.OcsaOCS0204U00FindWorkerListResponse> {
	
    @Resource
    private Adm3200Repository adm3200Repository;
    
    @Resource
    private Cht0110Repository cht0110Repository;
    
    @Override
    @Transactional(readOnly = true)
    public OcsaOCS0204U00FindWorkerListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaOCS0204U00FindWorkerListRequest request) throws Exception {
          OcsaServiceProto.OcsaOCS0204U00FindWorkerListResponse.Builder response = OcsaServiceProto.OcsaOCS0204U00FindWorkerListResponse.newBuilder();
    	  List<OcsaOCS0204U00MembListInfo> listOcsaOCS0204U00MembListInfo = adm3200Repository.getOcsaOCS0204U00MembListOcsaOCS0204U00FindWorkerList(getHospitalCode(vertx, sessionId),
    			  getLanguage(vertx, sessionId), request.getFFind(), false);
          if (listOcsaOCS0204U00MembListInfo != null && !listOcsaOCS0204U00MembListInfo.isEmpty()) {
              for (OcsaOCS0204U00MembListInfo item : listOcsaOCS0204U00MembListInfo) {
              	OcsaModelProto.OcsaOCS0204U00MembListInfo.Builder info = OcsaModelProto.OcsaOCS0204U00MembListInfo.newBuilder();
              	if(!StringUtils.isEmpty(item.getUserId())){
              		info.setUserId(item.getUserId());
              	}
              	if(!StringUtils.isEmpty(item.getUserNm())){
              		info.setUserNm(item.getUserNm());
              	}
                  response.addMembList(info);
              }
          }
          return response.build();
    }
}
