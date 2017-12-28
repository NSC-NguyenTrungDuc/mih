package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.data.model.ihis.system.DetailPaInfoFormGridInsureInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.DetailPaInfoFormGridInsureRequest;
import nta.med.service.ihis.proto.SystemServiceProto.DetailPaInfoFormGridInsureResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class DetailPaInfoFormGridInsureHandler
	extends ScreenHandler<SystemServiceProto.DetailPaInfoFormGridInsureRequest, SystemServiceProto.DetailPaInfoFormGridInsureResponse>{
	
	@Resource
    private Out0102Repository out0102Repository; 
	
	@Override
	@Transactional(readOnly = true)
	public DetailPaInfoFormGridInsureResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			DetailPaInfoFormGridInsureRequest request) throws Exception {
        List<DetailPaInfoFormGridInsureInfo> listDetailPaInfoFormGridInsureInfo = out0102Repository.getDetailPaInfoFormGridInsure(getHospitalCode(vertx, sessionId), 
        		request.getPatientCode(), getLanguage(vertx, sessionId));
        SystemServiceProto.DetailPaInfoFormGridInsureResponse.Builder response = SystemServiceProto.DetailPaInfoFormGridInsureResponse.newBuilder();
        if (listDetailPaInfoFormGridInsureInfo != null && !listDetailPaInfoFormGridInsureInfo.isEmpty()) {
            for (DetailPaInfoFormGridInsureInfo obj : listDetailPaInfoFormGridInsureInfo) {
            	SystemModelProto.DetailPaInfoFormGridInsureInfo.Builder builder = SystemModelProto.DetailPaInfoFormGridInsureInfo.newBuilder();
                BeanUtils.copyProperties(obj, builder, getLanguage(vertx, sessionId));
                response.addGridInsureItem(builder);
            }
        }
        return response.build();
	}

}
